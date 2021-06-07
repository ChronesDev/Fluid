using System;
using Fluid.Core;

namespace Fluid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Server.Start();
            Network server = new Network();
            server.Bind("127.0.0.1", 11111);

            Network client = new Network();
            client.Bind("127.0.0.1", 11111);
            client.Send("test");
        }
    }
}