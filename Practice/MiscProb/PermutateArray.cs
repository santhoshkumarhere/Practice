using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class PermutateArray
    {
        static IList<List<int>> output = new List<List<int>>();
        public static void Test()
        { 
            Permute(new List<int>(), new List<int> { 1, 2, 3 });
        }

        private static void Permute(List<int> current, List<int> remaining)
        {
            if (remaining.Count == 0)
            {
                output.Add(current);
            }
            else
            {
                for (var i = 0; i < remaining.Count; i++)
                {
                    var next = remaining.GetRange(i + 1, remaining.Count - (i + 1));
                    next.AddRange(remaining.GetRange(0, i));
                    var me = new List<int>(current);
                    me.Add(remaining[i]);
                    Permute(me, next);
                }
            }
        }
    }
}
