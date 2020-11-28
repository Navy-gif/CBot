using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class Role : DiscordBaseStructure
    {

        #region PubProps

        public Guild Guild { get; internal set; }

        public string Name { get; internal set; }

        public int Color { get; internal set; }

        public bool Hoisted { get; internal set; }

        public int Position { get; internal set; }

        public Permissions Permissions { get; internal set; }

        public bool Managed { get; internal set; }

        public bool Mentionable { get; internal set; }

        #endregion PubProps

        public Role(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {
            this.Guild = Guild;
            Patch(Data);
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }

        public override void Patch(JsonElement Data)
        {

            Name = Data.GetProperty("name").GetString();

            Color = Data.GetProperty("color").GetInt32();

            Hoisted = Data.GetProperty("hoist").GetBoolean();

            Position = Data.GetProperty("position").GetInt32();

            if (int.TryParse(Data.GetProperty("permissions").GetString(), out int perms))
                Permissions = new Permissions(this, perms);

            Managed = Data.GetProperty("managed").GetBoolean();

            Mentionable = Data.GetProperty("mentionable").GetBoolean();

        }
    }
}
