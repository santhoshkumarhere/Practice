using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class TrappingRainWater_HARD
    {
        public static void Test()
        {
            var res1 = Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        }

        private static int Trap(int[] height)
        {
            var length = height.Length;
            if (length == 0) return 0;

            var left_max = new int[length];
            var right_max = new int[length];
            left_max[0] = height[0];
            right_max[length - 1] = height[length - 1];
            var total = 0;

            for(var i = 1; i < length; i++)
            {
                left_max[i] = Math.Max(height[i], left_max[i - 1]);
            }

            for(var j = length - 2; j >= 0; j--)
            {
                right_max[j] = Math.Max(height[j], right_max[j + 1]);
            }

            for(var i = 1; i < length; i++)
            {
                total += Math.Min(left_max[i], right_max[i]) - height[i];
            }
            return total;
        }
    }
}
