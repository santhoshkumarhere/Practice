using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
   public class LongestIncreasingSubsequence
    {
        public static int Test()
        {
            int[] nums = { 0, 1, 0, 3, 2, 3 };
            var result =  lengthofLIS(nums, int.MinValue, 0);
            return result;
        }

        private static  int lengthofLIS(int[] nums, int prev, int curpos)
        {
            if (curpos == nums.Length)
            {
                return 0;
            }
            int taken = 0;
            if (nums[curpos] > prev)
            {
                taken = 1 + lengthofLIS(nums, nums[curpos], curpos + 1);
            }
            int nottaken = lengthofLIS(nums, prev, curpos + 1);
            return Math.Max(taken, nottaken);
        }
    }
}
