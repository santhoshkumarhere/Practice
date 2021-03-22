using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Graph
{
    public class DetectCycleUndirectedGraph
    {

        public static void Test()
        {
           var edges = new int[][]{
               new int[] { 1, 0 },
            new int[] { 0, 2},
            new int[] {2, 1},
            new int[] {0, 3},
            new int[] {3, 4}
           };

            var result = FindCycle(edges, 5);
        }

        public static bool FindCycle(int[][] edges, int n)
        {
            var graph = new Dictionary<int, List<int>>();
            var visited = new bool[n];

            for(var i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach(var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            foreach(var key in graph.Keys)
            {
                if(!visited[key])
                {
                    if(IsCyclic(key, graph, visited, -1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsCyclic(int key, Dictionary<int, List<int>> graph, bool[] visited, int parent)
        {
            visited[key] = true;

            foreach(var adjKey in graph[key])
            {
                if(!visited[adjKey])
                {
                    if(IsCyclic(adjKey, graph, visited, key))
                        return true;
                }
                else{
                    if (key != parent)
                        return true;
                }
            }
            return false;
        }
    }
}
