using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Graph
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public IEnumerable<Node<T>> Parents { get { return parents; } }
        public IEnumerable<Node<T>> Children { get { return children; } }

        private HashSet<Node<T>> parents = new HashSet<Node<T>>();
        private HashSet<Node<T>> children = new HashSet<Node<T>>();

        public Node(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            Value = value;
        }

        public void AddChild(Node<T> child)
        {
            if (!children.Contains(child))
            {
                children.Add(child);
                child.AddParent(this);
            }
        }

        public void RemoveChild(Node<T> child)
        {
            if (children.Contains(child))
            {
                children.Remove(child);
                child.RemoveParent(this);
            }
        }

        public void AddParent(Node<T> parent)
        {
            if (!parents.Contains(parent))
            {
                parents.Add(parent);
                parent.AddChild(this);
            }
        }

        public void RemoveParent(Node<T> parent)
        {
            if (parents.Contains(parent))
            {
                parents.Remove(parent);
                parent.RemoveChild(this);
            }
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj == this)
                return true;
            else if (!(obj is Node<T>))
                return false;

            var other = (Node<T>)obj;

            return this.Value.Equals(other.Value);
        }
    }
}
