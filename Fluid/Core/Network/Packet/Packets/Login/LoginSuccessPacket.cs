namespace Fluid.Core
{
    public struct LoginSuccessPacket : IPacket
    {
        public LoginSuccessPacket(string uuid, string username)
        {
            UUID = uuid;
            Username = username;
        }

        public string UUID;
        public string Username;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            UUID = stream.ReadString();
            Username = stream.ReadString();
            return NetworkMode.Play;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteString(UUID);
            stream.WriteString(Username);
            return NetworkMode.Play;
        }
    }
}