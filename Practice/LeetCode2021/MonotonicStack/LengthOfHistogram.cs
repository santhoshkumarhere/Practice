using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.MonotonicStack
{
    public class LengthOfHistogram
    {
        public static void Test()
        {
            var arr = new int[] { 6, 2, 5, 4, 5, 1, 6 };
            var arr2 = new int[] { 2, 1, 5, 6, 2, 3 };
            var res = LengthOfHistograms(arr);
            res = LengthOfHistogramsV2(arr);
        }

        private static int LengthOfHistogramsV2(int[] arr)
        {
            var max_area = 0;
            var stack = new Stack<int>();
            int end = 0; 
            while (end <= arr.Length)
            {
                var currentElement = (end == arr.Length) ? 0 : arr[end];

                while (stack.Count > 0 && currentElement < arr[stack.Peek()])
                {
                    var height = arr[stack.Pop()];                                                                                 // *
                    var width = stack.Count == 0 ? end : (end - stack.Peek() - 1); // gap between left and right of current element 2 4 2
                    max_area = Math.Max(max_area, height * width);
                }
                stack.Push(end); // push index only
                end++;
            }

            return max_area;
        }

        private static int LengthOfHistograms(int[] arr)
        {
            var max_area = 0;
            var stack = new Stack<int>();
            int end = 0;

            while (end <= arr.Length)
            {
                var currentElement = (end == arr.Length) ? 0 : arr[end];

                if (stack.Count == 0 || currentElement >= arr[stack.Peek()])
                {
                    stack.Push(end); // push index only
                    end++;
                }
                else
                {
                    while (stack.Count > 0 && currentElement < arr[stack.Peek()])
                    {
                        var height = arr[stack.Pop()];                                                      // *
                        var width = stack.Count == 0 ? end : (end - stack.Peek() - 1); // gap between left and right of current element 2 4 2
                        max_area = Math.Max(max_area, height * width);
                    }
                }                
            }
             
            return max_area;
        }
    }
}
