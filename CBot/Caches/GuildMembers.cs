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

        Guild Guild;

        public GuildMembers(BaseClient Client, Guild Guild) : base(Client)
        {
            this.Guild = Guild;
        }

        public override GuildMember Create(RestOptions Data)
        {
            throw new NotImplementedException();
        }

        public override GuildMember CreateEntry(JsonElement Data)
        {
            GuildMember Member = new GuildMember(Client, Guild, Data);
            _Cache.Add(Member.Id, Member);
            return Member;
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
