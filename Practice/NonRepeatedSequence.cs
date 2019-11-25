using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class NonRepeatedSequence
    {
        public static void GetResult()
        {
            string search = "abccba";

            char[] x = search.ToCharArray();
            string result = string.Empty;
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (result.IndexOf(x[i]) < 0)
                {
                    result = result + x[i];
                }
                else
                {
                    if (result.EndsWith("" + x[i]))
                    {
                        result = string.Empty;
                    }
                    else
                    {
                        result = result.Substring(result.IndexOf(x[i]) + 1, i);
                    }

                    result = result + x[i];
                }
            }

            Console.WriteLine(count > result.Length ? count : result.Length);
        }
    }
}
