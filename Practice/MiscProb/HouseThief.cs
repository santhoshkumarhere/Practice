using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    // { 3, 1, 2, 5, 4, 2 }
    //{5, 4, 4, 5}
    //{1, 3, 6}
    internal class HouseThief
    {

        public static void Test()
        {
            var arr = new int[] { 3, 1, 2, 5, 4, 2 };
            var res = Rob(arr);
            var list = new List<int>();
            var count = 0;
            var ct = Calculate(arr, 0);
        }

        public static int Calc(int[] net, int currentIndex, List<int> res, int count)
        {
            if (currentIndex >= net.Length)
            {
                return count;
            }
            count += net[currentIndex];
            res.Add(net[currentIndex]);
            return Calc(net, currentIndex + 2, res, count);
        }
        public static int Calculate(int[] netWorth, int currentIndex)
        {
            if (currentIndex >= netWorth.Length)
            {
                return 0;
            }
             
            var stealCurrentHouse = netWorth[currentIndex] +  Calculate(netWorth, currentIndex + 2);
            var skipCurrent = Calculate(netWorth, currentIndex + 1);
            return Math.Max(stealCurrentHouse, skipCurrent);
        }

        public static int Rob(int[] nums)
        {
            int prevMax = 0;
            int currMax = 0;
            foreach (var x in nums)
            {
                int temp = currMax;
                currMax = Math.Max(prevMax + x, currMax);
                prevMax = temp;
            }
            return currMax;
        }

    }
}
