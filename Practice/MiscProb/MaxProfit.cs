using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Practice.MiscProb
{
    public class MaxProfit
    {
        public static void Test()
        {
            int[] stockPrices = new int[] { 10, 7, 5, 3, 12, 15, 3};
            Calculate(stockPrices);
        }

        private static void Calculate(int[] prices)
        {

            if (prices.Length < 2)
            {
                return;
            }

            int maxProfit = prices[1] - prices[0];
            int minBuy = Math.Min(prices[0], prices[1]);

            
            for (var i = 2; i < prices.Length; i++)
            {
                minBuy = Math.Min(minBuy, prices[i]);
                maxProfit = Math.Max(maxProfit, prices[i] - minBuy);
            }
        }
    }
}
