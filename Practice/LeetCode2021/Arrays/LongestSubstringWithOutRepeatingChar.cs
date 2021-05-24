using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class LongestSubstringWithOutRepeatingChar
    {
        public static void Test()
        {

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
