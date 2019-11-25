using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.doubleRecursion
{
    class RecursionMultiplication
    {
        public int productRecursive(int n)
        {
            if (n == 0)
            {
                Console.WriteLine("Base Condition met!");
                return 1;
            }
            Console.WriteLine(n);
            return productRecursive(n - 1);
        }
    }
}
