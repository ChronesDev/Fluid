namespace Fluid.Core
{
    public struct PlayerLookPacket : IPacket
    {
        public PlayerLookPacket(float yaw, float pitch, bool onGround)
        {
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
        }

        public float Yaw, Pitch;
        public bool OnGround;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            Yaw = stream.ReadSingle();
            Pitch = stream.ReadSingle();
            OnGround = stream.ReadBoolean();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteSingle(Yaw);
            stream.WriteSingle(Pitch);
            stream.WriteBoolean(OnGround);
            return mode;
        }
    }
}