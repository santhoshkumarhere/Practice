using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    class TwoSum
    {
        public static void Test()
        {
            var result = Compute(new int[] { 2, 7, 11, 15 }, 9);
        }

        private static int[] Compute(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for(var i=0; i <= nums.Length; i++)
            {
                var remaining = target - nums[i];

                if(dict.ContainsKey(remaining))
                {
                    return new int[] { dict[remaining], i };
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }

            return new int[] { };
        }
    }
}
