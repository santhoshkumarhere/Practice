using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Matrix
{
    public class SpiralMatrix
    {
        public static void Test()
        {
            var matrix = new int[][]
            {
               new int[] {1, 2, 3, 4},
               new int[] {5, 6, 7, 8},
               new int[] {9, 10, 11, 12}
            };
            var result = SpiralOrder(matrix); //Output: [1,2,3,4,8,12,11,10,9,5,6,7]

        }

        private static IList<int> SpiralOrder(int[][] matrix)
        {
            var res = new List<int>();
            var rowBegin = 0;
            var rowEnd = matrix.Length - 1;
            var colBegin = 0;
            var colEnd = matrix[0].Length - 1;

            while(rowBegin <= rowEnd && colBegin <= colEnd)
            {
                for(var i = colBegin; i <= colEnd; i++)
                {
                    res.Add(matrix[rowBegin][i]);
                }
                rowBegin++;

                for(var i = rowBegin; i <= rowEnd; i++)
                {
                    res.Add(matrix[i][colEnd]);
                }
                colEnd--;

                if (rowEnd >= rowBegin) 
                {
                    for(var i = colEnd; i >= colBegin; i--)
                    {
                        res.Add(matrix[rowEnd][i]);
                    }
                }
                rowEnd--;

                if (colEnd >= colBegin)
                {
                    for(var i = rowEnd; i >= rowBegin; i--)
                    {
                        res.Add(matrix[i][colBegin]);
                    }
                }

                colBegin++;
            }
            return res;
        }
    }
}
