using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class UserCache : BaseCache<long, User>
    {

        public UserCache(BaseClient Client) : base(Client)
        {

        }

        public override User Create(RestOptions Data)
        {
            throw new NotImplementedException();
        }

        public override User CreateEntry(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, User> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<User> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override User Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
