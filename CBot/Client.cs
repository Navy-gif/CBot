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
            Console.WriteLine(e);
            DiscordPacket Packet = JsonSerializer.Deserialize<DiscordPacket>(e.Raw);
            Packet.Raw = e.Raw;

            Console.WriteLine(Packet);
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
