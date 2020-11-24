using CBot.Caches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class GuildMember : DiscordBaseStructure
    {
        public User User { get; internal set; }

        public string Nickname { get; internal set; }

        public MemberRoles Roles { get; internal set; }

        public DateTime JoinedAt { get; internal set; }

        public DateTime StartedBoosting { get; internal set; }

        public bool Deaf { get; internal set; }

        public bool Mute { get; internal set; }

        public GuildMember(BaseClient Client, Dictionary<string, JsonElement> Data) : base (Client, Data["id"])
        {

            Data.TryGetValue("nick", out JsonElement nick);
            Nickname = nick.GetString();

            Data.TryGetValue("joined_at", out JsonElement joined);
            JoinedAt = joined.GetDateTime();

            Data.TryGetValue("premium_since", out JsonElement booster);
            StartedBoosting = booster.GetDateTime();

            Data.TryGetValue("roles", out JsonElement roles);
            Roles = new MemberRoles(Client, this, roles);

            Data.TryGetValue("user", out JsonElement user);
            ResolveUser(user);

            Data.TryGetValue("deaf", out JsonElement deaf);
            Deaf = deaf.GetBoolean();

            Data.TryGetValue("mute", out JsonElement mute);
            Mute = mute.GetBoolean();



        }

        internal void ResolveUser(JsonElement UserData)
        {
            UserData.TryGetProperty("id", out JsonElement id);
            long.TryParse(id.GetString(), out long Id);
            if (Client.Users.Has(Id)) User = Client.Users.Resolve(Id);
            else User = new User(Client, UserData);
        }

    }
}
