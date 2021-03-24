using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    class LongestCommonSubstring
    {
        public static void Test()
        {
            var s1 = "OldSite:GeeksforGeeks.org";
            var s2 = "NewSite:GeeksQuiz.com";
            LCSubStr(s1, s2, s1.Length, s2.Length);
        }

        private static int LCSubStr(string s1, string s2, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            int result = 0;

            for(int row = 1; row <= m; row++)
            {
                for(int col = 1; col <= n; col++)
                {
                    if(s1[row-1] == s2[col-1])
                    {
                        dp[row, col] = dp[row - 1, col - 1] + 1;
                        result = Math.Max(result, dp[row, col]);
                    }
                }
            }
            return result;
        }
    }
}
