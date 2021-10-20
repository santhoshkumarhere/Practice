using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Search
{
    class BinarySearch
    {
        public static void Test()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            //var result = BinarySearchIterative(arr, 40);

            //if(result == -1)
            //{
            //    Console.WriteLine("Not found");
            //}
            //else
            //{
            //    Console.WriteLine($"Found at {result}");
            //} 

            var result = BinarySearchRecursive(arr, 0, arr.Length -1, 40);

            if (result == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"Found at {result}");
            }
        }

        private static int BinarySearchRecursive(int[] arr, int l, int r, int target)
        {
            if( l <= r )
            {
                var m = (l + r) / 2;

                if(arr[m] == target)
                {
                    return m;
                }
                
                else if(arr[m] > target)
                {
                    return BinarySearchRecursive(arr, l, m - 1, target);
                }
                else
                {
                    return BinarySearchRecursive(arr, m + 1, r, target);
                }
            }
            return -1;
        }

        private static int BinarySearchIterative(int[] arr, int target)
        {
            int l = 0, r = arr.Length - 1;

            while (l <= r)
            {
                var m = (l + r) / 2;

                if (arr[m] == target)
                {
                    return m;
                }

                if (arr[m] < target)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return -1;
        }
    }
}
