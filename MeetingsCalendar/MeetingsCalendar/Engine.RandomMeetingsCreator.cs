using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsCalendar
{
    public partial class Engine
    {
        public List<Meeting> Meetings { get; set; }

        private List<int> meetingsDuration;

        /// <summary>
        /// Creates random meetings in case there is no data available.
        /// </summary>
        /// <param name="nrEmpl">the number of employees</param>
        /// <param name="minMeetings">the minimum number of meetings per employee</param>
        /// <param name="maxMeetings">the maximum number of meetings per employee</param>
        /// <param name="maxDayDiff">the maximum period of time in which the meetings take place</param>
        public void CreateRandomMeetings(int nrEmpl, int minMeetings, int maxMeetings, int maxDayDiff)
        {
            CompleteMeetingsDurationList();
            CreateTheMeetingsList(nrEmpl, minMeetings, maxMeetings, maxDayDiff);
        }

        private void CompleteMeetingsDurationList()
        {
            this.meetingsDuration = new List<int>();
            int minimumDuration = 60; // minutes
            int interval = 30; // minutes

            // i min = 1 => the maximum meeting can take 30 minutes
            // i max = 8 => the maximum meeting can take 4 hours
            for (int i = 0; i < 7; i++)
            {
                this.meetingsDuration.Add(minimumDuration + i * interval);
            }
        }

        private void CreateTheMeetingsList(int nrEmpl, int minMeetings, int maxMeetings, int maxDayDiff)
        {
            Random ran = new Random();
            this.Meetings = new List<Meeting>();

            for (int i = 0; i < nrEmpl; i++)
            {
                int emplId = i;
                CreateTheMeetingsForCurrentEmployeeId(emplId, minMeetings, maxMeetings, maxDayDiff, ran);
            }
        }

        private void CreateTheMeetingsForCurrentEmployeeId(int emplId, int minMeetings, int maxMeetings, int maxDayDiff, Random ran)
        {
            int numberMeetings = ran.Next(minMeetings, maxMeetings);
            for (int i = 0; i < numberMeetings; i++)
            {
                Meeting meeting = new Meeting();
                meeting.EmplId = emplId;
                meeting.Start = DateTime.Today.AddHours(8).AddDays(ran.Next(0, maxDayDiff)).AddHours(ran.Next(0, 10));
                meeting.Finish = meeting.Start.AddMinutes(this.meetingsDuration[ran.Next(0, this.meetingsDuration.Count)]);

                this.Meetings.Add(meeting);
            }
        }
    }
}
