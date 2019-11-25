using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Graph
{
    class ZombieMatrix
    {
 public static void Test()
        {
            int[,] mat = {{0, 1, 1, 0, 1},
                {0, 1, 0, 1, 0},
                {0, 0, 0, 0, 1},
                {0, 1, 0, 0, 0}};
            var x = mat.GetLength(0);
            var y = mat.GetLength(1);
            var result = BFS(mat, x, y);
            Console.Write(result);
        }

        private static int[] row = { 1, 0, 0, -1 };
        private static int[] col = {0, -1, 1, 0};


        public static int BFS(int[,] mat, int x, int y)
        {
            var processed = new bool[x, y];

            var q = new Queue<Pair>();
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if(mat[i, j] == 1)
                    q.Enqueue(new Pair(i, j));
                }
            }
            var  steps = 0;
            var turned = false;
            while (q.Count > 0)
            {
                for (var size = q.Count; size > 0; size--)
                {
                    var pair = q.Dequeue(); 

                    for (var k = 0; k < 4; k++)
                    {
                        var r = pair.x + row[k];
                        var c = pair.y + col[k];
                        if (IsValidToProcess(mat, r, c))
                        {
                            turned = true;
                            mat[r, c] = 1;
                            q.Enqueue(new Pair(r, c));
                        }
                    }

                }
                if (turned)
                {
                    steps++;
                    turned = false;
                }
                else
                {
                    return steps;
                }
            }
            return steps;
        }

        private static bool IsValidToProcess(int[,] mat, int x, int y)
        {
            if (x >= 0 && x < mat.GetLength(0) && y >= 0 && y < mat.GetLength(1) && mat[x, y] == 0)
            {
                return true;
            }
            return false;
        }

}
     
}
