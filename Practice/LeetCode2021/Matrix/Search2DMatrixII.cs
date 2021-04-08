using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class Search2DMatrixII
    {
        static int[][] mat;
        static int target;

        public static void Test()
        {
            var matrix = new int[][]
            {
                new int[]{ 1, 4, 7, 11, 15 },
                new int[]{ 2, 5, 8, 12, 19 },
                new int[]{ 3, 6, 9, 16, 22 },
                new int[]{ 10, 13, 14, 17, 24},
                new int[]{ 18, 21, 23, 26, 30},
            };

            var res = SearchMatrix(matrix, 5);
        }

        private static bool SearchMatrix(int[][] matrix, int target)
        {
            var row = matrix.Length - 1;
            var col = 0;

            while(row >= 0 && col <= matrix[0].Length - 1)
            {
                var curr = matrix[row][col];
                if (curr > target)
                    row--;
                else if (curr < target)
                    col++;
                else
                    return true;
            }

            return false;
        }

        private static bool SearchMatrixII(int[][] matrix, int tar)
        {
            mat = matrix;
            target = tar;
            var res = searchRec(0, 0, matrix[0].Length - 1, matrix.Length - 1);

            return res;
        }

        private static bool searchRec(int left, int up, int right, int down)
        {
            // this submatrix has no height or no width.
            if (left > right || up > down)
            {
                return false;
                // `target` is already larger than the largest element or smaller
                // than the smallest element in this submatrix.
            }
            else if (target < mat[up][left] || target > mat[down][right])
            {
                return false;
            }

            int mid = left + (right - left) / 2;

            // Locate `row` such that matrix[row-1][mid] < target < matrix[row][mid]
            int row = up;
            while (row <= down && mat[row][mid] <= target)
            {
                if (mat[row][mid] == target)
                {
                    return true;
                }
                row++;
            }

            return searchRec(left, row, mid - 1, down) || searchRec(mid + 1, up, right, row - 1);
        }
    }
}
