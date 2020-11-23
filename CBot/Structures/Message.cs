using System.Collections.Generic;
using System.Text.Json;

namespace CBot.Structures
{
    class Message : DiscordBaseStructure
    {

        public Message(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {
            
        }

    }
}
