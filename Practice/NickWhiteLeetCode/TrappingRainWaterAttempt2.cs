using System;
using System.Collections.Generic;

namespace Practice.NickWhiteLeetCode
{
    public class TrappingRainWaterAttempt2
    {
       public static void Test()
       {
            var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var res = Trap(arr);
       }

        private static  int Trap(int[] height)
        {
            int l = 0;
            int r = height.Length - 1;
            int max = 0;
            int leftmax = 0;
            int rightmax = 0;
            while (l <= r)
            {
                leftmax = Math.Max(leftmax, height[l]);
                rightmax = Math.Max(rightmax, height[r]);
                if (leftmax < rightmax)
                {
                    max += (leftmax - height[l]);       // leftmax is smaller than rightmax, so the (leftmax-A[a]) water can be stored
                    l++;
                }
                else
                {
                    max += (rightmax - height[r]);
                    r--;
                }
            }
            return max;
        }
    }

   
}
