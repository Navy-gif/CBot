using CBot.RESTOptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBot.Interfaces
{
    interface IChannel
    {

        Task<IChannel> Edit(ChannelEditOptions Options);

        Task<IChannel> Delete();

        Task<IChannel> OverwritePermissions(PermissionOverwriteOptions Options);

    }
}
