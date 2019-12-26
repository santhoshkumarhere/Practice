using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode75.Array
{
    class ProductExceptSelf
    {
        public static void Test()
        {
            var res = ProductExceptSelves(new int[] { 1, 2, 3, 4 });
           // var res = ProductExceptSelves(new int[] { 0, 0 });
        }

        private static int[] ProductExceptSelves(int[] nums)
        {
            if(nums.Length == 0) { return nums; }
            var result = new int[nums.Length];

            var product = 1;
            var numOfZeros = 0;
           
            for(var i=0; i< nums.Length; i++)
            {
                if(nums[i] == 0)
                {
                    numOfZeros++;
                }
                product *= (nums[i] == 0 ? 1: nums[i]);
            }

            if(numOfZeros > 1)
            {
                return result;
            }

            for(var i=0; i< nums.Length; i++)
            {
                if(numOfZeros > 0)
                {
                    result[i] = nums[i] == 0 ? product : 0;
                }
                else 
                result[i] = product / nums[i];
            }

            return result;
        }
    }
}
