using CBot.Interfaces;
using CBot.RESTOptions;
using CBot.Structures;
using CBot.Structures.Base;
using CBot.Structures.Channels;
using CBot.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildChannels : BaseCache<long, AbstractGuildChannel>
    {
        Guild Guild;
        public GuildChannels(BaseClient Client, Guild Guild) : base(Client)
        {
            this.Guild = Guild;
        }

        public override AbstractGuildChannel Create(RestOptions Options)
        {
            throw new NotImplementedException();
        }

        public override AbstractGuildChannel CreateEntry(JsonElement Data)
        {
            int Type = Data.GetProperty("type").GetInt32();
            AbstractGuildChannel Channel = null;

            switch (Type)
            {
                case (int)ChannelType.Text:
                    Channel = new GuildTextChannel(Client, Guild, Data);
                    break;
                case (int)ChannelType.Voice:
                    Channel = new GuildVoiceChannel(Client, Guild, Data);
                    break;
                case (int)ChannelType.Category:
                    Channel = new GuildCategoryChannel(Client, Guild, Data);
                    break;
                case (int)ChannelType.News:
                    Channel = new GuildNewsChannel(Client, Guild, Data);
                    break;
                case (int)ChannelType.Store:
                    Channel = new GuildStoreChannel(Client, Guild, Data);
                    break;
            }
            _Cache.Add(Channel.Id, Channel);
            return Channel;
        }

        public override BaseCache<long, AbstractGuildChannel> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<AbstractGuildChannel> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override AbstractGuildChannel Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
