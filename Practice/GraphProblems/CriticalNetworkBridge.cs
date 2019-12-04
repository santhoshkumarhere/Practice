using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.GraphProblems
{
    class CriticalNetworkBridge
    {
        static int time = 0;
        static Graph g;
        public static void Test()
        {
            //g = new Graph(4);
            //IList<IList<int>> connections = new List<IList<int>>();
            //connections.Add(new List<int>() { 0, 1 });
            //connections.Add(new List<int>() { 1, 2 });
            //connections.Add(new List<int>() { 2, 0 });
            //connections.Add(new List<int>() { 1, 3 });

            //foreach (var connection in connections)
            //{
            //    g.AddNeighbours(connection[0], connection[1]);
            //}
            //var result = new List<IList<int>>();
            //bridge(4);

            g = new Graph(5);
            g.AddNeighbours(1, 0);
            g.AddNeighbours(0, 2);
            g.AddNeighbours(2, 1);
            g.AddNeighbours(0, 3);
            g.AddNeighbours(3, 4);
             bridge(5);
            Console.ReadLine();

        }
        static void bridgeUtil(int u, bool[] visited, int[] disc,
                           int[] low, int[] parent)
        {

            // Mark the current node as visited 
            visited[u] = true;

            // Initialize discovery time and low value 
            disc[u] = low[u] = ++time;

            // Go through all vertices aadjacent to this 

            foreach (var v in g.Neighbours[u])
            {
                // v is current adjacent of u 

                // If v is not visited yet, then make it a child 
                // of u in DFS tree and recur for it. 
                // If v is not visited yet, then recur for it 
                if (!visited[v])
                {
                    parent[v] = u;
                    bridgeUtil(v, visited, disc, low, parent);

                    // Check if the subtree rooted with v has a 
                    // connection to one of the ancestors of u 
                    low[u] = Math.Min(low[u], low[v]);

                    // If the lowest vertex reachable from subtree 
                    // under v is below u in DFS tree, then u-v is 
                    // a bridge 
                    if (low[v] > disc[u])
                        Console.WriteLine(u + " " + v);
                }

                // Update low value of u for parent function calls. 
                else if (v != parent[u])
                    low[u] = Math.Min(low[u], disc[v]);
            } 
        }


        // DFS based function to find all bridges. It uses recursive 
        // function bridgeUtil() 
        static void bridge(int V)
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[V];
            var disc = new int[V];
            var low = new int[V];
            var parent = new int[V];


            // Initialize parent and visited, and ap(articulation point) 
            // arrays 
            for (int i = 0; i < V; i++)
            {
                parent[i] = int.MinValue;
                visited[i] = false;
            }

            // Call the recursive helper function to find Bridges 
            // in DFS tree rooted with vertex 'i' 
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    bridgeUtil(i, visited, disc, low, parent);
        }
    }
}
