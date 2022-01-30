using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.BackTracking
{
    internal class SudokuSolver
    {
        public static void Test()
        {

        }

        private static bool SolveSudoku(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; i < board[i].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValid(board, c, i, j))
                            {
                                board[i][j] = board[i][j];
                                
                                if (SolveSudoku(board))
                                    return true;
                                else
                                    board[i][j] = '.';
                            }
                         }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsValid(char[][] board, char val, int row, int col)
        {
            for(int i = 0; i < 9;i++)
            {
                if (board[row][i] == val)
                    return false;
                if (board[i][col] == val)
                        return false;
                if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == val)
                    return false;
            }
            return true;
        }

    }
}
