﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class LengthOfHistogram_Hard_
    {
        public static void Test()
        {
            var arr = new int[]  { 6, 2, 5, 4, 5, 1, 6 };
            var res = LengthOfHistogram(arr);
        }

        private static int LengthOfHistogram(int[] arr)
        {
            var max_area = 0;
            var stack = new Stack<int>();

            for(int i = 0; i<= arr.Length; i++)
            {
                var currentElement = (i == arr.Length) ? 0 : arr[i]; // handle last element 
                if (stack.Count == 0 || currentElement >= arr[stack.Peek()])
                    stack.Push(i);
                else
                {
                    var height = arr[stack.Pop()];
                    var width = stack.Count == 0 ? i : (i - 1 - stack.Peek());
                    max_area = Math.Max(max_area, height * width);
                    i--;
                }
            }
            return max_area;
        }
    }
}
