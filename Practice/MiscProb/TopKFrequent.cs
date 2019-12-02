using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace Practice.MiscProb
{
    class TopKFrequent
    {
        public static void RecursionTest(string[] words, int k)
        {
              Dictionary<string, int> count = new Dictionary<string, int>();

              //var test = words.Distinct().ToDictionary(t => t, t => words.Count(c => c== t));

                foreach (string word in words) {
                    count[word] = count.ContainsKey(word) ? count[word] + 1 : 1;
                }

                var candidates = new List<string>(count.Keys);
                candidates.Sort((w1, w2) =>count[w1].Equals(count[w2]) ? w1.CompareTo(w2) : count[w2] - count[w1]);

                var list = candidates.Skip(0).Take(k).ToList();
        }

        public static IList<int> FrequentWord(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            var maxCount = 0;
            foreach (var item in nums)
            {
                var currCount = dict.ContainsKey(item) ? dict[item] + 1 : 1;
                dict[item] = currCount;
                maxCount = Math.Max(maxCount, currCount);
            }

             
            var countsArray = new List<int>[maxCount+1];
            var result = new List<int>();

            foreach (var key in dict.Keys)
            {
                var val = dict[key];

                if (countsArray[val] == null)
                {
                    countsArray[val] = new List<int>();
                }
                countsArray[val].Add(key);

            }
             
            for (var i = maxCount; i >= 0 && k > 0; i--)
            {
                if (countsArray[i] != null)
                {
                    foreach (var a in countsArray[i])
                    {
                        if (k > 0)
                        {
                            result.Add(a);
                            k--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
