namespace Fluid.Core
{
    public partial record Item
    {
        public interface ISwingable
        {
            void Swing(ItemSwingEventArgs e);
        }
    }
}