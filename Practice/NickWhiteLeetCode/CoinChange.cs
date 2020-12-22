using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class CoinChange1
    {
        // minimum no of coins needed
        public static void Test()
        {
            var res1 = CoinChangeMySolution(new int[] { 1, 2, 5 }, 11);
            var res5 = CoinChangeMySolution(new int[] { 186, 419, 83, 408 }, 6249);

            var res2 = CoinChangeMySolution(new int[] { 2 }, 3);
            var res3 = CoinChangeMySolution(new int[] { 1 }, 0);
            var res4 = CoinChangeMySolution(new int[] { 1 }, 2);
        }

        private static int CoinChangeMySolution(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            var dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            for (var i = 1; i <= amount; i++ )
              {
                for(var j = 0; j < coins.Length; j++)
                {
                    if(i >= coins[j])
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
              }
              return dp[amount] > amount ? -1 : dp[amount];
        }

        private static int CoinChange(int[] coins, int amount)
        {
            if(amount == 0)
            {
                return 0;
            }
            
            Array.Sort(coins);
            
            int i = coins.Length - 1, count = 0;

            while(amount > 0 && i >= 0)
            {
                if(amount >= coins[i])
                {
                    amount -= coins[i];
                    count++;
                }
                else
                {
                    i--;
                }              
            }
            return amount == 0 ? count : -1;
        }
    }
}
