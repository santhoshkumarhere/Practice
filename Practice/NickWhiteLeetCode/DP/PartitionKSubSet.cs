using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class PartitionKSubSet
    {

        public static void Test()
        {
            var res2 = CanPartitionKSubsets(new int[]{ 10,10,10,7,7,7,7,7,7,6,6,6}, 3);
            var res1 = CanPartitionKSubsets(new int[] { 4, 3, 2, 3, 5, 2, 1 }, 4);

            var res = CanPartitionKSubsets(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 5);
        }

        private static bool CanPartitionKSubsets(int[] nums, int k)
        {
            var totalSum = 0;

            foreach(int num in nums)
            {
                totalSum += num;
            }

            if (totalSum % k > 0) return false;

            var target = totalSum / k;
            Array.Sort(nums);
            var set = new HashSet<(int, int)>();
            var visited = new bool[ nums.Length];
            for (var row = 0; row < nums.Length; row++)
            {
                if (visited[row]) continue;

                for (var col = row; col < nums.Length; col++)
                {
                    if (visited[col]) continue;

                    if(row == col)
                    {
                        if (nums[col] == target)
                            AddToResult(row, col, set, visited);

                        continue;
                    }

                    if (nums[row] + nums[col] == target)
                    {
                        AddToResult(row, col, set, visited);
                        break;
                    }
                }
            }
            return set.Count == k;
        }

        private static void AddToResult(int row, int col, HashSet<(int, int)> set, bool[] visited)
        {
            set.Add( row < col ? (row, col) : (col, row) );
            visited[col] = true;
        }
    }
}
