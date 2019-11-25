using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.doubleRecursion
{
    class RecursionTest
    {
        public int productRecursive(int n)
        {
            if (n == 0)
            {
                Console.WriteLine("Base Condition met!");
                return 1;
            }


            int x = productRecursive(n - 1);
            Console.WriteLine(x);
            return x;

        }
    }
}
