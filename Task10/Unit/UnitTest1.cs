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
            var tree = new Tree();
            tree.Ideal(10, new Tree.Node(), new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            string str = "";
            string expected = "На уровне 1 1 вершин\nНа уровне 2 2 вершин\nНа уровне 3 4 вершин\nНа уровне 4 3 вершин\n";
            tree.Run(0, null, ref str);
            Assert.AreEqual(expected, str);
        }
    }
}
