using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class MatrixTest
    {
        public static void Test()
        {
            char[,] mat = { {'X', 'O', 'O'},
                            {'X', 'X', 'O'},
                            {'X', 'X', 'O'},
                            {'O', 'O', 'X'},
                            {'O', 'O', 'X'},
                            {'X', 'X', 'O'}
            };
            countIslands(mat, 6, 3);

            //int[,] mats = { {1, 1, 0, 0, 0},
            //                {0, 1, 0, 0, 1},
            //                {1, 0, 0, 1, 1},
            //                {0, 0, 0, 0, 0},
            //                {1, 0, 1, 0, 1}
            //};
            //var res = countIsLand(mats, 5, 5);

        }

        public int countComponents(int n, int[][] edges)
        {
            int count = n;

            int[] root = new int[n];
            // initialize each node is an island
            for (int i = 0; i < n; i++)
            {
                root[i] = i;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                int x = edges[i][0];
                int y = edges[i][1];

                int xRoot = getRoot(root, x);
                int yRoot = getRoot(root, y);

                if (xRoot != yRoot)
                {
                    count--;
                    root[xRoot] = yRoot;
                }

            }

            return count;
        }

        public int getRoot(int[] arr, int i)
        {
            while (arr[i] != i)
            {
                arr[i] = arr[arr[i]];
                i = arr[i];
            }
            return i;
        }

        static int countIsLand(int[,] mat, int m, int n)
        {
            var count = 0;

            for( var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (mat[i, j] == 1)
                    {
                        if (i == 0 && (j == 0 || mat[i, j - 1] == 0))
                        {
                            count++;
                        }
                        

                        if ((i == 0 || mat[i - 1, j] == 0 ) && (j == 0 || mat[i, j - 1] == 0))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        static int countIslands(char[,] mat, int m, int n)
        {

            // Initialize result 
            int count = 0;

            // Traverse the input matrix 
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // If current cell is 'X', then check 
                    // whether this is top-leftmost of a 
                    // rectangle. If yes, then increment 
                    // count 
                    if (mat[i, j] == 'X')
                    {
                        if ((i == 0 || mat[i - 1, j] == 'O') && (j == 0 || mat[i, j - 1] == 'O'))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        } 
    }
}
