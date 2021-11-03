namespace Practice.LeetCode2021.DP
{
    using System;
    public class MinCostClaimbingStairs_E
    {
        public static void Test()
        {
            var cost1 = new int[] { 10, 1, 20 };
            var cost = new int []{10,15,20 };
            var cost2 = new int[] {1,100,1,1,1,100,1,1,100,1};
            var res = MinCostClimbingStairs(cost1);
            var res1 = MinCostClimbingStairs(cost2);
        }

        private static int MinCostClimbingStairs(int[] cost)
        {
            int[] dp = new int[cost.Length + 1];        // * 
                                                    // 1 3 2
             for(var i = 2; i < dp.Length; i++)
            {
                dp[i] = Math.Min(cost[i-1] + dp[i-1], cost[i-2] + dp[i-2]);
            }

            return dp[dp.Length - 1]; //target is stored in last index of array
        }       
    
    }
}