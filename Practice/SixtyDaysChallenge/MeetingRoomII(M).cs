using System;
using System.Linq;

namespace Practice.SixtyDaysChallenge
{
    public class MeetingRoomII_M_
    {
        public static void Test()
        {
            var input = new int[][] { new int[] { 0, 30 }, new int[] { 5, 10 }, new int[] { 15, 20 } };
            var res = MinMeetingRooms(input); 
            input = new int[][]
            {
               new int[] {2,15},new int[]{4,9 },new int[]{9,29 },new int[]{16, 23},new int[]{36, 45}
            };

            res = MinMeetingRooms(input);
        }

        private static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            var start = intervals.Select(x => x[0]).OrderBy(x => x).ToArray();
            var end = intervals.Select(x => x[1]).OrderBy(x => x).ToArray();

            var startPointer = 0; var endPointer = 0; var usedRoom = 0;
            while( startPointer < intervals.Length)
            {
                if(start[startPointer] < end[endPointer])
                    usedRoom++;
                else
                    endPointer++;
                
                startPointer++;
            }

            return usedRoom;
        }
    }
}
