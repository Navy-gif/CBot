using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class GuildEmojis : BaseCache<string, Emoji>
    {
        public GuildEmojis(BaseClient Client, Guild Guild, JsonElement Emojis) : base (Client)
        {

        }

        public override void Create(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<string, Emoji> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<Emoji> Fetch(string Key)
        {
            throw new NotImplementedException();
        }

        public override Emoji Resolve(string Key)
        {
            throw new NotImplementedException();
        }
    }
}
