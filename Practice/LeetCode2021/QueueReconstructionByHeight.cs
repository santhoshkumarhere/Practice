using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class QueueReconstructionByHeight
    {
        public static void Test()
        {
            var people = new int[][]
            {
                new int[]{7, 0},
                new int[]{4, 4},
                new int[]{7, 1},
                new int[]{5, 0},
                new int[]{6, 1},
                new int[]{5, 2},
            };
            var res = ReconstructQueue(people);
        }

        private static int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, (a, b) => a[0] == b[0] 
                    ? a[1] - b[1] //asc
                    : b[0] - a[0]); //desc

            
            var output = new List<int[]>();
            foreach (int[] p in people)
            {
                output.Insert(p[1], p); //it will automatically do the adjustment
            } 
            return output.ToArray();
        }
    }
}
