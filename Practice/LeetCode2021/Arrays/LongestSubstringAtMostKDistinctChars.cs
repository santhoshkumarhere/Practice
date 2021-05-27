using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class LongestSubstringAtMostKDistinctChars
    {
        public static void Test()
        {
            var res = LengthOfLongestSubstringKDistinct("eceba", 2);
            var res2 = LengthOfLongestSubstringKDistinct("aa", 1);
        }

        private static int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0)
                return 0;
            int begin = 0, maxLength = 0, counter = 0;
            var map = new Dictionary<char, int>();
            
            for(int end = 0; end < s.Length; end++)
            {
                var ch = s[end];
                if(!map.ContainsKey(ch))
                {                    
                    if(counter == k)
                    {
                        var beginKey = s[begin];
                        map[beginKey]--;
                        begin++;
                        if (map[beginKey] > 0)
                        {
                            end--;
                            continue;
                        }
                        map.Remove(beginKey);
                        counter--;
                    }
                    map[ch] = 1;
                    counter++;
                }
                else
                {
                    map[ch]++;
                }
                maxLength = Math.Max(maxLength, end - begin + 1);
            }
            return maxLength;
        }
    }
}
