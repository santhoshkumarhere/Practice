using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class PermutationPalindrome
    {

        public static void Test()
        {
            var result = HasPalindrome("MMMADAMMM");
        }
        public static bool HasPalindrome(string input)
        {
            var set = new HashSet<char>();
            foreach (var c in input)
            {
                if (set.Contains(c))
                {
                    set.Remove(c);
                }
                else
                {
                    set.Add(c);
                }
            }

            return set.Count <= 1;
        }
    }
}
