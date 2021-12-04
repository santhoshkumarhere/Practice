using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class MaximumProductSubArray
    {

        public static void Test()
        {
            //var nums = new[] { -1, -2, -3, 0 };
            //var result = MaxProduct2021V2(nums);

            //var nums2 = new[] { -2, 3, -4 };
            //var result2 = MaxProduct2021V2(nums2);

            //var nums4 = new[] { -2, 0, -1 };
            //var result4 = MaxProduct2021V2(nums4);

            //var nums3 = new[] { 2, -5, -2, -4, 3 };
            //var result3 = MaxProduct2021V2(nums3);

            //var nums5 = new[] { 0, 2 };
            //var result5 = MaxProduct2021V1(nums5);

            var nums5 = new[] { 2, -5, 3, 1, -4, 0, -10, 2, 8 };
            var result5 = MaxProduct2021V2(nums5);

            //Understand the power of Min_so_Far and Max_so_Far
            //The concept is same for 2021 V1 and V2. 
            //if the current element is -ve the largest element can be formed by multiplying with min_so_far. that is why we are swapping min_so_far and max_so_far
        }

        private static int MaxProduct2021V1(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var max_so_far = nums[0];
            var min_so_far = nums[0];
            var result = max_so_far;

            for(int i = 1; i < nums.Length;  i++)
            {
                var prevMaxSofar = max_so_far; // this is VERY IMPORTANT WE NEED TO MULTIPLY PREVIOUS MAX SO FAR
                max_so_far = Math.Max(nums[i], Math.Max(max_so_far * nums[i], min_so_far * nums[i]));
                min_so_far = Math.Min(nums[i], Math.Min(prevMaxSofar * nums[i], min_so_far * nums[i]));
                result = Math.Max(result, max_so_far);
            }
            return result;
        }

        private static int MaxProduct2021V2(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var max_so_far = nums[0];
            var min_so_far = nums[0];
            var result = max_so_far;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    var temp = max_so_far;
                    max_so_far = min_so_far;
                    min_so_far = temp;
                }
                max_so_far = Math.Max(nums[i], max_so_far * nums[i]);
                min_so_far = Math.Min(nums[i], min_so_far * nums[i]);
                result = Math.Max(result, max_so_far);
            }
            return result;
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
