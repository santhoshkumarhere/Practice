using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.PriorityQueue
{
    public class FindKthLargestArrayPQ
    {
        public static void Test()
        {
            var res = FindKthLargest( new int[] { 3, 2, 1, 5, 6, 4 }, 2);
            var res1 = FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4);

        }

        private static int FindKthLargest(int[] nums, int k)
        {
            return 1; 
            //var queue = new PriorityQueue<int, int>(); // Leetcode is not ready for this c# version yet

            //foreach(var item in nums)
            //{
            //    queue.Enqueue(item, item);

            //    if (queue.Count > k)
            //        queue.Dequeue();
            //}
            //return queue.Dequeue();
        }
    }
}
