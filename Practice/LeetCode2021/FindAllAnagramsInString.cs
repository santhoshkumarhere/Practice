using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class FindAllAnagramsInString
    {
        public static void Test()
        {
            var s = "abab";
            var p = "ab";
            var result = FindAnagramsON2(s, p);
            var result2 = FindAnagrams(s, p);

            s = "cbaebabacd";
            p = "abc";
            result = FindAnagramsON2(s, p);
            result2 = FindAnagrams(s, p);
        }

        private static IList<int> FindAnagrams(string s, string p)
        {
            var res = new List<int>();

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || s.Length < p.Length)
                return res;

            var pHash = new char[26];
            var sHash = new char[26];

            foreach(var c in p)
            {
                pHash[c - 'a']++;
            }
                    
            var windowSize = p.Length;
           
            for(var i = 0; i < s.Length ; i++)
            {
                sHash[s[i] - 'a']++;
                
                if(i >= windowSize)
                {
                    sHash[s[i - windowSize] - 'a']--; //remove left side of window
                }
                if (new string(sHash).Equals(new string(pHash)))
                    res.Add(i - windowSize + 1); //current window starting index
                
            }

            return res;
        }

        private static IList<int> FindAnagramsON2(string s, string p)
        {
            var res = new List<int>();

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || s.Length < p.Length)
                return res;

            var arr = new char[26];
            foreach(var c in p)
            {
                arr[c - 'a']++;
            }

            var pKey = new string(arr);

            for(int i= 0; i < s.Length; i++)
            {
                arr = new char[26];
                arr[s[i] - 'a']++;

                for(int j = i+1; j < i + p.Length && j < s.Length; j++)
                {
                    arr[s[j] - 'a']++;
                }
                var sKey = new string(arr);

                if(sKey.Equals(pKey))
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }
}
