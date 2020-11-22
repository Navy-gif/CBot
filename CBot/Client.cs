using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBot
{
    class Client
    {

        private BotConfig config;
        public BotConfig Config
        {
            private set { config = value; }
            get { return config; }
        }

        private SocketManager WS = null;

        public Client(BotConfig config)
        {

            Config = config;
            Console.WriteLine(Config);
            WS = new SocketManager(this);

        }

        public async void Login(string token = null)
        {
            if (token is null) token = Config.Token;

            Uri Path = new PathBuilder(Config.WSURI)
                .AddQuery("v", "8")
                .AddQuery("encoding", "json")
                .Build();

            Console.WriteLine(Path);

            await WS.Connect(Path);
        }

    }
}
