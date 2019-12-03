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
            Console.WriteLine(string.Join(",", array));
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
                Merge(arr, helper, low, middle, high);
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
