namespace Fluid.Core
{
    public struct UseBedPacket : IPacket
    {
        public UseBedPacket(int entityId, int x, byte y, int z)
        {
            EntityId = entityId;
            X = x;
            Y = y;
            Z = z;
        }

        public int EntityId;
        public int X;
        public byte Y;
        public int Z;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            EntityId = stream.ReadInt32();
            X = stream.ReadInt32();
            Y = stream.ReadUInt8();
            Z = stream.ReadInt32();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteInt32(EntityId);
            stream.WriteInt32(X);
            stream.WriteUInt8(Y);
            stream.WriteInt32(Z);
            return mode;
        }
    }
}