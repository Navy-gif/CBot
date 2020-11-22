using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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

        public Dictionary<string, object> d
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
            return "op: " + op + "\ns: " + s + "\nt: " + t + "\nd: " + d + "\nRaw: " + Raw;
        }

    }

    enum PacketType
    {
        Dispatch = 0,
        Heartbeat = 1,
        Identify = 2,
        PresenceUpdate = 3,
        VoiceStateUpdate = 4,
        Resume = 6,
        Reconnect = 7,
        RequestGuildMembers = 8,
        InvalidSession = 9,
        Hello = 10,
        HeartbeatAck = 11
    }

    class Client
    {

        private BotConfig config;
        public BotConfig Config
        {
            internal set { config = value; }
            get { return config; }
        }

        private SocketManager WS = null;

        public Client(BotConfig config)
        {

            Config = config;
            Console.WriteLine(Config);
            WS = new SocketManager(this);
            WS.SocketEvent += OnSocketEvent;

            //JsonSerializerOptions JOptions = new JsonSerializerOptions
            //{
            //    MaxDepth = 5
            //};
            //DiscordPacket Packet = JsonSerializer.Deserialize<DiscordPacket>("{\"t\":null,\"s\":null,\"op\":10,\"d\": null}", JOptions);
            //Console.WriteLine(Packet);
            //object heartbeat = null;
            //foreach(string key in Packet.d.Keys)
            //{
            //    Packet.d.TryGetValue(key, out object value);
            //    Console.WriteLine(key + ": " + value);
            //}
            //Console.WriteLine(heartbeat);
        }

        private void OnSocketEvent(object sender, SocketMessage e)
        {
            Console.WriteLine("Event came through to client:");
            DiscordPacket Packet = JsonSerializer.Deserialize<DiscordPacket>(e.Raw);
            Packet.Raw = e.Raw;
            Console.WriteLine(Packet);

            ResolvePacketType(Packet);

        }

        public void ResolvePacketType(DiscordPacket Packet)
        {

            switch(Packet.op)
            {
                case (int)PacketType.Dispatch:

                    break;
                case (int)PacketType.Heartbeat:

                    break;
                case (int)PacketType.Identify:

                    break;
                case (int)PacketType.PresenceUpdate:

                    break;
                case (int)PacketType.VoiceStateUpdate:

                    break;
                case (int)PacketType.Resume:

                    break;
                case (int)PacketType.Reconnect:

                    break;
                case (int)PacketType.RequestGuildMembers:

                    break;
                case (int)PacketType.InvalidSession:

                    break;
                case (int)PacketType.Hello:
                    PacketHello(Packet);
                    break;
                case (int)PacketType.HeartbeatAck:

                    break;
            }

        }

        private void PacketHello(DiscordPacket Packet)
        {
            Console.WriteLine("Received hello packet");
        }
        public async Task Login(string token = null)
        {
            if (token != null && Config.Token is null) Config.Token = token;
            else if (token is null && Config.Token is null) throw new MissingTokenException("Token must be provided either in the login method or config");
            else if (token is null) token = Config.Token;

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
