using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.DP
{
    public class JumpGameII_Greedy_
    {
        public static void Test()
        {
            var res = Jump(new int[] { 2, 3, 1, 1, 4 });
        }

        private static int Jump(int[] nums)
        {
            int jumps = 0, currentJumpEnd = 0, farthestIndex = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //until it reach jumpend keep track of maximum index that can be reached
                farthestIndex = Math.Max(farthestIndex, i + nums[i]);

                //when loop reaches currentIndex maximum position, update Jump & see how far we can jump
                // from index 0, max we can reach is index 2, but along the way 3 can go farthest
                // when we reach currentJumpEnd, jump to farthest index
                if (i == currentJumpEnd) // always enters when i = 0
                {
                    jumps++;
                    currentJumpEnd = farthestIndex;
                }
            }
            return jumps;
        } 
    }
}
