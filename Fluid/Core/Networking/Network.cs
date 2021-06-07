using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

namespace Fluid.Core
{
    public partial class Network
    {
        private UdpClient server { get; set; }
        private int port { get; set; }
        private IPEndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private IPEndPoint endPoint { get; set; }

        public void Bind(string address, int port)
        {
            this.endPoint = new IPEndPoint(IPAddress.Parse(address), port);
            UdpClient server = new UdpClient(port);
            this.port = port;
            this.server = server;
            Receive();
        }

        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            server.Send(data, 1);
        }

        public void Client()
        {
            server.Connect(this.endPoint);
        }

        private void Receive()
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("Hearing on localhost and " + port);
                    byte[] data = server.Receive(ref epFrom);
                    Console.WriteLine(Encoding.ASCII.GetString(data));
                }
                /**_socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
                {
                    State so = (State)ar.AsyncState;
                    int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                    _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                    Console.WriteLine("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
                }, state);**/
            }
            catch (SocketException exce)
            {
                Console.WriteLine(exce);
            }
        }
    }
}