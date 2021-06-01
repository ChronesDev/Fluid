namespace Fluid.Core
{
    public struct PlayerPositionAndLookPacket : IPacket
    {
        public PlayerPositionAndLookPacket(double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
            OnGround = onGround;
            Stance = null;
        }

        public PlayerPositionAndLookPacket(double x, double y, double z, double stance, float yaw, float pitch, bool onGround)
            : this(x, y, z, yaw, pitch, onGround)
        {
            Stance = stance;
        }

        public double X, Y, Z;
        public double? Stance;
        public float Yaw, Pitch;
        public bool OnGround;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            X = stream.ReadDouble();
            if (direction == PacketDirection.Serverbound)
                Stance = stream.ReadDouble();
            Y = stream.ReadDouble();
            Z = stream.ReadDouble();
            Yaw = stream.ReadSingle();
            Pitch = stream.ReadSingle();
            OnGround = stream.ReadBoolean();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteDouble(X);
            if (direction == PacketDirection.Serverbound)
                stream.WriteDouble(Stance.GetValueOrDefault());
            stream.WriteDouble(Y);
            stream.WriteDouble(Z);
            stream.WriteSingle(Yaw);
            stream.WriteSingle(Pitch);
            stream.WriteBoolean(OnGround);
            return mode;
        }
    }
}