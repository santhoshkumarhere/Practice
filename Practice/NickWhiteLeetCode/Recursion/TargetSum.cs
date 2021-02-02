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

            FindWays(nums, S, 0, 0);
        }

        private static void FindWays(int[] nums, int S, int i, int currSum)
        {
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
    }
}
