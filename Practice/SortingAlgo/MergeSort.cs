using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SortingAlgo
{
    public class MergeSort
    {
        public static void Test()
        {
            var array = new[] { 20, 10, -10, 0, 50, 30, 40, 1 };
            Sort(array);
            System.Diagnostics.Debug.WriteLine(string.Join(",", array));
        }

        private static void Sort(int[] array)
        {
            int[] helper = new int[array.Length];
            Sort(array, helper, 0, array.Length - 1);
        }
        private static void Sort(int[] arr, int[] helper, int low, int high)
        {
            if (low < high)
            {
                var middle = (low + high) / 2;
                Sort(arr, helper, 0, middle);
                Sort(arr, helper, middle + 1, high);
                //Merge(arr, helper, low, middle, high);
                 MergeII(arr, low, middle, high);
            }
        }

        private static void MergeII(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];
            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int l = 0;
            int r= 0;
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

        private static void Merge(int[] array, int[] helper, int low, int middle, int high)
        {        
            for (var i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }
            var helperLeft = low;
            var helperRight = middle + 1;
            var current = low;
            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    array[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            int remaining = middle - helperLeft;

            for (var i = 0; i <= remaining; i++)
            {
                array[current + i] = helper[helperLeft + i];
            }
        }
    }
}
