using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsCalendar
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Meeting> Meetings { get; set; }

        public Employee()
        {
            this.Meetings = new List<Meeting>();
        }
    }
}
