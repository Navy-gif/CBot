using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBot.Interfaces
{
    interface ITextChannel : IChannel
    {

        Task<Message> FetchMessage(long Id);

        Task<Dictionary<long, Message>> FetchMessages(MessageQueryOptions Options);

        Task<Message> Send(string Text = null, MessageOptions Options = null);

        Task<Message> EditMessage(long Id, string Text = null, MessageOptions Options = null);

        Task<Message> DeleteMessage(long Id);

        Task<Dictionary<long, Message>> BulkDeleteMessages(long[] Ids);

        Task<Dictionary<long, Message>> BulkDeleteMessages(Dictionary<long, Message> Ids);

        Task<MessageReaction> AddReaction(long MessageId, MessageReaction Reaction);

        Task<MessageReaction> DeleteReaction(long MessageId, MessageReaction Reaction, long Target);

        Task<MessageReaction> DeleteReactions(long MessageId, MessageReaction Reaction = null);

        Task<MessageReaction> FetchReactions(long MessageId, MessageReaction Reaction, ReactionQueryOptions Options = null);

    }
}
