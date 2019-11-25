using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    internal class WaterContainer
    {
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
    }
}
