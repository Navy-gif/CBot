using System;
using System.Collections.Generic;
using System.Text;

namespace CBot.Util
{
    enum ChannelType
    {

        Text, //0
        Dm, // 1
        Voice, // 2
        GroupDm, // 3
        Category, // 4
        News, // 5
        Store // 6

    }

    enum OverwriteType
    {
        Role,
        Member
    }
}
