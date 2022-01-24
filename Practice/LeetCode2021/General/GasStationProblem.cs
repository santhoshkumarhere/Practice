using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.General
{
    internal class GasStationProblem
    {
        public static void Test()
        {
            var gas = new int[]  { 1, 2, 3, 4, 5 };
            var cost = new int[] { 3, 4, 5, 2, 1 };
            var res = CanCompleteCircuit(gas, cost);
        }

        private static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int totalTank = 0;
            int currTank = 0;
            int startingPos = 0;

            for(int i = 0; i < gas.Length; i++)
            {
                if(currTank <  0)
                {
                    startingPos = i; //when you come to my gas station if a running tank is negation then my gas station is a starting point
                    currTank = 0;
                }
                var travelCost = gas[i] - cost[i];
                totalTank += travelCost; // total tank and cost
                currTank += travelCost;
            }

            return totalTank >= 0 ? startingPos : -1;

        }
    }
}
