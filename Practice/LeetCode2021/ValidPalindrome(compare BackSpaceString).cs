using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class ValidPalindrome
    {
        public static void Test()
        {
            var str = ",.";
            var res = IsPalindrome(str);

            str = "racecar";
            var res1 = IsPalindrome(str);

            str = "race .,  ;' ,. a car";
            var res2 = IsPalindrome(str);


        }

        public static bool IsPalindrome(string s)
        {
            if (s == null || s.Length == 1) return true;

            int left = 0, right = s.Length - 1;

            while (left <= right)
            {
                while (left < s.Length - 1 && !char.IsLetterOrDigit(s[left])) //increment only within index
                {
                    left++;
                }

                while (right > 0 && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                //keep in mind left can go beyond right because of inner while loop
                if (left <= right && left <= s.Length - 1 && right >= 0 && (char.ToLower(s[left]) != char.ToLower(s[right])))
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
