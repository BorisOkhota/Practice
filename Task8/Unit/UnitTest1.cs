using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] actual = Program.Solve(4,2,new int[,] { {0,1 },{0,1 },{1,0 },{1,0 } });
            int[] expected = new int[] { 0, 1, 0, 1 };
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
