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
    public class NodeTests
    {
        [TestMethod]
        public void TestValue()
        {
            var node = new Node<int>(1);

            Assert.AreEqual(1, node.Value);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            var node = new Node<int>(1);

            Assert.AreEqual(1.GetHashCode(), node.GetHashCode());
        }

        [TestMethod]
        public void TestAreEqual()
        {
            var node = new Node<int>(1);

            Assert.IsFalse(node.Equals(null));
            Assert.IsFalse(node.Equals(1));

            Assert.IsTrue(node.Equals(node));
            Assert.IsTrue(node.Equals(new Node<int>(1)));

            Assert.IsFalse(node.Equals(new Node<int>(2)));
        }

        [TestMethod]
        public void TestAddChild()
        {
            var parent = new Node<int>(0);
            var child = new Node<int>(1);

            parent.AddChild(child);

            Assert.AreEqual(1, parent.Children.Count());
            Assert.AreEqual(child, parent.Children.First());
            Assert.AreEqual(1, child.Parents.Count());
            Assert.AreEqual(parent, child.Parents.First());
        }

        [TestMethod]
        public void TestAddParent()
        {
            var parent = new Node<int>(0);
            var child = new Node<int>(1);

            child.AddParent(parent);

            Assert.AreEqual(1, parent.Children.Count());
            Assert.AreEqual(child, parent.Children.First());
            Assert.AreEqual(1, child.Parents.Count());
            Assert.AreEqual(parent, child.Parents.First());
        }

        [TestMethod]
        public void TestRemoveChild()
        {
            var parent = new Node<int>(0);
            var child = new Node<int>(1);
            parent.AddChild(child);
            parent.AddChild(new Node<int>(2));

            parent.RemoveChild(child);

            Assert.AreEqual(1, parent.Children.Count());
            Assert.AreEqual(0, child.Parents.Count());
        }

        [TestMethod]
        public void TestRemoveParent()
        {
            var parent = new Node<int>(0);
            var child = new Node<int>(1);
            parent.AddChild(child);
            parent.AddChild(new Node<int>(2));

            child.RemoveParent(parent);

            Assert.AreEqual(1, parent.Children.Count());
            Assert.AreEqual(0, child.Parents.Count());
        }
    }
}
