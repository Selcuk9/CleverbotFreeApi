# CleverbotFreeApi
Cleverbot Api for <a href="https://www.cleverbot.com/" >cleverbot.com</a>
# Usage
1)Create a Visual Studio .NET Core and save it.<br>
2)In Visual Studio menu bar, go to Tools -> NuGet Package Manager -> Package Manager Console.<br>
3)Type Install-Package CleverbotFree and wait.<br>

<strong> A simple console client:</strong>
```CSharp
using cleverBotApi.Api;
using System;
using System.Threading.Tasks;

namespace TestBot
{
    class Program
    {
        static async Task Main()
        {
            string message;
            RestClient client = new RestClient(cleverBotApi.Api.Language.en);

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
```
