namespace CBot.DiscordPayloads
{
    class Heartbeat : Payload
    {

        public new object s { get; set; } = null;
        public new int? d { get; set; }
        public Heartbeat(int SeqNum)
        {
            this.op = 1;
            d = SeqNum;
        }

        public Heartbeat()
        {
            this.op = 1;
        }
    }
}
