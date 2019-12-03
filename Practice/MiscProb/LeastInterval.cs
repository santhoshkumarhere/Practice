namespace Practice.MiscProb
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    class LeastInterval
    {
        public static void Test()
        {
            var result = CalculateIntervals(new char[] { 'A', 'Z', 'B', 'B', 'X', 'X', 'X' }, 2);
            var result2 = CalculateIntervals(new char[] { 'A', 'A', 'B', 'B', 'B', 'A' }, 2);
        }


        public static int CalculateIntervals(char[] tasks, int n)
        {
            var dict = tasks.Distinct().ToDictionary(t => t, t => tasks.Count(c => c == t));
            var max = dict.Max(d => d.Value);
            var maxTaskCount = dict.Count(d => d.Value == max);

            var part = max - 1;
            var noOfEmptySlots = part * (n - (maxTaskCount - 1));

            var taskRemaining = tasks.Length - (maxTaskCount * max);

            var idle = Math.Max(0, noOfEmptySlots - taskRemaining);
            return tasks.Length + idle;
        }

    }
}
