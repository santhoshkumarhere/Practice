using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.LeetCode2021.Interval
{
    public class RectangleOverlap
    {
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            ///draw rectangle and understand this 
            ///compare by starting left bottom edge of rect2 with right top edge of rec1
            if (rec1[0] == rec1[2] || rec1[1] == rec1[3] ||
               rec2[0] == rec2[2] || rec2[1] == rec2[3])
            {
                // the line cannot have positive overlap
                return false;
            }
            //x < x && y < y
            //compare left bottom edge and right top corner edge and viceversa
            return rec2[0] < rec1[2] && rec2[1] < rec1[3] && rec1[0] < rec2[2] && rec1[1] < rec2[3];
        }
    }
}
