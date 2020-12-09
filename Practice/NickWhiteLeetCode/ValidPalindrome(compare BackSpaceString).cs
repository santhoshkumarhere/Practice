using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class ValidPalindrome
    {
        public static void Test()
        {
            var str = ".,";
            var res = IsPalindrome(str);
        }

        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            var left = 0;
            var right = s.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                    left++;
                    right--;
                }

            }
            return true;
        }
    }
}
