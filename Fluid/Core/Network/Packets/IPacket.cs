using Craft.Net;
using Fluid.Core.Network;

namespace Fluid.Core
{
    public interface IPacket
    {
        /// <summary>
        /// Reads this packet data from the stream, not including its length or packet ID, and returns
        /// the new network state (if it has changed).
        /// </summary>
        NetworkMode ReadPacket(ConnectionStream stream, NetworkMode mode, PacketDirection direction);

        /// <summary>
        /// Writes this packet data to the stream, not including its length or packet ID, and returns
        /// the new network state (if it has changed).
        /// </summary>
        NetworkMode WritePacket(ConnectionStream stream, NetworkMode mode, PacketDirection direction);
    }
}
