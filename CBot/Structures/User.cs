using CBot.Interfaces;
using CBot.RESTOptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Structures
{
    class User : DiscordBaseStructure, ITextBasedChannel
    {

        public string Username { get; internal set; }

        public string Discriminator { get; internal set; }

        public string Tag { 
            get
            {
                return $"{Username}#{Discriminator}";
            }
            internal set
            {

            }
        }

        public string Avatar { get; internal set; }

        public bool Bot { get; internal set; }

        public bool System { get; internal set; }

        public int RawFlags { get; internal set; }

        public User(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {

        }

        public User(BaseClient Client, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {

        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }

        #region TextChannel methods

        public Task<MessageReaction> AddReaction(long MessageId, MessageReaction Reaction)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> AddReaction(Message Message, MessageReaction Reaction)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<long, Message>> BulkDeleteMessages(long[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<long, Message>> BulkDeleteMessages(Dictionary<long, Message> Messages)
        {
            throw new NotImplementedException();
        }

        public Task<IChannel> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<Message> DeleteMessage(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> DeleteMessage(Message Message)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> DeleteReaction(long MessageId, MessageReaction Reaction, long Target)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> DeleteReaction(Message Message, MessageReaction Reaction, long Target)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> DeleteReactions(long MessageId, MessageReaction Reaction = null)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> DeleteReactions(Message Message, MessageReaction Reaction = null)
        {
            throw new NotImplementedException();
        }

        public Task<Message> EditMessage(long Id, string Text = null, MessageOptions Options = null)
        {
            throw new NotImplementedException();
        }

        public Task<Message> EditMessage(Message Message, string Text = null, MessageOptions Options = null)
        {
            throw new NotImplementedException();
        }

        public Task<Message> FetchMessage(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<long, Message>> FetchMessages(MessageQueryOptions Options)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<long, Message>> FetchPinnedMessages()
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> FetchReactions(long MessageId, MessageReaction Reaction, ReactionQueryOptions Options = null)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReaction> FetchReactions(Message Message, MessageReaction Reaction, ReactionQueryOptions Options = null)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PinMessage(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> PinMessage(Message Message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> Send(string Text = null, MessageOptions Options = null)
        {
            throw new NotImplementedException();
        }

        public Task<Message> UnpinMessage(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> UnpinMessage(Message Message)
        {
            throw new NotImplementedException();
        }

        public override void Patch(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        #endregion TextChannel methods

    }
}
