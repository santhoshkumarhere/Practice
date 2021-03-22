using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class WordSearch
    {
        public static void Test()
        {
            var word1 = "CAB";
            var board1 = new char[][]{ new char[]{'C','A','A'},
                                       new char[]{'A','A','A'},
                                       new char[]{'B','C','D'}
                    };

            var res = Exist(board1, word1);
        }

        private static bool Exist(char[][] board, string word)
        {
            var m = board.Length;
            var n = board[0].Length;
            var visited = new bool[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (board[i][j] == word[0] && Search(i, j, 0, word, board, visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool Search(int i, int j, int wordIndex, string word, char[][] board, bool[,] visited)
        {
            if (wordIndex == word.Length)
                return true;

            if (!IsSafe(i, j, wordIndex, word, board, visited))
                return false;

            visited[i, j] = true;

            if (Search(i - 1, j, wordIndex + 1, word, board, visited) ||
                Search(i, j + 1, wordIndex + 1, word, board, visited) ||
                Search(i + 1, j, wordIndex + 1, word, board, visited) ||
                Search(i, j - 1, wordIndex + 1, word, board, visited))
                return true;

            visited[i, j] = false;
            return false;
        }

        private static bool IsSafe(int i, int j, int wordIndex, string word, char[][] board, bool[,] visited)
        {
            if (i >= 0 && i < board.Length && j >= 0 && j < board[0].Length && visited[i, j] == false && board[i][j] == word[wordIndex])
                return true;
            return false;
        }
    }
}
