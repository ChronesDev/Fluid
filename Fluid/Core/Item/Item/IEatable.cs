namespace Fluid.Core
{
    public partial record Item
    {
        public interface IEatable
        {
            void BeginEating();
            void StopEating();
            void CompleteEating();
        }
    }
}