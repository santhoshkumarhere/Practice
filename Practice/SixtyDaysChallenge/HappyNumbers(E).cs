using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class HappyNumbers_E_
    {
        public static void Test()
        {
            var res = IsHappyNumber(55);
        }

        private static bool IsHappyNumber(int n)
        {
            var set = new HashSet<int>();
            var x = n;
            while ( x != 1 && !set.Contains(x))
            {
                set.Add(x);
                x = Sum(x);
            }
            return x == 1;
        }
        
        private static int Sum(int n)
        {
            var sum = 0;
            while( n > 0)
            {
                var d = n % 10;
                n = n / 10;
                sum += d * d;
            }
            return sum;
        }
    }
}



//foreach(var c in input)
//{
//    var digit = (int)Char.GetNumericValue(c);
//    count += digit * digit;
//}