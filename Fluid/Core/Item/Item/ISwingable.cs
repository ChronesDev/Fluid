namespace Fluid.Core
{
    public partial record Item
    {
        public interface ISwingable
        {
            public void Swing(ItemSwingEventArgs e);
        }
    }
}