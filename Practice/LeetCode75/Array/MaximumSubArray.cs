using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode75.Array
{
    class MaximumSubArray
    {
        public static void Test()
        {
           var x =  FindMaximumSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4});
        }

        private static int FindMaximumSubArray(int[] nums)
        {
            var currSum = nums[0]; // to avoid arrya with {-1}
            var maxSum = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                currSum = Math.Max(nums[i], currSum + nums[i]);
                maxSum = Math.Max(currSum, maxSum);
            }
            return maxSum;
        }
    }
}
