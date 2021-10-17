using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
   public class MissingNumbers
   {
        public int MissingNumber(int[] nums)
        {
            var actual = 0;
            var given = 0;

            for (int i = 1; i <= nums.Length; i++)
            {
                actual += i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                given += nums[i];
            }

            return actual - given;
        }
    }
}
