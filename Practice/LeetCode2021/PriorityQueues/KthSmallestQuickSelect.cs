using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.PriorityQueue
{
    internal class KthSmallestQuickSelect
    {
        public static void Test()
        {
            int[] arr = { 10, 4, 5, 8, 6, 11, 9 };

            var res = FindKthSmallest(arr, 0, arr.Length - 1, 1); // if you want second position pass k = 1 which is index 1 
        }

        private static int FindKthSmallest(int[] arr, int low, int high, int k)
        {
            var part = Partitions(arr, low, high);

            if (part == k)
                return arr[k];
            else if (part < k)
                return FindKthSmallest(arr, part + 1, high, k);
            else
                return FindKthSmallest(arr, low, part - 1, k);
        }

        static int Partitions(int[] arr, int low, int high)
        {
            int pivotValue = arr[high], pivotloc = low;

            for (int i = low; i <= high; i++)
            {
                // inserting elements of less value to the left of the pivot location
                if (arr[i] < pivotValue)
                {
                    Swap(arr, i, pivotloc);
                    pivotloc++;
                }
            }
            // swapping pivot to the readonly pivot location
            Swap(arr, high, pivotloc);

            return pivotloc;
        }


        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
