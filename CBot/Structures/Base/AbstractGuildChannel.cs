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
        #region Properties
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

        #endregion Properties

        public AbstractGuildChannel(BaseClient Client, Guild Guild, JsonElement Data) : base(Client, Data.GetProperty("id"))
        {
            _PermissionOverwrites = new List<PermissionOverwrite>();
            this.Guild = Guild;
        }

        public override void Patch(JsonElement Data)
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

        public Task<IGuildChannel> Edit(ChannelEditOptions Options)
        {
            throw new NotImplementedException();
        }

        public Task<IGuildChannel> OverwritePermissions(PermissionOverwrite Overwrite)
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
