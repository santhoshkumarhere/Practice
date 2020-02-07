using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class LongestSubsWithNonRepeatingChar_M_
    {
        public static void Test()
        {
            var res = Calculate("abcabcbad");
            res = lengthOfLongestSubstring("abcabcbad");
        }

        private static int Calculate(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return 0;
            }
            var currStr = string.Empty;
            var maxCount = 0;

            foreach(var c in s)
            {
                if(currStr.Contains(c))
                {
                    maxCount = Math.Max(maxCount, currStr.Length);
                    currStr = currStr.Substring(currStr.IndexOf(c) + 1);
                }
                currStr += c;
            }
            return Math.Max(maxCount, currStr.Length);
        }

        private static int lengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            var set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }
    }
}
