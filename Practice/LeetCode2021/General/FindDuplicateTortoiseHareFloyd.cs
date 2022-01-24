using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    public class FindDuplicateTortoiseHareFloyd
    {
        public static void Test()
        {
            var res = FindDuplicate(new int[] { 1, 3, 4, 2, 2 });
        }

        private static int FindDuplicate(int[] nums)
        {
            var tortoise = nums[0];
            var hare = nums[0];

            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]]; // skip 1 node
            } while (tortoise != hare);

            tortoise = nums[0];

            while(tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;
        }
    }
}

//F = h Mod C
//C = Length of cycle
//F is nodes outside of cycle