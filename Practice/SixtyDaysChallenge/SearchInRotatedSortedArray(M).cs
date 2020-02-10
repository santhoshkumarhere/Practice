using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class SearchInRotatedSortedArray_M_
    {
        public static void Test()
        {
            var nums = new int[]{ 4, 5, 6, 7, 0, 1, 2 };
            var target = 0;
            var res = Search(nums, target);
             res = Search(new int[] { 5, 1, 2, 3, 4 }, 1);
        }

        private static int Search(int[] nums, int target)
        {
            if(nums.Length == 0) { return -1; }

            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] >= nums[left])
                {
                    if (target >= nums[left] && target < nums[mid])
                      right = mid - 1; 
                    else
                      left = mid + 1; 
                }
                else
                {
                    if (target > nums[mid] && target <= nums[right])
                      left = mid + 1; 
                    else
                      right = mid - 1; 
                }
            }
            return -1;
        }
    }
}
