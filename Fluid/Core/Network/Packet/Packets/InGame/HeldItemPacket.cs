namespace Fluid.Core
{
    public struct HeldItemPacket : IPacket
    {
        public HeldItemPacket(sbyte slot)
        {
            Slot = slot;
        }

        public short Slot;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            if (direction == PacketDirection.Clientbound)
                Slot = stream.ReadInt8();
            else
                Slot = stream.ReadInt16();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            if (direction == PacketDirection.Clientbound)
                stream.WriteInt8((sbyte)Slot);
            else
                stream.WriteInt16(Slot);
            return mode;
        }
    }
}