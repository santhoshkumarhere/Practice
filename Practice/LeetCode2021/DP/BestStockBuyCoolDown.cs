using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class BestStockBuyCoolDown
    {

        public static void Test()
        {
            var prices = new int[] { 1, 2, 3, 0, 2 };
            var res1 = MaxProfitDP(prices);
;
           // var res2 = MaxProfit(new int[] { 1, 2, 3, 0, 2, 0, 4, 1, 2, 0, 4, 9, 18 });
        }

        private static int MaxProfitDP(int[] prices)
        {
            var prevBuy = 0;
            var prevSell = new int[prices.Length];
            var buy = prices[0] * -1;
            var sell = 0;

            for (var i = 1; i < prices.Length; i++)
            {
                prevBuy = buy;
                buy = Math.Max( i > 1 ? (prevSell[i-2] - prices[i]) : -1 * prices[i], prevBuy); // buy = Max(Profit before cooling period - spend current price, hold)
                sell = Math.Max(prevBuy + prices[i], sell); // sell = Max(selling previous holding, hold)
                prevSell[i] = sell;
            }
            return sell;
        }

            private static int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
                return 0;

            var dp = new int[prices.Length];
            var minPrice = prices[1];
          
            for(var i = 0; i < prices.Length; i++)
            {
                if (prices[i] >= minPrice)
                    dp[i] = prices[i] - minPrice;
                else
                    minPrice = prices[i];
            }

            var res = Recursive(1, dp);
            return res;
            //var mem = new int[dp.Length];

            //mem[1] = dp[1];

            //if (dp.Length > 2)
            //{
            //    mem[2] = Math.Max(dp[2], dp[1]);
            //    for (var i = 3; i < dp.Length; i++)
            //    {
            //        mem[i] = Math.Max(dp[i] + dp[i - 3], mem[i - 1]);
            //    }
            //}

            //return mem[prices.Length - 1];
        }

        private static int Recursive(int i, int[] prices)
        {
            if (i >= prices.Length)
                return 0;

            int p1, p2 = 0;

            p1 = prices[i] + Recursive(i + 3, prices);
            p2 = Recursive(i + 1, prices);
            return Math.Max(p1, p2);
        }
    }
}
