using Fluid.Core.Network;

namespace Fluid.Core
{
    public class OnlinePlayer : Player, ClientSyn
    {
        public override bool Is<T>() => typeof(T) == typeof(OnlinePlayer);
        
        
    }
}