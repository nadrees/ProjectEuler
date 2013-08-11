using System;
using System.Linq;
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

        [TestMethod]
        public void TestGeneratePermutations()
        {
            var expected = new[] { "012", "021", "102", "120", "201", "210" };
            var actual = "012".GeneratePermutations().ToList();

            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var permutation in actual)
                Assert.IsTrue(expected.Contains(permutation));
        }

        [TestMethod]
        public void TestGetAlphabetScore()
        {
            var expected = 53;
            var actual = "COLIN".GetAlphabetScore();
            Assert.AreEqual(expected, actual);

            expected = 55;
            actual = "SKY".GetAlphabetScore();
            Assert.AreEqual(expected, actual);
        }
    }
}
