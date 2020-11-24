using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class Emoji : DiscordBaseStructure
    {
        public Emoji(BaseClient Client, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {

        }
    }
}
