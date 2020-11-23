using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Text;

namespace CBot
{
    class SocketMessage : EventArgs
    {
        public string Raw
        {
            get;
            set;
        } = "";

        public SocketMessage(string message)
        {
            this.Raw = message;
        }

        public override string ToString()
        {
            return Raw;
        }

    }
    // TODO: Rewrite this into a proper websocket wrapper, not necessarily just for a discord bot
    class SocketManager
    {

        public Client Client;
        private ClientWebSocket Socket = null;
        private CancellationTokenSource CTS = null;
        private int BufferSize { get; set; } = 4096;

        private SemaphoreSlim SendBusy;

        public SocketManager(Client client)
        {
            Client = client;
            SendBusy = new SemaphoreSlim(1);
        }

        public async Task Send(string Message)
        {

            Console.WriteLine("Send pre-check");
            if (Socket is null) return;
            if (Socket.State != WebSocketState.Open && Socket.State != WebSocketState.CloseReceived) return;
            Console.WriteLine("Pre-check success\nAwaiting and setting semaphore");

            await SendBusy.WaitAsync();
            byte[] Bytes = Encoding.UTF8.GetBytes(Message);

            try
            {
                Console.WriteLine($"Starting send of message: \n{Message}");
                int len = Bytes.Length;
                int Segments = len / BufferSize;
                if (len % BufferSize != 0) Segments++;

                for(int i = 0; i < Segments; i++)
                {
                    int Start = BufferSize * i;
                    int SegmentLength = Math.Min(BufferSize, len - Start);

                    await Socket.SendAsync(new ArraySegment<byte>(Bytes, Start, SegmentLength), WebSocketMessageType.Text, i == Segments - 1, CancellationToken.None);
                }

            } catch
            {

            } finally
            {
                Console.WriteLine("Message sent, releasing semaphore");
                SendBusy.Release();
            }
        }
        
        public async Task Connect(Uri Target)
        {

            if(Socket != null)
            {
                if (Socket.State == WebSocketState.Open) return;
                else Socket.Dispose();
            }

            Console.WriteLine("Opening socket");
            Socket = new ClientWebSocket();

            if (CTS != null) CTS.Dispose();
            CTS = new CancellationTokenSource();

            await Socket.ConnectAsync(Target, CTS.Token);
            // Add a receiver method that listens for incoming data from the socket
            Task.Factory.StartNew(Receiver, CTS.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Console.WriteLine("Receiver running.");

        }

        public async Task Disconnect()
        {
            if (Socket is null) return;
            if(Socket.State == WebSocketState.Open)
            {
                Console.WriteLine("Closing socket...");
                CTS.CancelAfter(2000);
                await Socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CTS.Token);
                // await Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CTS.Token);
            }

            Socket.Dispose();
            Socket = null;
            CTS.Dispose();
            CTS = null;
            Console.WriteLine("Socket closed");

        }

        private async Task Receiver()
        {

            MemoryStream StreamIn = null;
            WebSocketReceiveResult Result = null;
            byte[] buffer = new byte[BufferSize];

            try
            {
                while (!CTS.Token.IsCancellationRequested)
                {
                    StreamIn = new MemoryStream(BufferSize);
                    do
                    {
                        Result = await Socket.ReceiveAsync(buffer, CTS.Token);
                        if (Result.MessageType != WebSocketMessageType.Close) StreamIn.Write(buffer, 0, Result.Count);
                    } while (!Result.EndOfMessage);

                    if (Result.MessageType == WebSocketMessageType.Close) break;
                    StreamIn.Position = 0;
                    HandleReceive(StreamIn);
                }
            } catch(TaskCanceledException)
            {

            } finally
            {
                StreamIn?.Dispose();
            }

        }

        public virtual void HandleReceive(MemoryStream incoming)
        {
            byte[] Buffer = new byte[incoming.Length];
            incoming.Read(Buffer);
            string _Message = Encoding.UTF8.GetString(Buffer);

            SocketMessage msg = new SocketMessage(_Message);

            OnSocketEvent(msg);

        }

        public event EventHandler<SocketMessage> SocketEvent;
        protected virtual void OnSocketEvent(SocketMessage args)
        {
            EventHandler<SocketMessage> handler = SocketEvent;
            handler?.Invoke(this, args);
        }

    }
}
