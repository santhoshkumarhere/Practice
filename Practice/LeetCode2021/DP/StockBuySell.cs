using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class StockBuySell
    {
        public static void Test()
        {

        }

        private static int MaxProfit(int[] prices)
        {
           if(prices.Length <= 1)
           {
                return 0;
           }

            var currMinPrice = Math.Min(prices[0], prices[1]);
            var currProfit = Math.Max(0, prices[1] - prices[0]);

           for(var i = 2; i < prices.Length; i++)
           {
                currMinPrice = Math.Min(currMinPrice, prices[i]);
                currProfit = Math.Max(currProfit, prices[i] - currMinPrice);
           }

            return currProfit;
        }
    }
}
