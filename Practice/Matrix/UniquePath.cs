using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Matrix
{
    class UniquePath
    {
        public static void Test()
        {
            MyPath(4, 4);
        }

        public static int Compute(int m, int n)
        {
            {
                // Create a 2D table to store results 
                // of subproblems 
                int[,] count = new int[m, n];

                // Count of paths to reach any cell in 
                // first column is 1 
                for (int i = 0; i < m; i++)
                    count[i, 0] = 1;

                // Count of paths to reach any cell in 
                // first column is 1 
                for (int j = 0; j < n; j++)
                    count[0, j] = 1;

                // Calculate count of paths for other 
                // cells in bottom-up manner using 
                // the recursive solution 
                for (int i = 1; i < m; i++)
                {
                    for (int j = 1; j < n; j++)

                        // By uncommenting the last part the 
                        // code calculatest he total possible paths 
                        // if the diagonal Movements are allowed 
                        count[i, j] = count[i - 1, j] + count[i, j - 1]; //+ count[i-1][j-1]; 
                }
                return count[m - 1, n - 1];
            }

        }

        static int MyPath(int m, int n)
        {
            var count = new int[m, n];
            for (var i = 0; i < m; i++)
            {
                count[i, 0] = 1;
            }
            for (var i = 0; i < n; i++)
            {
                count[0, i] = 1;
            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    count[i, j] = count[i - 1, j] + count[i, j - 1];
                }
            }
            return count[m - 1, n - 1];
        }

        static int numberOfPaths(int m, int n)
        {
            // Create a 1D array to store 
            // results of subproblems 
            int[] dp = new int[n];
            dp[0] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[j] += dp[j - 1];
                }
            }

            return dp[n - 1];
        }
    }
}
