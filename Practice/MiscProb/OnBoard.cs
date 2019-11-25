using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class OnBoard
    {

        public static void Test()
        {
            var result = Compute(3, new int[]{3, 4, 2, 1, 5});
        }

        public static bool Compute(int totalFlightLength, int[] movieLength)
        {
            var set = new HashSet<int>();

            foreach (var len in movieLength)
            {
                var x = totalFlightLength - len;
                if (set.Contains(x))
                {
                    return true;
                }

                set.Add(len);
            }

            return false;
        }
    }
}
