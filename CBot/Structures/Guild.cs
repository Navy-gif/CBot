using CBot.Caches;
using CBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;
using static System.Text.Json.JsonElement;

namespace CBot.Structures
{
    class Guild : DiscordBaseStructure
    {
        #region Properties
        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public string Splash { get; internal set; }

        public string DiscoverySplash { get; internal set; }

        public GuildMember Owner { get; internal set; }

        public long OwnerId { get; internal set; }

        public bool OwnedBySelf { get; internal set; } = false;

        public string Region { get; internal set; }

        public VoiceChannel AfkChannel { get; internal set; } = null;

        public long AfkChannelId { get; internal set; }

        public int AfkTimeout { get; internal set; }

        public bool WidgetEnabled { get; internal set; }

        public IGuildChannel WidgetChannel { get; internal set; }

        public long WidgetChannelId { get; internal set; }

        public int VerificationLevel { get; internal set; }

        public int DefaultNotifications { get; internal set; }

        public int ExplicitContentFilter { get; internal set; }

        public GuildRoles Roles { get; internal set; }

        public GuildEmojis Emojis { get; internal set; }

        public string[] Features { get; internal set; }

        public int MfaLevel { get; internal set; }

        public long ApplicationId { get; internal set; }

        public ITextBasedChannel SystemChannel { get; internal set; } // Needs system channel flags https://discord.com/developers/docs/resources/guild#guild-object-system-channel-flags

        public long SystemChannelId { get; internal set; }

        public ITextBasedChannel RulesChannel { get; internal set; }

        public long RulesChannelId { get; internal set; }

        public bool Large { get; internal set; }

        public bool Unavailable { get; internal set; }

        public int MemberCount { get; internal set; }

        public VoiceStates VoiceStates { get; internal set; }

        public GuildMembers Members { get; internal set; }

        public GuildChannels Channels { get; internal set; }

        public GuildPresences Presences { get; internal set; }

        public int MaxPresences { get; internal set; } = 25000;

        public int MaxMembers { get; internal set; } = -1;

        public string VanityUrl { get; internal set; }

        public string Description { get; internal set; }

        public string Banner { get; internal set; }

        public int PremiumTier { get; internal set; }

        public int Boosters { get; internal set; }

        public string Locale { get; internal set; }

        public ITextBasedChannel PublicUpdatesChannel { get; internal set; }

        public long PublicUpdatesChannelId { get; internal set; }

        public int VideoChannelCapacity { get; internal set; }

        public int ApproxMemberCount { get; internal set; }

        public int ApproxPresenceCount { get; internal set; }

        public DateTime JoinedAt { get; internal set; }

        public bool Partial { get; internal set; }

        #endregion Properties

        public Guild(BaseClient Client, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {
            Console.WriteLine($"Creating empty Guild with ID: {this.Id}");
            Partial = true;
        }

        public Guild(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {
            Console.WriteLine($"Creating and patching Guild with ID: {this.Id}");
            Patch(Data);
            Partial = false;
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            //if (!Partial) return;
            Console.WriteLine($"Patching guild data for {this.Id}");

            JsonElement temp;
            long tempL;

            #region String values
            Name = Data["name"].GetString();
            Icon = Data["icon"].GetString();
            Splash = Data["splash"].GetString();
            DiscoverySplash = Data["discovery_splash"].ToString();
            Region = Data["region"].ToString();

            ArrayEnumerator _Features = Data["features"].EnumerateArray();
            Features = new string[Data["features"].GetArrayLength()];
            for (int i = 0; i < Features.Length; i++)
            {
                _Features.MoveNext();
                Features[i] = _Features.Current.GetString();
            }
            #endregion String values

            #region Integer values
            AfkTimeout = Data["afk_timeout"].GetInt32();
            VerificationLevel = Data["verification_level"].GetInt32();
            DefaultNotifications = Data["default_message_notifications"].GetInt32();
            ExplicitContentFilter = Data["explicit_content_filter"].GetInt32();
            MfaLevel = Data["mfa_level"].GetInt32();
            if (Data.TryGetValue("member_count", out temp))
                MemberCount = temp.GetInt32();
            if (Data.TryGetValue("max_presences", out temp))
                MaxPresences = temp.GetInt32();
            if (Data.TryGetValue("max_members", out temp))
                MaxMembers = temp.GetInt32();
            #endregion Integer values

            #region Long values
            OwnerId = long.Parse(Data["owner_id"].GetString());
            if (Data.TryGetValue("afk_channel_id", out temp) && long.TryParse(temp.GetString(), out tempL))
                AfkChannelId = tempL;
            if (Data.TryGetValue("application_id", out temp) && long.TryParse(temp.GetString(), out tempL))
                ApplicationId = tempL;
            if (long.TryParse(Data["system_channel_id"].GetString(), out tempL)) 
                SystemChannelId = tempL;
            if (long.TryParse(Data["rules_channel_id"].GetString(), out tempL))
                RulesChannelId = tempL;
            if (Data.TryGetValue("widget_channel_id", out temp) && long.TryParse(temp.GetString(), out tempL))
                WidgetChannelId = tempL;
            #endregion Long values

            #region Bool values
            if (Data.TryGetValue("widget_enabled", out temp))
                WidgetEnabled = temp.GetBoolean();
            if (Data.TryGetValue("large", out temp))
                Large = temp.GetBoolean();
            if (Data.TryGetValue("unavailable", out temp))
                Unavailable = temp.GetBoolean();
            #endregion Bool values

            if(Data.TryGetValue("joined_at", out temp))
                JoinedAt = DateTime.Parse(temp.GetString());

            // TODO: Create role objects

            // TODO: Create emoji objects

            // TODO: AFK channel

            // TODO: System channel

            // TODO: Rules channel

            // TODO: Channels
            Channels = new GuildChannels(this.Client, this);
            ArrayEnumerator _Channels = Data["channels"].EnumerateArray();
            foreach(JsonElement Channel in _Channels)
            {
                Channels.CreateEntry(Channel);
            }


            // TODO: Members

            // TODO: Presences

            // TODO: Voice states

        }

        public override string ToString()
        {
            return $"Guild: {Name} - {Id}";
        }

    }
}
