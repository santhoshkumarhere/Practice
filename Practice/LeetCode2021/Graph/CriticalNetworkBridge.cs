using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Graph
{
    internal class CriticalNetworkBridge
    {
        static int timer = 0;

        public static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            connections.Add(new List<int>() { 0, 1});
            connections.Add(new List<int>() { 1, 2 });
            connections.Add(new List<int>() { 2, 0 });
            connections.Add(new List<int>() { 1, 3 });

            var graph = new Dictionary<int, IList<int>>();
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach(var connection in connections)
            {
                graph[connection[0]].Add(connection[1]);
                graph[connection[1]].Add(connection[0]);
            }

            var disc = new int[n];
            var low = new int[n];
            var parent = new int[n];
            var bridges = new List<IList<int>>();

            Array.Fill(disc, -1);

            for (int i = 0; i < n; i++)
            {
                if (disc[i] == -1)
                    FindBridge(i, disc, low, parent, graph, bridges);
            }
            return bridges;

         }

        private static void FindBridge(int u, int[] disc, int[] low, int[] parent,
            Dictionary<int, IList<int>> graph, IList<IList<int>> bridge)
        {
            timer++;
            disc[u] = low[u] = timer;
            foreach (var v in graph[u])
            {
                if (disc[v] == -1)
                {
                    parent[v] = u;
                    FindBridge(v, disc, low, parent, graph, bridge);
                    low[u] = Math.Min(low[u], low[v]);

                    if (low[v] > disc[u]) // bridge child can go to ancestor
                    {
                        bridge.Add(new List<int> { u, v });
                    }
                }
                else if (v != parent[u]) // ignore child to parent link
                {
                    low[u] = Math.Min(low[u], disc[v]);
                }
            }
        }
    }
}
