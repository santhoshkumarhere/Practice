using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class UniquePath
    {
        public static void Test()
        {
            var res = UniquePaths(3, 2);
        }

        private static int UniquePaths(int m, int n)
        {
            if (m == 1) return 1;
            var mat = new int[m, n];

            for(int i = 1; i < n; i++)
            {
                mat[0, i] = 1;
            }
            for(int j = 1; j < m; j++)
            {
                mat[j, 0] = 1;
            }

            for(int row = 1; row < m; row++)
            {
                for(int col = 1; col < n; col++)
                {
                    mat[row, col] = mat[row - 1, col] + mat[row, col - 1];
                }
            }

            return mat[m - 1, n - 1];
        }
    }
}
