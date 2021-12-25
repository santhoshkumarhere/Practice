using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.SlidingWindow
{
    internal class MaximumSlidingWindow
    {
        public static void Test()
        {
            var nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
          var k = 3;
          var res = MaxSlidingWindow(nums, k); ;

        }

        private static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var linkedList = new LinkedList<int>();
            int[] result = new int[nums.Length + 1 - k]; // 0 1 2 3 4 => l = 5 , window count = 3 , 5 + 1 - 3 

            for(int i = 0; i < nums.Length; i++)
            {
                // 1. Adjust sliding window length
                if(linkedList.Any() && linkedList.First.Value <= i - k)  // 0 1 2 3  => when i = 3 remove 0 from list
                {
                    linkedList.RemoveFirst();
                }

                //2. Keep Max value at top
                while(linkedList.Any() && nums[linkedList.Last.Value] <= nums[i])
                {
                    linkedList.RemoveLast();
                }
                
                linkedList.AddLast(i);
                //0 1 2 3 4
                var index = i - k + 1; // 2 - 3 + 1, 3 - 3 + 1, 4 - 3 - 1
                if(index >= 0)
                {
                    result[index] = nums[linkedList.First.Value];
                }
            }
            return result;
        }
    }
}
