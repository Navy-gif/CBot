using CBot.Structures.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures.Channels
{
    class GuildCategoryChannel : AbstractGuildChannel
    {

        public Dictionary<long, AbstractGuildChannel> _Channels;

        public Dictionary<long, AbstractGuildChannel> Channels { get => CacheChannels(); internal set { } }

        public GuildCategoryChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Guild, Data)
        {
            
        }

        internal Dictionary<long, AbstractGuildChannel> CacheChannels()
        {

            if (_Channels != null) return _Channels;
            _Channels = new Dictionary<long, AbstractGuildChannel>();

            foreach (AbstractGuildChannel Channel in Guild.Channels.Cache)
            {
                if (Channel.Id == this.Id) _Channels.Add(Channel.Id, Channel);
            }

            return _Channels;

        }

    }
}
