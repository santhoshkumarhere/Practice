using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class CombinationIV
    {
        public static void Test()
        {
            var nums = new int[] { 1, 2, 3 };
            var res = CombinationSum4(nums, 4);
        }

        private static int CombinationSum4(int[] nums, int target)
        {
            var dp = new int[target + 1];

            dp[0] = 1;

            for(var i = 1; i <= target; i++)
            {
                var count = 0;
                foreach(var num in nums) //nums sort order does n't matter as for every target, we loop through all a values in nums
                {
                    if(num <= i)
                    {
                        count += dp[i - num];
                    }
                }
                dp[i] = count;
            }
            return dp[target];
        }
    }
}
