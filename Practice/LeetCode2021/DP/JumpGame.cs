using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class JumpGame
    {
        public static void Test()
        {
            var res = CanJumpDP(new int[] { 2, 3, 1, 1, 4 });
            var res1 = CanJumpDP(new int[] { 3, 2, 1, 0, 4 });
        }

        private static bool CanJumpDP(int[] nums)
        {
            int lastGood = nums.Length - 1;

            for(int i = lastGood - 1; i >=0; i--)
            {
                if(i + nums[i] >= lastGood)
                {
                    lastGood = i;
                }
            }

            return lastGood == 0;
        }

        private static  bool CanJump(int[] nums)
        {
            if (nums.Length == 1)
                return true;

          if (nums[0] == 0) return false;

            var memo = new Dictionary<int, bool>();
          return CanReach(nums, 0, memo);
        }

        private static bool CanReach(int[] nums, int currIndex, Dictionary<int, bool> memo)
        { 
            //TL exceeded with memoization
            if (memo.ContainsKey(currIndex))
                return memo[currIndex];

            if (currIndex >= nums.Length)
                return false;

            if (currIndex == nums.Length - 1)
                return true;

            if (nums[currIndex] == 0)
                return false;
           

            var val = nums[currIndex];
            for(var i = val; i > 0; i--)
            {
                if (CanReach(nums, i + currIndex, memo))
                {
                    memo[currIndex] = true;
                    return true;
                }
            }
            memo[currIndex] = false;
            return false;
        }
    }
}
