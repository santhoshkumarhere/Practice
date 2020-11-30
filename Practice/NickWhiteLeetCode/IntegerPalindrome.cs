using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class IntegerPalindrome
    {
        public static void Test()
        {
            var result = IsPalindrome(1001);
        }

        private static bool IsPalindrome(int input)
        {
            if(input == 0)
            {
                return true;
            }

            if(input < 0 || input % 10 == 0)
            {
                return false;
            }

            int  rem = 0, num = input;
            while(num >= 10)
            {
                rem = (rem * 10) + num % 10;
                num = num / 10;
            }
            rem = (rem * 10) + num;

            return input == rem;
        }
    }
}
