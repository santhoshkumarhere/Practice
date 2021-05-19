using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class RottenOranges
    {
        private static int[] rows = { -1, 0, 1, 0 };
        private static int[] cols = { 0, 1, 0, -1 };

        public static void Test()
        {
          var grid = new int[][]
          {
                new int[]{2, 1, 1},
                new int[]{1, 1, 0},
                new int[]{0, 1, 1},
          };

          var result1 = OrangesRotting(grid);

          grid = new int[][]
          { 
                new int[]{2, 1, 1},
                new int[]{0, 1, 1},
                new int[]{1, 0, 1},
          };
           var result2 = OrangesRotting(grid);

            grid = new int[][]
            {
                new int[]{0, 2}
            };
            var result3 = OrangesRotting(grid);
        }

        private static int OrangesRotting(int[][] grid)
        {
            int noOfMinutes = 0;
            int noOfFreshOranges = 0;
            int rowCount = grid.Length;
            int colCount = grid[0].Length;
            bool[,] processed = new bool[rowCount, colCount];
            var q = new Queue<int[]>();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (grid[i][j] == 1)
                        noOfFreshOranges++;

                    if(grid[i][j] == 2)
                        q.Enqueue(new int[] { i, j });
                }
            }

            if(q.Count == 0 && noOfFreshOranges > 0)
                return -1; // All fresh
            if (q.Count == 0 && noOfFreshOranges == 0)
                return 0; // All empty

            noOfMinutes = BFS(q, grid, noOfFreshOranges);
            return noOfMinutes;
        }

        private static bool IsSafe(int rowIndex, int colIndex, int[][] grid)
        {
            if(rowIndex >= 0 && rowIndex < grid.Length && colIndex >= 0 && colIndex < grid[0].Length && grid[rowIndex][colIndex] == 1)
            {
                return true;
            }
            return false;
        }

        private static int BFS(Queue<int[]> q, int[][] grid, int noOfFreshOranges)
        {
            var steps = 0;
            while (q.Count > 0 && noOfFreshOranges > 0)
            {
                for (var size = q.Count; size > 0; size--)
                {
                    var curr = q.Dequeue();
                    for (int k = 0; k < 4; k++)
                    {
                        var row = curr[0] + rows[k];
                        var col = curr[1] + cols[k];

                        if (IsSafe(row, col, grid))
                        {
                            grid[row][col] = 2;
                            q.Enqueue(new int[] { row, col });
                            noOfFreshOranges--;
                        }
                    }
                }
                steps++;
            }

            return noOfFreshOranges > 0 ? - 1 : steps; //if fresh oranges left then retunr -1;
        }
    }
}
