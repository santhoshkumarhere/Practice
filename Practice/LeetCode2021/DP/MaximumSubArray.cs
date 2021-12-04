using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class MaximumSubArray
    {
        public static void Test()
        {
            var res = MaxSubArrayGreedy(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            var result = MaxSubArrayDPOrKandane(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
        }

        private static int MaxSubArrayGreedy(int[] nums)
        {
            var maxSum = nums[0];
            var max_so_far = nums[0]; //power of max_so_Far

            for (var i = 1; i < nums.Length; i++)
            {
                max_so_far = Math.Max(nums[i], max_so_far + nums[i]);
                maxSum = Math.Max(max_so_far, maxSum);
            }

            return maxSum;
        }

        private static int MaxSubArrayDPOrKandane(int[] nums)
        {
            var maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > 0)
                    nums[i] += nums[i - 1];
                maxSum = Math.Max(nums[i], maxSum);
            }
            return maxSum;
        }
    }
}
