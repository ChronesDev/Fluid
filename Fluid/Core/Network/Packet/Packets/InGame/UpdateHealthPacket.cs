namespace Fluid.Core
{
    public struct UpdateHealthPacket : IPacket
    {
        public UpdateHealthPacket(float health, short food, float foodSaturation)
        {
            Health = health;
            Food = food;
            FoodSaturation = foodSaturation;
        }

        public float Health;
        public short Food;
        public float FoodSaturation;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            Health = stream.ReadSingle();
            Food = stream.ReadInt16();
            FoodSaturation = stream.ReadSingle();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteSingle(Health);
            stream.WriteInt16(Food);
            stream.WriteSingle(FoodSaturation);
            return mode;
        }
    }
}