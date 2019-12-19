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
            visited[u] = true;

            // Initialize discovery time and low value 
            disc[u] = low[u] = ++time;

            foreach (var v in g.Neighbours[u])
            {
                if (!visited[v])
                {
                    parent[v] = u;
                    bridgeUtil(v, visited, disc, low, parent);

                    // Check if the subtree rooted with v has a connection to one of the ancestors of u 
                    low[u] = Math.Min(low[u], low[v]);

                    // If the lowest vertex reachable from subtree under v is below u in DFS tree, then u-v is a bridge 
                    if (low[v] > disc[u])
                        Console.WriteLine(u + " " + v);
                }
                // Update low value of u for parent function calls. 
                else if (v != parent[u])
                    low[u] = Math.Min(low[u], disc[v]);
            } 
        }

        static void bridge(int V)
        {
            bool[] visited = new bool[V];
            var disc = new int[V];
            var low = new int[V];
            var parent = new int[V];

            for (int i = 0; i < V; i++)
            {
                parent[i] = int.MinValue;
            }

            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    bridgeUtil(i, visited, disc, low, parent);
        }
    }
}
