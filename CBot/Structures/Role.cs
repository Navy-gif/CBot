using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class Role : DiscordBaseStructure
    {
        public Role(BaseClient Client, JsonElement Data) : base(Client, Data)
        {

        }
    }
}
