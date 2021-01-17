using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
   public  class FindMountainPeak
    {
        public static void Test()
        { 
            int[] arr = new int[] { 24, 69, 100, 99, 79, 78, 67, 36, 26, 19 };
            var res = FindMountainPeakBinarySearch(arr);
        }

        private static int FindMountainPeakBinarySearch(int[] arr)
        {
            int left = 0; 
            int right = arr.Length - 1;

            while(left < right)
            {
                var middle = (left + right) / 2;
                if(arr[middle] < arr[middle + 1])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            return left;
        }
    }
}
