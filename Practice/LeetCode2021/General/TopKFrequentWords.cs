using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class TopKFrequentWords
    {
        public static void Test()
        {
            var arr = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            var res = TopKFrequent(arr, 1);

            arr = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            var res1 = TopKFrequent(arr, 3);
        }

        private  static IList<string> TopKFrequent(string[] words, int k)
        {
            var dict = new SortedDictionary<string, int>();
            var res = new List<string>();
            int maxCount = 0;
            foreach(var key in words)
            {
                var count = dict.ContainsKey(key) ? dict[key] + 1 : 1;
                dict[key] = count;
                maxCount = Math.Max(maxCount, count);
            }

            var list = new List<string>[maxCount + 1];

            foreach(var key in dict.Keys)
            {
               var val = dict[key];
               if (list[val] == null)
                    list[val] = new List<string>();
                list[val].Add(key);
            }

            for(var i = maxCount; i >= 0 && k > 0; i--)
            {
                if(list[i] != null)
                {
                    foreach(var item in list[i])
                    {
                        if (k > 0)
                        {
                            res.Add(item);
                            k--;
                        }
                    }
                }
            }
            return res;
        }
    }
}
