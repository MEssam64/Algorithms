using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> header = null;
        private Node<T> lastNode = null;
        private int count = 0;

        public LinkedList()
        {

        }

        public LinkedList(T item)
        {
            this.header = new Node<T>(item);
            this.lastNode = this.header;
        }

        public LinkedList(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                AddLast(item);
            }
        }

        public Node<T> FindAtIndex(int index)
        {
            CheckIndex(index);

            Node<T> node = header;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public Node<T> AddAtIndex(T item, int index)
        {
            CheckIndex(index);

            Node<T> node = new Node<T>(item);
            if (index == 0)
            {
                node.Next = header;
                header = node;
                if (lastNode == null)
                    lastNode = header;
            }
            else if (index == count)
            {
                lastNode.Next = node;
                lastNode = lastNode.Next;
            }
            else
            {
                Node<T> previousNode = FindAtIndex(index - 1);
                node.Next = previousNode.Next;
                previousNode.Next = node;
            }
            count++;

            return node;
        }

        public Node<T> AddFirst(T item)
        {
            return AddAtIndex(item, 0);
        }

        public Node<T> AddLast(T item)
        {
            return AddAtIndex(item, count);
        }

        public Node<T> RemoveAtIndex(int index)
        {
            CheckIndex(index);
            if (count == 0)
                throw new Exception("List is already empty");
            if (index == count)
                throw new Exception("Index couldn't be equal to count");

            Node<T> node;
            if (index == 0)
            {
                node = header;
                header = header.Next;
            }

            else
            {
                Node<T> temp = FindAtIndex(index - 1);
                node = temp.Next;
                temp.Next = temp.Next.Next;
                if (index == count - 1)
                    lastNode = temp;
            }

            count--;
            if (count == 0)
                lastNode = header;
            return node;
        }

        public Node<T> RemoveFirst()
        {
            return RemoveAtIndex(0);
        }

        public Node<T> RemoveLast()
        {
            return RemoveAtIndex(count - 1);
        }

        private bool CheckIndex(int index)
        {
            if (index < 0)
                throw new Exception("Index couldn't be negative");
            if (index > count)
                throw new Exception("Index must be less than or equal total count");
            return true;

        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = header;
            while (node != null)
            {
                yield return node.Val;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
