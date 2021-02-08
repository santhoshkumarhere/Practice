using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class DetectCycleDirectedGraph
    {
        public static void Test()
        {
            var edges = new int[][]{
               new int[] { 0, 1},
            new int[] { 0, 2},
            new int[] {1, 2},
            new int[] {2, 0},
            new int[] {2, 3},
            new int[] {3, 3}
           };

            var result = FindCycle(edges, 6);
        }

        public static bool FindCycle(int[][] edges, int n)
        {
            var graph = new Dictionary<int, List<int>>();
            var visited = new bool[n];
            var currentStack = new bool[n];

            for (var i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
            }

            foreach (var key in graph.Keys)
            {
                if (!visited[key])
                {
                    if (IsCyclic(key, graph, visited, currentStack))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool IsCyclic(int key, Dictionary<int, List<int>> graph, bool[] visited, bool[] currentStack)
        {
            if (currentStack[key]) //imagine the recursion tree and you should not see the parent in the child tree 
                return true;
            
            if (visited[key])
                return false;

            currentStack[key] = true;
            visited[key] = true;

            foreach(var adjKey in graph[key])
            {
                if (IsCyclic(adjKey, graph, visited, currentStack))
                    return true;
            }
            currentStack[key] = false; //remove the key as it is no more in current stack
            return false;
        }
    }
}
