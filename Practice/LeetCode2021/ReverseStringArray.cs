using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class ReverseStringArray
    {

        public static void Test()
        {
            var arr = new char[] { 'h', 'i', 'y', 'm', 'f' };
            var result = ReverseArr(arr);
        }

        public static char[] ReverseArr(char[] arr)
        {
            if (arr == null || arr.Length <= 1) return arr;
            int left = 0, right = arr.Length - 1;
            
            while(left <= right)
            {
                var leftVal = arr[left];

                arr[left++] = arr[right];
                arr[right--] = leftVal;
            }
            return arr;
        }
    }
}
