using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.SlidingWindow
{
    public class LongestSubstringWithTwoDistinctChar
    {
        public static void Test()
        {
            var res3 = LengthOfLongestSubstringTwoDistinct("ccaabbb");
        }

        private static int LengthOfLongestSubstringTwoDistinct2022(string s)
        {
            int start = 0, end = 0, maxLength = 0;

            var map = new Dictionary<char, int>();

            while (end < s.Length)
            {
                if(map.ContainsKey(s[end]))
                {
                    map[s[end]]++;
                }
                else
                {
                    map[s[end]] = 1;
                }
                end++;

                if(map.Keys.Count > 2)
                {
                    while(map.Keys.Count > 2)
                    {
                        map[s[start]]--;
                        if (map[s[start]] == 0)
                            map.Remove(s[start]);
                        start++;                        
                    }
                }
                maxLength = Math.Max(maxLength, end - start);
            }
            return maxLength;
        }

        private static int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int start = 0, end = 0, maxLength = 0;

            var map = new Dictionary<char, int>();

            while (end < s.Length)
            {
                var currentChar = s[end];
                if (map.ContainsKey(currentChar))
                {
                    map[currentChar]++;
                }
                else
                {
                    map[currentChar] = 1;
                }

                while (map.Keys.Count > 2) // for k distinct problem replace 2 with k
                {
                    var beginChar = s[start];
                    map[beginChar]--;
                    if (map[beginChar] == 0)
                        map.Remove(beginChar);
                    start++;
                }
                end++;
                maxLength = Math.Max(maxLength, end - start);
            }

            return maxLength;
        }
    }
}
