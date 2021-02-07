using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class GraphValidTree
    {
        public static void Test()
        {
            var edges11 = new int[][]
             {
                new int[]{1, 0}
             };
            var res11 = ValidTree(2, edges11);

            var edges = new int[][]
              {
                new int[]{0, 1},
                new int[]{0, 2},
                new int[]{0, 3},
                new int[]{1, 4},
              };
            var res = ValidTree(5, edges);

            var edges2 = new int[][]
            {
                new int[]{0, 1 }, 
                new int[]{1, 2 },
                new int[]{2, 3 },
                new int[]{1, 3},
                new int[] {1, 4 }
            };
            var res2 = ValidTree(5, edges2);
        }

        private static bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1) //Graph Theory - Tree should have exactly n-1 edges
                return false;

            var adjList = new Dictionary<int, List<int>>();

            for(var i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
            }

            foreach(var edge in edges)
            {
                adjList[edge[0]].Add(edge[1]);
                adjList[edge[1]].Add(edge[0]);
            }

            var seen = new HashSet<int>();

            var stack = new Stack<int>();
            stack.Push(0);
            seen.Add(0);

            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                foreach(var key in adjList[curr])
                {
                    if(!seen.Contains(key))
                    {
                        stack.Push(key);
                        seen.Add(key);
                    }
                }
            }

            DFS(0, adjList, seen);

            return seen.Count == n; // Graph Theory - it is connected if all the edges can be visited (HashSet can eliminate duplicates for undirected graph)
        }

        private static void DFS(int key, Dictionary<int, List<int>> adjList, HashSet<int> seen)
        {
            if (seen.Contains(key))
                return;

            seen.Add(key);
            foreach(var neighbor in adjList[key])
            {
                DFS(neighbor, adjList, seen);               
            }
        }

        private static bool ValidTreeIterative(int n, int[][] edges)
        {
            if (edges.Length != n - 1) //Graph Theory - Tree should have exactly n-1 edges
                return false;

            var adjList = new Dictionary<int, List<int>>();

            for (var i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adjList[edge[0]].Add(edge[1]);
                adjList[edge[1]].Add(edge[0]);
            }

            var seen = new HashSet<int>();

            var stack = new Stack<int>();
            stack.Push(0);
            seen.Add(0);

            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                foreach (var key in adjList[curr])
                {
                    if (!seen.Contains(key))
                    {
                        stack.Push(key);
                        seen.Add(key);
                    }
                }
            }

            return seen.Count == n;
        }
    }
}
