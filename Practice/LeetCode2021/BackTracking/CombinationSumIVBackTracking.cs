﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.BackTracking
{
   public  class CombinationSumIVBackTracking
   {
        public static void Test()
        {
            var nums = new int[] { 1, 2, 3 };
            var res = CombinationSum4(nums, 4);
        }

        private static int CombinationSum4(int[] nums, int target)
        {
            return CombinationSum4(nums, target, new Dictionary<int, int>());
        }

        private static int CombinationSum4(int[] nums, int remaining, Dictionary<int, int> dp)
        {
            if (remaining == 0)
                return 1;
            if (dp.ContainsKey(remaining))
                return dp[remaining];

            int result = 0;

            for(var i=0; i < nums.Length; i++)
            {
                var rem = remaining - nums[i];
                if (rem >= 0)
                    result += CombinationSum4(nums, rem, dp); //memorize this pattern to return results from backtracking
            }
            dp[remaining] = result;
            return result;
        }
    }
}

//Input: nums = [1, 2, 3], target = 4
//Output: 7
//Explanation:
//The possible combination ways are:
//(1, 1, 1, 1)
//(1, 1, 2)
//(1, 2, 1)
//(1, 3)
//(2, 1, 1)
//(2, 2)
//(3, 1)
