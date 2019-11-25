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
        public int Calculate(int[] netWorth, int currentIndex)
        {
            if (currentIndex >= netWorth.Length)
            {
                return 0;
            }
             
            var stealCurrentHouse = netWorth[currentIndex] +  Calculate(netWorth, currentIndex + 2);
            var skipCurrent = Calculate(netWorth, currentIndex + 1);
            return Math.Max(stealCurrentHouse, skipCurrent);
        }
    }
}
