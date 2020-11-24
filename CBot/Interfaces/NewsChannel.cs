using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBot.Interfaces
{
    interface INewsChannel : ITextBasedChannel, IGuildChannel
    {

        Task<INewsChannel> Follow(ITextBasedChannel Target); // Add a crosspost webhook to the Target channel

        Task<Message> CrosspostMessage(long Id);

        Task<Message> CrosspostMessage(Message Message);

    }

}
