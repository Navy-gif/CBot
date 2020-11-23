using System;
using System.Collections.Generic;
using System.Text;

namespace CBot.DiscordPayloads
{
    class Payload
    {
        public int op { get; set; }
        public object s { get; set; } // Not always present, should be null if not
        public string t { get; set; } // Present in received events
        public object d { get; set; } // 
    }
}
