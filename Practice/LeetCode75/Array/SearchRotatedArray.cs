using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode75
{
    class SearchRotatedArray
    {
        public static void Test()
        {
            var x = Search(new int[] {5, 1, 3}, 0);
        }

        private static int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            while(left <= right)
            {
                var mid = (left + right) / 2;
                if(nums[mid] == target)
                {
                    return mid;
                } 
                if (nums[mid] >= nums[left])
                {
                    if(target >= nums[left] &&  target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if(target <= nums[right] && target > nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}
