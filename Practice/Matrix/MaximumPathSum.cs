using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Matrix
{
    class MaximumPathSum
    {

        public static void Test()
        {
            var grid = new int[][]
            {
                new int[]{ 1, 3, 1 },
                new int[]{ 1, 5, 1 },
                new int[]{ 4, 2, 1 }
            };
            var result = Compute(grid);
        }

        public static int Compute(int[][] grid)
        {

            int m = grid.Length;
            int n = grid[0].Length;
            var count = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                if (i != 0)
                {
                    count[i, 0] = count[i - 1, 0] + grid[i][0];
                }
                else
                {
                    count[i, 0] = grid[i][0];
                }
            }

            for (var j = 0; j < n; j++)
            {

                if (j != 0)
                {
                    count[0, j] = count[0, j - 1] + grid[0][j];
                }
                else
                {
                    count[0, j] = grid[0][j];
                }

            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    count[i, j] = Math.Min(grid[i][j] + count[i - 1, j], grid[i][j] + count[i, j - 1]);
                }
            }

            return count[m - 1, n - 1];
        }
    }
}
