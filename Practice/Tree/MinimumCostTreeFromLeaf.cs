using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Tree
{
    public class MinimumCostTreeFromLeaf
    {
        public static void Test()
        {
            var arr = new int[] {4, 11};  
           var c = Calculate(new int[] { 6, 2, 4 });
           var c1 = Calculate(new int[] {4, 11}); 

           var x = Calculate(new int[] {11, 12, 12});
        }

        private static int Calculate(int[] arr)
        {
            int n = arr.Length;
            int result = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(int.MaxValue);
            foreach (int val in arr)
            {
                Console.WriteLine("val = " + val);
                while (stack.Peek() <= val)
                {
                    int mid = stack.Pop();
                    Console.WriteLine("mid = " + mid);
                    result += mid * Math.Min(stack.Peek(), val);
                    Console.WriteLine(result);
                }
                stack.Push(val);
            }
            while (stack.Count > 2)
            {
                result += stack.Pop() * stack.Peek();
            }
            return result;
        }
    }
}
