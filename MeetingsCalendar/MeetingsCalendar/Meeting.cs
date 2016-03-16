using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsCalendar
{
    public class Meeting
    {
        public int EmplId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int YPos { get; set; }
    }
}
