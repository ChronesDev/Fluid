namespace Fluid.Core
{
    public struct KeepAlivePacket : IPacket
    {
        public KeepAlivePacket(int keepAlive)
        {
            KeepAlive = keepAlive;
        }

        public int KeepAlive;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            KeepAlive = stream.ReadInt32();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteInt32(KeepAlive);
            return mode;
        }
    }
}