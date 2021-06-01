using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fluid.Core
{
    internal static class PacketHandlers
    {
        public static void RegisterHandlers(Main server)
        {
            server.RegisterPacketHandler(typeof(HandshakePacket), LoginHandlers.Handshake);
            server.RegisterPacketHandler(typeof(LoginStartPacket), LoginHandlers.LoginStart);
            server.RegisterPacketHandler(typeof(EncryptionKeyResponsePacket), LoginHandlers.EncryptionKeyResponse);
            server.RegisterPacketHandler(typeof(ClientStatusPacket), LoginHandlers.ClientStatus);
            server.RegisterPacketHandler(typeof(ClientSettingsPacket), LoginHandlers.ClientSettings);


            server.RegisterPacketHandler(typeof(StatusRequestPacket), StatusRequest);
            server.RegisterPacketHandler(typeof(StatusPingPacket), StatusPing);
            server.RegisterPacketHandler(typeof(KeepAlivePacket), KeepAlive);
        }

        public static void StatusRequest(RemoteClient client, Main server, IPacket _packet)
        {
            client.SendPacket(new StatusResponsePacket(GetServerStatus(server)));
        }

        public static void StatusPing(RemoteClient client, Main server, IPacket _packet)
        {
            client.SendPacket(_packet);
        }

        public static void KeepAlive(RemoteClient client, Main server, IPacket _packet)
        {
            // TODO: Confirm value validity
            client.LastKeepAlive = DateTime.Now;
            client.Ping = (short)(client.LastKeepAlive - client.LastKeepAliveSent).TotalMilliseconds;
        }

        private static ServerStatus GetServerStatus(Main server)
        {
            return new ServerStatus(
                new ServerStatus.ServerVersion(NetworkManager.FriendlyVersion, NetworkManager.ProtocolVersion),
                new ServerStatus.PlayerList(100, server.Clients.Count(c => c.IsLoggedIn),
                    server.Clients.Where(c => c.IsLoggedIn).Take(10).Select(p =>
                    new ServerStatus.PlayerList.Player(p.Username, 5.ToString())).ToArray()),
                "Fluid Server",
                ""); // TODO: Icon
        }
    }
}
