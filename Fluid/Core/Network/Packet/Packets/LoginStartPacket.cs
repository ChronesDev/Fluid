namespace Fluid.Core
{
    public struct LoginStartPacket : IPacket
    {
        public LoginStartPacket(string username)
        {
            Username = username;
        }

        public string Username;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            Username = stream.ReadString();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteString(Username);
            return mode;
        }
    }
}