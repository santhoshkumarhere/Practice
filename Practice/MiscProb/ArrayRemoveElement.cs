using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class ArrayRemoveElement
    {
        public static void Test()
        {
            int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            RemoveElement(nums, 2);
            int[] nums1 = {3,3};
            RemoveElement(nums1, 5);
        }

        public static int RemoveElement(int[] nums, int val)
        {
            var i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }
    }
}
