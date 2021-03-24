using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Recursion
{
    public class TargetSum
    {
        public static int count = 0;

        public static void Test()
        {
            var nums = new int[] { 1, 1, 1, 1, 1 };
            FindTargetSumWays(nums, 3);
        }

        private static void FindTargetSumWays(int[] nums, int S)
        {

            // FindWays(nums, S, 0, 0);
            var memo = new Dictionary<(int, int), int>();
            var res = FindWaysMemoization(nums, S, 0, 0, memo);
        }

        private static void FindWays(int[] nums, int S, int i, int currSum)
        { //this is also passed in leetcode
            if (i == nums.Length)
            {
                if (currSum == S)
                {
                    count++;
                }
                return;
            }
            
            FindWays(nums, S, i + 1, currSum + nums[i]);
            FindWays(nums, S, i + 1, currSum - nums[i]);            
        }

        private static int FindWaysMemoization(int[] nums, int S, int i, int currSum, Dictionary<(int, int), int> memo)
        {
            if (i == nums.Length)
            {
                if (currSum == S)
                {
                    return 1;
                }
                return 0;
            }
            if(memo.ContainsKey((i, currSum)))
            {
                return memo[(i, currSum)];
            }
            int add = FindWaysMemoization(nums, S, i + 1, currSum + nums[i], memo);
            int sub = FindWaysMemoization(nums, S, i + 1, currSum - nums[i], memo);
            memo[(i, currSum)] = add + sub;

            return memo[(i, currSum)];
        }
    }
}
