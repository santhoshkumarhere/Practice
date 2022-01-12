using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class _0_1KnapSackProblem
    {
        public static void Test()
        {
            var weights = new int[] { 3, 1, 5, 2 };
            var profits = new int[] { 31, 26, 72, 17 }; 
            var res1 = FindMaximumProfit(weights, profits, 7);//98

            var weights2 = new int[] { 20, 10, 40, 30 };
            var profits2 = new int[] { 40, 100, 50, 60 };
            var res2 = FindMaximumProfit(weights2, profits2, 60); //200

            var profits3 = new int[] { 60, 100, 120 };
            var weights3 = new int[] { 10, 20, 30 };
            var res3 = FindMaximumProfit(weights3, profits3, 50); //220
        }


        private static int FindMaximumProfit(int[] weights, int[] profits, int capacity)
        {
            int n = profits.Length;
            var matrix = new int[n + 1, capacity + 1];
            
            for (var row = 1; row <= n; row++)
            {
                for (var col = 1; col <= capacity; col++)
                {
                    if (col >= weights[row - 1]) //IMPORTANT :: weights[row - 1] profits[row-1] gives current row values;
                        matrix[row, col] = Math.Max(matrix[row - 1, col], profits[row - 1] + matrix[row - 1, col - weights[row - 1]]); //Max(prevrow, current weight profit + remaining weight from previous row)
                    else
                        matrix[row, col] = matrix[row - 1, col]; //previous row
                }
            }
            return matrix[n, capacity];
        }
    }
}

//col = capaity
//row = what if includes current row and previous row involved // Tech Dose