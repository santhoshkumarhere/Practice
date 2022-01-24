using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class NextGreaterElementsGeeks
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
            stack.Push(0);

            for(var i= 1; i < arr.Length; i++)
            {
                if(stack.Count > 0)
                {
                    var peek = stack.Peek();
                    if(arr[i] > arr[peek])
                    {
                        stack.Pop();
                        result[peek] = arr[i];
                        i--;
                        continue;                        
                    }
                }
                stack.Push(i);
            }
        }
    }
}
