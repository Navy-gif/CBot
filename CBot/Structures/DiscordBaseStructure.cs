using System;
using System.Text.Json;

namespace CBot.Structures
{
    class DiscordBaseStructure
    {
        public long Id { get; internal set; }
        public BaseClient Client { get; internal set; }

        public DiscordBaseStructure(BaseClient Client, JsonElement Id)
        {
            this.Id = long.Parse(Id.GetString());
            this.Client = Client;
            Console.WriteLine($"Creating DiscordStructure with ID: {this.Id}");
        }

    }
}
