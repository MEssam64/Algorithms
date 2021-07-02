using System.Collections.Generic;

namespace Algorithms
{
    public class Vertex<T>
    {
        public T Val { get; set; }
        public HashSet<Vertex<T>> Adjacents { get; set; }

        public bool IsVisited { get; set; }

        public Vertex(T val)
        {
            this.Val = val;
            this.Adjacents = new HashSet<Vertex<T>>();
            this.IsVisited = false;
        }

        public void AddAdjacent(Vertex<T> adjacent)
        {
            this.Adjacents.Add(adjacent);
        }

        public void RemoveAdjacent(Vertex<T> adjacent)
        {
            this.Adjacents.Remove(adjacent);
        }
    }
}