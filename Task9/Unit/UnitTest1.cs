using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task9;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var actual = new List(10);
            var expected = "1 2 3 4 5 6 7 8 9 10 ";
            string str = "";
            Assert.AreEqual(expected, actual.PrintList());
            actual.Remove(5);
            actual.Search(4);
            actual.Search(5);
        }
    }
}
