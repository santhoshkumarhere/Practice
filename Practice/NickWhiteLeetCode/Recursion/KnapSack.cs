using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Recursion
{
    public class KnapSack
    {
        public static void Test()
        {
            var weights = new int[] { 3, 1, 5, 2 };
            var profits = new int[] { 31, 26, 72, 17 };
            var res = KnapSacks(0, 0, 0, 0, weights, profits, 7);
        }

        private static int KnapSacks(int start, int runningWeight, int runningProfit, int result, int[] weights, int[] profits, int capacity)
        {
            if (runningWeight == capacity)
            {
                return result;
            }

            for (int i = start; i < profits.Length; i++)
            {
                runningProfit += profits[i];
                runningWeight += weights[i];
                if (runningWeight <= capacity)
                {
                    result = Math.Max(result, runningProfit);
                    result = KnapSacks(i + 1, runningWeight, runningProfit, result, weights, profits, capacity);
                }
                runningWeight -= weights[i];
                runningProfit -= profits[i];
                
            }
            return result;
        }

    }
}
