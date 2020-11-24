using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildCache : BaseCache<long, Guild>
    {

        public GuildCache(BaseClient Client) : base(Client)
        {

        }

        public override Guild Create(JsonElement Data)
        {

            long Id = long.Parse(Data.GetProperty("id").GetString());
            Guild Guild = new Guild(Client, Data);
            Cache.Add(Id, Guild);
            return Guild;

        }

        public Guild Create(Dictionary<string, JsonElement> Data)
        {

            long Id = long.Parse(Data["id"].GetString());
            Guild Guild = new Guild(Client, Data);
            Cache.Add(Id, Guild);
            return Guild;

        }

        public override BaseCache<long, Guild> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<Guild> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override Guild Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
