using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class SubArraySumK
    {
        public static void Test()
        {
            var x = SubarraySum(new int[] { 2 }, 2); //2
            var res = SubarraySum(new int[] { 2, 1, -2, 1, 3 }, 3); //3
            var res1 = SubarraySum(new int[] { -3, 3, 3 }, 3);
            var res2 = SubarraySum(new int[] { 1, 1, -3, 5, -3 }, 2);
        }

        private static int SubarraySum(int[] nums, int k)
        {
            int count = 0;

            for(var i = 0; i < nums.Length; i++)
            {
                var sum = nums[i];
                if(sum == k) count++;

                for(var j = i+1; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                        count++;
                }
            }
            return count;
        }
    }
}
