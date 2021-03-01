using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.NickWhiteLeetCode.DP
{
    public class PartitionEqualSubSetSum
    {
        public static void Test()
        {
            var nums = new int[] { 1, 5, 11, 5 };

            var totalSum = nums.Sum();

            if (totalSum % 2 > 0)
                return;

            var subset = totalSum / 2;
            var memo = new Dictionary<(int, int), bool>();
            var res = DFS(subset, 0, nums, memo);
        }

        private static bool DFS(int remaining, int start, int[] nums, Dictionary<(int, int), bool> memo)
        {
            if (remaining == 0)
                return true;

            if (memo.ContainsKey((start, remaining)))
                return memo[(start, remaining)];

            for (var i = start; i < nums.Length; i++)
            {
                if (remaining - nums[i] >= 0)
                {
                    if (DFS(remaining - nums[i], i + 1, nums, memo))
                    {
                        return true;
                    }
                }
            }
            memo[(start, remaining)] = false;
            return false;
        }
    }
}
