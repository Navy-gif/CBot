using CBot.Caches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class GuildMember : DiscordBaseStructure
    {

        public Guild Guild { get; internal set; }

        public new long Id { get => User.Id; internal set { } }

        public User User { get; internal set; }

        public string Nickname { get; internal set; }

        public MemberRoles Roles { get; internal set; }

        public DateTime JoinedAt { get; internal set; }

        public DateTime StartedBoosting { get; internal set; }

        public bool Deaf { get; internal set; }

        public bool Mute { get; internal set; }

        public GuildMember(BaseClient Client, Dictionary<string, JsonElement> Data) : base (Client, Data["id"])
        {

            Patch(Data);

        }

        public GuildMember(BaseClient Client, Guild Guild, JsonElement Data) : base (Client)
        {

            this.Guild = Guild;
            Patch(Data);

        }

        internal void ResolveUser(JsonElement UserData)
        {
            UserData.TryGetProperty("id", out JsonElement id);
            long.TryParse(id.GetString(), out long Id);
            if (Client.Users.Has(Id)) User = Client.Users.Resolve(Id);
            else User = new User(Client, UserData);
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {

            if (Data.TryGetValue("nick", out JsonElement nick))
                Nickname = nick.GetString();

            if (Data.TryGetValue("joined_at", out JsonElement joined))
                JoinedAt = joined.GetDateTime();

            if (Data.TryGetValue("premium_since", out JsonElement booster))
                StartedBoosting = booster.GetDateTime();

            if (Data.TryGetValue("roles", out JsonElement roles))
                Roles = new MemberRoles(Client, this, roles);

            if (Data.TryGetValue("user", out JsonElement user))
                ResolveUser(user);

            if (Data.TryGetValue("deaf", out JsonElement deaf))
                Deaf = deaf.GetBoolean();

            if (Data.TryGetValue("mute", out JsonElement mute))
                Mute = mute.GetBoolean();

        }

        public override void Patch(JsonElement Data)
        {

            if (Data.TryGetProperty("nick", out JsonElement nick))
                Nickname = nick.GetString();

            if (Data.TryGetProperty("joined_at", out JsonElement joined))
                JoinedAt = joined.GetDateTime();

            if (Data.TryGetProperty("premium_since", out JsonElement booster) && booster.TryGetDateTime(out DateTime time))
                StartedBoosting = time;

            if (Data.TryGetProperty("roles", out JsonElement roles))
                Roles = new MemberRoles(Client, this, roles);

            if (Data.TryGetProperty("user", out JsonElement user))
                ResolveUser(user);

            if (Data.TryGetProperty("deaf", out JsonElement deaf))
                Deaf = deaf.GetBoolean();

            if (Data.TryGetProperty("mute", out JsonElement mute))
                Mute = mute.GetBoolean();

        }
    }
}
