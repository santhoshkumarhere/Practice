using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode.DP
{
    public class CoinChange
    {
        public static void Test()
        {
            var res1 =  CoinChangeMySolution(new int[] { 1, 2, 5 }, 6);
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
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coins[c]]); // 1+  1 coin taken 
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
