using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{

    public class NumberOfProvince
    {
        static int[] rows = {0, 1, 0, -1};
        static int[] cols = {-1, 0, 1, 0};

        public static void Test()
        {
            var mat = new int[][]
            {
                new int[]{1, 0, 0, 1 },
                new int[]{0, 1, 1, 0 },
                new int[]{0, 1, 1, 1 },
                new int[]{1, 0, 1, 1 }
            };
            var res = FindCircleNum(mat);
        }

        private static int FindCircleNum(int[][] mat)
        {
            var visited = new bool[mat.Length];             
            var component = 0;
            for(int row = 0; row < mat.Length; row++)
            {
                if(!visited[row])
                {
                    BFS(mat, visited, row);
                    component++;
                } 
            }
            return component;
        }

        private static void BFS(int[][] M, bool[] visited, int row)
        {
            var q = new Queue<int>();
            q.Enqueue(row);
            while (q.Count > 0)
            {
                var currRow = q.Dequeue();
                visited[currRow] = true;
                for (int col = 0; col < M.Length; col++)
                {
                    if (M[currRow][col] == 1 && !visited[col])
                        q.Enqueue(col);
                }
            }
        }

        private static void DFS(int[][] M, bool[] visited, int row)
        {
            for (int col = 0; col < M.Length; col++)
            {
                if (M[row][col] == 1 && !visited[col])
                {
                    visited[col] = true;
                    DFS(M, visited, col);
                }
            }
        }
    }
}
