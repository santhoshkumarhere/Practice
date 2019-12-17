using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    class MakingChange
    {
        public static void Test()
        {
           // var result = ChangePossibilitiesBottomUp(5, new int[]{1, 3, 5});
            var result = CombinationSum(new int[]{2, 3, 6, 7}, 7);
        }
        
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> combination = new List<int>();
            Array.Sort(candidates);
            CombinationSum(result, candidates, combination, target, 0);
            return result;
        }

        private static void CombinationSum(IList<IList<int>> result, int[] candidates, IList<int> combination, int target, int start)
        {
            if (target == 0)
            {
               result.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i != candidates.Length && target >= candidates[i]; ++i)
            {
                combination.Add(candidates[i]);
                CombinationSum(result, candidates, combination, target - candidates[i], i);
                combination.Remove(combination.Last());
            }
        }

        public static int ChangePossibilitiesBottomUp(int amount, int[] denominations)
        {
            // Array of zeros from 0..amount
            int[] waysOfDoingNCents = new int[amount + 1];

            waysOfDoingNCents[0] = 1;

            foreach (int coin in denominations)
            {
                for (int higherAmount = coin; higherAmount <= amount; higherAmount++)
                {
                    int higherAmountRemainder = higherAmount - coin;
                    waysOfDoingNCents[higherAmount] = waysOfDoingNCents[higherAmount] + waysOfDoingNCents[higherAmountRemainder];
                }
            }

            return waysOfDoingNCents[amount];
        }
    }
}
