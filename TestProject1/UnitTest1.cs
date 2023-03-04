using WpfApp1.Helper;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var test = Library.GetLibrary();
            Assert.True(true);
        }
    }
}