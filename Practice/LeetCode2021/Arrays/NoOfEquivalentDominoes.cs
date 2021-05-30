using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class NoOfEquivalentDominoes
    {

        public static void Test()
        {
            var dominoes = new int[][]
            {
                new int[]{1, 2},
                new int[]{2, 1},
                new int[]{3, 4},
                new int[]{5, 6},
            };
            var res = NumEquivDominoPairs(dominoes);
        }

        private static int NumEquivDominoPairs(int[][] dominoes)
        {
            var result = 0;
            var dict = new Dictionary<int, int>();
            foreach (var d in dominoes)
            {
                //good hashing
                var key = Math.Min(d[0], d[1]) * 10 + Math.Max(d[0], d[1]);

                if (dict.ContainsKey(key))
                {
                    result += dict[key];
                    dict[key]++;
                }
                else
                {
                    dict[key] = 1;
                }

            }
            return result;
        }
    }
}
