using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.SixtyDaysChallenge
{
    public class CoinChange_M_
    {
        public static void Test()
        {
            var res = CoinChange(new int[] {186, 419, 83, 408 }, 6249);
            res = CoinChange(new int[] { 1, 2, 5, 10 }, 18);
            res = CoinChange(new int[] { 1, 2, 5 }, 11);
            res = CoinChange(new int[] { 1, 3, 5 }, 4);
           res = CoinChange(new int[] { 1 }, 11);
           res = CoinChange(new int[] { 2 }, 3);
        }

        public static int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
          
            var dp = new int[amount + 1];

            Array.Fill(dp, amount+1);

            dp[0] = 0;
            for (var i=1; i <= amount; i++)
            {
                for( var j=0; j < coins.Length; j++)
                {
                    if(i >= coins[j])
                    dp[i] = Math.Min(1 + dp[i - coins[j]], dp[i]);
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
