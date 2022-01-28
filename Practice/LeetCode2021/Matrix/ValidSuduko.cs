using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Matrix
{
    internal class ValidSuduko
    {
        public static void Test()
        {

        }

        private static bool ValidSudokoCheck(char[][] board)
        {
            var rowMap = new Dictionary<int, HashSet<int>>(); // check Neetcode easy implementation only
            var colMap = new Dictionary<int, HashSet<int>>();
            var squareMap = new Dictionary<(int, int), HashSet<int>>(); //key row/3 col/3

            for (int i = 0; i < 10; i++)
            {
                rowMap[i] = new HashSet<int>();
                colMap[i] = new HashSet<int>();
                squareMap[(i/3, i%3)] = new HashSet<int>(); 
                /* 0 => 0, 0 i/3  , i%3
                 * 1 => 0, 1   
                 * 2 => 0, 2 
                 * 3 => 1, 0
                 * 4 => 1, 1
                 * 5 => 1, 2
                 * 6 => 2, 0
                 * 7 => 2, 1
                 * 8 => 2, 2
                 **/
            }

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == '.')
                    {
                        continue;
                    }

                    var currValue = int.Parse(board[row][col] + "");
                    if(rowMap[row].Contains(currValue) || colMap[col].Contains(currValue) || squareMap[(row/3, col/3)].Contains(currValue))
                    {
                        return false;
                    }
                    rowMap[row].Add(currValue);
                    colMap[col].Add(currValue);
                    squareMap[(row / 3, col / 3)].Add(currValue);
                }
            }

            return true;
        }
    }
}
