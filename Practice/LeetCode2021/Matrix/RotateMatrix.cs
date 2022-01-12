using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Matrix
{
    internal class RotateMatrix
    {
        public static void Test()
        {
            int[][] input =
                {
                    new int[]{1, 2, 3},
                    new int[]{4, 5, 6},
                    new int[]{7, 8, 9}
                };

            RotateClockwise(input);
        }

        private static void RotateClockwise(int[][] mat)
        {

            var m = mat.Length;
            var n = mat[0].Length;

            for (int row = 0; row < m; row++)
            {
                for (int col = row + 1; col < n; col++) // or simple start col with row without +1
                {
                    var temp = mat[row][col];
                    mat[row][col] = mat[col][row];
                    mat[col][row] = temp;
                }
            }

            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n / 2; col++)
                {
                    var temp = mat[row][col];
                    mat[row][col] = mat[row][n - col - 1];
                    mat[row][n - col - 1] = temp;
                }
            }
        }
    }
}
