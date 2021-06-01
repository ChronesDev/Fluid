namespace Fluid.Core
{
    public partial record Item
    {
        public interface IPlaceable
        {
            void Place();
        }
    }
}