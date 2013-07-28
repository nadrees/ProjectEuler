using Lib.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.GraphTests
{
    [TestClass]
    public class GraphTests
    {
        private Graph<int?> graph;

        [TestInitialize]
        public void SetUp()
        {
            graph = new Graph<int?>();
        }

        [TestMethod]
        public void TestAddValue_NewValue_NoParent()
        {
            graph.AddValue(1, null);

            var headNodes = graph.GetHeadNodes();

            Assert.AreEqual(1, headNodes.Count());
            var node = headNodes.First();

            Assert.AreEqual(1, node.Value);
        }

        [TestMethod]
        public void TestAddValue_ExistingValue_NoParent()
        {
            graph.AddValue(1, null);
            graph.AddValue(1, null);

            var headNodes = graph.GetHeadNodes();

            Assert.AreEqual(1, headNodes.Count());
            var node = headNodes.First();

            Assert.AreEqual(1, node.Value);
        }

        [TestMethod]
        public void TestAddValue_NewValue_NewParent()
        {
            graph.AddValue(1, 0);

            var headNodes = graph.GetHeadNodes();

            Assert.AreEqual(1, headNodes.Count());
            var node = headNodes.First();

            Assert.AreEqual(0, node.Value);
            Assert.AreEqual(1, node.Children.Count());
            Assert.AreEqual(1, node.Children.First().Value);
        }

        [TestMethod]
        public void TestAddValue_NewValue_ExistingParent()
        {
            graph.AddValue(1, 0);
            graph.AddValue(2, 0);

            var headNodes = graph.GetHeadNodes();

            Assert.AreEqual(1, headNodes.Count());
            var node = headNodes.First();

            Assert.AreEqual(0, node.Value);
            Assert.AreEqual(2, node.Children.Count());

            var childrenValues = node.Children.Select(c => c.Value).ToList();
            foreach (var childValue in new[] { 1, 2 })
            {
                Assert.IsTrue(childrenValues.Contains(childValue));
            }
        }

        [TestMethod]
        public void TestAddValue_ExistingValue_ExistingImmediateParent()
        {
            graph.AddValue(1, 0);
            graph.AddValue(1, 0);

            var headNodes = graph.GetHeadNodes();

            Assert.AreEqual(1, headNodes.Count());
            var node = headNodes.First();

            Assert.AreEqual(0, node.Value);
            Assert.AreEqual(1, node.Children.Count());

            Assert.AreEqual(1, node.Children.First().Value);
        }

        [TestMethod]
        public void TestAddValue_ExistingValue_NewParent()
        {
            graph.AddValue(1, 0);
            graph.AddValue(1, 2);

            var headNodes = graph.GetHeadNodes();

            Assert.AreEqual(2, headNodes.Count());
            var nodeValues = headNodes.Select(n => n.Value).ToList();

            foreach (var nodeValue in new[] { 0, 2 })
                Assert.IsTrue(nodeValues.Contains(nodeValue));

            foreach (var headNode in headNodes)
            {
                Assert.AreEqual(1, headNode.Children.Count());
                Assert.AreEqual(1, headNode.Children.First().Value);
            }
        }

        [TestMethod]
        public void TestTopologicalSort()
        {
            graph.AddValue(1, 0);
            graph.AddValue(2, 0);
            graph.AddValue(2, 1);
            graph.AddValue(3, 1);
            graph.AddValue(3, 2);
            graph.AddValue(4, 3);
            graph.AddValue(5, 3);
            graph.AddValue(5, 4);
            graph.AddValue(6, 4);
            graph.AddValue(6, 5);

            var sorted = graph.TopologicalSort().ToArray();

            var expected = new[] { 0, 1, 2, 3, 4, 5, 6 };

            Assert.AreEqual(expected.Length, sorted.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], sorted[i]);

            // check for graph state modification
            var headNodes = graph.GetHeadNodes();
            Assert.AreEqual(1, headNodes.Count());
            Assert.AreEqual(0, headNodes.First().Value);

            Assert.AreEqual(2, headNodes.First().Children.Count());
        }
    }
}
