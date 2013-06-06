using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class CollatzTests
    {
        [TestMethod]
        public void TestCollatzChainLengthOf()
        {
            var answer = new Collatz().CollatzChainLengthOf(13);
            var expected = 10;

            Assert.AreEqual(expected, answer);
        }
    }
}
