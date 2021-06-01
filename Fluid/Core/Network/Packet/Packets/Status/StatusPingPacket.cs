namespace Fluid.Core
{
    public struct StatusPingPacket : IPacket
    {
        public StatusPingPacket(long time)
        {
            Time = time;
        }

        public long Time;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            Time = stream.ReadInt64();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteInt64(Time);
            return mode;
        }
    }
}