using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SortingAlgo
{
    public class CoreMergeSort
    {
        public static void Test()
        {
            var arr = new[] { 20, 10, -10, 0, 50, 30, 40, 1 };
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int l, int r)
        {
            if(l < r)
            {
                var m = (l + r) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        private static void Merge(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];
            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int l = 0;
            int r = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (l == leftArray.Length)
                {
                    input[k] = rightArray[r];
                    r++;
                }
                else if (r == rightArray.Length)
                {
                    input[k] = leftArray[l];
                    l++;
                }
                else if (leftArray[l] <= rightArray[r])
                {
                    input[k] = leftArray[l];
                    l++;
                }
                else
                {
                    input[k] = rightArray[r];
                    r++;
                }
            }
        }
    }
}
