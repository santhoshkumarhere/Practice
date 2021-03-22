using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Recursion
{
    public class KnapSack
    {
        public static void Test()
        {
            var weights = new int[] { 3, 1, 5, 2 };
            var profits = new int[] { 31, 26, 72, 17 };
            var res = KnapSacks(0, 0, 0, 0, weights, profits, 7);
            var res1= KnapSackRecursive(0, 7, weights, profits);

            var weights2 = new int[] { 20, 10, 40, 30 };
            var profits2 = new int[] { 40, 100, 50, 60 };
            var res2 = KnapSacks(0, 0, 0, 0, weights2, profits2, 60);
            var res21 = KnapSackRecursive(0, 60, weights2, profits2);

            var profits3 = new int[]  { 60, 100, 120 };
            var weights3 = new int[] { 10, 20, 30 };
            var res3 = KnapSacks(0, 0, 0, 0, weights3, profits3, 50);
            var res31 = KnapSackRecursive(0, 50, weights3, profits3);
        }


        private static int KnapSacks(int start, int runningWeight, int runningProfit, int result, int[] weights, int[] profits, int capacity)
        {
            for (int i = start; i < profits.Length; i++)
            {
                runningWeight += weights[i];
                runningProfit += profits[i];
                if (runningWeight <= capacity)
                {
                    var tempResult = Math.Max(runningProfit, result);
                    result = KnapSacks(i + 1, runningWeight, runningProfit, tempResult, weights, profits, capacity);
                }
                runningWeight -= weights[i];
                runningProfit -= profits[i];
            }
            return result;
        }

        private static int KnapSackRecursive(int currentIndex, int capacity, int[] weights, int[] profits)
        {
            if(capacity <= 0 || currentIndex >= profits.Length)
            {
                return 0;
            }            

            var profit1 = 0;
            if (weights[currentIndex] <= capacity)
                profit1 = profits[currentIndex] + KnapSackRecursive(currentIndex + 1, capacity - weights[currentIndex],weights, profits);
            int profit2 = KnapSackRecursive(currentIndex+1, capacity, weights, profits);

            return Math.Max(profit1, profit2);

        }
    }
}
