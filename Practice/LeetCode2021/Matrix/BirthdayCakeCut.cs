using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Matrix
{
    public class BirthdayCakeCut
    {
        public static void Test()
        {
            var res = MaxArea(5, 4, new int[] { 1, 2, 4 }, new int[] { 1, 3 });
        }

        private static int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);

            int maxH = 0, maxV = 0;

            for(var i = 0; i < horizontalCuts.Length; i++)
            {
                maxH = Math.Max(maxH, i == 0 ? horizontalCuts[i] : horizontalCuts [i] - horizontalCuts [i-1]);
            }
            maxH = Math.Max(maxH, h - horizontalCuts[horizontalCuts.Length - 1]);

            for (var i = 0; i < verticalCuts.Length; i++)
            {
                maxV = Math.Max(maxV, i == 0 ? verticalCuts[i] : verticalCuts[i] - verticalCuts[i - 1]);
            }
            maxV = Math.Max(maxV, w - verticalCuts[verticalCuts.Length - 1]);

            return (int) (maxH % (1e9 + 7) * maxV % (1e9 + 7));
        }
    }
}
