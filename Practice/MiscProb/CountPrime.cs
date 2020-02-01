using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    public class CountPrime
    {
        static IList<int> list = new List<int> { 2, 3};
        public static void Test()
        {
           var result = CountPrimeNumbers(665);
        }

        public static int CountPrimeNumbers(int n)
        {
            if (n <= 1) return 0;

            var isVisited = new bool[n];
            isVisited[0] = true;
            isVisited[1] = true;

            var primeCount = 0;
            for (int i = 2; i < n; i++)
            {
                if (isVisited[i])
                {
                    continue;
                }
                else
                {
                    primeCount++;
                    for (var j = 1; j < n; j++)
                    {
                        if (i * j >= n) break;
                        isVisited[i * j] = true;
                    }
                }
            }

            return primeCount;
        }

        public static int CountPrimeNumberss(int n)
        {
            if (n == 0 || n == 1 || n == 2) return 0; 
            if (n == 3) return 1;

            for(var i=5; i< n; i++)
            {
                if(IsPrime(i))
                {
                    list.Add(i);
                }
            }
            return list.Count;
        }

        public static bool IsPrime(int n)
        {
            var count = list.Count;
            for(var i=0; i < count && list[i] < n/2; i++)
            {
               if((n % list[i]) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}


