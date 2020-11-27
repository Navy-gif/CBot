using CBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Structures.Channels
{
    class GuildNewsChannel : GuildTextChannel, INewsChannel
    {

        public GuildNewsChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Guild, Data)
        {

        }

        public Task<Message> CrosspostMessage(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> CrosspostMessage(Message Message)
        {
            throw new NotImplementedException();
        }

        public Task<INewsChannel> Follow(ITextBasedChannel Target)
        {
            throw new NotImplementedException();
        }
    }
}
