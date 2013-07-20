using System;
using Lib.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ExtensionsTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestIsPalindrome()
        {
            Assert.IsTrue("9009".IsPalindrome());
            Assert.IsFalse("90".IsPalindrome());
        }

        [TestMethod]
        public void TestIsPandigital()
        {
            Assert.IsTrue("123456789".IsPandigital());
            Assert.IsTrue("987612345".IsPandigital());
            Assert.IsFalse("012345679".IsPandigital());
            Assert.IsFalse("113456789".IsPandigital());
        }

        [TestMethod]
        public void TestRotateLeft()
        {
            Assert.AreEqual("971", "197".RotateLeft());
        }
    }
}
