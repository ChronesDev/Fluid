namespace Fluid.Core
{
    public struct JoinGamePacket : IPacket
    {
        public JoinGamePacket(int entityId, byte maxPlayers, string levelType)
        {
            EntityId = entityId;
            MaxPlayers = maxPlayers;
            LevelType = levelType;
        }

        public int EntityId;
        public byte MaxPlayers;
        public string LevelType;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            EntityId = stream.ReadInt32();
            MaxPlayers = stream.ReadUInt8();
            LevelType = stream.ReadString();
            return mode;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteInt32(EntityId);
            stream.WriteUInt8(MaxPlayers);
            stream.WriteString(LevelType);
            return mode;
        }
    }
}