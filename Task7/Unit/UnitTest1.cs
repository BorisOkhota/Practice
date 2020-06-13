using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task7;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var actual = Program.Solve(new int[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(actual, actual);
        }
    }
}
