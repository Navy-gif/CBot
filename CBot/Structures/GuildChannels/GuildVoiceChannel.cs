using CBot.Interfaces;
using CBot.Structures.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures.Channels
{
    class GuildVoiceChannel : AbstractGuildChannel, IVoiceChannel
    {

        public int Bitrate { get; internal set; }

        public int UserLimit { get; internal set; }

        public Dictionary<long, GuildMember> Members { get; internal set; }

        public GuildVoiceChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Guild, Data)
        {
            Patch(Data);
            Members = new Dictionary<long, GuildMember>();
        }

        public override void Patch(JsonElement Data)
        {
            base.Patch(Data);

            if (Data.TryGetProperty("bitrate", out JsonElement bitrate))
                Bitrate = bitrate.GetInt32();

            if (Data.TryGetProperty("user_limit", out JsonElement limit))
                Bitrate = limit.GetInt32();

        }

    }
}
