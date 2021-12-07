using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.MonotonicStack
{
    public class MinimalRectangle
    {
        public static void Test()
        {

            var matrix = new char[][]
                {
                    new char[] { '1', '0', '1', '1', '0'},
                    new char[] { '1', '0', '1', '1', '1'},
                    new char[] { '1', '0', '1', '1', '1'},
                    new char[] { '1', '0', '1', '0', '0'}
                };
            var res = MaximalRectangle(matrix);
        }

        private static int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            var dp = new int[matrix[0].Length];
            var max_area = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    dp[j] = matrix[i][j] == '1' ? 1 + dp[j] : 0;
                }
                max_area = Math.Max(max_area, LengthOfHistogram(dp));
            }
            return max_area;
        }

        private static int LengthOfHistogram(int[] dp)
        {
            var stack = new Stack<int>();
            var max_area = 0;
            stack.Push(-1);
            for(int i = 0; i <= dp.Length; i++)
            {
                var currElement = i == dp.Length ? 0 : dp[i];
                while(stack.Peek() != -1 && currElement < dp[stack.Peek()])
                {
                    var height = dp[stack.Pop()];
                    var width  = i - stack.Peek() - 1;
                    max_area = Math.Max(max_area, height * width);
                }
                stack.Push(i);
            }

            return max_area;
        }
        
    }
}
