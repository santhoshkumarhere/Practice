using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Arrays
{
    public class RangeAddition
    {
        public static void Test()
        {
            var res = GetModifiedArray(5, new int[][]
            {
               new int[]{1, 3, 2},
               new int[]{2, 4, 3},
               new int[]{0, 2, -2}
            });
            var res1 = res;
        }

        private static int[] GetModifiedArray(int length, int[][] updates)
        {
            var arr = new int[length];

            foreach(var update in updates)
            {
                var start = update[0];
                var end = update[1];
                var incr = update[2];
                
                arr[start] += incr;        // just two lines of code for this solution        
                if(end < length - 1)
                    arr[end + 1] -= incr; // construct prefix sum so that start to end will have correct values. - means do not add incr to index after end
            }


            for (int i = 1; i < length; i++) //calculate prefix sum
            {
                arr[i] += arr[i-1];
            }
            return arr;
        }

        private static int[] GetModifiedArrayNaiveAccepted(int length, int[][] updates)
        {

            var arr = new int[length];
            var row = updates.Length;

            if (row == 0) return arr;
            var col = updates[0].Length;
            var counter = 0;
            while (counter < row)
            {
                var start = updates[counter][0];
                var end = updates[counter][1];
                var incr = updates[counter][2];

                for (int i = start; i <= end; i++)
                {
                    arr[i] += incr;
                }
                counter++;
            }
            return arr;
        }
    }
}
