using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class Search2DMatrix
    {
        public static void Test()
        {
            var nums = new int[][]
            {
                new int[]{ 1, 3, 5, 7 },
                new int[]{ 10, 11, 16, 20 },
                new int[]{ 23, 30, 34, 60 }
            };
            var res = SearchMatrix(nums, 3);
        }

        private static bool SearchMatrix(int[][] matrix, int target)
        {
            var row = matrix.Length;
            if (row == 0) return false;
            var col = matrix[0].Length;

            var left = 0;
            var right = row * col - 1; // treating the matrix as a single array

            while(left <= right)
            {
                var middle = (left + right) / 2;
                var middleElement = matrix[middle / col][middle % col];
                if (middleElement == target)
                    return true;
                else if (middleElement > target)
                    right = middle - 1;
                else
                    left = middle + 1;
            }
            return false;
        }
    }
}
