using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class LongestRectangularArea
    {
        public static void Test()
        {
           var res = largestRectangleArea(new int[] { 6, 7, 5, 2, 4, 5, 9, 3 });
           // var res = largestRectangleArea(new int[] { 6, 2, 5, 4, 5, 1, 6 });
        }

        private static int largestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int length = heights.Length;
            int maxArea = 0;
            for (int i = 0; i < length; i++)
            {
                while ((stack.Peek() != -1)
                        && (heights[stack.Peek()] >= heights[i]))
                {
                    int currentHeight = heights[stack.Pop()];
                    int currentWidth = i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, currentHeight * currentWidth);
                }
                stack.Push(i);
            }
            while (stack.Peek() != -1)
            {
                int currentHeight = heights[stack.Pop()];
                int currentWidth = length - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);
            }
            return maxArea;
        }
    }
}
