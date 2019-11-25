using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MiscProb
{
    class PascalTriangle
    {
        public static void Test()
        {
            Compute(5);
        }

        private static IList<IList<int>> Compute(int end)
        {
            var result = new List<IList<int>>();
            
            var lastList = new List<int>(){1, 1};
            result.Add(new List<int>(){1});
            result.Add(lastList);
            if (end < 2)
            {
                return result;
            }
           
            for (int i = 2; i < end; i++)
            {
                var counter = 0;
                var temp = new List<int>();
                while (counter <= i)
                {
                   
                    if (counter == 0 || counter == i)
                    { 
                        temp.Add(lastList[0]);
                    }
                    else
                    {
                        temp.Add(lastList[counter - 1] + lastList[counter]);
                    }

                    counter++;
                }

                lastList = temp;
                result.Add(temp);
            }

            return result;
        }
    }
}
