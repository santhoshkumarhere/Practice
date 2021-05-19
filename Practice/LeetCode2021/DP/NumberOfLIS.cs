using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class NumberOfLIS
    {
        public static void Test()
        {
            //var tes = FindNumberOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            var test1 = FindNumberOfLIS(new int[] { 1, 3, 5, 4, 7 });
            var test2 = FindNumberOfLIS(new int[] { 2, 2, 2, 2, 2 });
        }

        private static int FindNumberOfLIS(int[] nums)
        {
            int n = nums.Length, res = 0, max_len = 0;
            int[] len = new int[n], cnt = new int[n];
            Array.Fill(len, 1);
            Array.Fill(cnt, 1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (len[i] == len[j] + 1)
                        {
                            cnt[i] += cnt[j]; // it is the second time we get same length with the current element, so just increment the count
                        }
                        else if (len[i] < len[j] + 1)
                        {
                            len[i] = len[j] + 1; //we are getting maximum length here, so increment length
                            cnt[i] = cnt[j];
                        }
                    }
                }
                if (max_len == len[i])
                {
                    res += cnt[i]; //if current length greater than previous max length, then increment count
                }
                if (max_len < len[i])
                {
                    max_len = len[i];
                    res = cnt[i];
                }
            }
            return res;
        }
    }
}
