using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Graph
{
    public class Graph<T>
    {
        private HashSet<Node<T>> headNodes = new HashSet<Node<T>>();

        public void AddValue(T value, T parent)
        {
            var existingNode = Find(value);

            if (existingNode == null)
            {
                if (parent == null)
                    headNodes.Add(new Node<T>(value));
                else
                {
                    var parentNode = Find(parent);
                    if (parentNode == null)
                    {
                        parentNode = new Node<T>(parent);
                        headNodes.Add(parentNode);
                    }

                    var node = new Node<T>(value);
                    node.AddParent(parentNode);
                }
            }
            else
            {
                if (parent != null)
                {
                    var parentNode = Find(parent);
                    if (parentNode == null)
                    {
                        parentNode = new Node<T>(parent);
                        headNodes.Add(parentNode);
                    }

                    parentNode.AddChild(existingNode);
                    if (headNodes.Contains(existingNode))
                        headNodes.Remove(existingNode);
                }
            }
        }

        public IEnumerable<Node<T>> GetHeadNodes()
        {
            return headNodes;
        }

        public IEnumerable<T> TopologicalSort()
        {
            // peform deep copy to preserve current graph
            var graph = new Graph<T>();
            var queue = new Queue<Node<T>>(headNodes);
            var visitedValues = new HashSet<T>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visitedValues.Add(node.Value);
                if (node.Parents.Count() > 0)
                {
                    foreach (var parent in node.Parents)
                        graph.AddValue(node.Value, parent.Value);
                }
                else
                    graph.AddValue(node.Value, default(T));

                // check for visited values to prevent cycles
                foreach (var child in node.Children.Where(c => !visitedValues.Contains(c.Value)))
                    queue.Enqueue(child);
            }

            return TopologicalSort(graph);
        }

        private IEnumerable<T> TopologicalSort(Graph<T> graph)
        {
            var nodeQueue = new Queue<Node<T>>(graph.headNodes);

            while (nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();
                yield return node.Value;

                foreach (var child in node.Children.ToArray())
                {
                    node.RemoveChild(child);
                    if (child.Parents.Count() == 0)
                        nodeQueue.Enqueue(child);
                }
            }
        }

        private Node<T> Find(T value)
        {
            foreach (var node in headNodes)
            {
                var result = WalkGraph(value, node);
                if (result != null)
                    return result;
            }
            return null;
        }

        private Node<T> WalkGraph(T value, Node<T> node)
        {
            if (node.Value.Equals(value))
                return node;

            foreach (var child in node.Children)
            {
                var result = WalkGraph(value, child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
