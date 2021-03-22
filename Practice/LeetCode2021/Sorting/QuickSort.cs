using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Sorting
{
    public class QuickSort
    {
        public static void Test()
        {
            var arr = new int[] { 10, 5, 8, 12, 15, 6, 3, 9, 16 };
            Sort(arr, 0, arr.Length - 1);

            int[] arr4 = { 10, 7, 8, 9, 1, 5 };
            Sort(arr4, 0, arr4.Length - 1);

            var arr1 = new int[] { 10, 2, 4, 5 };
            Sort(arr1, 0, arr1.Length - 1);

            var arr2 = new int[] { 2, 4, 5, 1 };
            Sort(arr2, 0, arr2.Length - 1);

            var arr3 = new int[] { 1, 3, 4, 5 };
            Sort(arr3, 0, arr3.Length - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            if( l < r )
            {              
                var p = Partition(arr, l, r);
                Sort(arr, l, p-1);
                Sort(arr, p + 1, r);
            }
        }

        private static int Partition(int[] arr, int l, int r)
        {
            int i = l, j = r;
            int pivot = arr[l];
            while(i < j)
            {
                while (i <= r && arr[i] <= pivot)
                {
                    i++;
                }

                while (j >= 0 && arr[j] > pivot)
                {
                    j--;
                }

                if (i < j)
                    Swap(arr, i, j);
            }

            if (i > j)
                Swap(arr, l, j);

            return j;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
