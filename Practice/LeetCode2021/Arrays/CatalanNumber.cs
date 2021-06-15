using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Arrays
{
    public class CatalanNumber
    {
        public static void Test()
        {
            var result = FindCatalanNumber(4);
        }

        private static int FindCatalanNumber(int n)
        {
            var catalan = new int[n + 1];

            catalan[0] = catalan[1] = 1;

            for(var i = 2; i <= n; i++)
            {
                for(var j = 0; j <= i; j++)
                {
                    catalan[i] +=  (j - 1 < 0 ? 1 : catalan[j - 1]) * catalan[i - j]; // j = index, length = i;
                }
            }

            return catalan[n];
        }
    }
}

//[1, 2, 3, 4, 5, 6, 7]
//F(index, numberOfElements] = F(2, 7) = G[2] * G[4] = G[index -1] * G[Length - index];
