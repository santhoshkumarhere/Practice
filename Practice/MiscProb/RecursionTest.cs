using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class RecursionTest
    {
        List<string> output = new List<string>();
      Dictionary<string, string> dict = new Dictionary<string, string>()
      {
          {"2", "abc" },
          {"3", "def" },
          {"4", "ghi" }
      };

        public void Test(string combination, string nextValue)
        {
            if (nextValue.Length == 0)
            {
                output.Add(combination);
            }
            else
            {
                var digit = nextValue.Substring(0, 1);
                var current = dict[digit];
                foreach (var letter in current)
                {
                    Test(combination + letter, nextValue.Substring(1));
                }
            }
        }
    }
}
