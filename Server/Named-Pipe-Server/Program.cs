using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Named_Pipe_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServePipe();
            Task.Delay(1000).Wait();
            Console.WriteLine("[*] Serving Named Pipe");
            Console.ReadLine();
        }


        static void ServePipe()
        {
            Task.Factory.StartNew(() =>
            {
                var server = new NamedPipeServerStream("Pipe1");
                server.WaitForConnection();
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                while (true)
                {
                    var line = reader.ReadLine();
                    writer.WriteLine(String.Join("", line.Reverse()));
                    writer.Flush();
                }
            });
        }
    }
}
