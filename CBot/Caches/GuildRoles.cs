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

        public Guild Guild { get; internal set; }

        public GuildRoles(BaseClient Client, Guild Guild) : base(Client)
        {
            this.Guild = Guild;
        }

        public override Role Create(RestOptions Data)
        {
            throw new NotImplementedException();
        }

        public override Role CreateEntry(JsonElement Data)
        {

            Role Role = new Role(this.Client, Guild, Data);
            this._Cache.Add(Role.Id, Role);
            return Role;

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
