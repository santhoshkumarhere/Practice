using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class RemoveDuplicatesFromSortedArray
    {
        public static void Test()
        {
            int[] nums = {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
            var i = 0;
            for (var j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
        }

        public static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static void Test(int[] nums)
        {
            //if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
           var res =  i + 1;
        }
    }
}
