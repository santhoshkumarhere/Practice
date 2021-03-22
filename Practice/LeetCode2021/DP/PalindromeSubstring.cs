using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class PalindromeSubstring
    {

        public static void Test()
        {
            var res1 = CountSubstrings("abc");
            var res2 = CountSubstrings("aaa");
        }

        public static int CountSubstrings(string s)
        {
            if (s == null || s.Length < 1) return 0;

            var count = 0;

            for(var i = 0; i < s.Length; i++)
            {
                count += PalindromeLength(i, i, s);
                count += PalindromeLength(i, i + 1, s);
            }

            return count;
        }

        private static int PalindromeLength(int left, int right, string s)
        {
            var count = 0;
            while(left >=0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
                count++;
            }

            return count;
        }
    }
}
