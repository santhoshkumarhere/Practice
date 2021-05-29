using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class RankingArray
    {
        public static void Test()
        {
            var res = ArrayRankTransform(new int[] { 40, 10, 20, 30});
        }
        private static int[] ArrayRankTransform(int[] arr)
        {
            var temp = new int[arr.Length];

            Array.Copy(arr, temp, arr.Length);
            Array.Sort(temp);

            var map = new Dictionary<int, int>();
            var rank = 1;
            foreach (var key in temp)
            {
                if (!map.ContainsKey(key))
                {
                    map[key] = rank++;
                }
            }

            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = map[arr[i]];
            }
            return arr;
        }
    }
}
