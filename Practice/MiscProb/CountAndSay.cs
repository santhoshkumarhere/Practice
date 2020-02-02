using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class CountAndSay
    {
        public static void Test()
        {
            var result = CountAndSa(6);
        }

        public static string CountAndSa(int n)
        {
            var res = "1"; 
            for(var i = 2; i <= n; i++)
            {
                res = Find(res);
            }
            return res;
        }

        public static string Find(string s)
        {
            var result = string.Empty;
            var frequency = 1;

            for(var i=1; i < s.Length; i++)
            {
                if( s[i-1] != s[i])
                {
                    result = result + frequency.ToString() + s[i - 1];
                    frequency = 1;
                }
                else
                {
                    frequency++;
                }
            }
            return result = result + frequency.ToString() + s[s.Length - 1];
        }
    }
}
