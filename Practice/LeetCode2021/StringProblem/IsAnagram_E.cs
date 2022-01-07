using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.StringProblem
{
    public class IsAnagram_E
    {
        public static void Test()
        {
            var res = IsAnagram("anagram", "nagarm");
        }

        private static bool IsAnagram(string s, string t)
        {

            if (s.Length != t.Length)
                return false;
            var map = new int[26];
            foreach (var c in s)
            {
                map[c - 'a']++;
            }

            foreach (var c in t)
            {
                if (map[c - 'a'] == 0)
                    return false;
                map[c - 'a']--;
            }
            return true;
        }
    }
}
