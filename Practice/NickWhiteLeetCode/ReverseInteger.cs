using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class ReverseInteger
    {
        public static void Test()
        {
            var result =ReverseInt(-23455778);
        }

        private static int ReverseInt(int num)
        {
            int reversed = 0, rem;

            while (num != 0)
            {
                rem = num % 10;
                num /= 10;
                if(reversed > int.MaxValue/10 || reversed == int.MaxValue/10  && rem > 7)
                {
                    return 0;
                }
                if(reversed < int.MinValue/10 || reversed == int.MinValue && rem <- 8 )

                {
                    return 0;
                }
                reversed = (reversed * 10) + rem;
            }
            return reversed;
        }
    }
}
