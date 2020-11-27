using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures.Channels
{
    class GuildStoreChannel : GuildTextChannel
    {

        public GuildStoreChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Guild, Data)
        {

        }

    }
}
