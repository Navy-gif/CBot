using CBot.Structures.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures.Channels
{
    class GuildCategoryChannel : AbstractGuildChannel
    {

        public Dictionary<long, AbstractGuildChannel> Channels;

        public GuildCategoryChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Guild, Data)
        {
            Channels = new Dictionary<long, AbstractGuildChannel>();
        }

    }
}
