using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CBot.Structures
{
    class Guild : DiscordBaseStructure
    {

        public Guild(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {
            Console.WriteLine($"Creating Guild with ID: {this.Id}");
        }

    }
}
