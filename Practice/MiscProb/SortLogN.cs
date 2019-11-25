using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class SortLogN
    {
        public static void Test()
        {
            var x = new int[] {90, 8, 2, 40,1, 4, 1};
            Sort(x, 100);
        }
        public static void Sort(int[] input, int highestPossibleScore)
        {
            var result = new int[highestPossibleScore+1];
            foreach (var val in input)
            {
                result[val]++;
            }

            var sortedArray = new int[input.Length];
            int sortedArrayIndex = 0;

            for (var i = highestPossibleScore; i >= 0; i--)
            {
                int count = result[i];
                for(var occurences = 0; occurences < count; occurences++)
                {
                    sortedArray[sortedArrayIndex] = i;
                    sortedArrayIndex++;
                }
            }
        }

    }
}
