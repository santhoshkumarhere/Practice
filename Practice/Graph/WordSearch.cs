using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Graph
{
    class WordSearch
    {
        private static int rows;
            private static int columns;
            static bool[,] visited;
    public static void Test()
    {
            //var board1 = new char[][]{  new char[]{'A','B','C','E'},
            //                            new char[]{'S','F','C','S'},
            //                            new char[]{'A','D','E','E'}
            //            };

            //var board2 = new char[][]{ new char[]{'C','A','A'},
            //                           new char[]{'A','A','A'},
            //                           new char[]{'B','C','D'}
            //            };

            //var board3 = new char[][]{
            //                new char[]{'a', 'b'},
            //                new char[]{'c', 'd'}};

            //var word1 = "FDS";
            var word1 = "AAB"; 

            //var res = Exist(board1, word1);
            //var res2 = Exist(board2, word2);
            //var res3 = Exist(board1, "SEE");
            //var res4 = Exist(board1, "FDS");
            //var res5 = Exist(board3, "abcd");


            var board1 = new char[][]{ new char[]{'C','A','A'},
                                       new char[]{'A','A','A'},
                                       new char[]{'B','C','D'}
                    };

            var res = Exist(board1, word1);
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
        if (Search(board, word, wordIndex + 1, i + 1, j) || 
            Search(board, word, wordIndex + 1, i, j + 1) ||
            Search(board, word, wordIndex + 1, i - 1, j) ||
            Search(board, word, wordIndex + 1, i, j - 1))
            {
                return true;
            }

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
