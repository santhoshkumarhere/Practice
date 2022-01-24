using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class SquareOfSortedArray
    {
        public static void Test()
        {
            var arr = new int[] { -4, 3, 4, 10 };
            var res = SqOfSortedArray(arr);

            arr = new int[] { -5, -3, -2, -1 };
            res = SqOfSortedArray(arr);

            arr = new int[] { -4, -1, 0, 3, 10 };
            res = SqOfSortedArray(arr);

            arr = new int[] { -11, 5, 9, 11, 12 };
            res = SqOfSortedArray(arr);
        }

        public static int[] SqOfSortedArray(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            var res = new int[arr.Length];

            for(var i = arr.Length - 1; i >=0; i--)
            {
                if(Math.Abs(arr[left]) >= Math.Abs(arr[right]))
                {
                    res[i] = arr[left] * arr[left];
                    left++;
                }
                else
                {
                    res[i] = arr[right] * arr[right];
                    right--;
                }
            }

            return res;
        }
    }
}
