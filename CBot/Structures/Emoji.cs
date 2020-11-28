using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static System.Text.Json.JsonElement;

namespace CBot.Structures
{
    class Emoji : DiscordBaseStructure
    {

        public Guild Guild { get; internal set; }

        public string Name { get; internal set; }

        public List<long> Roles { get; internal set; }

        public User Author { get; internal set; }

        public bool RequireColons { get; internal set; }

        public bool Managed { get; internal set; }

        public bool Animated { get; internal set; }

        public bool Available { get; internal set; }

        public Emoji(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {
            this.Guild = Guild;
            Roles = new List<long>();
            Patch(Data);
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }

        public override void Patch(JsonElement Data)
        {

            this.Name = Data.GetProperty("name").GetString();

            if (Data.TryGetProperty("roles", out JsonElement roles))
            {

                foreach(JsonElement Role in roles.EnumerateArray())
                {
                    long Id = long.Parse(Role.GetString());
                    Roles.Add(Id);
                }
            }

            //TODO: Resolve author

            JsonElement val;
            if (Data.TryGetProperty("require_colons", out val))
                this.RequireColons = val.GetBoolean();

            if (Data.TryGetProperty("managed", out val))
                this.Managed = val.GetBoolean();

            if (Data.TryGetProperty("animated", out val))
                this.Animated = val.GetBoolean();

            if (Data.TryGetProperty("available", out val))
                this.Available = val.GetBoolean();

        }
    }
}
