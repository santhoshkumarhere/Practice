using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.LeetCode2021.Interval
{
    public class PartitionLabels
    {
        public static void Test()
        {
            var s = "ababcbacadefegdehijhklij";
            var res = Partition(s);
        }

        private static IList<int> PartitionLeetCode(string s)
        {
            var result = new List<int>();
            if (s == null || s.Length== 0)
                return result;

            var charPositions = new int[26];
            for (var i = 0; i < s.Length; i++)
            {
                charPositions[s[i] - 'a'] = i;  // 'a' - 97 = 0
            }

            var last = 0;
            var start = 0;
            for (var i = 0; i < s.Length; i++)
            {
                last = Math.Max(last, charPositions[s[i] - 'a']);

                if (i == last)
                {
                    result.Add(last - start + 1);
                    start = last + 1;
                }
            }

            return result;
        }

        private static IList<int> Partition(string s)
        {
            var result = new List<int>();

            if (s == null)
                return result;

            var map = new Dictionary<char, int[]>();
            
            for(var i = 0; i < s.Length; i++)
            {
                if(map.ContainsKey(s[i]))
                {
                    map[s[i]][1] = i;
                }
                else
                {
                    map[s[i]] = new int[] { i, i };
                }
            }

            var prev = map[map.Keys.First()];
            foreach(var key in map.Keys)
            {
                var curr = map[key];

                if(curr[0] <= prev[1])
                {
                    prev[1] = Math.Max(prev[1], curr[1]);
                }
                else
                {
                    result.Add(prev[1] - prev[0] + 1);
                    prev = curr;
                }
            }

            result.Add(prev[1] - prev[0] + 1);
            return result;
        }
    }
}
