using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Practice.MiscProb
{
    class RotateMatrix
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

        public static void RotateAntiClockWise(int[][] mat)
        {
            var length = mat.Length;

            for (var i = 0; i < length / 2; i++)
            {
                for (var j = i; j < length - i - 1; j++)
                {
                    var temp = mat[i][j];
                    mat[i][j] = mat[j][length - 1 - i];
                    mat[j][length - 1 - i] = mat[length - 1 - i][length - 1 - j];
                    mat[length - 1 - i][length - 1 - j] = mat[length - 1 - j][i];
                    mat[length - 1 - j][i] = temp;
                }
            }

        }

        public static void RotateClockwise(int[][] mat)
        {
            var length = mat.GetLength(0);

            for (var i = 0; i < length / 2; i++)
            {
                for (var j = i; j < length - i - 1; j++)
                {
                    var temp = mat[i][j];
                    mat[i][j] = mat[length - 1 - j][i];
                    mat[length - 1- j][i] = mat[length - 1 - i][length - 1 - j];

                    mat[length - i - 1][length - 1 - j] = mat[j][length - 1 - i];
                    mat[j][length - 1 - i] = temp;
                }
            }
        }

        //public static void Rotate(int[,] matrix)
        //{
        //    var length = matrix.GetLength(0);
            
        //    for (int row = 0; row < length / 2; row++)
        //    {
        //        for (int col = row; col < length - row - 1; col++)
        //        {
        //            // Swap elements of each cycle 
        //            // in clockwise direction 
        //            int temp = matrix[row, col];

        //            matrix[row, col] = matrix[length - 1 - col, row]; //Left most corner bottom

        //            matrix[length - 1 - col, row] = matrix[length - 1 - row, length - 1 - col]; // Right most corner bottom

        //            matrix[length - 1 - row, length - 1 - col] = matrix[col, length - 1 - row]; //Right most top corner

        //            matrix[col, length - 1 - row] = temp;
        //        }
        //    }
        //}
    }
}
 

//int temp = matrix[row, col];
//matrix[row, col] = matrix[N - 1 - col, row];
//matrix[N - 1 - col, row] = matrix[N - 1 - row, N - 1 - col];
//matrix[N - 1 - row, N - 1 - col] = matrix[col, N - 1 - row];
//matrix[col, N - 1 - row] = temp;