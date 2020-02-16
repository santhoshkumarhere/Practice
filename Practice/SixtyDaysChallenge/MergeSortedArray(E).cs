using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class MergeSortedArray_E_
    {
        public static void Test()
        {
            Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            Merge(new int[] { 1 }, 1, new int[] { }, 0);
            Merge(new int[] { 2, 0 }, 1, new int[] { 1 }, 1);
            Merge(new int[] { 1, 2, 7, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            Merge(new int[] { 1, 2, 7, 0, 0, 0 }, 3, new int[] { 8 }, 1);
            Merge(new int[] { 4,5,6, 0, 0, 0 }, 3, new int[] { 1,2,3 }, 3);
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var p1 = m - 1;
            var p2 = n - 1;
            var p = m + n - 1;

            while ( p1 >=0 && p2 >= 0)
            {
                if(nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;p--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--; p--;
                }
            }
            Array.Copy(nums2, 0, nums1, 0, p2 + 1);
        }
    }
}
