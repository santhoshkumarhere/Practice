using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Graph
{
    class WordSearch
    {


        private static int[] rows1 = { -1, 0, 1, 0 };
        private static int[] cols1 = { 0, 1, 0, -1 };

        private static int rows;
            private static int columns;
            static bool[,] visited;
    public static void Test()
    {
        var board1 = new char[][]{  new char[]{'A','B','C','E'},
                                    new char[]{'S','F','C','S'},
                                    new char[]{'A','D','E','E'}
                    };

        var board2 = new char[][]{ new char[]{'C','A','A'},
                                   new char[]{'A','A','A'},
                                   new char[]{'B','C','D'}
                    };

        var board3 = new char[][]{
                        new char[]{'a', 'b'},
                        new char[]{'c', 'd'}};

        var word1 = "FDS";
        var word2 = "AAB"; 

        //var res = Exist(board1, word1);
        //var res2 = Exist(board2, word2);
        //var res3 = Exist(board1, "SEE");
        //var res4 = Exist(board1, "FDS");
        //var res5 = Exist(board3, "abcd");

            var q = new Queue<int[]>();
            for(var i = 0; i < board1.Length; i++)
            {
                for(var j = 0; j < board1[0].Length; j++)
                {
                    if(board1[i][j] == word1[0])
                    {
                        q.Enqueue(new int[] { i, j });
                        var res =  BFS(q, board1, word1);
                        if (res) return;
                    }
                }
            } 
    }

        public static bool BFS(Queue<int[]> q, char[][] board, string word)
        {
            var index = 1;
            visited = new bool[board.Length, board[0].Length];
            var currentSearch = new StringBuilder();
            currentSearch.Append(word[0]);
            
            while (q.Count > 0)
            {
                for(var size = q.Count; size > 0; size--)
                {
                    var p = q.Dequeue();
                    visited[p[0], p[1]] = true;
                    var isNeighbourExists = false;
                    for (var k = 0; k < 4; k++)
                    {
                        var x = p[0] + rows1[k];
                        var y = p[1] + cols1[k];
                        if(currentSearch.Equals(word))
                        {
                            return true;
                        }

                        if(IsSafe(board, x, y, word[index]))
                        {
                            visited[x, y] = true;
                            isNeighbourExists = true;
                            currentSearch.Append(word[index]);
                            q.Enqueue(new int[] { x, y });
                        }
                    }

                    if(isNeighbourExists)
                    index++;
                }
            }
            return false;
        }

    public static bool Exist(char[][] board, string word)
    {
        // init
        rows = board.Length;
        columns = board[0].Length;
        visited = new bool[rows, columns];

        // search one by one
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (board[i][j].Equals(word[0]) && Search(board, word, 0, i, j))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool Search(char[][] board, string word, int wordIndex, int i, int j)
    {
        // word search is already finished
        if (wordIndex == word.Length) return true;


        if (!IsSafe(board, i, j, word[wordIndex]))           // char does not match
        {
            return false;
        }

        // mark current position as visited
        visited[i, j] = true;

        //  // down, right, top, left
        if (Search(board, word, wordIndex + 1, i + 1, j)) return true;
        if (Search(board, word, wordIndex + 1, i, j + 1)) return true;
        if (Search(board, word, wordIndex + 1, i - 1, j)) return true;
        if (Search(board, word, wordIndex + 1, i, j - 1)) return true;

        // not found, restore current position to unvisited
        visited[i, j] = false;
        return false;
    }
    private static bool IsSafe(char[][] board, int x, int y, char c)
    {
        if (x >= 0 && x < board.Length && y >= 0 && y < board[0].Length && board[x][y].Equals(c) && !visited[x, y])
        {
            return true;
        }
        return false;
    }
}
}
