using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class LongestContinuousSubsequence
    {
        public static void Test()
        {
            var nums = new int[] { 100, 4, 200, 1, 3, 2 }; // and = 4
            var result = LongestConsecutiveV2(nums);
        }

        private static int LongestConsecutiveV2(int[] nums)
        {
            var set = new HashSet<int>(nums);

            var longestSequence = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (!set.Contains(nums[i] - 1)) // it will improve time complexity of this problem
                {
                    var currentSequenceLength = 1;
                    var next = nums[i] + 1;
                    while (set.Contains(next))
                    {
                        next++;
                        currentSequenceLength++;
                    }
                    longestSequence = Math.Max(longestSequence, currentSequenceLength);
                }
            }

            return longestSequence;
        }

        private static int LongestConsecutive(int[] nums)
        {

            var set = new HashSet<int>(nums);

            var longestSequence = 0;

            foreach (var num in nums)
            {
                if (set.Contains(num - 1))
                    continue;
                var next = num + 1;

                var currentSequenceLength = 1;

                while (set.Contains(next))
                {
                    next++;
                    currentSequenceLength++;
                }
                longestSequence = Math.Max(longestSequence, currentSequenceLength);
            }
            return longestSequence;
        }
    }
}
