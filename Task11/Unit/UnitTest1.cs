using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task11;

namespace Unit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<char, string> code = new Dictionary<char, string>();
            Dictionary<string, char> encode = new Dictionary<string, char>();
            var actual = Program.Code("abacaba", ref code, ref encode);
            var expected = "abacaba";
            Assert.AreEqual(expected, Program.Encode(actual,ref code,ref encode));
        }
    }
}
