using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    internal class WaterContainer
    {
        //{ 1, 8, 6, 2, 5, 4, 8, 3, 7 }
        public int Compute(int[] arr)
        {
            var max_prod = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                var curr_prod = 0;
                for (var j = arr.Length - 1; j >= i; j--)
                {
                    curr_prod = Math.Min(arr[i], arr[j]) * (j - i);
                    max_prod = Math.Max(max_prod, curr_prod);
                }
            }
            Console.WriteLine(max_prod);
            return max_prod;
        }

        public int maxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }
    }
}
