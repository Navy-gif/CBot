using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBot.DiscordPayloads
{
    class Identify : Payload
    {
        public new IdentifyData d { get; private set; }
        public Identify(string Token, int Intents)
        {
            this.op = 2;
            this.d = new IdentifyData();
            this.d.SetIntents(Intents);
            this.d.SetToken(Token);
        }

        public class IdentifyData
        {
            public string token { get; private set; }

            public bool compress { get; private set; }
            public bool guild_subscriptions { get; private set; }

            public int intents { get; private set; }
            public int large_threshold { get; private set; }
            public int[] shard { get; private set; }

            public Presence presence { get; private set; }
            public Dictionary<string, string> properties { get; private set; }

            public IdentifyData()
            {

                this.compress = false;
                this.guild_subscriptions = true;

                this.large_threshold = 250;
                this.shard = null;

                this.presence = null;
                this.properties = new Dictionary<string, string>();
                this.properties.Add("$os", $"{Environment.OSVersion}");
                this.properties.Add("$browser", "C# Lib");
                this.properties.Add("$device", "C# Lib");

            }

            internal void SetIntents(int Intents)
            {
                this.intents = Intents;
            }

            internal void SetToken(string Token)
            {
                this.token = Token;
            }

        }

    }
}
