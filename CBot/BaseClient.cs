using CBot.DiscordPayloads;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CBot
{

    class DiscordPacket
    {
        public int op
        {
            get;
            set;
        }

        public int? s
        {
            get;
            set;
        }

        public string t
        {
            get;
            set;
        }

        public Dictionary<string, JsonElement> d
        {
            get;
            set;
        }

        public string Raw
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"==============\nop: {op}\ns: {s}\nt: {t}\nd: {d}\nRAW: {Raw}\n==============";
        }

    }

    enum PacketType
    {
        Dispatch = 0,           // Receive
        Heartbeat = 1,          // Receive & Send
        Identify = 2,           // Send
        PresenceUpdate = 3,     // Send
        VoiceStateUpdate = 4,   // Send
                                // 5 doesn't exist, possibly a future gateway op
        Resume = 6,             // Send
        Reconnect = 7,          // Receive
        RequestGuildMembers = 8,// Send
        InvalidSession = 9,     // Receive
        Hello = 10,             // Receive
        HeartbeatAck = 11       // Receive
    }

    class BaseClient
    {

        private BotConfig config;
        public BotConfig Config
        {
            internal set { config = value; }
            get { return config; }
        }

        private SocketManager WS = null;

        private int HeartbeatInterval;
        private int SequenceNum;
        private int MissedHeartbeats = 0;
        private CancellationTokenSource HeartbeatCTS;

        private Dictionary<string, Func<DiscordPacket, bool>> Events = new Dictionary<string, Func<DiscordPacket, bool>>();

        public BaseClient(BotConfig config)
        {

            Config = config;
            Console.WriteLine(Config);
            WS = new SocketManager();
            WS.SocketEvent += OnSocketEvent;
            WS.Debug += (source, Text) => { Console.WriteLine(Text); };

            #region Register events
            Events.Add("MESSAGE_CREATE", this.OnMessage);
            Events.Add("GUILD_CREATE", this.OnGuildCreate);
            #endregion Register events
        }

        #region Websocket stuff
        internal void OnSocketEvent(object Sender, string Message)
        {
            Console.WriteLine("Event came through to client:");
            DiscordPacket Packet = JsonSerializer.Deserialize<DiscordPacket>(Message);
            Packet.Raw = Message;
            Console.WriteLine(Packet);
            if (Packet.s.HasValue) SequenceNum = (int)Packet.s;
            Console.WriteLine($"SequenceNum: {SequenceNum}");

            ResolvePacketType(Packet);

        }

        public void ResolvePacketType(DiscordPacket Packet)
        {

            switch(Packet.op)
            {
                case (int)PacketType.Dispatch:
                    ResolveDiscordEvent(Packet);
                    break;
                case (int)PacketType.Heartbeat:
                    // TODO: HeartBeatRequested(Packet); //Discord requested heartbeat
                    break;
                case (int)PacketType.Identify:
                    // Sent to discord, shouldn't need to do anything here
                    break;
                case (int)PacketType.PresenceUpdate:
                    // Sent to discord, shouldn't need to do anything here
                    break;
                case (int)PacketType.VoiceStateUpdate:
                    // Sent to discord, shouldn't need to do anything here
                    break;
                case (int)PacketType.Resume:
                    // Sent to discord, shouldn't need to do anything here
                    break;
                case (int)PacketType.Reconnect:
                    // TODO: Reconnect(Packet);
                    break;
                case (int)PacketType.RequestGuildMembers:
                    // Sent to discord, shouldn't need to do anything here
                    break;
                case (int)PacketType.InvalidSession:
                    // TODO: Reconnect(Packet);
                    break;
                case (int)PacketType.Hello:
                    PacketHello(Packet);
                    break;
                case (int)PacketType.HeartbeatAck:
                    HeartbeatAck(Packet);
                    break;
            }

        }

        private void ResolveDiscordEvent(DiscordPacket Packet)
        {
            Console.WriteLine($"==== New event! ====\n{Packet.t}");
            Events.TryGetValue(Packet.t, out Func<DiscordPacket, bool> Func);
            Console.WriteLine(Func);
            if (Func is null)
            {
                Console.WriteLine("Func is null");
                return;
            }
            _ = Func(Packet);
        }

        private async void PacketHello(DiscordPacket Packet)
        {
            // WS should identify to the gateway after receiving this
            Console.WriteLine("Received hello packet");
            Console.WriteLine(Packet.d["heartbeat_interval"]);
            HeartbeatInterval = Packet.d["heartbeat_interval"].GetInt32();

            if (HeartbeatCTS != null) HeartbeatCTS.Dispose();
            HeartbeatCTS = new CancellationTokenSource();

            Console.WriteLine("Starting heartbeat");
            await Task.Factory.StartNew(this.Heartbeat, HeartbeatCTS.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default).ConfigureAwait(false);
            await Identify();
        }

        private async Task Identify()
        {
            Console.WriteLine("Sending identify");
            Identify Packet = new Identify(Config.Token, Config.IntentsInteger);
            string Serialised = JsonSerializer.Serialize(Packet, new JsonSerializerOptions { IgnoreNullValues = true });
            await WS.Send(Serialised).ConfigureAwait(false);
        }

        private async Task Heartbeat()
        {
            CancellationToken Token = HeartbeatCTS.Token;
            while(!Token.IsCancellationRequested)
            {
                Console.WriteLine("Sending heartbeat");
                Heartbeat HB = SequenceNum > -1 ? new Heartbeat(SequenceNum) : new Heartbeat() ;
                string Message = JsonSerializer.Serialize(HB);
                await WS.Send(Message).ConfigureAwait(false);
                MissedHeartbeats++;
                await Task.Delay(HeartbeatInterval, Token);
            }
        }

        private void HeartbeatAck(DiscordPacket Packet)
        {
            MissedHeartbeats--;
            Console.WriteLine("Heartbeat acknowledged");
        }

        #endregion Websocket stuff

        #region Connect/Disconnect to socket
        public async Task Login(string token = null)
        {
            if (token != null && Config.Token is null) Config.Token = token;
            else if (token is null && Config.Token is null) throw new MissingTokenException("Token must be provided either in the login method or config");

            Uri Path = new PathBuilder(Config.WSURI)
                .AddQuery("v", Config.GWVersion)
                .AddQuery("encoding", "json")
                .Build();

            Console.WriteLine(Path);

            await WS.Connect(Path);
        }

        public async Task Logout()
        {
            await WS.Disconnect();
        }
        #endregion Connect/Disconnect to socket

        #region Events

        public event EventHandler Ready;

        public virtual void OnReady()
        {
            EventHandler Handler = Ready;
            Ready?.Invoke(this, null);
        }

        public event EventHandler<Message> MessageCreate;

        public virtual bool OnMessage(DiscordPacket Packet)
        {
            MessageCreate?.Invoke(this, new Message(this, Packet.d));
            return true;
        }

        public event EventHandler<Guild> GuildCreate;

        public virtual bool OnGuildCreate(DiscordPacket Packet)
        {
            Console.WriteLine("Trying to create guild");
            Guild Guild = null;
            try
            {
                Guild = new Guild(this, Packet.d);
                Console.WriteLine("Created guild");

            } catch (Exception ex)
            {
                Console.WriteLine("Guild create failed");
                Console.WriteLine(ex.Message);
            }
            GuildCreate?.Invoke(this, Guild);
            return true;
        }
        #endregion Events

    }

    [Serializable]
    internal class MissingTokenException : Exception
    {
        public MissingTokenException()
        {
        }

        public MissingTokenException(string message) : base(message)
        {
        }

        public MissingTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
