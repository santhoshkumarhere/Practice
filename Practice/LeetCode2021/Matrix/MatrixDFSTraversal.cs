using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class MatrixDFSTraversal
    {
        //left, down, right, top
        private static int[] rows = { 0, 1, 0, -1};
        private static int[] cols = { -1, 0, 1, 0 };

        public static  void Test()
        {
            var mat = new int[,] {
                {1, 2, 3},
                {5, 6, 7},
                {9, 10, 11}
            };
            DFS(0, 0, mat);
        }

        private static void DFS(int row, int col, int[,] mat)
        {
           var visited = new bool[mat.Length, mat.GetLength(0)];

           var stack = new Stack<int[]>();
            stack.Push(new int[] { row, col });

            while (stack.Count > 0)
            {
                var currentPosition = stack.Pop();

                var currentRow = currentPosition[0];
                var currentCol = currentPosition[1];

                if (!IsSafe(currentRow, currentCol, visited, mat))
                    continue;

                Console.Write(mat[currentRow, currentCol] + " " );

                visited[currentRow, currentCol] = true;

                for(int i = 0; i < 4; i++)
                {
                    var nextRow = currentRow + rows[i];
                    var nextCol = currentCol + cols[i];
                    stack.Push(new int[]{nextRow, nextCol });
                }
            }
        }

        private static bool IsSafe(int row, int col, bool[,] visited, int[,] mat)
        {
            if(row >= 0 && row < mat.GetLength(0) && col >=0 && col < mat.GetLength(1) && !visited[row, col])
            {
                return true;
            }

            return false;
        }
    }
}
