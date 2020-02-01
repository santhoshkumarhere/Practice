using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class StockBuyMultipleTransactions
    {
        public static void Test()
        {
            var result = Calculate(new int[] { 7, 1, 5, 3, 6, 4 }, 0);
            result = Calculate(new int[] { 1, 2, 3, 4, 5 }, 0);
        }

        private static int Calculate(int[] prices, int currentIndex)
        {
            var maxProfit = 0;

            for(var i=1; i< prices.Length; i++)
            {
                if(prices[i] > prices[i-1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }
    }
}
