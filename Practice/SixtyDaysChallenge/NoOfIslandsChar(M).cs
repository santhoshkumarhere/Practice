using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class NoOfIslands_M_C
    {
        private static int[] rows = { -1, 0, 1, 0};
        private static int[] cols = { 0, 1, 0, -1 };

        private static bool IsSafe(char[][] grid, int x, int y, bool[,] processed)
        {
            if( x >= 0 && x < grid.Length && y >=0 && y < grid[0].Length && !processed[x, y] && grid[x][y] == '1')
            {
                return true;
            }
            return false;
        }

        public static void Test()
        {
            var grid = new char[][]
            {
                new char[]{'1','1','0','0','0'},
                new char[]{'1','1','0','0','0'},
                new char[]{'1','0','1','0','0'},
                new char[]{'0','0','0','1','1'}
            };

            var x = grid.Length; var y = grid[0].Length;
            var processed = new bool[x, y];
            var islandCount = 0;
            for(var i=0; i< x; i++)
            {
                for(var j=0; j < y; j++)
                {
                    if(grid[i][j] == '1' && !processed[i, j])
                    {
                        BFS(i, j, grid, processed);
                        islandCount++;
                    }
                }
            }
        }

        private static void BFS(int i, int j, char[][] grid, bool[,] processed)
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

        void dfs(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }

        public int numIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;
            for (int r = 0; r < nr; ++r)
            {
                for (int c = 0; c < nc; ++c)
                {
                    if (grid[r][c] == '1')
                    {
                        ++num_islands;
                        dfs(grid, r, c);
                    }
                }
            }

            return num_islands;
        }
    }
}
