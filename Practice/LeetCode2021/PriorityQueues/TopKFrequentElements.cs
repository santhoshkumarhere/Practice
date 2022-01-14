using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.PriorityQueues
{
    internal class TopKFrequentElements
    {
        public static void Test()
        {
            var res = TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
        }

        private static int[] TopKFrequent(int[] nums, int k)
        {
            var result = new int[k];
            var map = new Dictionary<int, int>();
            
            foreach(var num in nums)
            {
                if(map.ContainsKey(num))
                {
                    map[num]++;
                }
                else
                {
                    map[num] = 1;
                }
            }

            var pq = new PriorityQueue<int, int>();

            foreach(var key in map.Keys)
            {
                pq.Enqueue(key, map[key]); // min heap to have Time complexity better than O(N log k)

                if (pq.Count > k)
                    pq.Dequeue();
            }

            for(int i = k-1; i >= 0; i--)
            {
                result[i] = pq.Dequeue();
            }
            
            return result;
        }
    }    
}

