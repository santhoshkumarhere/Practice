using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.Sorting
{
    public class MergeSort
    {

        public static void Test() {
            var arr = new int[] { 1, 5, 6, 2, 8, 4};
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            if(l < r)
            {
                var m = (l + r) / 2;
                Sort(arr, l, m);
                Sort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }

        private static void Merge(int[] result, int l, int m, int r)
        {
            var leftArray = new int[m - l + 1];
            var rightArray = new int[r - m];

            Array.Copy(result, l, leftArray, 0, m - l + 1);
            Array.Copy(result, m+1, rightArray, 0, r-m);

            int i = 0, j = 0, k = l;

            while(i < leftArray.Length && j < rightArray.Length)
            {
                if(leftArray[i] <= rightArray[j])
                {
                    result[k++] = leftArray[i++];
                }
                else
                {
                    result[k++] = rightArray[j++];
                }
            }

            for(var x = i; x < leftArray.Length; x++)
            {
                result[k++] = leftArray[x];
            }

            for (var x = j; x < rightArray.Length; x++)
            {
                result[k++] = rightArray[x];
            }
        }
    }
}
