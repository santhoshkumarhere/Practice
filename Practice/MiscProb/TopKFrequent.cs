using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Practice.MiscProb
{
    class TopKFrequent
    {
        public static void RecursionTest(String[] words, int k)
        {
              Dictionary<string, int> count = new Dictionary<string, int>();
                foreach (string word in words) {
                    count[word] = count.ContainsKey(word) ? count[word] + 1 : 1;
                }

                var candidates = new List<string>(count.Keys);
                candidates.Sort((w1, w2) =>count[w1].Equals(count[w2]) ? w1.CompareTo(w2) : count[w2] - count[w1]);

                var list = candidates.Skip(0).Take(k).ToList();
        }
    }
}
