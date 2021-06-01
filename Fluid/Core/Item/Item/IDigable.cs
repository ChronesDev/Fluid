namespace Fluid.Core
{
    public partial record Item
    {
        public interface IDigable
        {
            void BeginDigging();
            void StopDigging();
            void CompleteDigging();
        }
    }
}