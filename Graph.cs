using System.Collections.Generic;

namespace Algorithms
{
    public class Graph<T>
    {
        public Dictionary<T, Vertex<T>> Vertices { get; set; }
        private readonly bool IsUnDirected;

        public Graph(bool isUnDirected)
        {
            this.IsUnDirected = isUnDirected;
            Vertices = new Dictionary<T, Vertex<T>>();
        }

        public Vertex<T> AddVertex(T value)
        {
            Vertex<T> vertex = new Vertex<T>(value);
            this.Vertices.Add(value, vertex);
            return vertex;
        }

        public Vertex<T> RemoveVertex(Vertex<T> vertex)
        {
            foreach (Vertex<T> v in Vertices.Values)
            {
                if (v.Adjacents.Contains(vertex))
                {
                    v.Adjacents.Remove(vertex);
                }
            }

            Vertices.Remove(vertex.Val);
            return vertex;
        }

        public void AddEdge(Vertex<T> u, Vertex<T> v)
        {
            u.AddAdjacent(v);
            if (IsUnDirected)
            {
                v.AddAdjacent(u);
            }
        }

        public void RemoveEdge(Vertex<T> u, Vertex<T> v)
        {
            u.RemoveAdjacent(v);
            if (IsUnDirected)
            {
                v.RemoveAdjacent(u);
            }
        }
    }
}