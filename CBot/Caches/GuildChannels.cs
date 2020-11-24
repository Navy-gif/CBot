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

        public GuildChannels(BaseClient Client, Guild Guild) : base(Client)
        {

        }

        public override void Create(JsonElement Data)
        {
            throw new NotImplementedException();
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
