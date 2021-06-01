namespace Fluid.Core
{
    public struct TimeUpdatePacket : IPacket
    {
        public TimeUpdatePacket(long worldAge, long timeOfDay)
        {
            WorldAge = worldAge;
            TimeOfDay = timeOfDay;
        }

        public long WorldAge;
        public long TimeOfDay;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            WorldAge = stream.ReadInt64();
            TimeOfDay = stream.ReadInt64();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteInt64(WorldAge);
            stream.WriteInt64(TimeOfDay);
            return mode;
        }
    }
}