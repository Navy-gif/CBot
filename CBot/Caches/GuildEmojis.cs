using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildEmojis : BaseCache<long, Emoji>
    {

        public Guild Guild { get; internal set; }

        public GuildEmojis(BaseClient Client, Guild Guild) : base (Client)
        {
            this.Guild = Guild;
        }

        public override Emoji Create(RestOptions Data)
        {
            throw new NotImplementedException();
        }

        public override Emoji CreateEntry(JsonElement Data)
        {
            Emoji Emoji = new Emoji(this.Client, Guild, Data);
            _Cache.Add(Emoji.Id, Emoji);
            return Emoji;
        }

        public override BaseCache<long, Emoji> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<Emoji> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override Emoji Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
