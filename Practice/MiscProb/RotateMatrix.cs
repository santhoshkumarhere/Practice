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

        public static void RotateByTranspose(int[][] mat)
        {
            var length = mat.Length;

            for(int row = 0; row < length; row++)
            {
                for(int col = row; col < length; col++)
                {
                    var temp = mat[row][col];
                    mat[row][col] = mat[col][row];
                    mat[col][row] = temp;
                }                
            } // transpose

            //reverse
            for(int row = 0; row < length; row++)
            {
                for(int col = 0; col < length/2; col++)
                {
                    var temp = mat[row][col];
                    mat[row][col] = mat[row][length - 1 - col];
                    mat[row][length - 1 - col] = temp;
                }
            }
        }

        public static void RotateClockwise(int[][] mat)
        {
            var length = mat.Length;

            for (var row = 0; row < length / 2; row++)
            {
                for (var col = row; col < length - row - 1; col++)
                {
                    //think that replacing rows with columns & vice versa
                    //draw 4 x 4 matrix and then see this logic
                    var temp = mat[row][col];
                    mat[row][col] = mat[length - 1 - col][row];
                    mat[length - 1 - col][row] = mat[length - 1 - row][length - 1 - col];

                    mat[length - 1 - row][length - 1 - col] = mat[col][length - 1 - row];
                    mat[col][length - 1 - row] = temp;
                }
            }
        }

        public static void RotateAntiClockWise(int[][] mat)
        {
            var length = mat.Length;

            for (var row = 0; row < length / 2; row++)
            {
                for (var col = row; col < length - row - 1; col++)
                {
                    var temp = mat[row][col];
                    mat[row][col] = mat[col][length - 1 - row];
                    mat[col][length - 1 - row] = mat[length - 1 - row][length - 1 - col];
                    mat[length - 1 - row][length - 1 - col] = mat[length - 1 - col][row];
                    mat[length - 1 - col][row] = temp;
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