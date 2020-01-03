using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
   public class Permutation
    {
       static IList<string> output = new List<string>();
 

        // Driver Code 
        public static void Test()
        {
            Permutate("", "1234");
        }

        public static void Permutate(string combination, string next)
        {
            if (string.IsNullOrEmpty(next))
            {
                Console.WriteLine($"Added -> {combination}");
                output.Add(combination);
            }
            else
            {
                for (var i = 0; i < next.Length; i++)
                {
                    Permutate(combination + next[i], next.Substring(0, i) + next.Substring(i + 1));
                }
            }
           
        }

    } 

}
