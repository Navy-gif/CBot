using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class Attachment : DiscordBaseStructure
    {

        public Attachment(BaseClient Client, JsonElement Data) : base(Client, Data)
        {

        }

        public override void Patch(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }
    }
}
