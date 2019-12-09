using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Matrix
{
    class RottenOranges
    {

        public static void Test()
        {
            var grid = new int[][] { new int[] { 2, 1, 1 },
                                     new int[] {0, 1, 1 },
                                     new int[] { 1, 0, 1 }
            };

           // var grid = new int[][] { new int[] { 0, 1, 1, 1, 1,0}            };
            bool isContainsFresh = false;
            var q = new Queue<int[]>();
            for(var i = 0; i < grid.Length; i++)
            {
                for( var j = 0; j < grid[0].Length; j++)
                {
                    if(grid[i][j] == 1)
                    {
                        isContainsFresh = true;
                    }
                    if(grid[i][j] == 2)
                    { 
                        q.Enqueue(new int[] { i, j });
                    }
                }
            }
           
            var count = BFS(grid, q, isContainsFresh);
        }

        private static int[] rows = { -1, 0, 1, 0 };
        private static int[] cols = { 0, 1, 0, -1 };


        public static int BFS(int[][] grid, Queue<int[]> q, bool isContainsFresh)
        {

            if (q.Count == 0)
            {

                if (isContainsFresh)
                {
                    return -1;
                }
                else if (!isContainsFresh)
                {
                    return 0;
                }
                else return -1;
            }

            var steps = 0;
            while (q.Count > 0)
            {
                var isRottened = false;
                for(var size = q.Count; size >0; size--)
                {
                    var point = q.Dequeue();

                    for(var k = 0; k < 4; k++)
                    {
                        var row = point[0] + rows[k];
                        var col = point[1] + cols[k];

                        if(IsSafe(grid, row, col))
                        {
                            grid[row][col] = 2;
                            isRottened = true;
                            q.Enqueue(new int[] { row, col });
                        }
                    }
                }

                if (!isRottened)
                {
                    for (var i = 0; i < grid.Length; i++)
                    {
                        for (var j = 0; j < grid[0].Length; j++)
                        {
                            if (grid[i][j] == 1)
                            {
                                return -1;
                            }
                        }
                    }

                    return steps;
                }
                 
                steps++;
            }

            return -1;
        }

        private static bool IsSafe(int[][] grid, int x, int y)
        {
            if(x >= 0 && x < grid.Length && y >=0 && y < grid[0].Length && grid[x][y] == 1)
            {
                return true;
            }
            return false;
        }
    }
}
