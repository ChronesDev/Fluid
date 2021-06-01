namespace Fluid.Core
{
    public struct HandshakePacket : IPacket
    {
        public HandshakePacket(int protocolVersion, string hostname, ushort port, NetworkMode nextState)
        {
            ProtocolVersion = protocolVersion;
            ServerHostname = hostname;
            ServerPort = port;
            NextState = nextState;
        }

        public int ProtocolVersion;
        public string ServerHostname;
        public ushort ServerPort;
        public NetworkMode NextState;

        public NetworkMode ReadPacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            ProtocolVersion = stream.ReadVarInt();
            ServerHostname = stream.ReadString();
            ServerPort = stream.ReadUInt16();
            NextState = (NetworkMode)stream.ReadVarInt();
            return NextState;
        }

        public NetworkMode WritePacket(MinecraftStream stream, NetworkMode mode, PacketDirection direction)
        {
            stream.WriteVarInt(ProtocolVersion);
            stream.WriteString(ServerHostname);
            stream.WriteUInt16(ServerPort);
            stream.WriteVarInt((int)NextState);
            return NextState;
        }
    }
}