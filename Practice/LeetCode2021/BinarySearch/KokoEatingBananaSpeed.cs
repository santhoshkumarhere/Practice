using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.LeetCode2021.BinarySearch
{
    public class KokoEatingBananaSpeed
    {
        public static void Test()
        {
            var res = MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8);
        }


        private static bool canEatBananas(int[] piles, int speed, int hours)
        {
            if (speed == 0)
                return false;

            var count = 0;

            foreach (var p in piles)
            {
                count += p / speed;
                count += p % speed != 0 ? 1 : 0;
            }

            return count <= hours;
        }

        private static int MinEatingSpeed(int[] piles, int h)
        {
            var left = 0;
            var right = piles.Max();

            //can be solved like find first and last position method as well with 'ans' variable
            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (!canEatBananas(piles, mid, h))  // 0 1 2 3 4m 5 6 7 
                {
                    left = mid + 1;
                    //right = mid - 1;
                }
                else
                {
                    right = mid - 1;
                    //left = mid + 1;
                }
            }

            return left;
        }
    }
}