﻿using CBot.RESTOptions;
using CBot.Structures;
using CBot.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBot.Interfaces
{
    interface IGuildChannel : IChannel
    {
        //ChannelType Type { get; set; }

        //string Name { get; set; }

        Task<IGuildChannel> Edit(ChannelEditOptions Options);

        Task<IGuildChannel> OverwritePermissions(PermissionOverwrite Overwrite);

        Task<IGuildChannel> DeletePermissionOverwrite(PermissionOverwrite Overwrite);

        Task<IGuildChannel> DeletePermissionOverwrite(long Id);

        Task<Invite> CreateInvite(InviteOptions Options);

        Task<Dictionary<string, Invite>> FetchInvites();

    }
}
