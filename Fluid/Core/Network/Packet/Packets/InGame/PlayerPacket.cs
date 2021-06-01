namespace Fluid.Core
{
    public struct PlayerPacket : IPacket
    {
        public PlayerPacket(bool onGround)
        {
            OnGround = onGround;
        }

        public bool OnGround;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            OnGround = stream.ReadBoolean();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteBoolean(OnGround);
            return mode;
        }
    }
}