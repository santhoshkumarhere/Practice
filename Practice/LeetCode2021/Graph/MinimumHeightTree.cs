using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.Graph
{
    public class MinimumHeightTree
    {
        // Self solution  Tim limit exceeded at 66/68
        public static void Test()
        {
            var edg = new int[][]
            {
               new int[]{ 0, 1 },new int[]{ 0, 2 }, new int[] { 0, 3 },new int[]{ 3, 4 },new int[]{ 4, 5 }
            };
            var res = FindMinHeightTrees(6, edg);
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
            // base cases
            if (n < 2)
            {
                var centroids = new List<int>();
                for (int i = 0; i < n; i++)
                    centroids.Add(i);
                return centroids;
            }

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

            var leaves = new List<int>();

            foreach(var key in graph.Keys)
            {
                if(graph[key].Count == 1)
                {
                    leaves.Add(key);
                }
            }

            while(n > 2)
            {
                n = n - leaves.Count;
                var newLeaves = new List<int>();
                foreach(var i in leaves)
                {
                    var parent = graph[i].FirstOrDefault(); //parent contains the leaf
                    graph[parent].Remove(i);

                    if (graph[parent].Count == 1)
                        newLeaves.Add(parent);
                }
                leaves = newLeaves;
            }

            return leaves;
        }
    }
}
