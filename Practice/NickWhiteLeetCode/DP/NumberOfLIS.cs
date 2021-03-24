using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
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
            for (int i = 0; i < n; i++)
            {
                len[i] = cnt[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (len[i] == len[j] + 1) cnt[i] += cnt[j];
                        if (len[i] < len[j] + 1)
                        {
                            len[i] = len[j] + 1;
                            cnt[i] = cnt[j];
                        }
                    }
                }
                if (max_len == len[i]) res += cnt[i];
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
