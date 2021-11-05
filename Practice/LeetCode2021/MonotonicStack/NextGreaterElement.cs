using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.MonotonicStack
{
    public class NextGreaterElement
    {
        public static void Test()
        {
            NGE(new int[] { 11, 13, 21, 3 });
            NGE(new int[] { 13, 7, 6, 12, 10 });
        }

        private static void NGE(int[] arr)
        {
            var result = new int[arr.Length];

            Array.Fill(result, -1);

            var stack = new Stack<int>();

            var ptr = 0;

            while(ptr <= arr.Length)
            {
                var currentElement = ptr == arr.Length ? 0 : arr[ptr];

                while(stack.Count > 0 && currentElement > arr[stack.Peek()])
                {
                    result[stack.Pop()] = currentElement;
                }
                stack.Push(ptr);
                ptr++;
            }
        }
    }
}
