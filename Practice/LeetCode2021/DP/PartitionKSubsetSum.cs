using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class PartitionKSubsetSum
    {
        public static void Test()
        {
            var nums = new int[] { 4, 3, 2, 3, 5, 2, 1 }; 
            //var nums = new int[] { 2, 2, 2, 2, 3, 4, 5}; 4
            // var nums = new int[] { 5, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3 }; 15
           // var nums = new int[] { 7, 2, 2, 2, 2, 2, 2, 2, 3 };
 

            var result = CanPartitionKSubsets(nums, 4);
        }


        private static  bool CanPartitionKSubsets(int[] nums, int k)
        {
            var totalSum = nums.Sum();
            var maxNum = nums.Max();

            if (totalSum % k != 0 || maxNum > totalSum / k)
            {
                return false;
            }

            var targetSubSetSum = totalSum / k;
            var visited = new bool[nums.Length];
            return CanPartitionK(0, k, nums, visited, targetSubSetSum, 0);
        }


        private static bool CanPartitionK(int start, int k, int[] nums, bool[] visited, int targetSubSetSum, int currentSubSetSum)
        {
            if (k == 0)
                return true;

            if (currentSubSetSum == targetSubSetSum)
                return CanPartitionK(0, k - 1, nums, visited, targetSubSetSum, 0);

            for(int i = start; i < nums.Length; i++)
            {
                var currSum = currentSubSetSum + nums[i];
                if (!visited[i] && currSum <= targetSubSetSum)
                {
                    visited[i] = true;
                    if (CanPartitionK(i + 1, k, nums, visited, targetSubSetSum, currSum))
                    {
                        return true;
                    }

                    visited[i] = false;
                }
            }

            return false;
        }

    }
}
