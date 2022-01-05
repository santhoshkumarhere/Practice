using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.BackTracking
{
    internal class CombinateMultiDimensionalArray
    {

        public static void Test()
        {
            var nums = new int[4][] {
                new int[] { 2, 3 },
                new int[]{4},
                new int[]{2, 3},
                new int[] { 1, 2 }
                }; //answer must 4 ways
            var result = new List<List<int>>();
             BackTrack(10, 0, 0, nums, result , new List<int>());
        }

        private static void BackTrack(int target, int currSum, int start, int[][] nums, List<List<int>> result, List<int> track)
        {            
            if (currSum <= target && track.Count == nums.Length)
            {
                result.Add(new List<int>(track));
                return;
            }

            var arr = nums[start];

            for(int i = 0; i < arr.Length; i++)
            {
                var sum = currSum + arr[i];
                if (sum <= target)
                {
                    track.Add(arr[i]);
                    BackTrack(target, sum, start + 1, nums, result, track); // start should be no of arrays
                    track.RemoveAt(track.Count - 1);
                }
            }
        }
    }


}
