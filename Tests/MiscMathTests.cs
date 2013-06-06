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
    public class MiscMathTests
    {
        [TestMethod]
        public void TestNumberOfFactors()
        {
            var expected = 8;
            var actual = MiscMath.NumberOfFactors(24);

            Assert.AreEqual(expected, actual);
        }
    }
}
