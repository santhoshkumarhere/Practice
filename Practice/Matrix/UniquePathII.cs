using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Matrix
{
    class UniquePathII
    {
        public static void Test()
        {
            var obstacleGrid = new int[][]
            {
                new int[] {0, 0, 0},
                new int[] {0, 1, 0},
                new int[] {0, 0, 0}
            };
            FindPathWithObstacle(obstacleGrid);
        }

        public static int FindPathWithObstacle(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            var count = new int[m, n];

            for (var i = 0; i < m && obstacleGrid[i][0] != 1; i++)
            {
                count[i, 0] = -1;
            }
            for (var i = 0; i < n && obstacleGrid[0][i] != 1; i++)
            {
                count[0, i] = -1;
            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    if(obstacleGrid[i][j] !=1)
                    count[i, j] = count[i - 1, j] == 1 ? 0 : count[i - 1, j] + (count[i, j - 1] == 1 ? 0 : count[i, j - 1]);
                }
            }
            return -1 * count[m - 1, n - 1];
        }
    }
    
}
