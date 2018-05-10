using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 1, y = 2, exp = 3;
            Test test = new Test();
            int abs = test.Add(x, y);
            Assert.AreEqual(exp, abs);
        }
    }
}
