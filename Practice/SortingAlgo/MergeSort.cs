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
            System.Diagnostics.Debug.WriteLine($"left = {left}, middle = {middle}, right = {right} ");
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];
            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            
            System.Diagnostics.Debug.WriteLine("leftArray =>  " + string.Join(",", leftArray));
            System.Diagnostics.Debug.WriteLine("rightArray =>  " + string.Join(",", rightArray));
            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
            System.Diagnostics.Debug.WriteLine("ResultArray =>  " + string.Join(",", input));
            System.Diagnostics.Debug.WriteLine("");
        }

        private static void Merge(int[] array, int[] helper, int low, int middle, int high)
        {
            System.Diagnostics.Debug.WriteLine($"low = {low}, middle = {middle}, high = {high} ");
            System.Diagnostics.Debug.WriteLine("Array =>  " + string.Join(",", array));
            System.Diagnostics.Debug.WriteLine("Helper =>  " + string.Join(",", helper));
            for (var i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }
            System.Diagnostics.Debug.WriteLine("After copy Helper =>  " + string.Join(",", helper));
            var helperLeft = low;
            var helperRight = middle + 1;
            var current = low;
            System.Diagnostics.Debug.WriteLine($"HelperLeft = {helperLeft}, HelperRight = {helperRight}, Current = {current} ");
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
            System.Diagnostics.Debug.WriteLine("Array =>  " + string.Join(",", array));
            int remaining = middle - helperLeft;

            for (var i = 0; i <= remaining; i++)
            {
                array[current + i] = helper[helperLeft + i];
            }
            System.Diagnostics.Debug.WriteLine("After copy =>  " + string.Join(",", array));
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
