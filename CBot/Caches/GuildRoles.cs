using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildRoles : BaseCache<long, Role>
    {
        public GuildRoles(BaseClient Client, Guild Guild, JsonElement Roles) : base(Client)
        {

        }

        public override void Create(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, Role> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<Role> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override Role Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
