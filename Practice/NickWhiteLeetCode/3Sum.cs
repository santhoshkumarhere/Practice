using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public static class _3Sum
    {
        public static void Test()
        {
            //var nums = new int[] { -1, 0, 1, 2, -1, -4 };
           // var result = ThreeSum(nums);
            var nums = new int[] { -5, -3, -2, 0, 1, 3, 5 };
            var result = ThreeSum(nums);
        }
        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();

            if (nums == null || nums.Length <= 2) return res;
            
            Array.Sort<int>(nums);
            
            for(var i = 0; i<= nums.Length - 3; i++)
            {
            }

            return res;
        }
    }

}