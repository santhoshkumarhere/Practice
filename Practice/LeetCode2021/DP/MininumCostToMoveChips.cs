using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.DP
{
    public class MininumCostToMoveChips
    {
        public static void Test()
        {
            var pos = new int[] { 2, 2, 2, 3, 3 };
            var es = MinCostToMoveChips(pos);
            var res2 = MinCostToMoveChips(new int[] {1, 100 });
             res2 = MinCostToMoveChips(new int[] { 1, 99 });

             res2 = MinCostToMoveChips(new int[] { 2, 100 });
        }

        private static int MinCostToMove(int[] position)
        {
            var evenCount = 0;
            var oddCount = 0;

            foreach(var pos in position)
            {
                if (pos % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
            return Math.Min(evenCount, oddCount);
        }

        private static int MinCostToMoveChips(int[] position)
        {
            if (position.Length == 1) //Think brute force solution. All kind of other solution leads to waste of time
                return 0;

           var costToMove = int.MaxValue;

           for(var i = 0; i < position.Length;i++)
            {
                var runningMove = 0;
                for(int j = 0; j < position.Length; j++)
                {
                    var cost = 0;
                    if (Math.Abs(position[j] - position[i]) % 2 != 0)
                        cost = 1;

                    runningMove += cost;
                }
                costToMove = Math.Min(costToMove, runningMove);
            }
            return costToMove;
        }
    }
}
