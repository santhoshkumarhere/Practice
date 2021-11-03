using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.SlidingWindow
{
    public class FindAllAnagramsSlidingWindow
    {
        public static void Test()
        {
            var result = FindAnagrams("cbaebabacd", "abc");
        }

        private static IList<int> FindAnagrams(string s, string p)
        {
            var res = new List<int>();
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || s.Length < p.Length)
                return res;

            var pHash = new int[26];

            foreach (var c in p)
            {
                pHash[c - 'a']++;
            }

            int begin = 0, end = 0, counter = p.Length;

            while (end < s.Length)
            {
                var endChar = s[end] - 'a';

                if (pHash[endChar] > 0)
                    counter--;
                pHash[endChar]--;
                end++;

                while (counter == 0)
                {
                    var beginChar = s[begin] - 'a';
                    if ( end - begin == p.Length)
                        res.Add(begin);

                    pHash[beginChar]++;

                    if (pHash[beginChar] > 0)
                        counter++;

                    begin++;
                }
            }

            return res;
        }
    }
}
