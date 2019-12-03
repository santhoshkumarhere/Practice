using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class RotatedArraySearch
    {
        public static void Search()
        {
            var arr = new[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
            var result = BinarySearch(arr, 0, arr.Length - 1, 2);
            Console.WriteLine(result);

            result = BinarySearch(arr, 0, arr.Length - 1, 5);
            Console.WriteLine(result);

            result = BinarySearch(arr, 0, arr.Length - 1, 10);
            Console.WriteLine(result);

            result = BinarySearch(arr, 0, arr.Length - 1, 11);
            Console.WriteLine(result);

            result = BinarySearch(arr, 0, arr.Length - 1, 3);
            Console.WriteLine(result);

            var x = new[] { 30, 40, 50, 10, 20 };
            result = BinarySearch(x, 0, x.Length - 1, 30);
            Console.WriteLine(result);
        }

        public static int BinarySearch(int[] arr, int l, int r, int target)
        {
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (arr[m] == target)
                {
                    return m;
                }
                else if (arr[l] < arr[m])
                {
                    if (target > arr[m] || target < arr[l]) //target < arr[m])
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }
                else// if(arr[l] > arr[m]) //target > arr[m])
                {
                    if (target > arr[m] && target <= arr[r])
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }

            }
            return -1;
        }
    }
}
