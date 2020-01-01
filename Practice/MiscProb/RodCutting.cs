using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class RodCutting
    {

        public static void Test()
        {
            int[] price = { 1, 5, 8, 9, 10, 17, 17, 20 };
            var x = RodCut(price, 4);
        }

        private static int RodCut(int[] price, int n)
        {
            if(n==0)
            {
                return 0;
            }

            var max_val = int.MinValue;
            for(var i=1; i <= n; i++)
            {
                max_val = Math.Max(max_val, price[i - 1] + RodCut(price, n - i));
            }
            return max_val;
        }
    }
}
