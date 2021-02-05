using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode.Graph
{
    public class NoOfConnectedCompUndirectedGraph
    {

        public static void Test()
        {
            var edges = new int[][]
            {
                new int[]{0, 1},
                new int[]{1, 2},
                new int[]{3, 4},
            };
            var res = CountComponents(5, edges);

            var edges2 = new int[][]
            {
                new int[]{0, 1},
            };
            var res2 = CountComponents(2, edges2);
        }

        private static int CountComponents(int n, int[][] edges)
        {
            var dict = new Dictionary<int, List<int>>();
            var visited = new bool[n];
            int count = 0;

            for(var i = 0; i < n; i++)
            {
                dict[i] = new List<int>();
            }

            foreach (int[] edge in edges)
            {
                dict[edge[0]].Add(edge[1]);
                dict[edge[1]].Add(edge[0]);
            }

            foreach(var key in dict.Keys)
            {
                if (!visited[key])
                {
                    //DFS(dict, key, visited);
                    DFSStack(dict, key, visited);
                    count++;
                }
            }

            return count;
        }

        private static void DFSStack(Dictionary<int, List<int>> dict, int key, bool[] visited)
        {
            var stack = new Stack<int>();
            stack.Push(key);
            visited[key] = true;

            while(stack.Count > 0)
            {
                var curr = stack.Pop();
                foreach(var neighbor in dict[curr])
                {
                    if(!visited[neighbor])
                    {
                        stack.Push(neighbor);
                        visited[neighbor] = true;
                    }
                }
            }
        }

        private static void DFS(Dictionary<int, List<int>> dict, int key, bool[] visited)
        {
            if (visited[key]) 
                return;

            visited[key] = true;
            foreach(var neighbor in dict[key])
            {
               if(!visited[neighbor])
                {
                    DFS(dict, neighbor, visited);
                }
            }
        }
    }

}
