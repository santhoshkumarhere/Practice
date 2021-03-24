using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class RobotBoundedInCircle
    {
        public static void Test()
        {
            var result = IsRobotBounded("GGLLGG");
        }

        private static bool IsRobotBounded(string instructions)
        {
            int x = 0, y = 0, direction = 0;

            foreach(var ch in instructions)
            {
                if (ch == 'L')
                    direction = (direction + 1) % 4;
                else if (ch == 'R')
                    direction = (direction + 3) % 4;
                else if( ch == 'G')
                {
                    switch (direction)
                    {
                        case 0: y++; break;
                        case 1: x--; break;
                        case 2: y--; break;
                        case 3: x++; break;
                    }
                }
            }

            return (direction != 0) || (x == 0 && y == 0);
        }
    }
}
