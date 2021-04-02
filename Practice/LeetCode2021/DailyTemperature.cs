using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class DailyTemperature
    {
        public static void Test()
        {
            var res = DailyTemperaturesWhile(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
        }

        private static int[] DailyTemperatures(int[] T)
        { // This is faster
            var stack = new Stack<int>();
            var result = new int[T.Length];
            for (var i = 0; i < T.Length; i++)
            {
                if (stack.Count == 0)
                    stack.Push(i);
                else
                {
                    var peek = stack.Peek();
                    if (T[i] > T[peek])
                    {
                        stack.Pop();
                        result[peek] = i - peek;
                        i--;
                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
            }
            return result;
        }

        private static int[] DailyTemperaturesWhile(int[] T)
        {
            var stack = new Stack<int>();
            var result = new int[T.Length];
            for(var i = 0; i < T.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                    continue;
                }
                
                while (stack.Count > 0 && T[i] > T[stack.Peek()])
                {
                    var top = stack.Pop();
                    result[top] = i - top;
                }
                stack.Push(i);               
            }
            return result;
        }
    }
}
