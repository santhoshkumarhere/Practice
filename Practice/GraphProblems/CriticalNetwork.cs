using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.GraphProblems
{
    class CriticalNetwork
    {
        
        public static void Test()
        {
            var g = new Graph(4);
            IList<IList<int>> connections = new List<IList<int>>();
            connections.Add(new List<int>() { 0, 1 });
            connections.Add(new List<int>() { 1, 2 });
            connections.Add(new List<int>() { 2, 0 });
            connections.Add(new List<int>() { 1, 3 });

            foreach (var connection in connections)
            {
                g.AddNeighbours(connection[0], connection[1]);
            }
            var result = new List<IList<int>>();

            for(var i = 0; i< g.Vertex; i++)
            {
                g.RemoveNeighbours(connections[i][0], connections[i][1]);
                var count = ConnectedComponents(g);
                if(count > 1)
                {
                    result.Add(new List<int>() { connections[i][0], connections[i][1] });
                }
                g.AddNeighbours(connections[i][0], connections[i][1]);

            }
             
        }

        private static void DFS(int v, bool[] visited, Graph g)
        {
            visited[v] = true;
            Console.WriteLine(v + " ");
            foreach(var neighbour in g.Neighbours[v])
            {
                if(!visited[neighbour])
                DFS(neighbour, visited, g);
            }
        }

        private static int ConnectedComponents(Graph g)
        {
            var noOfConnectedComponents = 0;

            var visited = new bool[g.Vertex];

            for(var i =0; i < g.Vertex; i++)
            {
                if (!visited[i])
                {
                    DFS(0, visited, g);

                    noOfConnectedComponents++;
                }
            }

            return noOfConnectedComponents;
        }
    }
}
