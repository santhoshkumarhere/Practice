using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class NoOfIslands_M_
    {
        private static int[] rows = { -1, 0, 1, 0};
        private static int[] cols = { 0, 1, 0, -1 };

        private static bool IsSafe(int[][] grid, int x, int y, bool[,] processed)
        {
            if( x >= 0 && x < grid.Length && y >=0 && y < grid[0].Length && !processed[x, y] && grid[x][y] == 1)
            {
                return true;
            }
            return false;
        }

        public static void Test()
        {
            var grid = new int[][]
            {
                new int[]{1,1,0,0,0},
                new int[]{1,1,0,0,0},
                new int[]{1,0,1,0,0},
                new int[]{0,0,0,1,1}
            };

            var x = grid.Length; var y = grid[0].Length;
            var processed = new bool[x, y];
            var islandCount = 0;
            for(var i=0; i< x; i++)
            {
                for(var j=0; j < y; j++)
                {
                    if(grid[i][j] ==1 && !processed[i, j])
                    {
                        BFS(i, j, grid, processed);
                        islandCount++;
                    }
                }
            }
        }

        private static void BFS(int i, int j, int[][] grid, bool[,] processed)
        {
            var q = new Queue<int[]>();
            q.Enqueue(new int[] { i, j });
            processed[i, j] = true;

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                for (var k=0; k < 4; k++)
                {                   
                    var x = p[0] + rows[k];
                    var y = p[1] + cols[k];
                    if(IsSafe(grid, x, y, processed))
                    {
                        q.Enqueue(new int[] { x, y });
                        processed[x, y] = true;
                    }
                }
            }
        }
    }
}
