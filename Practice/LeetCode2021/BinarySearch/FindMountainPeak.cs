using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
   public  class FindMountainPeak
    {
        public static void Test()
        { 
            int[] arr = new int[] { 24, 69, 100, 99, 79, 78, 67, 36, 26, 19 };
            var res = PeakIndexInMountainArray(arr);
        }

        // This is the natural version
        private static int FindMountainPeakBinarySearchII(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                var middle = (left + right) / 2;
                if (arr[middle] < arr[middle + 1])
                {                        // m  
                    left = middle + 1;  // 69, 100, 99
                }
                else
                {                    //    m        the number before 67 could be less than 67 which could make it Peak
                    right = middle; // 78, 67, 36
                }
            }
            return left;
        }

        //This is the binary search version
        private static int PeakIndexInMountainArray(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (arr[middle] < arr[middle + 1])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return left;
        }

    }
}
