using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CBot
{

    class Program
    {

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {

            Console.WriteLine("Starting client.");

            //Read config
            byte[] raw = CBot.Properties.FileResources.config;
            string rawString = System.Text.Encoding.UTF8.GetString(raw);
            BotConfig config = JsonSerializer.Deserialize<BotConfig>(rawString);

            //Start client
            Client Client = new Client(config);
            await Client.Login();
            
            Thread.Sleep(-1);
            //await Client.Logout();
            //Thread.Sleep(10000);

        }


    }

}
