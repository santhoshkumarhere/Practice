using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class FindUnSortedSubArray
    {
        public static void Test()
        {
            var nums = new int[] { 2, 6, 4, 8, 10, 9, 15 };
            var res = FindUnsortedSubarray(nums);
            nums = new int[] {1,3,2,2,2};
            res = FindUnsortedSubarray(nums);
        }

        private static int FindUnsortedSubarray(int[] nums)
        {
            var stack = new Stack<int>();
            var left = nums.Length;
            var right = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                while(stack.Count > 0 && nums[stack.Peek()] > nums[i])
                {
                    left = Math.Min(left, stack.Pop());
                }
                stack.Push(i);
            }
            stack.Clear();

            for(int i = nums.Length - 1; i >= 0; i--)
            {
                while(stack.Count > 0 && nums[stack.Peek()] < nums[i])
                {
                    right = Math.Max(right, stack.Pop());
                }
                stack.Push(i);
            }
            return right - left > 0 ? right - left + 1 : 0;
        }
    }
}
