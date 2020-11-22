using System;
using System.Text.Json;
using System.Threading;

namespace CBot
{

    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Starting client.");

            //Read config
            byte[] raw = CBot.Properties.FileResources.config;
            string rawString = System.Text.Encoding.UTF8.GetString(raw);
            BotConfig config = JsonSerializer.Deserialize<BotConfig>(rawString);

            //Start client
            Client Client = new Client(config);
            Client.Login();
            Thread.Sleep(10000);

        }


    }

}
