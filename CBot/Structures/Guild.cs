using CBot.Caches;
using CBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;

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

        #endregion Properties

        public Guild(BaseClient Client, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {
            Console.WriteLine($"Creating empty Guild with ID: {this.Id}");
        }

        public Guild(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {
            Console.WriteLine($"Creating and patching Guild with ID: {this.Id}");
            Patch(Data);
        }

        public void Patch(Dictionary<string, JsonElement> Data)
        {
            Console.WriteLine($"Patching guild data for {this.Id}");

            #region String values
            Name = Data["name"].GetString();
            Icon = Data["icon"].GetString();
            Splash = Data["splash"].GetString();
            #endregion String values
        }

    }
}
