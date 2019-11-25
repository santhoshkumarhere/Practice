using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Practice.MiscProb
{
    class ArrayRangeSearch
    {

        public static int[] Test(int[] arr, int target)
        {

            // ArrayRangeSearch.Test(new[] { 5, 7, 7, 8, 8, 10, 11 }, 8);
            var result = new []{-1, -1};
            if (arr.Length == 0)
            {
                return result;
            }
            Console.WriteLine(string.Join(",", arr));
            result[0] = BinarySearchLeftMost(arr, 0, arr.Length-1, target);
            if (result[0] != -1)
            {
                var end = BinarySearchRightMost(arr, result[0]+1 , arr.Length - 1, target);
                result[1] =  end == -1 ? result[0] : end;
            }

            Console.WriteLine(string.Join(",", result));
            return result;
        }

        public static int BinarySearchLeftMost(int[] arr, int l, int r, int target)
        {
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (target <= arr[m])
                {
                    r = m - 1;
                }
                else if (target > arr[m])
                {
                    l = m + 1;
                }
            }

            return l <= arr.Length - 1 && arr[l] == target ? l : -1;
        }

        public static int BinarySearchRightMost(int[] arr, int l, int r, int target)
        {
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (target < arr[m])
                {
                    r = m - 1;
                }
                else if (target >= arr[m])
                {
                    l = m + 1;
                }
            }
            return r <= arr.Length - 1 && arr[r] == target ? r : -1;
        }

        public static int BinarySearch(int[] arr, int l, int r, int target)
        {
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (target < arr[m])
                {
                    r = m - 1;
                }
                else if (target > arr[m])
                {
                    l = m + 1;
                }
                else
                {
                    return m;
                }
            }

            return -1;
        }

        //public static int BinarySearchLeftMost(int[] arr, int l, int r, int target)
        //{
        //    Console.WriteLine("Left");
        //    Console.WriteLine("");
        //    while (l <= r)
        //    {
        //        int m = (l + r) / 2;
        //        Console.WriteLine($"m = {l} + {r} / 2 =  {m}");
        //        if (target <= arr[m])
        //        {
        //            Console.WriteLine($"target <= arr[{m}] {target} <= {arr[m]} = true");
        //            r = m - 1;
        //            Console.WriteLine($"  r =  {m} - {1} = {r}");
        //            Console.WriteLine("");
        //        }
        //        else if (target > arr[m])
        //        {
        //            Console.WriteLine($"target > arr[{m}] {target} > {arr[m]} = true");
        //            l = m + 1;
        //            Console.WriteLine($"  l =  {m} + {1} = {l}");
        //            Console.WriteLine("");
        //        }
        //    }

        //    return l <= arr.Length - 1 && arr[l] == target ? l : -1;
        //}

        //public static int BinarySearchRightMost(int[] arr, int l, int r, int target)
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine("Right");
        //    Console.WriteLine("");

        //    while (l <= r)
        //    {
        //        var m = (l + r) / 2;
        //        Console.WriteLine($"m = {l} + {r} / 2 =  {m}");
        //        if (target < arr[m])
        //        {
        //            Console.WriteLine($"target < arr[{m}] {target} < {arr[m]} = true");
        //            r = m - 1;
        //            Console.WriteLine($"  r =  {m} - {1} = {r}");
        //            Console.WriteLine("");
        //        }
        //        else if (target >= arr[m])
        //        {
        //            Console.WriteLine($"target >= arr[{m}] {target} >= {arr[m]} = true");
        //            l = m + 1;
        //            Console.WriteLine($"  l =  {m} + {1} = {l}");
        //            Console.WriteLine("");
        //        }
        //    }
        //    return r <= arr.Length - 1 && arr[r] == target ? r : -1;
        //}
    }
}
