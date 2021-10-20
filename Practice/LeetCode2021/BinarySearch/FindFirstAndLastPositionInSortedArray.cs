using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.BinarySearch
{
    public class FindFirstAndLastPositionInSortedArray
    {

        public static void Test()
        {
            var nums =  new int[] { 5, 7, 7, 8, 8, 10 };
            var target = 6;
            var res1 = SearchRange(nums, target);
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            var result = new int[2];
            
            result[0] = GetFirstPosition(nums, target);
            
            if (result[0] == -1)
            {
                result[1] = -1; // no need to do right most search
                return result;
            }
            
            result[1] = GetLastPosition(nums, target);  
            return result;
        }

        private static int GetFirstPosition(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            var ans = -1;

            while(left <= right)
            {
                var middle = left + (right - left) / 2;
                if(nums[middle] == target)
                {
                    ans = middle;
                    right = middle - 1;
                }
                else if(nums[middle] < target)
                {
                    left = middle + 1;
                }
                else if(nums[middle]  > target)
                {
                    right = middle - 1;
                }
            }
            return ans;
        }


        // This method is very similar to GetFirstPosition, so we can merge both methods
        private static int GetLastPosition(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            var ans = -1;

            while (left <= right)
            {
                var middle = left + (right - left) / 2;
                if (nums[middle] == target)
                {
                    ans = middle;
                    left = middle + 1;
                }
                else if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                else if (nums[middle] > target)
                {
                    right = middle - 1;
                }
            }
            return ans;
        }
    }
}
