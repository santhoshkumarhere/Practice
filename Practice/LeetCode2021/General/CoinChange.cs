using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class CoinChange1
    {
        // minimum no of coins needed
        public static void Test()
        {
            //var res1 = CoinChangeMySolution(new int[] { 1, 2, 5 }, 11);
            var res5 = CoinChangeMySolution(new int[] { 186, 419, 83, 408 }, 6249);
            var res2 = CoinChangeMySolution(new int[] { 2 }, 3);
            var res3 = CoinChangeMySolution(new int[] { 1 }, 0);
            var res4 = CoinChangeMySolution(new int[] { 1 }, 2);
            var res1 = MakeChange(new int[] { 1, 2, 5 }, 11, 0, 0, 0, 12);
            //var res5 = MakeChange(new int[] { 186, 419, 83, 408 }, 6249, 0, 0, 0, 6250);

            //var res2 = MakeChange(new int[] { 2 }, 3, 0, 0, 0, 4);
            //var res3 = MakeChange(new int[] { 1 }, 0, 0, 0, 0, 1);
            //var res4 = MakeChange(new int[] { 1 }, 2, 0, 0, 0, 3);
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

        private static int MakeChange(int[] coins, int amount, int start, int currentMinimum, int currentSum, int result)
        {   //Timelimit exceeded solution - well tried 
            if(currentSum == amount)
            {
                result = Math.Min(currentMinimum, result);
                return result;
            }
            
            for(var i = start; i < coins.Length; i++)
            {
                currentMinimum++;
                if(amount >= currentSum + coins[i])
                {
                   result =  MakeChange(coins, amount, i, currentMinimum, currentSum + coins[i], result);
                }
                currentMinimum--;
            }
            return result;
        }
    }
}
