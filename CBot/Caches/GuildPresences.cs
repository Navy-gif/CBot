using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildPresences : BaseCache<long, Presence>
    {
        public GuildPresences(BaseClient Client, Guild Guild) : base (Client)
        {

        }

        public override void Create(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, Presence> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<Presence> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override Presence Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
