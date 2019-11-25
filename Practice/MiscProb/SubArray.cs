using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class SubArray
    {
        public static void Test()
        {
            var res = MaxSubArray(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4, 3, 4, 5});
        }

        public static int MaxSubArray(int[] arr)
        {
            int maxSum = arr[0];
            var runningSum = arr[0];

            for(var i = 1; i < arr.Length; i++)
            {
                var tempRunningSum = runningSum + arr[i];

                if (arr[i] > tempRunningSum)
                {
                    runningSum = arr[i];
                }
                else
                {
                    runningSum = tempRunningSum;
                }
    

                maxSum = Math.Max(maxSum, runningSum);

            }

            return maxSum;
        }

        public static int MaxSubArray(int[] arr, int o)
        {
            int max_end = 0;
            int max_sofar = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                max_end = max_end + arr[i];
                max_sofar = Math.Max(max_end, max_sofar);

                if (max_end < 0)
                {
                    max_end = 0;
                }
            }
            return max_sofar; 
        } 
    }
}
