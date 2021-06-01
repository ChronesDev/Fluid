namespace Fluid.Core
{
    public partial record Item
    {
        public interface IUseable
        {
            void Use(ItemUseEventArgs e);
        }
    }
}