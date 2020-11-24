using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    class VoiceStates : BaseCache<long, VoiceState>
    {
        public VoiceStates(BaseClient Client, Guild Guild) : base (Client)
        {

        }

        public override void Create(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override BaseCache<long, VoiceState> Fetch(CacheFetchOptions Options)
        {
            throw new NotImplementedException();
        }

        public override Task<VoiceState> Fetch(long Key)
        {
            throw new NotImplementedException();
        }

        public override VoiceState Resolve(long Key)
        {
            throw new NotImplementedException();
        }
    }
}
