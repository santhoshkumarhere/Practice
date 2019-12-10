using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.GraphProblems
{
    class GameOfLifeProblem
    {

        private static int[] rows = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        private static int[] cols = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        private static bool IsSafe(int[][] board, int x, int y)
        {
            if (x >= 0 && x < board.Length && y >= 0 && y < board[0].Length)
            {
                return true;
            }
            return false;
        }

        public static void Test()
        {

            var board = new int[][] { new int []{0, 1, 0 },
                                      new int []{0, 0, 1 },
                                      new int []{1, 1, 1},
                                      new int[] {0, 0, 0 }
                };
           var res =  GameOfLife(board);
        }

        public static int[][] GameOfLife(int[][] board)
        {

            int m = board.Length;
            int n = board[0].Length;
            bool[,] visited = new bool[m, n];

            var dupBoard = new int[m][];

            for (var i = 0; i < m; i++)
            {
                dupBoard[i] = new int[n];
                for (var j = 0; j < n; j++)
                {

                    dupBoard[i][j] = board[i][j];
                }
            }

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (!visited[i, j])
                    {
                        BFS(dupBoard, i, j, visited, board);
                    }
                }
            }
            return board;
        }

        private static void BFS(int[][] board, int i, int j, bool[,] visited, int[][] originalBoard)
        {
            var q = new Queue<int[]>();
            q.Enqueue(new int[] { i, j });
            visited[i, j] = true;
            while (q.Count > 0)
            {
                for (var size = q.Count; size > 0; size--)
                {
                    var p = q.Dequeue();
                    var noOfNeighbourLiveCells = 0;
                    var isCurrentLiveCell = board[p[0]][p[1]] == 1;
                    for (var k = 0; k < 8; k++)
                    {
                        var x = p[0] + rows[k];
                        var y = p[1] + cols[k];

                        if (IsSafe(board, x, y))
                        {
                            noOfNeighbourLiveCells = noOfNeighbourLiveCells + board[x][y];

                            if (!visited[x, y])
                            {
                                q.Enqueue(new int[] { x, y });
                            }
                            visited[x, y] = true;
                        }
                    }
                    UpdateLives(isCurrentLiveCell, noOfNeighbourLiveCells, originalBoard, p[0], p[1]);
                }
            }
        }

        private static void UpdateLives(bool isCurrentLiveCell, int noOfNeighbourLiveCells, int[][] originalBoard, int i, int j)
        {
            if (isCurrentLiveCell && (noOfNeighbourLiveCells > 3 || noOfNeighbourLiveCells < 2))
            {
                originalBoard[i][j] = 0;
            }
            else if (isCurrentLiveCell && (noOfNeighbourLiveCells == 2 || noOfNeighbourLiveCells == 3))
            {
                originalBoard[i][j] = 1;
            }
            else if (!isCurrentLiveCell && noOfNeighbourLiveCells == 3)
            {
                originalBoard[i][j] = 1;
            }
        }
    }
}
