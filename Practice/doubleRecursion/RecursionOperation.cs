using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.doubleRecursion
{
    class RecursionOperation
    {

        //// int[] arr = { 2, 5, 6, 1, 3, 2, 8, 7 };

        public string PrintMyName(int[] arr)
        {
            Console.WriteLine("Called With values: " + string.Join(", ", arr));
            if (arr.Length == 1)
            {
                return "Base Case Done";
            }
            int q = arr.Length / 2;

            int[] left = new int[q];
            int[] right = new int[arr.Length - q];

            for (int i = 0; i < q; i++)
            {
                left[i] = arr[i];
            }

            for (int i = 0; i < (arr.Length - q); i++)
            {
                right[i] = arr[q + i];
            }

            Console.WriteLine("Executing Left");
            Console.WriteLine(string.Join(", ", left));
            PrintMyName(left);
            Console.WriteLine("Executing Right");
            Console.WriteLine(string.Join(", ", right));
            PrintMyName(right);
            Console.WriteLine("Merge: " + string.Join(", ", left) + " & " + string.Join(", ", right));
            return "Recursion completed";
        }
    }
}
