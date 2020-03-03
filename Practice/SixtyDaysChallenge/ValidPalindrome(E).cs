using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class ValidPalindrome_E_
    {
        public static void Test()
        {
           var result =  IsValidPalindrome("A man, a plan, a canal: Panama");

            result = IsValidPalindrome(".,");
        }

        private static bool IsValidPalindrome(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return true;
            }

            var left = 0;
            var right = s.Length -1;

            while (left < right)
            {
               if(!char.IsLetterOrDigit(s[left]))
               { 
                    left++;
               }
               else if(!char.IsLetterOrDigit(s[right]))
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
