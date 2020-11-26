using CBot.Interfaces;
using CBot.RESTOptions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Text.Json.JsonElement;

namespace CBot.Structures.Base
{
    class AbstractGuildChannel : DiscordBaseStructure, IGuildChannel
    {

        public Guild Guild { get; internal set; }

        public int Type { get; internal set; }

        public int? Position { get; internal set; }

        private List<PermissionOverwrite> _PermissionOverwrites;

        public PermissionOverwrite[] PermissionOverwrites
        {
            get
            {
                return _PermissionOverwrites.ToArray();
            }
            internal set
            {}
        }
        public string Name { get; internal set; }

        public AbstractGuildChannel ParentChannel { get { return Guild.Channels.Resolve(ParentChannelId); } internal set { } }

        public long ParentChannelId { get; internal set; }

        public AbstractGuildChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Data)
        {
            _PermissionOverwrites = new List<PermissionOverwrite>();
            this.Guild = Guild;
        }

        public virtual void Patch(JsonElement Data)
        {

            this.Type = Data.GetProperty("type").GetInt32();

            if (Data.TryGetProperty("parent_id", out JsonElement _parent))
                this.ParentChannelId = long.Parse(_parent.GetString());


            this.Name = Data.GetProperty("name").GetString();

            if (Data.TryGetProperty("position", out JsonElement pos))
                this.Position = pos.GetInt32();

            JsonElement Overwrites = Data.GetProperty("permission_overwrites");
            ArrayEnumerator OverwriteEnumerator = Overwrites.EnumerateArray();
            foreach(JsonElement Overwrite in OverwriteEnumerator)
            {
                _PermissionOverwrites.Add(new PermissionOverwrite(Client, Overwrite));
            }

        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }

        public Task<AbstractGuildChannel> Edit(ChannelEditOptions Options)
        {
            throw new NotImplementedException();
        }

        public Task<AbstractGuildChannel> OverwritePermissions(PermissionOverwrite Overwrite)
        {
            throw new NotImplementedException();
        }

        public Task<AbstractGuildChannel> DeletePermissionOverwrite(PermissionOverwrite Overwrite)
        {
            throw new NotImplementedException();
        }

        public Task<AbstractGuildChannel> DeletePermissionOverwrite(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<Invite> CreateInvite(InviteOptions Options)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, Invite>> FetchInvites()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<AbstractGuildChannel>(this);
        }

        public Task<IChannel> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
