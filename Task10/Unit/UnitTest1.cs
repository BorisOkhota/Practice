using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task10;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.Main(new string [] {""});
            Assert.AreEqual(true,true);
        }
    }
}
