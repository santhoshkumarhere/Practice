using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class JewelsAndStones
    {
        public static void Test()
        {
            var result1 = HashSetApproach("aA", "aAAbbbb");
            var result2 = HashSetApproach("aA", "ZZb");
        }

        private static int NickSolu(string jewels, string stones)
        {
            var result = 0;
            if (stones == null || stones == null) return result;

            for (var i = 0; i < stones.Length; i++)
            {
                if(jewels.IndexOf(stones[i]) > -1)
                {
                    result += 1; ;
                }
            }
            return result;
        }

        private static int HashSetApproach(string jewels, string stones)
        {
            var result = 0;
            if (stones == null || stones == null) return result;

            var set = new HashSet<char>(jewels);

            for (var i = 0; i < stones.Length; i++)
            {
                if (set.Contains(stones[i]))
                {
                    result += 1; ;
                }
            }
            return result;
        }

        private static int NumJewelsInStones(string jewels, string stones)
        { //My Solution
            var result = 0;
            if (stones == null || stones == null) return result;
            var stoneMap = new Dictionary<char, int>();
            foreach (var s in stones)
            {
                if(stoneMap.ContainsKey(s))
                {
                    stoneMap[s]++;
                }
                else
                {
                    stoneMap[s] = 1;
                }
            }

            for(int i = 0; i < jewels.Length; i++)
            {
                if(stoneMap.ContainsKey(jewels[i]))
                {
                    result += stoneMap[jewels[i]];
                }
            }
            return result;
        }
    }
}
