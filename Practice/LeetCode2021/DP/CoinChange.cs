using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class CoinChange
    {
        public static void Test()
        {
            var res1 = CoinChange2022(new int[] { 1, 2, 5 }, 6);
        }

        private static int CoinChange2022(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            var dp = new int[amount + 1];

            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            for(int amt = 1; amt <= amount; amt++)
            {
                for(int coin = 0; coin < coins.Length; coin++)
                {
                    if(coins[coin] <= amt)
                    {
                        dp[amt] = Math.Min(1 + dp[amt - coins[coin]], dp[amt]);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }

        private static int CoinChangeMySolution(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            var dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            for(var i = 1; i <= amount; i++)
            {
                for(var c = 0; c < coins.Length; c++)
                {
                    if (i >= coins[c]) //amount > coins
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coins[c]]); // 1+ = 1 current coin taken & add remaining from dp
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
