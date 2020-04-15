using cleverBotApi;
using cleverBotApi.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestBot
{
    class Program
    {
        static async Task Main()
        {

            string message;
            RestClient client = new RestClient(cleverBotApi.Api.Language.ru);

            do
            {
                Console.Write("Type your message: ");
                message = Console.ReadLine();
                Console.Write("Bot: ");
                Console.WriteLine(await client.SendMessage(message));

            } while (true);
        }
    }
}
