using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class ClientUser : User
    {
        public ClientUser(BaseClient Client, JsonElement Data) : base(Client, Data)
        {

        }
    }
}
