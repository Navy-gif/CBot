using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class VoiceChannel : DiscordBaseStructure
    {
        VoiceChannel(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {

        }
    }
}
