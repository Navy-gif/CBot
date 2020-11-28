using CBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CBot.Structures
{
    class Message : DiscordBaseStructure
    {

        public ITextBasedChannel Channel { get; internal set; }

        public long ChannelId { get; internal set; }

        public Guild Guild { get; internal set; }

        public User Author { get; internal set; }

        public GuildMember Member { get; internal set; }

        public string Content { get; internal set; }

        public DateTime Timestamp { get; internal set; }

        public DateTime EditedTimestamp { get; internal set; }

        public bool Tts { get; internal set; }

        public bool MentionEveryone { get; internal set; }

        public User[] Mentions { get; internal set; }

        public Role[] RoleMentions { get; internal set; }

        public IChannel[] ChannelMentions { get; internal set; }

        public Dictionary<long, Attachment> Attachments { get; internal set; }

        public Message(BaseClient Client, Dictionary<string, JsonElement> Data) : base(Client, Data["id"])
        {
            Console.WriteLine("Ding");
            Patch(Data);
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {

            if(Data.TryGetValue("guild_id", out JsonElement value))
            {
                long Id = long.Parse(value.GetString());
                Guild = Client.Guilds.Get(Id);
            }
                

            ChannelId = long.Parse(Data["channel_id"].GetString());
            Channel = (ITextBasedChannel)this.Client.Channels.Get(ChannelId);
           


        }

        public override void Patch(JsonElement Data)
        {
            throw new System.NotImplementedException();
        }
    }
}
