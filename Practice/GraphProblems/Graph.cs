using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.GraphProblems
{
    public class Graph
    {
        public readonly int Vertex;
        public IList<IList<int>> Neighbours;

        public Graph(int v)
        {
            this.Vertex = v;
            Neighbours = new List<IList<int>>();

            for (var i = 0; i< Vertex; i++)
            {
                Neighbours.Add(new List<int>());
            }
        }

        public void AddNeighbours(int source, int destination)
        {
            this.Neighbours[source].Add(destination);
            this.Neighbours[destination].Add(source);
        }

        public void RemoveNeighbours(int source, int destination)
        {
            this.Neighbours[source].Remove(destination);
            this.Neighbours[destination].Remove(source);
        }
    }
}
