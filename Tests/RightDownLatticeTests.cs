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
    public class RightDownLatticeTests
    {
        private RightDownLattice lattice;

        [TestInitialize]
        public void SetUp()
        {
            lattice = new RightDownLattice(2, 2);
        }

        [TestMethod]
        public void TestCountPaths()
        {
            var expected = 6;

            var numPaths = lattice.CountPaths(2, 2);

            Assert.AreEqual(expected, numPaths);
        }
    }
}
