using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Interval
{
    internal class IntervalListIntersection
    {
        public static void Test()
        {
            // draw lines and understand the logic its v ery easy
            var firstList = new int[4][]
            {
                new int[] {0, 2},
                new int[] {5, 10},
                 new int[] {13,  23},
                  new int[] {24, 25}
            };

           var secondList = new int[4][]
           {
                new int[] {1, 5},
                new int[] {8, 12},
                 new int[] {15, 24},
                  new int[] {25, 26}
           };

            var result = IntervalIntersection2022(firstList, secondList); // O/P => [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
        }                                        
        private static int[][] IntervalIntersection2022(int[][] l1, int[][] l2)
        {
            var p1 = 0;
            var p2 = 0;

            var result = new List<int[]>();

            while (p1 < l1.Length && p2 < l2.Length)
            {

                if (l1[p1][1] >= l2[p2][0] && l2[p2][1] >= l1[p1][0]) // intersection exists if E1 >= S2 && E2 >= S1
                {
                    result.Add(new int[] { Math.Max(l1[p1][0], l2[p2][0]), Math.Min(l1[p1][1], l2[p2][1]) }); // Max(S1, S2), Min(E1, E2)
                }

                if (l1[p1][1] > l2[p2][1]) // only the list with higher end time will stay
                {
                    p2++;
                }
                else
                {
                    p1++;
                }
            }
            return result.ToArray();
        }
    }
}
