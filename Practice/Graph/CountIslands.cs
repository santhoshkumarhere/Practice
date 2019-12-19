using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Graph
{

    class Pair
    {
        public int x, y;

        public Pair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class CountIslands
    {
        public static readonly int[] row =  { -1, -1, -1,  0, 0,  1, 1, 1 };
        private static readonly int[] col = { -1,  0,  1, -1, 1, -1, 0, 1 };

        public static bool isSafe(int[,] mat, int x, int y,
                                 bool[,] processed)
        {
            return (x >= 0) && (x < processed.GetLength(0)) && (y >= 0) && (y < processed.GetLength(1)) && (mat[x,y] == 1 && !processed[x,y]);
        }

        public static void BFS(int[,] mat, bool[,] processed, int i, int j)
        {
            Queue<Pair> q = new Queue<Pair>();
            q.Enqueue(new Pair(i, j));

            processed[i,j] = true;
            int count = 0;
            while (q.Count > 0)
            {
                int x = q.Peek().x;
                int y = q.Peek().y;
                q.Dequeue();
                count++;
                for (int k = 0; k < 8; k++)
                {
                    if (isSafe(mat, x + row[k], y + col[k], processed))
                    {
                        processed[x + row[k],y + col[k]] = true;
                        q.Enqueue(new Pair(x + row[k], y + col[k]));
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static void Test()
        {
            int[,] mat =
            {
            { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1 },
            { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 1, 0, 0, 0 },
            { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 },
            { 0, 1, 0, 1, 0, 0, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 1, 1, 1, 0 },
            { 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 }
        };

            int M = mat.GetLength(0);
            int N = mat.GetLength(1);

            bool[,] processed = new bool[M,N];

            int island = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (mat[i,j] == 1 && !processed[i,j])
                    {
                        BFS(mat, processed, i, j);
                        island++;
                    }
                }
            }

            Console.Write("Number of islands are " + island);
        }
    }
}
