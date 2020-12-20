using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BackTracking
{
    public class Combination
    {
        public static void Test()
        {
            var result = new List<IList<int>>();
            Combinate(new int[] { 1, 2, 5 }, 5, 0, 0, new List<int>(), result); //make sure coins are sorted using Array.Sort
            //CombinationSums(new int[] { 1, 2, 5 }, 5);
        }

        private static IList<IList<int>> Combinate(int[] coins, int target, int currentSum, int start, List<int> track, IList<IList<int>> result)
        {
            if(currentSum == target)
            {
                result.Add(new List<int>(track));
                return result;
            }

            for (var i = start; i < coins.Length; i++)
            {
                track.Add(coins[i]);

                if(currentSum + coins[i] <= target)
                Combinate(coins, target, currentSum + coins[i], i, track, result);
                
                track.Remove(coins[i]);
            }

            return result;
        }

        public static IList<IList<int>> CombinationSums(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);
            CombinateLeet(candidates, target, 0, 0, new List<int>(), result); //make sure coins are sorted using Array.Sort
            return result;
        }

        private static IList<IList<int>> CombinateLeet(int[] candidates, int target, int start, int currentSum, List<int> track, IList<IList<int>> result)
        {
            if(currentSum == target)
            {
                result.Add(new List<int>(track));
                return result;
            }
            for (int i = start; i < candidates.Length; i++)
            {
                track.Add(candidates[i]);
                if (currentSum + candidates[i] <= target)
                    CombinateLeet(candidates, target, i, currentSum + candidates[i], track, result);
                track.Remove(candidates[i]);
            }
            return result;
        }
    }
}
