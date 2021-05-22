using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BackTracking
{
    public class Subset
    {
        public static void Test()
        {
            var result = new List<IList<int>>();
            var track = new List<int>();
            result.Add(new List<int>(track)); //always it has one empty set provided nums.Length >=1
              
            Subsets(new int[] { 1, 2, 3 }, 0, track, result);
        }

        private static IList<IList<int>> Subsets(int[] nums, int start, IList<int> track, IList<IList<int>> result)
        {           
            for(int i = start; i < nums.Length; i++)
            {
                track.Add(nums[i]);
                result.Add(new List<int>(track));
                Subsets(nums, i + 1, track, result);
                track.Remove(nums[i]);
            }

            return result;
        }
    }
}

//Input: nums = [1, 2, 3]
//Output:[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
