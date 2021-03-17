using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class LongestCommonSubsequence
    {
        private static void Test()
        {
            var s1 = "AGGTAB";
            var s2 = "GXTXAYB";
            var res = LongestCommonSubsequences(s1, s2);
        }

        private static int LongestCommonSubsequences(string text1, string text2)
        {
            var m = text1.Length;
            var n = text2.Length;

            var dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m, n];
        }
    }
}
