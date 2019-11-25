using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json.Bson;
using Practice.xmlParsing;

namespace Practice.MiscProb
{
    class ArrayInsert
    {
        public static void Test()
        {
            var arr = new[] {1, 3, 5, 6};

            var index = BinarySearch(arr, 0, arr.Length - 1, 4);
            Console.WriteLine(index);

            //index = BinarySearch(arr, 0, arr.Length - 1, 2);
            //Console.WriteLine(index);

            //index = BinarySearch(arr, 0, arr.Length - 1, 5);
            //Console.WriteLine(index);

            //index = BinarySearch(arr, 0, arr.Length - 1, 0);
            //Console.WriteLine(index);

            //index = BinarySearch(arr, 0, arr.Length - 1, 7);
            //Console.WriteLine(index);
        }

        public static int BinarySearch(int[] arr, int l, int r, int target)
        {
            if (target <= arr[l])
            {
                return l;
            }

            if (target > arr[r])
            {
                return r+1;
            }

            while (l <= r)
            {
                var m = (l + r) / 2;

                if (target < arr[m])
                {
                    r = m - 1;
                    if (l > r)
                    {
                        return l;
                    }
                }
                else if (target > arr[m])
                {
                    l = m + 1;
                    if (l > r)
                    {
                        return l;
                    }
                }
                else
                {
                    return m;
                }
            }

            return -1;
        } 
    }
}
