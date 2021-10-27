using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice.LeetCode2021.Arrays
{
    public class SortColorDutchFlagEPI
    {
        public enum Color {Red, White, Blue};

        public static void Test()
        {
            DutchFlagPartition(2, new List<Color>() { Color.White, Color.Blue, Color.Red, Color.Blue, Color.White });
        }

        private static void DutchFlagPartition(int partition, List<Color> list)
        {
            // not sure about this pivot thing
            var pivot = list[partition];

            int smaller = 0, current = 0, larger = list.Count;
            
            while (current < larger)
            {
                // A.get(equal) is the incoming unclassified element.
                if (list[current] < pivot)
                {
                    Swap(list, smaller++, current++);
                }
                else if (list[current] == pivot)
                {
                    ++current;
                }
                else
                { // A.get(equal) > pivot.
                    Swap(list, current, --larger);
                }

            }
        }

        private static void Swap(List<Color> list, int i, int j)
        {
            var temp = list[j];
            list[j] = list[i];
            list[i] = temp;
        }
    }
}
