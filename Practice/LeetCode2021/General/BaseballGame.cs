using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021
{
    class BaseballGame
    {
        public static void Test()
        {
            var res1 = CalPoints(new string[] { "5", "2", "C", "D", "+" });
            var res2 = CalPoints(new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" });
            var res3 = CalPoints(new string[] { "5" });
        }

        private static int CalPoints(string[] ops)
        {
            var points = 0;
            var list = new List<int>();
            var currIndex = -1;

            foreach (var op in ops)
            {
                int currentValue = 0;
                var isInt = int.TryParse(op, out currentValue);

                if (isInt)
                {
                    list.Add(currentValue);
                    currIndex++;
                }
                else if (op == "C")
                {
                    list.RemoveAt(currIndex);
                    currIndex--;
                }
                else if (op == "D")
                {
                    list.Add(list[currIndex] * 2);
                    currIndex++;
                }
                else
                {
                    list.Add(list[currIndex] + list[currIndex - 1]);
                    currIndex++;
                }
            }

            foreach (var item in list)
            {
                points += item;
            }
            return points;
        }
    }
}
