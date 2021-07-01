using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Node<T>
    {
        public T Val { get; set; }
        public Node<T> Next { get; set; }

        public Node(T val, Node<T> next)
        {
            Val = val;
            Next = next;
        }

        public Node(T val) : this(val, null) { }
    }
}
