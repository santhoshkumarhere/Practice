using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.SlidingWindow
{
    public class FindAllAnagramsSlidingWindow
    {
        public static void Test()
        {
            //567. Permutation in String same answer

            var result = FindAnagrams2022("cbaebabacd", "abc");
        }

        private static IList<int> FindAnagrams2022(string s, string p)
        {
            var result = new List<int>();
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || s.Length < p.Length)
                return result;

            var k = p.Length;
            var hashS = new int[26];
            var hashP = new int[26];
            for(int i = 0; i < k; i++)
            {
                hashP[p[i] - 'a']++;
                hashS[s[i] - 'a']++;
            }

            if (Enumerable.SequenceEqual<int>(hashS, hashP))
                result.Add(0);

            for(int i = k; i < s.Length; i++)
            {
                hashS[s[i - k] - 'a']--;
                hashS[s[i] - 'a']++;

               if(Enumerable.SequenceEqual<int>(hashS, hashP))
                    result.Add(i - k + 1);
            }
            return result;
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
