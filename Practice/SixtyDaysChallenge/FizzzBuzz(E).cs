using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class FizzzBuzz_E_
    {
        public static void Test()
        {

        }

        public static IList<string> FizzBuzz(int n)
        {
            var list = new List<string>();
            for(var i=1; i <= n; i++)
            {
                var threeMod = i % 3;
                var fiveMod = i % 5;
                if(threeMod == 0 && fiveMod == 0)
                {
                    list.Add("FizzBuzz");
                }
                else if(fiveMod == 0)
                {
                    list.Add("Buzz");
                }
                else if( threeMod == 0)
                {
                    list.Add("Fizz");
                }
                else
                {
                    list.Add(i.ToString());
                }
            }
            return list;
        }
    }
}
