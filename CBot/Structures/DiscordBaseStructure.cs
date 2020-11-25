using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CBot.Structures
{
    abstract class DiscordBaseStructure
    {
        public long Id { get; internal set; }
        public BaseClient Client { get; internal set; }

        public DiscordBaseStructure(BaseClient Client, JsonElement Id)
        {
            this.Id = long.Parse(Id.GetString());
            this.Client = Client;
            Console.WriteLine($"Creating DiscordStructure with ID: {this.Id}");
        }

        public DiscordBaseStructure(BaseClient Client, long Id)
        {
            this.Id = Id;
            this.Client = Client;
        }

        public abstract void Patch(Dictionary<string, JsonElement> Data);

    }
}
