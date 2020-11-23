using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Text;

namespace CBot
{
    // TODO: Rewrite this into a proper websocket wrapper, not necessarily just for a discord bot
    class SocketManager
    {

        private ClientWebSocket Socket = null;
        private CancellationTokenSource CTS = null;
        private int BufferSize { get; set; } = 4096;

        private SemaphoreSlim SendBusy;

        public SocketManager()
        {
            SendBusy = new SemaphoreSlim(1);
        }

        public async Task Send(string Message)
        {

            EmitDebug("Send pre-check");
            if (Socket is null) return;
            if (Socket.State != WebSocketState.Open && Socket.State != WebSocketState.CloseReceived) return;
            EmitDebug("Pre-check success\nAwaiting and setting semaphore");

            await SendBusy.WaitAsync();
            byte[] Bytes = Encoding.UTF8.GetBytes(Message);

            try
            {
                EmitDebug($"Starting send of message: \n{Message}");
                int len = Bytes.Length;
                int Segments = len / BufferSize;
                if (len % BufferSize != 0) Segments++;
                EmitDebug($"{Segments} segments to send");

                for(int i = 0; i < Segments; i++)
                {
                    EmitDebug($"Sending segment {i+1} of {Segments}");
                    int Start = BufferSize * i;
                    int SegmentLength = Math.Min(BufferSize, len - Start);

                    await Socket.SendAsync(new ArraySegment<byte>(Bytes, Start, SegmentLength), WebSocketMessageType.Text, i == Segments - 1, CancellationToken.None);
                }

            } catch
            {
                EmitDebug("Some error while sending?");
            } finally
            {
                EmitDebug("Message sent, releasing semaphore");
                SendBusy.Release();
            }
        }
        
        public async Task Connect(Uri Target)
        {
            EmitDebug($"Attempting to connect to {Target.OriginalString}");
            if (Socket != null)
            {
                if (Socket.State == WebSocketState.Open)
                {
                    EmitDebug("Socket already connected.");
                    return;
                }
                else Socket.Dispose();
            }

            EmitDebug("Opening socket");
            Socket = new ClientWebSocket();

            if (CTS != null) CTS.Dispose();
            CTS = new CancellationTokenSource();

            await Socket.ConnectAsync(Target, CTS.Token);
            // Add a receiver method that listens for incoming data from the socket
            await Task.Factory.StartNew(Receiver, CTS.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default).ConfigureAwait(false);
            EmitDebug("Receiver running.");

        }

        public async Task Disconnect()
        {
            if (Socket is null) return;
            if(Socket.State == WebSocketState.Open)
            {
                EmitDebug("Closing socket...");
                CTS.CancelAfter(2000);
                await Socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CTS.Token);
                // await Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CTS.Token);
            }

            Socket.Dispose();
            Socket = null;
            CTS.Dispose();
            CTS = null;
            EmitDebug("Socket closed gracefully");
            EmitClose();

        }

        private async Task Receiver()
        {

            MemoryStream StreamIn = null;
            WebSocketReceiveResult Result;
            byte[] buffer = new byte[BufferSize];

            try
            {
                while (!CTS.Token.IsCancellationRequested)
                {
                    EmitDebug("Awaiting message from socket");
                    StreamIn = new MemoryStream(BufferSize);
                    do
                    {
                        Result = await Socket.ReceiveAsync(buffer, CTS.Token);
                        if (Result.MessageType != WebSocketMessageType.Close) StreamIn.Write(buffer, 0, Result.Count);
                    } while (!Result.EndOfMessage);
                    EmitDebug("Received message from socket, sending to handler");
                    if (Result.MessageType == WebSocketMessageType.Close)
                    {
                        EmitDebug($"Received close from WS\n{Result.CloseStatus}:{Result.CloseStatusDescription}");
                        await Disconnect();
                        break;
                    }
                    Result = null;
                    StreamIn.Position = 0;
                    HandleReceive(StreamIn);
                }
            } catch(TaskCanceledException Ex)
            {
                EmitDebug($"Receiver failed:\n{Ex.Message}");
                EmitError(Ex);
            } finally
            {
                StreamIn?.Dispose();
            }

        }

        public virtual void HandleReceive(MemoryStream incoming)
        {
            byte[] Buffer = new byte[incoming.Length];
            incoming.Read(Buffer);
            string Message = Encoding.UTF8.GetString(Buffer);

            OnMessage(Message);

        }
        #region Events

        public event EventHandler<string> SocketEvent;
        protected virtual void OnMessage(string args)
        {
            SocketEvent?.Invoke(this, args);
        }

        public event EventHandler<string> Debug;

        public virtual void EmitDebug(string Message)
        {
            Debug?.Invoke(this, Message);
        }

        public event EventHandler<Exception> Error;

        public virtual void EmitError(Exception Ex)
        {
            Error?.Invoke(this, Ex);
        }

        public event EventHandler OnClose;

        public virtual void EmitClose()
        {
            OnClose?.Invoke(this, null);
        }

        #endregion Events

    }
}
