using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class ConvertAStringToAnother_Recursion_
    {
        public static void Test()
        {
            var res = FindMinOperationsDP(new int[6+1, 6+1],"table", "tbres", 0, 0);
            var res1 = FindMinOperations( "table", "tbres", 0, 0);
        }

        private static int FindMinOperations(string s1, string s2, int i1, int i2)
        {
            if (i1 == s1.Length) // if we have reached the end of s1, then insert all the remaining characters of s2
                return s2.Length - i2;

            if (i2 == s2.Length) // if we have reached the end of s2, then delete all the remaining characters of s1
                return s1.Length - i1;

            if (s1[i1] == s2[i2])
            {
                return FindMinOperations(s1, s2, i1 + 1, i2 + 1);
            }

            var ins = 1 + FindMinOperations(s1, s2, i1 + 1, i2);
            var del = 1 + FindMinOperations(s1, s2, i1, i2 + 1);            
            var upd = 1 + FindMinOperations(s1, s2, i1 + 1, i2 + 1);
            
            return Math.Min(del, Math.Min(ins, upd));
        }

        private static int FindMinOperationsDP(int[,] dp, string s1, string s2, int i1, int i2)
        {
            if (i1 == s1.Length) // if we have reached the end of s1, then insert all the remaining characters of s2
            {
                dp[i1, i2] = s2.Length - i2;
                return dp[i1, i2];
            }

            if (i2 == s2.Length) // if we have reached the end of s2, then delete all the remaining characters of s1
            {
                dp[i1, i2] = s1.Length - i1;
                return dp[i1, i2];
            }

            if (s1[i1] == s2[i2])
            {
                dp[i1, i2] = FindMinOperationsDP(dp, s1, s2, i1 + 1, i2 + 1);
                return dp[i1, i2];
            }

            var ins = 1 + FindMinOperationsDP(dp, s1, s2, i1 + 1, i2);
            var del = 1 + FindMinOperationsDP(dp, s1, s2, i1, i2 + 1);
            var upd = 1 + FindMinOperationsDP(dp, s1, s2, i1 + 1, i2 + 1);

            dp[i1, i2] = Math.Min(del, Math.Min(ins, upd));

            return dp[i1 ,i2];
        }
    }
}
