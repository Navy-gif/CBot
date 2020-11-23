namespace CBot.DiscordPayloads
{
    class Payload
    {
        public int op { get; set; }
        public int s { get; set; }
        public string t { get; set; }
        public object d { get; set; }
    }
    class Heartbeat : Payload
    {

        public new object s { get; set; } = null;
        public Heartbeat()
        {
            this.op = 1;
            
        }
    }
}
