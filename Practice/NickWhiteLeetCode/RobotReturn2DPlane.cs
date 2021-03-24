using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.NickWhiteLeetCode
{
    public class RobotReturn2DPlane
    {
        public static void Test()
        {
            var result = JudgeCircleEffective("UD");
            result = JudgeCircleEffective("URDL");
            result = JudgeCircleEffective("LDRRLRUULR");
        }

        public static bool JudgeCircle(string moves)
        {
            if (moves == null || string.IsNullOrEmpty(moves)) return true;

            var dict = new Dictionary<char, int[]>
            {
                {'U', new int[] {-1, 0}},
                {'D', new int[] {1, 0}},
                {'L', new int[] {0, -1}},
                {'R', new int[] {0, 1}}
            };
            var x = 0; var y = 0;
            foreach(var m in moves)
            {
                var currCoordinate = dict[m];
                x += currCoordinate[0];
                y += currCoordinate[1];
            }
            return x == 0 && y == 0;
        }

        public static bool JudgeCircleEffective(string moves)
        {
            if (moves == null || string.IsNullOrEmpty(moves)) return true;
            var x = 0; var y = 0;
            foreach (var m in moves)
            {
                if(m == 'U')
                {
                    x -= 1;
                }
                else if (m == 'D')
                {
                    x += 1;
                }
                else if (m == 'L')
                {
                    y -= 1;
                }
                else if (m == 'R')
                {
                    y += 1;
                }

            }
            return x == 0 && y == 0;
        }
    }
}
