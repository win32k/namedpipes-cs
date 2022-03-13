using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace Named_Pipe_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Delay(1000).Wait();
            var client = new NamedPipeClientStream("Pipe1"); // Create new client and connect to Pipe1
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);
            Console.WriteLine("[+] Connected to named pipe");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break; // If input is null, break
                writer.WriteLine(input);
                writer.Flush();
                Console.WriteLine(reader.ReadLine());
            }
        }
    }
}
