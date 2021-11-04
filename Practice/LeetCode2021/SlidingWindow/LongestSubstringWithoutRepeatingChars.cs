using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.SlidingWindow
{
    public class LongestSubstringWithoutRepeatingChars
    {
        public static void Test()
        {
            var s = "abba";
            var res = LongestSubsMap(s);
        }

        private static int LongestSubsMap(string s)
        {
            var map = new Dictionary<char, int>();
            int start = 0, end = 0, ans = 0;
            
            while(end < s.Length)
            {
                if(map.ContainsKey(s[end]))
                {
                    start = Math.Max(start, map[s[end]] + 1);
                }
                ans = Math.Max(ans, end - start + 1);
                map[s[end]] = end;
                end++;
            }

            return ans;
        }

    }
}
