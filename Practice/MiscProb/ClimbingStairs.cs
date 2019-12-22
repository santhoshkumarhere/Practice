using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    class ClimbingStairs
    {
        public static void Test()
        {
            int n = 3;

            var dp = new int[n+1];
            var result = Climb(n, 0, dp);
        }
        
        private static int Climb(int target, int i, int[] dp)
        { 

            if(target == i)
            {
                return 1;
            }
             if(target < i)
            {
                return 0;
            }

            if (dp[i] > 0)
            {
                return dp[i];
            }
                var x = Climb(target, i + 1, dp);
                var y = Climb(target, i + 2, dp);
                return dp[i] = x + y; 
        }
    }
}

                //var res = 0;
                //for (int i = 0; i < nums.Length; i++)
                //{
                //    res += Climb(nums, target - nums[i]);
                //}
                //return res;