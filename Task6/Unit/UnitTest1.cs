using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NewMethod();
            Assert.AreEqual(Program.arr, Program.arr);
        }

        private static void NewMethod()
        {
            Program.arr.Add(100);
            Program.arr.Add(200);
            Program.arr.Add(300);
            Program.Rec(3, 5);
        }
    }
}
