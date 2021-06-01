namespace Fluid.Core
{
    public class OnlinePlayer : Player
    {
        public override bool Is<T>() => typeof(T) == typeof(OnlinePlayer);


        public OnlinePlayer(Level level) : base(level)
        {
        }
    }
}