using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.SlidingWindow
{
    public class MinimumWindowSubstring
    {
        public static void Test()
        {
            var res = MinWindowMap("aa", "aa"); ;
            var res1 = MinWindowMap("ADOBECODEBANC", "ABC");
        }

        private static string MinWindowMap(string s, string t)
        {
            var begin = 0;
            var end = 0;

            //var map = GetFrequencyMap(t);
            var map = new Dictionary<char, int>();
            foreach(var c in t)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map[c] = 1;
            }
            var counter = t.Length;
            var minLen = int.MaxValue;
            var head = 0;

            while (end < s.Length)
            {
                var endChar = s[end];
                
                if(map.ContainsKey(endChar))
                {
                    if (map[endChar] > 0)
                        counter--;

                    map[endChar]--;
                }

                end++;

                while (counter == 0)
                {
                    var beginChar = s[begin];

                    if(end - begin < minLen)
                    {
                        head = begin;
                        minLen = end - begin;
                    }

                    if(map.ContainsKey(beginChar))
                    {
                        map[beginChar]++;
                        if (map[beginChar] > 0)
                            counter++;
                    }                    
                    begin++;
                }
            }

            return minLen == int.MaxValue ? "" : s.Substring(head, minLen);
        }

        private static string MinWindow(string s, string t)
        {
            var begin = 0;
            var end = 0; 

            var map = GetFrequencyMap(t);
            var counter = t.Length;
            var minLen = int.MaxValue;
            var head = 0;

            while (end < s.Length)
            {
                var endChar = s[end];
                // If char in s exists in t, decrease counter
                 
                    if (map[endChar] > 0)
                    {
                        counter--;
                    }
                    map[endChar]--; // Decrease m[s[end]]. If char does not exist in t, m[s[end]] will be negative.
                              
                end++;  // When we found a valid window, move start to find smaller window.

                while (counter == 0)
                {
                    var beginChar = s[begin];
                    if ((end - begin) < minLen)
                    {
                        head = begin;
                        minLen = end - begin;
                    }
                  
                        map[beginChar]++;

                        if(map[beginChar] > 0) // When char exists in t, increase counter.
                        {
                            counter++;
                        }
                   
                    begin++;
                }
            }
            
            return minLen == int.MaxValue ? "" : s.Substring(head, minLen);            
        }

        private static int[] GetFrequencyMap(string t)
        {
            var map = new int[128];
            foreach (var c in t)
            {
                map[c]++;
            }
            return map;
        }
    }
}
