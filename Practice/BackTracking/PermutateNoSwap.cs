using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BackTracking
{
    public class PermutateNoSwap
    {
        public static void Test()
        {
            var result = new List<IList<int>>();
            Permutate(new int[] { 1, 2, 3 }, new HashSet<int>(), result);
        }

        private static IList<IList<int>> Permutate(int[] nums, HashSet<int> track, IList<IList<int>> res)
        {
            if (track.Count == nums.Length)
            {
                res.Add(new List<int>(track));
                return res;
            }
            for(var i=0; i < nums.Length; i++)
            {
                if (track.Contains(nums[i]))
                    continue;
                track.Add(nums[i]);
                Permutate(nums, track, res);
                track.Remove(nums[i]);
            }
            return res;
        }
    }
}
