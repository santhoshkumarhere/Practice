using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    class SubSet
    {
        public static void Test()
        {
            var list = new List<List<int>>();
            // Perm("", "123", list);
            Perm2(new List<int>(), new int[] { 1, 2, 3 }, list,0);
        }

        private static void Perm2(IList<int> comb, int[] next, IList<List<int>> result, int start)
        {
            result.Add(new List<int>(comb));
            return;

            for(var i=0; i < next.Length; i++)
            {
                comb.Add(next[i]);
                Perm2(comb, next, result, i);
            }
        }

        private static void Perm(string comb, string next, IList<string> result)
        {
            if(next.Length == 0)
            {
                result.Add(comb);
            }
            for(var i=0; i<next.Length; i++)
            {
                Perm(comb + next[i], next.Substring(0, i) + next.Substring(i + 1), result);
            }
        }
    }
}

/*
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
 * */
