using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class DecodeWays
    {
        public static void Test()
        {
            //draw tree to figure out the answer
            var res = NumDecDP("10");

            var res1 = NumDecWays("06");

            var res2 = NumDecDP("11106");

            var res3 = NumDecDP("226");

            var res4 = NumDecDP("12");
        }

        private static int NumDecDP(string s)
        {
            var dp = new int[s.Length+1];
            dp[0] = 1;
            if (s[0] != '0')
                dp[1] = 1;

            for(int i = 2; i < dp.Length; i++) //looping wiht dp length so we are validating current string and previous string
            {
                dp[i] = s[i-1] != '0' ? dp[i - 1] : 0;
                
                var twoDigit = int.Parse(s.Substring(i - 2, 2));
                if (twoDigit >= 10 && twoDigit <=26)
                {
                    dp[i] += dp[i - 2];
                }
            }
            return dp[s.Length];
        }

        private static  int NumDecWays(string s)
        {
            var set = new HashSet<string>();
            for (int i = 1; i < 27; i++)
            {
                set.Add("" + i);
            }

            var dp = new Dictionary<(int, int), int>();
            return NumDecodings(s, 0, 0, set, dp);
        }

        private static int NumDecodings(string s, int currentIndex, int length, HashSet<string> set, Dictionary<(int, int), int> dp) 
        {
            if (length > 0)
            {
                if (dp.ContainsKey((currentIndex, length))) return dp[(currentIndex, length)];
                if (currentIndex == s.Length)
                    return 1;
                if (currentIndex == s.Length - 1 && length > 1)
                    return 0;

                var currString = s.Substring(currentIndex, length);                

                if (!set.Contains("" + currString))
                    return 0;
                currentIndex+=length;
            }
            int s1 = NumDecodings(s, currentIndex, 1, set, dp);
            dp[(currentIndex, 1)] = s1;
            int s2 = 0;
            if(currentIndex < s.Length)
                 s2 = NumDecodings(s, currentIndex, 2, set, dp);
            dp[(currentIndex, 2)] = s2;
            return s1 + s2;
        }
    }
}
