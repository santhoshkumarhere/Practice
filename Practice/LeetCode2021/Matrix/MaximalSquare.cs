using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class MaximalSquare
    {

        public static void Test()
        {
            var matrix = new char[][]
            {
                new char[]{'1', '0', '1', '0', '0'},
                new char[]{'1', '0', '1', '1', '1'},
                new char[]{'1', '1', '1', '1', '1'},
                new char[]{'1', '0', '0', '1', '0'},
            };
            var res = MaximalSquares(matrix);
        }

        private static int MaximalSquares(char[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var dp = new int[m, n];
            var max = 0;
            for(int row = 0; row < m; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    if(matrix[row][col] == '1')
                    {   
                        if(row - 1 >= 0 && col - 1 >= 0 && matrix[row-1][col] == '1' && matrix[row][col-1] == '1' && matrix[row-1][col-1] == '1')
                        {
                            dp[row, col] = 1 + dp[row - 1, col - 1];
                        }
                        else
                        {
                            dp[row, col] = 1;
                        }
                        max = Math.Max(max, dp[row, col]);
                    }
                }
            }
            return max * max;
        }
    }
}
