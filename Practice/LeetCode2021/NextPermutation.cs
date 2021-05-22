using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class NextPermutation
    {
        //132
        //identify first decreasing number from right which is 1
        //find first number bigger than 1 from right which is 2
        //swap 2 and 1 = 231
        //reverse numbers right of 2 = 213
        public static void Test()
        {
            int[] nums = new int[] { 1, 5, 4, 3, 0 };
            NextPermute(nums);
        }

        private static void NextPermute(int[] nums)
        {
            //Find first decreasing element from right
            var i = nums.Length - 2;
            while(i >= 0 && nums[i] >= nums[i+1])
            {
                i--;
            }

            //Find first element greater than nums[i]
            if(i>=0)
            {
                var j = nums.Length - 1;
                while(nums[i] >= nums[j])
                {
                    j--;
                }
                //swap i & j
                Swap(nums, i, j);
            }
            //reverse elements next to i
            Reverse(nums, i + 1);
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private static void Reverse(int[] nums, int start)
        {
            int left = start, right = nums.Length - 1;

            while(left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }
    }
}
