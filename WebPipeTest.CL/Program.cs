using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PipeLib;

namespace WebPipeTest.CL
{
    class Program
    {
        private const string PipeName = "WebPipeTest";
        private static StringPipeServer _server;

        static void Main(string[] args)
        {
            // Start a named pipe server and listen
            _server = new StringPipeServer(PipeName);
            _server.PipeConnected += PipeConnect;
            _server.PipeClosed += PipeClose;
            _server.MessageReceived += OnMessage;

            Console.WriteLine("Waiting for data");

            while (true)
            {
                string msg = Console.ReadLine();
                if (string.IsNullOrEmpty(msg)) break;

            }
        }

        private static void OnMessage(int id, string str)
        {
            Console.WriteLine($"R:{PipeName}:{id}:{str}");

        }

        private static void PipeClose()
        {
            Console.WriteLine($"Pipe [{PipeName}] closed");
        }

        private static void PipeConnect()
        {
            Console.WriteLine($"Pipe [{PipeName}] connected");
        }
    }
}
