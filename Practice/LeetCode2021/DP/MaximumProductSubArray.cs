using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class MaximumProductSubArray
    {

        public static void Test()
        {
            var nums = new[] { -1, -2, -3, 0 };
            var result = MaxProduct(nums);

            var nums2 = new[] { -2, 3, -4 };
            var result2 = MaxProduct(nums2);

            var nums4 = new[] { -2, 0, -1 };
            var result4 = MaxProduct(nums4);

            var nums3 = new[] { 2, -5, -2, -4, 3 };
            var result3 = MaxProduct(nums3);

            var nums5 = new[] { 0, 2 };
            var result5 = MaxProduct(nums5);
        }

        private static int MaxProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var leftToRight = new int[nums.Length];
            var rightToLeft = new int[nums.Length];

            leftToRight[0] = nums[0];
            rightToLeft[nums.Length - 1] = nums[nums.Length - 1];

            int currSum = int.MinValue;
            currSum = Math.Max(currSum, Math.Max(leftToRight[0], rightToLeft[nums.Length - 1]));

            for (var i = 1; i < nums.Length; i++)
            {
                leftToRight[i] = leftToRight[i - 1] == 0 ? nums[i] : nums[i] * leftToRight[i - 1];
                currSum = Math.Max(currSum,  leftToRight[i]);
            }

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                rightToLeft[i] = rightToLeft[i + 1] == 0 ? nums[i] : nums[i] * rightToLeft[i + 1];
                currSum = Math.Max(currSum, Math.Max(nums[i], rightToLeft[i]));
            }
            
            return currSum;
        }
    }
}
