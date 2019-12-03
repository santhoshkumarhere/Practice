namespace Practice.Graph
{
    using System;
    using System.Collections.Generic;
    public class ShortestPathTreasureIsland
    {

        private static int[] row = { 1, 0, -1, 0 };
        private static int[] col = { 0, 1, 0, -1 };
        public static int minSteps(char[,] grid)
        {
            Queue<Pair> q = new Queue<Pair>();
            q.Enqueue(new Pair(0, 0));
            grid[0, 0] = 'D'; // mark as visited
            Console.WriteLine($"({0}, {0})");
            int steps = 1;
            while (q.Count > 0)
            {
                Console.WriteLine(steps);
                for (int sz = q.Count; sz > 0; sz--)
                {
                    Pair p = q.Dequeue();

                    for (int k = 0; k < 4; k++)
                    {
                        int r = p.x + row[k];
                        int c = p.y + col[k];

                        if (isSafe(grid, r, c))
                        {
                            if (grid[r, c] == 'X')
                            {
                                return steps;
                            }
                            grid[r, c] = 'D';
                            q.Enqueue(new Pair(r, c));
                            Console.WriteLine($"({r}, {c})");
                        }
                    }
                }
                steps++;
            }
            return -1;
        }

        private static bool isSafe(char[,] grid, int r, int c)
        {
            return r >= 0 && r < grid.GetLength(0) && c >= 0 && c < grid.GetLength(1) && grid[r, c] != 'D';
        }


        public static void main()
        {
            char[,] grid = {{'O', 'O', 'O', 'O'},
                         {'D', 'O', 'D', 'O'},
                         {'O', 'O', 'O', 'O'},
                         {'X', 'D', 'D', 'O'}};
            int shortestPath = minSteps(grid);
            Console.Write(shortestPath);
        }
    }
}
