using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DSA
{
    public class UnionFindDetectCycle
    {
        public static void Test()
        {
            var graph = new int[][]
            {
                new int[]{0, 1},
                new int[]{1, 2},
                new int[]{0, 2}
            };
            var res = FindCycle(graph);
        }

        private static bool FindCycle(int[][] graph)
        {
            var ds = new int[graph.Length];

            Array.Fill(ds, -1);

            for(int i = 0; i < graph.Length; i++) // take each pair one by one
            {
                int x = Find(ds, graph[i][0]);
                int y = Find(ds, graph[i][1]);

                if (x == y)
                    return true; //cycle exists

                Union(ds, x, y);
            }
            return false;
        }

        private static int Find(int[] ds, int index)
        {
            if(ds[index] == -1)
            {
                return index;
            }

            return Find(ds, ds[index]);
        }

        private static void Union(int[] ds, int index, int parent)
        {
            ds[index] = parent;
        }
    }
}
//Parent -> 1 2 -1
//nodes  -> 0 1  2
// 0 and 1 points to same parent 2