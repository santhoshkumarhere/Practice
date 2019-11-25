using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    internal class ConvertString
    {
        public int Convert(string s1, string s2, int i1, int i2)
        {
            if (i1 == s1.Length)
            {
                return s2.Length - i2;
            }

            if (i2 == s2.Length)
            {
                return s1.Length - i1;
            }

            if (s1[i1] == s2[i2])
            {
                return Convert(s1, s2, i1+1, i2+1);
            }
            var insertion = 1 + Convert(s1, s2, i1 + 1, i2);
            var deletion = 1 + Convert(s1, s2, i1, i2 + 1);
            var replace = 1 + Convert(s1, s2, i1 + 1, i2 + 1);

            return Math.Min(insertion, Math.Min(deletion, replace));
        }
    }
}
