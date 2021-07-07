using System;
using Fluid.Core;
using Xunit;

namespace FluidLab
{
    public class TestTemplate
    {
        [Fact]
        public void ExampleItem()
        {
            Item item = new Items.TestItem {DisplayName = "LUL"};
            var item2 = item with {DisplayName = "Hello World", Count = 10};
        }
    }
}