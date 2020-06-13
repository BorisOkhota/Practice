using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task12;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Quick()
        {
            var arr = new int[] { 5, 7, 8, 6, 1, 5, 0 };
            var actual = arr;
            int a=0,b=0;
            Program.QuickSort(ref actual, 0, 6, ref a, ref b);
            Array.Sort(arr);
            Assert.AreEqual(arr, actual);
        }
        [TestMethod]
        public void Bin()
        {
            var arr = new int[] { 5, 7, 8, 6, 1, 5, 0 };
            int a = 0, b = 0;
            var actual = Program.TreeSort(arr, ref a, ref b);
            Array.Sort(arr);
            Assert.AreEqual(arr.ToString(), actual.ToString());
        }
    }
}
