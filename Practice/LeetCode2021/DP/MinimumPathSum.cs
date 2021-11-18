using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class MinimumPathSum
    {
        public static void Test()
        {
            var grid = new int[][]
            {
                //new int[]{1, 3, 1},
                //new int[]{1, 5, 1},
                //new int[]{4, 2, 1},
                 new int[]{1, 2, 3},
                new int[]{4, 5, 6}, 
            };

            var res = MinPathSum(grid);
        }

        private static int MinPathSum(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            for(var i = 1; i < n; i++)
            {
                grid[0][i] += grid[0][i - 1];
            }

            for (var i = 1; i < m; i++)
            {
                grid[i][0] += grid[i-1][0];
            }

            for(var row = 1; row < m; row++)
            {
                for(var col = 1; col < n; col++)
                {
                    grid[row][col] += Math.Min(grid[row - 1][col], grid[row][col - 1]);
                }
            }

            return grid[m - 1][n - 1];
        }
    }
}
