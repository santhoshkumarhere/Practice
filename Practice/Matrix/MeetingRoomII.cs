using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Matrix
{
    class MeetingRoomII
    {
        public static void Test()
        {
            var input = new int[][]
            {
               new int[] {2,15},new int[]{4,9 },new int[]{9,29 },new int[]{16, 23},new int[]{36, 45}
            };

            MinMeetingRooms(input);
        }

        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return 0;
            }
            var start = intervals.Select(x=>x[0]).OrderBy(x => x).ToArray();
            var end = intervals.Select(x => x[1]).OrderBy(x => x).ToArray();

            int startPointer = 0, endPointer = 0;

            int usedRooms = 0;

            while (startPointer < intervals.Length)
            {
                // If there is a meeting that has ended by the time the meeting at `start_pointer` starts
                if (start[startPointer] >= end[endPointer])
                {
                    usedRooms -= 1;
                    endPointer += 1;
                } 
                usedRooms += 1;
                startPointer += 1;
            }

            return usedRooms;
        }
    }
}
