using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class ReverseString
    {
        public static void Test()
        {
            Reverse("santhosh", 0);
        }
        public static void Reverse(string s, int i)
        {
            if(i == s.Length)
            {
                return;
            }
            else
            {
                Reverse(s, i + 1);
                Console.WriteLine(s[i]);
            }
        }
    }
}
