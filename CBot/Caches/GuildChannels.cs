using CBot.Interfaces;
using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildChannels : BaseCache<long, IGuildChannel>
    {
        Guild Guild;
        public GuildChannels(BaseClient Client, Guild Guild) : base(Client)
        {
            this.Guild = Guild;
        }

        public override IGuildChannel Create(RestOptions Options)
        {
            throw new NotImplementedException();
        }

        public override IGuildChannel CreateEntry(JsonElement Data)
        {
            long Id = long.Parse(Data.GetProperty("id").GetString());
            GuildTextChannel Channel = new GuildTextChannel(Client, Guild, Data);
            Cache.Add(Id, Channel);
            return Channel;
        }

        public override BaseCache<long, IGuildChannel> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<IGuildChannel> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override IGuildChannel Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
