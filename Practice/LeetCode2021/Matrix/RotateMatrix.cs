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

            int[][] input2 =
               {
                    new int[]{1,  2,  3,  4,  5},
                    new int[]{6,  7,  8,  9,  10},
                    new int[]{11, 12, 13, 14, 15},
                    new int[]{16, 17, 18, 19, 20},
                    new int[]{21, 22, 23, 24, 25}
                };

            RotateClockwise(input);
        }

        private static void RotateClockwise2022(int[][] mat)
        {
            var length = mat.Length;

            for(int row = 0; row < length / 2; row++) // image in 5x5 matrix we have three layers 0 < 3 -> we have to process three outer layers
            {
                for(int col = row; col < length - row - 1; col++) // tip - (0, 4) no to be processed.  tip 2 - after each rotation column right and let side decrement by one
                {
                    //see row/col swap
                    var temp = mat[row][col];

                    mat[row][col] = mat[length - col - 1][row]; //[(0, 0) (4, 0)] [(0, 1) (3, 0)] [(0, 2) (2, 0)] => 0th row 0th colomn
                    mat[length - col - 1][row] = mat[length - row - 1][length - col - 1]; // (4, 0) (4, 4)
                    mat[length - row - 1][length - col - 1] = mat[col][length - row - 1];  //(4, 4) (0, 4)) 
                    mat[col][length - row - 1] = temp;
                }
            }
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
