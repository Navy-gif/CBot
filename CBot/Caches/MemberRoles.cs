using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Caches
{
    class MemberRoles : BaseCache<long, Role>
    {
        public MemberRoles(BaseClient Client, GuildMember Member, JsonElement Roles) : base(Client)
        {

        }

        public override Role Create(RestOptions Data)
        {
            throw new NotImplementedException();
        }

        public override Role CreateEntry(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, Role> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override System.Threading.Tasks.Task<Role> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override Role Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
