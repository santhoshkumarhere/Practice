using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    class LongestPalindromicSubstring
    {
        public static void Test()
        {
           var res= LongestPalindrome("babad");
            var res1 = LongestPalindrome("racecar");
            var res2 = LongestPalindrome("aabbab");
        }

        private static string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0, maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(i);
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > maxLen) // if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    maxLen = Math.Max(maxLen, len); //end = i + len / 2;
                }
            }
            return s.Substring(start, maxLen);
        }
        private static int expandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }
    }
}
