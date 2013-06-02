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
    }
}
