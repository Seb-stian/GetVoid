using Xunit;

namespace GetVoid.Tests
{
    public class Void_Get
    {
        [Fact]
        public void VoidGet_ReturnsVoidObject()
        {
            object @void = Void.Get();
            Assert.Equal(typeof(void), @void.GetType());
        }

        [Fact]
        public void VoidToString_ReturnsSystemVoid()
        {
            object @void = Void.Get();
            Assert.Equal(typeof(void).FullName, @void.ToString());
        }
    }
}
