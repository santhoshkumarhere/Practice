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
        }

        private static IList<IList<int>> Combinate(int[] coins, int target, int currentSum, int start, List<int> track, IList<IList<int>> result)
        {
            if(currentSum == target)
            {
                result.Add(new List<int>(track));
                return result;
            }
            else if (currentSum > target)
            {
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
    }
}
