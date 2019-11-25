using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.MiscProb
{
    class MergedMeet
    {

        public static void Test()
        {
            var test = new List<Meeting>()
            {
                new Meeting(2, 4),
                new Meeting(6, 7),
                new Meeting(1, 3)
            };
            Merged(test);
        }

        public static void Merged(List<Meeting> meetings)
        {
            var sortedMeeting = meetings.Select(m => new Meeting(m.StartTime, m.EndTime)).OrderBy(x => x.StartTime).ToList();

            var mergedMeeting = new List<Meeting>
            {
                sortedMeeting[0]
            };

            foreach (var currentMeeting in sortedMeeting)
            {
                var lastMeeting = mergedMeeting.Last();
                if (currentMeeting.StartTime <= lastMeeting.EndTime)
                {
                    lastMeeting.EndTime = Math.Max(lastMeeting.EndTime, currentMeeting.EndTime);
                }
                else
                {
                    mergedMeeting.Add(currentMeeting);
                }
            }
        }
    }

    class Meeting
    {
        public int StartTime;
        public int EndTime;

        public Meeting(int startTime, int endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
