using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021
{
    public class KthLargestElementArray
    {
        public static void Test()
        {
            var inp = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var res = FindKthLargest(inp, 4);
        }

        internal class MinHeap
        {
            public SortedDictionary<int, int> sorted = new SortedDictionary<int, int>(); // O(log n)

            public void Add (int key)
            {
                if(sorted.ContainsKey(key))
                {
                    sorted[key]++;
                }
                else
                {
                    sorted.Add(key, 1);
                }
            }

            public int PopMin()
            {
                var key = sorted.Keys.First();
                var count = sorted[key];
                if(count > 1)
                {
                    sorted[key]--;
                }
                else
                {
                    sorted.Remove(key);
                }
                return key;
            }            
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
                return -1;

            var length = nums.Length;
            var heap = new MinHeap();
            int size = 0;

            foreach(var num in nums)
            {
                heap.Add(num);
                size++;

                if(size > k)
                {
                    heap.PopMin();
                }
            }
            return heap.PopMin();
        }
    }
}
