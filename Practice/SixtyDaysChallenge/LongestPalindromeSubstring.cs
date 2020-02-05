using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class LongestPalindromeSubstring
    {
        public static void Test()
        {

        }

        public static bool IsPalindrome(string s)
        {
            var len = s.Length;
            for(var i=0; i < len/2; i++)
            {
                if(s[i] != s[len - i -1])
                {
                    return false;
                }
            }
            return true;
        }

        public static string LongestPalindrome(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return s;
            }

            var len = s.Length;
            int min = 0, max = 0;
            
            for(var startIndex = 0; startIndex < len; startIndex++)
            {
                for(var endIndex = len-1; endIndex > startIndex; endIndex--)
                {
                    var noOfWords = endIndex - startIndex + 1;
                    if (s[startIndex] == s[endIndex])
                    {                        
                        var isPalindrome = IsPalindrome(s.Substring(startIndex, noOfWords));
                        if(isPalindrome && noOfWords > max)
                        {
                            min = startIndex;
                            max = noOfWords;
                        }
                    }
                }
            }
            if (min == 0 && max == 0)
                return s;
            return s.Substring(min, max);
        }
    }
}
