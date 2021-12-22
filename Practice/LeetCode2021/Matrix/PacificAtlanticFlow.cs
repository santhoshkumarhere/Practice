using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Matrix
{
    internal class PacificAtlanticFlow
    {
        private static int[] rows = { 1, -1, 0, 0 };
        private static int[] cols = { 0, 0, 1, -1 };

        public static void Test()
        {
            var mat = new int[][]
            {
                new int[]{ 1,2, 2, 3, 5},
                new int[]{ 3, 2, 3, 4, 4 },
                new int[] {2, 4, 5, 3, 1 },
                new int[] {6, 7, 1, 4, 5 },
                new int[] {5, 1, 1, 2, 4}
            };
            var res = PacificAtlantic(mat);
        }

        private static IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            var result = new List<IList<int>>();
            if (heights == null || heights.Length == 0 || heights[0].Length == 0)
            {
                return result;
            }
            var row = heights.Length;
            var col = heights[0].Length;
            bool[,] pacific = new bool[row, col];
            bool[,] atlantic = new bool[row, col];

            var pacificQ = new Queue<int[]>();
            var atlanticQ = new Queue<int[]>();

            for (int i = 0; i < col; i++)
            {
                pacific[0, i] = true;
                atlantic[row - 1, i] = true;
                pacificQ.Enqueue(new int[] { 0, i });
                atlanticQ.Enqueue(new int[] { row - 1, i });
            }

            for (int i = 0; i < row; i++)
            {
                pacific[i, 0] = true;
                atlantic[i, col - 1] = true;
                pacificQ.Enqueue(new int[] { i, 0 });
                atlanticQ.Enqueue(new int[] { i, col - 1 });
            }
            BFS(heights, pacificQ, row, col, pacific);
            BFS(heights, atlanticQ, row, col, atlantic);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (pacific[i, j] && atlantic[i, j])
                    {
                        var list = new List<int>();
                        list.Add(i);
                        list.Add(j);
                        result.Add(list);
                    }
                }
            }
            return result;
        }

        private static void BFS(int[][] heights, Queue<int[]> q, int row, int col, bool[,] visited)
        {
            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    var nextRow = curr[0] + rows[i];
                    var nextCol = curr[1] + cols[i];

                    if (nextRow >= 0 && nextRow < row && nextCol >= 0 && nextCol < col && !visited[nextRow, nextCol]
                        && heights[nextRow][nextCol] >= heights[curr[0]][curr[1]])
                    {
                        q.Enqueue(new int[] { nextRow, nextCol });
                        visited[nextRow, nextCol] = true;
                    }
                }
            }
        }
    }
}
