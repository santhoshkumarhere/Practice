using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.BinarySearch
{
    public class FindNumberOfNegativeElements
    {
        public static void Test()
        {
            var nums = new int[] { -20, -18, -17, -4, -3, -2, -1, 0, 5, 7, 9, 23, 45 };
            var count = Find(nums);
        }

        private static int Find(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;

            while(left < right)
            {
                var mid = (left + right) / 2;

                if (nums[mid] < 0)
                {
                    left = mid + 1; // -ve numbers will be in left side so move to left side
                }
                else
                {
                    right = mid;
                }

                //if(nums[mid] >=0 )
                //{
                //    right = mid; // -ve numbers will be in left side so move to left side
                //}
                //else
                //{
                //    left = mid + 1;
                //}
            }
            return left;
        }
    }
}
