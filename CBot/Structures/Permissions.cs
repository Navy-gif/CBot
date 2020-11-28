using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CBot.Structures
{
    class Permissions : DiscordBaseStructure
    {

        public int Raw { get; internal set; }

        public Permissions(Role Role, int Permissions) : base(Role.Client, Role.Id)
        {
            Raw = Permissions;
        }

        public static string[] Resolve(Permissions Perms)
        {
            return null;
        }

        public override void Patch(JsonElement Data)
        {
            throw new NotImplementedException();
        }

        public override void Patch(Dictionary<string, JsonElement> Data)
        {
            throw new NotImplementedException();
        }
    }
}
