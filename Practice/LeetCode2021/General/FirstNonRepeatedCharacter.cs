using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class FirstNonRepeatedCharacter
    {
        public static void Test()
        {
            var s = FirstUniqChar("aaabcddde");
        }

        public static int FirstUniqChar(string s)
        {
            if (string.IsNullOrEmpty(s))
                return -1;

            var map = new Dictionary<char, int>();

            foreach(var c in s)
            {
                if(map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            for(var i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1)
                    return i;
            }

            return -1;
        }
    }
}
