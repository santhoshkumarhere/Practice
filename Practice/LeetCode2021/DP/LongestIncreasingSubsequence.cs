using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
   public class LongestIncreasingSubsequence
    {
        public static int Test()
        {
            int[] nums = { 0, 1, 0, 3, 2, 3 };
            var result = LengthOfLISBinarySearch(nums);// lengthofLIS(nums, int.MinValue, 0);
            return result;
        }

        private static int LengthOfLISBinarySearch(int[] nums)
        {
            int[] dp = new int[nums.Length];
            int len = 0;
            foreach (int num in nums)
            {
                int i = Array.BinarySearch(dp, 0, len, num);
                if (i < 0)
                {
                    i = -(i + 1);
                }
                dp[i] = num;
                if (i == len)
                {
                    len++;
                }
            }
            return len;
        }

        private static int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            Array.Fill(dp, 1);
            var maxLength = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]); // this is little confusing draw boxes and understand. You care only ith index in dp
                        maxLength = Math.Max(maxLength, dp[i]);
                    }
                }
            }

            return maxLength;
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
