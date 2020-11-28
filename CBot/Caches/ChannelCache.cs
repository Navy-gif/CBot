using CBot.Interfaces;
using CBot.RESTOptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class ChannelCache : BaseCache<long, IChannel>
    {

        public ChannelCache(BaseClient Client) : base(Client)
        {

        }

        public override IChannel Create(RestOptions Options)
        {
            throw new NotImplementedException();
        }

        public override IChannel CreateEntry(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, IChannel> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<IChannel> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override IChannel Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
