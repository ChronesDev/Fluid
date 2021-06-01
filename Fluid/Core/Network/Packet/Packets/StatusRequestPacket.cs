namespace Fluid.Core
{
    public struct StatusRequestPacket : IPacket
    {

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            return mode;
        }
    }
}