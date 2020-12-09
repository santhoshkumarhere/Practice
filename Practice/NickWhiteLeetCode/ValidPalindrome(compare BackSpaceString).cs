using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class ValidPalindrome
    {
        public static void Test()
        {
            var str = "race .,'  .,  acar";
            var res = IsPalindrome(str);
        }

        public static bool IsPalindrome(string s)
        {
            if (s == null || s.Length == 1) return true;

            int left = 0, right = s.Length - 1;

            while (left <= right)
            {
                while (left < s.Length - 1 && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }

                while (right > 0 && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (left < s.Length - 1 && right >= 0 && (char.ToLower(s[left]) != char.ToLower(s[right])))
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }
    }
}
