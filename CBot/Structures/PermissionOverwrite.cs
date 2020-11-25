using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class PermissionOverwrite : DiscordBaseStructure
    {
        
        public int Type { get; internal set; }

        public int Allow { get; internal set; }

        public int Deny { get; internal set; }

        public PermissionOverwrite(BaseClient Client, JsonElement Data) : base (Client, Data.GetProperty("id"))
        {
            Patch(Data);
        }

        public void Patch(JsonElement Data)
        {
            this.Type = Data.GetProperty("type").GetInt32();
            this.Allow = int.Parse(Data.GetProperty("allow").GetString());
            this.Deny = int.Parse(Data.GetProperty("deny").GetString());
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }
    }
}
