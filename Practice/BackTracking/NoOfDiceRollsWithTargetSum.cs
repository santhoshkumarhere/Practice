using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BackTracking
{
    class NoOfDiceRollsWithTargetSum
    {
        public static void Test()
        {
            var dict = new Dictionary<(int, int), int>();
            var result = DFS(2, 6, 7, dict); 
        }

        static int MOD = (int)1e9 + 7;
        private static int DFS(int d, int faces, int target, Dictionary<(int, int), int> memo)
        {
            if (d == 0 && target == 0)
            {
                return 1;
            }

            if (d <= 0)
            {
                return 0;
            }

            if (memo.ContainsKey((d, target)))
            {
                return memo[(d, target)];
            }

            int result = 0;

            for (int i = 1; i <= faces; i++)
            {
                if (target - i >= 0)
                    result = (result + DFS(d - 1, faces, target - i, memo)) % MOD;
            }
            memo[(d, target)] = result;
            return result;
        }
    }
}
