using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class MergeIntervals_M_
    {

        public static void Test()
        {
            var input = new int[][]{ new int[]{ 1, 3 }, new int[] { 2, 8 }, new int[] { 8, 10}, new int[] { 15, 18}};
            var res = Merge(input);

            input = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            res = Merge(input);

            input = new int[][] { new int[] { 1, 4 }, new int[] { 0, 4 } };
            res = Merge(input);
            input = new int[][] { new int[] { 1, 4 }, new int[] { 2, 3 } };
            res = Merge(input);
        }

        private static int[][] Merge(int[][] intervals)
        {
            var res = new List<int[]> {};

            if (intervals.Length == 0 || intervals.Length == 1)
                return intervals;
                   
            Array.Sort(intervals, (x, y) => Comparer<int>.Default.Compare(x[0], y[0]));

            var prevStart = intervals[0][0];
            var prevEnd = intervals[0][1];

            for (var i=1; i < intervals.Length; i++)
            {
                var current = intervals[i];
                if(prevEnd >= current[0])
                {
                    prevEnd = Math.Max(prevEnd, current[1]);                   
                }
                else
                {
                    res.Add(new int[] { prevStart, prevEnd });
                    prevStart = current[0];
                    prevEnd = current[1];
                }
                if (i == intervals.Length - 1)
                {
                    res.Add(new int[] { prevStart, prevEnd });
                }
            }

            return res.ToArray();
        }
    }
}
