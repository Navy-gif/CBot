using CBot.RESTOptions;
using CBot.Structures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBot.Interfaces
{
    interface ITextBasedChannel : IChannel
    {

        Task<Message> FetchMessage(long Id);

        Task<Dictionary<long, Message>> FetchMessages(MessageQueryOptions Options);

        Task<Message> Send(string Text = null, MessageOptions Options = null);

        Task<Message> EditMessage(long Id, string Text = null, MessageOptions Options = null);

        Task<Message> EditMessage(Message Message, string Text = null, MessageOptions Options = null);

        Task<Message> DeleteMessage(long Id);

        Task<Message> DeleteMessage(Message Message);

        Task<Dictionary<long, Message>> BulkDeleteMessages(long[] Ids);

        Task<Dictionary<long, Message>> BulkDeleteMessages(Dictionary<long, Message> Messages);

        Task<MessageReaction> AddReaction(long MessageId, MessageReaction Reaction);

        Task<MessageReaction> AddReaction(Message Message, MessageReaction Reaction);

        Task<MessageReaction> DeleteReaction(long MessageId, MessageReaction Reaction, long Target);

        Task<MessageReaction> DeleteReaction(Message Message, MessageReaction Reaction, long Target);

        Task<MessageReaction> DeleteReactions(long MessageId, MessageReaction Reaction = null);

        Task<MessageReaction> DeleteReactions(Message Message, MessageReaction Reaction = null);

        Task<MessageReaction> FetchReactions(long MessageId, MessageReaction Reaction, ReactionQueryOptions Options = null);

        Task<MessageReaction> FetchReactions(Message Message, MessageReaction Reaction, ReactionQueryOptions Options = null);

        Task<Dictionary<long, Message>> FetchPinnedMessages();

        Task<Message> PinMessage(long Id);

        Task<Message> PinMessage(Message Message);

        Task<Message> UnpinMessage(long Id);

        Task<Message> UnpinMessage(Message Message);

    }
}
