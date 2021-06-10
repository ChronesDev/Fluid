using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.IO;

namespace Fluid.Core
{
    public partial class Network
    {
        private UdpClient Socket { get; set; }
        private IPEndPoint EpFrom = new IPEndPoint(IPAddress.Any, 0);

        public void Bind(string address, int port)
        {
            this.Socket = new UdpClient(new IPEndPoint(IPAddress.Parse(address), port));
            Receive();
        }

        public void Pack()
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
        }

        public void UnPack(byte[] packet)
        {
            MemoryStream stream = new MemoryStream();
            BinaryReader reader = new BinaryReader(stream);

            reader.ReadByte();
        }

        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            Socket.Send(data, data.Length);
        }

        private void Receive()
        {
            Console.WriteLine("Listening on port 11111.");
            byte[] data = Socket.Receive(ref EpFrom);
            Console.WriteLine(data);
        }
    }
}