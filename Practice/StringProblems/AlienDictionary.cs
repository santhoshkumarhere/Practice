using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.StringProblems
{
    class AlienDictionary
    {
        public static void Test()
        {
            var x = IsAlienSorted(new string[]{ "wwid", "word", "row" }, "worldabcefghijkmnpqstuvxyz");

        }

        private static bool IsSmaller(string str1, string str2, int[] ord)
        {
            var l = Math.Min(str1.Length, str2.Length);

            for (int i = 0; i < l; i++)
            {
                if (str1[i] == str2[i])
                {
                    continue;
                }

                return ord[str1[i] - 'a'] <= ord[str2[i] - 'a'];
            }

            return str1.Length <= str2.Length;
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            int[] ord = new int[26];
            for (int i = 0; i < 26; i++)
            {
                ord[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!IsSmaller(words[i], words[i + 1], ord))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
