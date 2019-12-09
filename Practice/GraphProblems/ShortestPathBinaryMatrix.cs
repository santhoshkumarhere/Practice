using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.GraphProblems
{
    public class ShortestPathBinaryMatrix
    {
        public static void Test()
        {
            var grid = new int[][]
            {
                new int[]{0, 0, 0 },
                new int[]{1, 1, 0 },
                new int[]{1, 1, 0 }
            };

            var res = ShortestPathMatrix(grid);

            grid = new int[][]
             {
                new int[]{0, 0, 0 },
                new int[]{1, 1, 0 },
                new int[]{1, 1, 1 }
             };
            res = ShortestPathMatrix(grid);
        }

        public static int ShortestPathMatrix(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            return BFS(grid);

        }

        private static bool IsSafe(int[][] grid, int x, int y)
        {
            if (x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length && grid[x][y] != 1)
            {
                return true;
            }
            return false;
        }


        private static int[] rows = { -1, -1, -1, 0, 0, 1, 1, 1 };
        private static int[] cols = { -1, 0, 1, -1, 1, -1, 0, 1 };

        private static int BFS(int[][] grid)
        {

            int m = grid.Length;
            int n = grid[0].Length;
            if (grid[0][0] == 1 || grid[m-1][n-1] == 1)
            {
                return -1;
            }

            if(m ==1 && n ==1)
            {
                return 1;
            }

            var q = new Queue<int[]>();
            q.Enqueue(new int[] { 0, 0 });
            grid[0][0] = 1;
            int count = 1;
            while (q.Count > 0)
            {
                count++;
                for (var size = q.Count; size > 0; size--)
                {
                    var p = q.Dequeue();

                    for (int k = 0; k < 8; k++)
                    {
                        var x = p[0] + rows[k];
                        var y = p[1] + cols[k];
                        if (IsSafe(grid, x, y))
                        {
                            if (x == m - 1 && y == n - 1)
                            {
                                return count;
                            }

                            grid[x][y] = 1;
                            q.Enqueue(new int[] { x, y });
                        }
                    }
                }
            }
            return -1;
        }
    }
}
