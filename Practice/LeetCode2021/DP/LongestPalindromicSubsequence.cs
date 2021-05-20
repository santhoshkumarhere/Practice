using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class LongestPalindromicSubsequence
    {

        public static void Test()
        {
            var s = "cdde";
          
            var res = LongestPalindromeSubseq(s, 0, s.Length - 1, new int[s.Length, s.Length]);
            s = "bbb1ab";
            var res1 = LongestPalindromeSubseq(s, 0, s.Length - 1, new int[s.Length, s.Length]);
        }

        private static int LongestPalindromeSubseq(string s, int start, int end, int[,] dp)
        {
            if(start > end)
            {
                return 0;
            }

            if(start == end)
            {
                return 1;
            }

            var l1 = 0;
            var l2 = 0;
            var l3 = 0;

            if (dp[start, end] == 0)
            {
                if (s[start] == s[end])
                {
                    l1 = 2 + LongestPalindromeSubseq(s, start + 1, end - 1, dp);
                }
                l2 = LongestPalindromeSubseq(s, start + 1, end, dp);
                l3 = LongestPalindromeSubseq(s, start, end - 1, dp);

                dp[start, end] = Math.Max(l1, Math.Max(l2, l3));
            }
            return dp[start, end];
        }
    }
}
