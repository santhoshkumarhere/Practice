using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.Arrays
{
    internal class RotateArray
    {
        public static void Test()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            Rotate(arr, 3);
        }

        private static void Rotate(int[] arr, int k)
        {
            int prev = arr[0];
            int index = 0;
            int len = arr.Length;
            do
            {
                var idx = (index + k) % len;
                var temp = arr[idx];
                arr[idx] = temp;
                index = idx;
            } while (index != 0);
        }
    }
}
