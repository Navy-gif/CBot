using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CBot.Interfaces;
using CBot.RESTOptions;
using CBot.Structures.Base;
using CBot.Util;

namespace CBot.Structures.Channels
{
    class GuildTextChannel : AbstractGuildChannel, IGuildChannel, ITextBasedChannel
    {

        public string Topic { get; internal set; }

        public bool Nsfw { get; internal set; } = false;

        public int RateLimit { get; internal set; } = 0;

        public DateTime LastPinTime { get; internal set; }

        public long LastMessageId { get; set; }

        public GuildTextChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Guild, Data)
        {
            Patch(Data);
        }

        public override void Patch(JsonElement Data)
        {

            base.Patch(Data);

            if(Data.TryGetProperty("last_message_id", out JsonElement lmsgid))
                this.LastMessageId = long.Parse(lmsgid.GetString());

            if(Data.TryGetProperty("topic", out JsonElement topic))
                this.Topic = topic.GetString();

            if(Data.TryGetProperty("nsfw", out JsonElement nsfw))
                this.Nsfw = nsfw.GetBoolean();

            if(Data.TryGetProperty("rate_limit_per_user", out JsonElement rl))
                this.RateLimit = rl.GetInt32();

            if (Data.TryGetProperty("last_pin_timestamp", out JsonElement date))
                this.LastPinTime = date.GetDateTime();

        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }

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

        public Task<Invite> CreateInvite(InviteOptions Options)
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

        public Task<IGuildChannel> DeletePermissionOverwrite(PermissionOverwrite Overwrite)
        {
            throw new NotImplementedException();
        }

        public Task<IGuildChannel> DeletePermissionOverwrite(long Id)
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

        public Task<IGuildChannel> Edit(ChannelEditOptions Options)
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

        public Task<Dictionary<string, Invite>> FetchInvites()
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

        public Task<IGuildChannel> OverwritePermissions(PermissionOverwrite Overwrite)
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
    }
}
