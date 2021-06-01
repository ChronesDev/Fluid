namespace Fluid.Core
{
    public struct PlayerPositionPacket : IPacket
    {
        public PlayerPositionPacket(double x, double y, double z, double stance, bool onGround)
        {
            X = x;
            Y = y;
            Z = z;
            Stance = stance;
            OnGround = onGround;
        }

        public double X, Y, Z;
        public double Stance;
        public bool OnGround;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            X = stream.ReadDouble();
            Stance = stream.ReadDouble();
            Y = stream.ReadDouble();
            Z = stream.ReadDouble();
            OnGround = stream.ReadBoolean();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(Stance);
            stream.WriteDouble(Y);
            stream.WriteDouble(Z);
            stream.WriteBoolean(OnGround);
            return mode;
        }
    }
}