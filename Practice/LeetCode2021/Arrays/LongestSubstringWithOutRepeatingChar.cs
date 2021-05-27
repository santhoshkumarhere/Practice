using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class LongestSubstringWithOutRepeatingChar
    {
        public static void Test()
        {
            var s = "abba";
            var res = LongestSubsTemplate(s);
        }

        private static  int LongestSubsMap(string s)
        {
            // master this logic
            var map = new Dictionary<char, int>();
            var start = 0;
            var ans = 0;
            for(int end = 0; end < s.Length; end++)
            {
                if(map.ContainsKey(s[end]))
                {
                    start = Math.Max(start, map[s[end]] + 1); // abba
                }
                map[s[end]] = end;
                ans = Math.Max(ans, end - start + 1);
            }
            return ans;
        }

        private static int LongestSubsTemplate(string s)
        {
            var map = new Dictionary<char, int>();
            int begin = 0, end = 0, ans = 0, counter = 0;

            while(end < s.Length)
            {
                var c = s[end];
                if (map.ContainsKey(c))
                {
                    map[c]++;
                    if(map[c] > 1) counter++; //duplicate, so increment counter
                }
                else
                {
                    map[c] = 1;
                }
                end++;

                while (counter > 0)
                {
                    var ch = s[begin];
                    if (map[ch] > 1) counter--;

                    map[ch]--;
                    begin++;
                }
                ans = Math.Max(ans, end - begin);
            }

            return ans;
        }

        private int LongestSubs(string s)
        {
            var set = new HashSet<char>();
            int i = 0, j = 0;
            int ans = 0;
            while( i < s.Length && j < s.Length)
            {
                if(!set.Contains(s[j]))
                {
                    set.Add(s[j]);
                    j++;
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i]);
                    i++;
                }
            }
            return ans;
        }
    }
}
