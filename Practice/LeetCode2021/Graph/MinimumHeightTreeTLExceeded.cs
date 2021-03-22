using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.Graph
{
    public class MinimumHeightTreeTlExceeded
    {
        // Self solution  Tim limit exceeded at 66/68
        public static void Test()
        {
            var edges = new int[][] {
                new int[]{3, 0 },
                new int[]{3, 1 },
                new int[]{3, 2 },
                new int[]{3, 4 },
                new int[]{5, 4 } };

            FindMinHeightTrees(6, edges);

            var edges2 = new int[][] {
                new int[]{0, 1 } };

            FindMinHeightTrees(2, edges2);
        }


        private static IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            var graph = new Dictionary<int, List<int>>();

            for (var i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                if (edge != null)
                {
                    graph[edge[0]].Add(edge[1]);
                    graph[edge[1]].Add(edge[0]);
                }
            }

            var visited = new bool[n];
            var sortDic = new SortedDictionary<int, List<int>>();
            var res = new List<int>();
            foreach (var key in graph.Keys)
            {
                var result = DFS(key, graph, 0, 0, visited);       
                if(!sortDic.ContainsKey(result))
                {
                    sortDic[result] = new List<int>() { key };
                }
                else
                {
                    sortDic[result].Add(key);
                }

                visited = new bool[n];
            }

            var min = sortDic.Keys.FirstOrDefault();
             
            var ress =  sortDic[min];
            return ress;
        }

        private static int DFS(int key, Dictionary<int, List<int>> graph, int count, int result, bool[] visited)
        {
            visited[key] = true;

            count++;

            foreach (var adjkey in graph[key])
            {
                if (!visited[adjkey])
                {
                    var childCount = DFS(adjkey, graph, count, result, visited);
                    result = Math.Max(childCount, result);
                }
            }
            return Math.Max(count, result);
        }
    }
}
