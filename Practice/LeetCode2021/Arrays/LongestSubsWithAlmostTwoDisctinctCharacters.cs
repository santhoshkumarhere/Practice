using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class LongestSubsWithAlmostTwoDisctinctCharacters
    {
        public static void Test()
        {
           // var res = LengthOfLongestSubstringTwoDistinct("eceba");
           // var res2 = LengthOfLongestSubstringTwoDistinct("ecoooec");
            var res3 = LengthOfLongestSubstringTwoDistinct("ccaabbb");            
        }
        
        private static int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int begin = 0, counter = 0, maxLength = 0;

            var map = new Dictionary<char, int>();
            
            for(var end = 0; end < s.Length; end++)
            {
                if(!map.ContainsKey(s[end]))
                {
                    if(counter == 2) //two distinct
                    {
                        map[s[begin]]--;
                        begin++;
                        if (map[s[begin]] > 0)
                        {
                            end--;
                            continue; // reprocess current index until duplicated removed from front - count still not decrement yet
                        }
                        else
                        {
                            map.Remove(s[begin]);                           
                            counter--;
                        }                        
                    }
                    map[s[end]] = 1; // add new element
                    counter++;
                }
                else
                {
                    map[s[end]]++;
                }
                maxLength = Math.Max(maxLength, end - begin + 1);
            }
            return maxLength;
        }

    }
}
