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
            var result = CombinationSum(new int[]{1, 2, 3}, 5);
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

            for (int i = start; i < candidates.Length && target >= candidates[i]; ++i)
            {
                combination.Add(candidates[i]);
                CombinationSum(result, candidates, combination, target - candidates[i], i);
                combination.Remove(combination.Last());
            }
        }
    }
}
