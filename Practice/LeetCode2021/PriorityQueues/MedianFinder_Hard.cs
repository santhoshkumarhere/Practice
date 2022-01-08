using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.PriorityQueues
{
    public class MedianFinder
    {
        PriorityQueue<int, int> maxHeap;

        PriorityQueue<int, int> minHeap;

        public MedianFinder()
        {
            maxHeap = new PriorityQueue<int, int>(new MaxComparator<int>());
            minHeap = new PriorityQueue<int, int>();
        }

        public static void Test()
        {
            var medianFinder = new MedianFinder();
            var nums = new int[] { 41, 35, 62, 4, 97, 108 };

            foreach(var num in nums)
            {
                medianFinder.AddNum(num);
                Console.Write(" " + medianFinder.FindMedian());
            }
        }

        public void AddNum(int num)
        {
            maxHeap.Enqueue(num, num);
            var peek = maxHeap.Dequeue();
            minHeap.Enqueue(peek, peek);

            if (maxHeap.Count < minHeap.Count)
            {
                peek = minHeap.Dequeue();
                maxHeap.Enqueue(peek, peek);
            }
        }

        public double FindMedian()
        {
            var maxHeapSize = maxHeap.Count;
            var minHeapSize = minHeap.Count;

            if(maxHeapSize > minHeapSize)
            {
                return maxHeap.Peek();
            }
            return (maxHeap.Peek() + minHeap.Peek()) * 0.5;
        }

        private class MaxComparator<T>:  IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
