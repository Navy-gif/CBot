using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildMembers : BaseCache<long, GuildMember>
    {
        public GuildMembers(BaseClient Client, Guild Guild) : base(Client)
        {

        }

        public override GuildMember Create(RestOptions Data)
        {
            throw new NotImplementedException();
        }

        public override GuildMember CreateEntry(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, GuildMember> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<GuildMember> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override GuildMember Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
