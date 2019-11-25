using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Practice.MiscProb
{
    class LongestCommonSubsequence
    {
        public int Find(string s1, string s2, int i1, int i2)
        {
            var c1 = 0;
            var c2 = 0;
            var c3 = 0;

            if (i1 == s1.Length || i2 == s2.Length)
            {
                return 0;
            }
            
           //  Console.WriteLine($"{s1[i1]} = {s2[i2]}");

            if (s1[i1] == s2[i2])
            {
                c1 = 1 + Find(s1, s2, i1 + 1, i2 + 1);
            }

            c2 = Find(s1, s2, i1 + 1, i2);
            c3 = Find(s1, s2, i1, i2 + 1);
            return Math.Max(Math.Max(c1, c2), c3);
        }
    }
}
  