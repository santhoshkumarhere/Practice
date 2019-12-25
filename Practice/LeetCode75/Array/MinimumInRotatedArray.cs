using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode75.Array
{
    class MinimumInRotatedArray
    {
        public static void Test()
        {
            var x = FindMinimum(new int[] { 1, 2 });
        }

        private static int FindMinimum(int[] nums)
        {
            if (nums.Length == 1 || nums[0] < nums[nums.Length - 1])
            {
                return nums[0];
            }
            var left = 0;
            var right = nums.Length - 1;
            while(left <= right)
            {
                var mid = (left + right) / 2;

                if (nums[mid] > nums[mid + 1])
                    return nums[mid + 1];

                if (nums[mid - 1] > nums[mid])
                    return nums[mid];

                if(nums[0] < nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return 0;
        }
    }   
}
