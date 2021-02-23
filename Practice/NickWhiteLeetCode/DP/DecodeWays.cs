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
            var res = NumDecWays("0");

            var res1 = NumDecWays("06");

            var res2 = NumDecWays("11106");

            var res3 = NumDecWays("226");
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
