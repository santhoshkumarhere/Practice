using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021
{
    internal class MyAtoi
    {

        public static void Test()
        {
            var res = MyAtoiRes("");
        }

        private static int MyAtoiRes(string s)
        {
            int sign = 1;
            int result = 0; 
            int len = s.Length;
            int index = 0;

            while(index < len && s[index] == ' ')
            {
                index++;
            }

            if(index < len && (s[index] == '+' || s[index] == '-'))
            {
                sign = s[index] == '-' ? - 1 : 1;
                index++;
            }
            
            while(index < len && char.IsDigit(s[index]))
             {
                if ((result > int.MaxValue / 10) ||
                        (result == int.MaxValue / 10 && (s[index] - '0') > int.MaxValue % 10))
                {
                    // If integer overflowed return 2^31-1, otherwise if underflowed return -2^31.    
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                result = result * 10 + s[index] - '0';
                index++;
            }
            
            return result *= sign;
        }


    }
}
