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
            int[] arr = new int[] { -1, -100, 3, 99 }; // 3, 99, -1, -100
            Rotate(arr, 10);
        }

        private static void Rotate(int[] arr, int k)
        {
            int count = 0;
            int len = arr.Length;
           // k = k % len;
            for (int start = 0; count < arr.Length; start++)            {

                int prev = arr[start];
                int currentIndex = start;
                do
                {
                    var next = (currentIndex + k) % len;
                    var temp = arr[next];
                    arr[next] = prev;
                    prev = temp;
                    currentIndex = next;
                    count++;
                } while (currentIndex != start);
            }
        }
    }
}
