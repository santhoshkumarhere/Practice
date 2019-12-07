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
        // Below arrays details all 8 possible movements from a cell
        // (top, right, bottom, left and 4 diagonal moves)
        //private static int[] row = { -1, -1, -1, 0, 1, 0, 1, 1 };
        //private static int[] col = { -1, 1, 0, -1, -1, 1, 0, 1 };

        public static readonly int[] row =  { -1, -1, -1,  0, 0,  1, 1, 1 };
        private static readonly int[] col = { -1,  0,  1, -1, 1, -1, 0, 1 };

        // Function to check if it is safe to go to position (x, y)
        // from current position. The function returns false if (x, y)
        // is not valid matrix coordinates or (x, y) represents water or
        // position (x, y) is already processed
        public static bool isSafe(int[,] mat, int x, int y,
                                 bool[,] processed)
        {
            return (x >= 0) && (x < processed.GetLength(0)) && (y >= 0) && (y < processed.GetLength(1)) && (mat[x,y] == 1 && !processed[x,y]);
        }

        public static void BFS(int[,] mat, bool[,] processed, int i, int j)
        {
            // create an empty queue and enqueue source node
            Queue<Pair> q = new Queue<Pair>();
            q.Enqueue(new Pair(i, j));

            // mark source node as processed
            processed[i,j] = true;
            int count = 0;
            // run till queue is not empty
            while (q.Count > 0)
            {
                // pop front node from queue and process it
                int x = q.Peek().x;
                int y = q.Peek().y;
                q.Dequeue();
                count++;
                // check for all 8 possible movements from current cell
                // and enqueue each valid movement
                for (int k = 0; k < 8; k++)
                {
                    // Skip if location is invalid or already processed 
                    // or has water
                    if (isSafe(mat, x + row[k], y + col[k], processed))
                    {
                        // skip if location is invalid or it is already
                        // processed or consists of water
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

            // stores if cell is processed or not
            bool[,] processed = new bool[M,N];

            int island = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // start BFS from each unprocessed node and
                    // increment island count
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
