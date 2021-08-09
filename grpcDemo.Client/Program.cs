using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace grpcDemo.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Name: ");
                var name = Console.ReadLine();
                var greetMessage = $"{name}..";
                using var channel = GrpcChannel.ForAddress("https://localhost:5001"); // our grpc server
                var client = new Greeter.GreeterClient(channel);

                var reply = await client.SayHelloAsync(new HelloRequest { Name = greetMessage });

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                
                Console.WriteLine("\nServer says: " + reply.Message);
                Console.ResetColor();

                Console.WriteLine("\nPress any key to continue...");
                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Home)
                {
                    Console.Clear();        
                }
            }
        }
    }
}
