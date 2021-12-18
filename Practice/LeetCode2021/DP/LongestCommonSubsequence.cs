using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
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

        public int Find(string s1, string s2, int i1, int i2)
        {
            var c1 = 0;
            var c2 = 0;
            var c3 = 0;

            if (i1 == s1.Length || i2 == s2.Length)
            {
                return 0;
            }

            //  Console.WriteLine($"{s1[i1]} = {s2[i2]}");

            if (s1[i1] == s2[i2])
            {
                c1 = 1 + Find(s1, s2, i1 + 1, i2 + 1);
            }

            c2 = Find(s1, s2, i1 + 1, i2);
            c3 = Find(s1, s2, i1, i2 + 1);
            return Math.Max(Math.Max(c1, c2), c3);
        }

        private static int LongestCommonSubsequenceV2(string t1, string t2)
        {
            var m = t2.Length;
            var n = t1.Length; //solve it by recursion and come here

            var dp = new int[m + 1, n + 1];

            for(int row = 1; row <= m; row++)
            {
                for(int col = 1; col <= n; col++)
                {
                    if (t1[col - 1] == t2[row - 1])
                        dp[row, col] = 1 + dp[row - 1, col - 1];
                    else
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                }
            }
            return dp[m, n];
        }
    }
}
