using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CBot
{

    enum IntentCodes
    {
        NONE = 0,
        GUILDS = 1 << 0,
        GUILD_MEMBERS = 1 << 1,
        GUILD_BANS = 1 << 2,
        GUILD_EMOJIS = 1 << 3,
        GUILD_INTEGRATIONS = 1 << 4,
        GUILD_WEBHOOKS = 1 << 5,
        GUILD_INVITES = 1 << 6,
        GUILD_VOICE_STATES = 1 << 7,
        GUILD_PRESENCES = 1 << 8,
        GUILD_MESSAGES = 1 << 9,
        GUILD_MESSAGE_REACTIONS = 1 << 10,
        GUILD_MESSAGE_TYPING = 1 << 11,
        DIRECT_MESSAGES = 1 << 12,
        DIRECT_MESSAGE_REACTIONS = 1 << 13,
        DIRECT_MESSAGE_TYPING = 1 << 14,
        ALL = GUILDS
            | GUILD_MEMBERS
            | GUILD_BANS
            | GUILD_EMOJIS
            | GUILD_INTEGRATIONS
            | GUILD_WEBHOOKS
            | GUILD_INVITES
            | GUILD_VOICE_STATES
            | GUILD_PRESENCES
            | GUILD_MESSAGES
            | GUILD_MESSAGE_REACTIONS
            | GUILD_MESSAGE_TYPING
            | DIRECT_MESSAGES
            | DIRECT_MESSAGE_REACTIONS
            | DIRECT_MESSAGE_TYPING
    }

    class Intents
    {

        private int _Integer;
        public int Integer
        {
            get
            {
                return _Integer;
            }

            private set
            {
                _Integer |= value;
            }
        }

        private string[] _Intents;

        public Intents(string [] intents = null)
        {
            if (intents != null) Set(intents);
        }

        public void Set(string[] intents)
        {
            _Intents = intents;
            _Integer = 0;
            foreach (string intent in intents)
            {
                IntentCodes result;
                if (Enum.TryParse<IntentCodes>(intent, true, out result))
                {
                    Integer = (int)result;
                    //Console.WriteLine(result + ":" + (int)result + " - " + Integer);
                }
            }
        }

        public string[] Strings()
        {
            return _Intents;
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", _Intents) + "]";
        }

    }

    class BotConfig
    {

        private string _token;
        public string Token {
            set { _token = value; }
            get { return _token; }
        }

        private Intents _intents = new Intents();
        public string[] Intents {
            set { _intents.Set(value); }
            get { return _intents.Strings(); }
        }

        private string _WSURI;
        public string WSURI
        {
            set { _WSURI = value; }
            get { return _WSURI; }
        }

        public override string ToString()
        {
            //PropertyInfo[] properties = typeof(BotConfig).GetProperties();
            //Console.WriteLine("BotConfig properties");
            //foreach (var property in properties) Console.WriteLine(property);
            return $"Token: {Token}\nIntents: {_intents}\nCalculated intents: {_intents.Integer}";
        }

    }
}
