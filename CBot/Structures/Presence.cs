using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class Presence : DiscordBaseStructure
    {
        public Presence(BaseClient Client, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {

        }
    }
}
