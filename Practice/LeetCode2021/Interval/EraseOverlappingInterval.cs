using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Interval
{
    internal class EraseOverlappingInterval
    {
        public static void Test()
        {
            var intervals = new int[4][]
          {
                new int[] {1, 2},
                new int[] {2, 3},
                 new int[] {3, 4},
                  new int[] {1, 3}
          };
            var c = EraseOverlappingIntervals(intervals);
        }

        private static int EraseOverlappingIntervals(int[][] intervals)
        {
            var count = 0;
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            int l = 0;
            int r = l+1;
            
            while(l < r && l < intervals.Length && r < intervals.Length)
            {
                int[] first = intervals[l];
                int[] second = intervals[r];
                if (second[1] >= first[1] && second[0] < first[1]) // overlapping 
                {
                    count++;
                    r++;
                }
                else if(second[1] <= first[1] && second[0]>= first[0]) // overlapping one inside other
                {
                    count++;
                    l = r;
                    r++;
                }
                else
                {
                    l = r; // non overlapping
                    r++;
                }
            }

            return count;
        }
    }
}
