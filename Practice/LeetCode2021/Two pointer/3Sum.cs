﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public static class _3Sum
    {
        public static void Test()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var result = ThreeSum(nums);
             nums = new int[] { -5, -3, -2, 0, 1, 2, 4, 5 };
             result = ThreeSum(nums);
        }

        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums.Length == 0 || nums.Length <= 2)
                return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i - 1] != nums[i]) //skip duplicates
                    FindTwoSum(i, nums, result);
            }

            return result;
        }

        private static void FindTwoSum(int i, int[] sortedNums, IList<IList<int>> result)
        {
            int left = i + 1, right = sortedNums.Length - 1;

            while (left < right)
            {
                var currSum = sortedNums[i] + sortedNums[left] + sortedNums[right];
                if (currSum == 0)
                {
                    result.Add(new List<int> { sortedNums[i], sortedNums[left], sortedNums[right] });

                    while (left < right && sortedNums[left] == sortedNums[left + 1]) // skip duplicates
                        left++;

                    left++;
                    right--;
                }
                else if (currSum > 0)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        private static IList<IList<int>> ThreeSumII(int[] nums)
        {
            var res = new List<IList<int>>();

            if (nums == null || nums.Length <= 2) return res;
            
            Array.Sort<int>(nums);
            
            for(var i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1])) // (1) process first record (2) skip duplicates, since we processed it already
                {
                    int left = i + 1, right = nums.Length - 1;
                    while (left < right)
                    {
                        var remainingNeeded = 0 - nums[i];
                        var sum = nums[left] + nums[right];

                        if (remainingNeeded == sum)
                        {
                            var list = new List<int>() { nums[i], nums[left], nums[right] };
                            res.Add(list);
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++; // there are no chance that any other with current left make it to zero
                            right--; // there are no chance that any other with current left make it to zero
                        }
                        else if (sum < remainingNeeded) left++;
                        else if (sum > remainingNeeded) right--;
                    }
                }
            }

            return res;
        }
    }

}