using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class CoinChange2
    {
        // no of ways
        public static void Test()
        {
            var res = Change(10, new int[] { 10 });
        }

        private static int Change(int amount, int[] coins)
        {
            var result = new int[amount+1];
            result[0] = 1;
            
            for(var i = 0; i < coins.Length; i++)
            {
                for( var j = 1; j <= amount; j++)
                {
                    var prevPosition = j - coins[i];
                    var toAdd = prevPosition < 0 ? 0 : result[prevPosition];                    
                    result[j] = result[j] +  toAdd;
                }
            }
            return result[amount];
        }
    }
}
