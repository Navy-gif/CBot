using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBot.Interfaces
{
    interface IChannel
    {

        Task<IChannel> Delete();

    }
}
