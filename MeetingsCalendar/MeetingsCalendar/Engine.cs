using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsCalendar
{
    public partial class Engine
    {
        public List<Employee> Employees { get; set; }

        public Engine()
        {

        }

        public void CreateEmployeesList(List<Meeting> meetings)
        {
            CreateList(meetings);
            ModifyMeetingsInEmployees();
        }

        private void CreateList(List<Meeting> meetings)
        {
            this.Employees = new List<Employee>();
            foreach (Meeting currentMeeting in meetings)
            {
                int indexInEmplList = -1;

                for (int i = 0; i < this.Employees.Count; i++)
                {
                    if (currentMeeting.EmplId == this.Employees[i].Id)
                    {
                        indexInEmplList = i;
                        break;
                    }
                }

                if (indexInEmplList == -1)
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Id = currentMeeting.EmplId;
                    newEmployee.Meetings.Add(currentMeeting);
                    this.Employees.Add(newEmployee);
                }
                else
                {
                    this.Employees[indexInEmplList].Meetings.Add(currentMeeting);
                }
            }
        }

        private void ModifyMeetingsInEmployees()
        {
            foreach (Employee currentEmployee in this.Employees)
            {
                OrderLists(currentEmployee);
                SetYPos(currentEmployee);
            }
        }

        private static void OrderLists(Employee currentEmployee)
        {
            currentEmployee.Meetings = currentEmployee.Meetings.OrderBy(x => x.Finish).ToList();
            currentEmployee.Meetings = currentEmployee.Meetings.OrderBy(x => x.Start).ToList();
        }

        private void SetYPos(Employee currentEmployee)
        {
            for (int i = 0; i < currentEmployee.Meetings.Count; i++)
            {
                Meeting currentMeeting = currentEmployee.Meetings[i];
                currentMeeting.YPos = GetAvailableY(currentEmployee, currentMeeting, i, 0);
            }
        }

        private int GetAvailableY(Employee currentEmployee, Meeting currentMeeting, int currentMeetingIndex, int YPos)
        {
            for (int i = 0; i < currentMeetingIndex; i++)
            {
                if (currentEmployee.Meetings[i].YPos == YPos && currentEmployee.Meetings[i].Finish > currentMeeting.Start) // there is an overlapping
                {
                    YPos++;
                    return GetAvailableY(currentEmployee, currentMeeting, currentMeetingIndex, YPos);
                }
            }
            return YPos;
        }
    }
}
