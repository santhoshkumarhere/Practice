using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Matrix
{
    public class CountOfIsland
    {
        private static int[] rows = { -1, 0, 1, 0 };
        private static int[] cols = { 0, 1, 0, -1 };

        public static void Test()
        {
          var grid = new int[][]
          {
                new int[]{1,1,0,0,0},
                new int[]{1,1,0,0,0},
                new int[]{1,0,1,0,0},
                new int[]{0,0,0,1,1}
          };

            var result = CountNoOfIsland(grid);
        }

        private static int CountNoOfIsland(int[][] grid)
        {
            int noOfIsland = 0;
            int rowCount = grid.Length;
            int colCount = grid[0].Length;
            bool[,] processed = new bool[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < colCount; j++)
                {
                    if(!processed[i, j] && grid[i][j] == 1)
                    {
                        DFS(i, j, grid, processed);
                        noOfIsland++;
                    }
                }
            }

            return noOfIsland;
        }

        private static bool IsSafe(int rowIndex, int colIndex, int[][] grid, bool[,] processed)
        {
            if(rowIndex >= 0 && rowIndex < grid.Length && colIndex >= 0 && colIndex < grid[0].Length && !processed[rowIndex, colIndex] && grid[rowIndex][colIndex] == 1)
            {
                return true;
            }
            return false;
        }

        private static void BFS(int i, int j, int[][] grid, bool[,] processed)
        {
            var q = new Queue<int[]>();
            q.Enqueue(new int[] { i, j });
            processed[i, j] = true;
            
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                for(int k = 0; k < 4; k++)
                {
                    var row = curr[0] + rows[k];
                    var col = curr[1] + cols[k];

                    if(IsSafe(row, col, grid, processed))
                    {
                        q.Enqueue(new int[] { row, col });
                        processed[row, col] = true;
                    }                    
                }
            }
        }

        private static void DFS(int i, int j, int[][] grid, bool[,] processed)
        {
            if (!IsSafe(i, j, grid, processed))
                return;

            processed[i, j] = true;

            DFS(i - 1, j, grid, processed);
            DFS(i, j + 1, grid, processed);
            DFS(i + 1, j, grid, processed);
            DFS(i, j - 1, grid, processed);            
        }
    }
}
