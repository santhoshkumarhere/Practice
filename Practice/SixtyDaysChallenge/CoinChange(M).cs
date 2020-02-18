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
            //var res = CoinChange(new int[] { 1, 2, 5, 10 }, 18);
            //res = CoinChange(new int[] { 1, 2, 5 }, 11);
            //res = CoinChange(new int[] { 1, 3, 5 }, 4);
            //res = CoinChange(new int[] { 1 }, 11);
            //res = CoinChange(new int[] { 2 }, 3);
        }

        public static int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            Array.Sort(coins);
            var set = new HashSet<int>(coins);
            var count = 0; var i = coins.Length - 1;
            while (amount > 0 && i >=0)
            {
                if (amount >= coins[i])
                {
                    count = count + amount / coins[i];

                    amount = amount % coins[i];
                }
                else if (set.Contains(amount))
                {                    
                    return count + 1 ;
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
