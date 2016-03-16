using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingsCalendar
{
    public partial class CalendarUI : Form
    {
        private int startPointX = 12;
        private int startPointY = 67;
        private int gap = 0;
        private int calendarLengh = 1500;

        private int sizeX = 60;
        private int sizeY = 40;
        private int meetingSize = 150;

        protected Label[] theLabels;

        private Engine engine;
        private List<Label> lblMeetings = new List<Label>();

        public CalendarUI(List<int> emplIds)
        {
            CreateEngine();

            InitializeComponent();
            CompleteCombobox(this.engine.Employees);
            SetUI();
        }

        private void CreateEngine()
        {
            this.engine = new Engine();

            this.engine.CreateRandomMeetings(500, 200, 300, 60);
            this.engine.CreateEmployeesList(this.engine.Meetings);

        }

        private void CompleteCombobox(List<Employee> emplList)
        {
            foreach (Employee currentEmpl in emplList)
            {
                cbx.Items.Add(currentEmpl.Id);
            }
            cbx.SelectedIndex = 0;
        }

        private void SetUI()
        {
            SetTimeLabels();
        }

        private void SetTimeLabels()
        {
            this.theLabels = new Label[16];
            int index = 0;
            string name = "a";

            int currentX = this.startPointX;
            int currentY = this.startPointY;

            for (int x = 0; x < 16; x++)
            {

                name = string.Format("{0}a", x.ToString());
                theLabels[index] = new System.Windows.Forms.Label();
                theLabels[index].BackColor = System.Drawing.SystemColors.ControlLight;
                theLabels[index].Location = new System.Drawing.Point(currentX, currentY);
                theLabels[index].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                theLabels[index].Size = new System.Drawing.Size(this.sizeX, this.sizeY);
                theLabels[index].Text = string.Format("{0}:00", (x + 7).ToString());
                theLabels[index].TextAlign = System.Drawing.ContentAlignment.TopRight;
                theLabels[index].Name = name;
                this.Controls.Add(theLabels[index]);

                index++;
                currentY += this.sizeY + this.gap;
            }
        }

        private void CalendarUI_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Pen firstPen = new Pen(Color.Gray, 1);
            Pen secondPen = new Pen(Color.Gray, 2);

            for (int i = 0; i < 16*2 + 1; i++)
            {
                if (i % 2 == 0)
                {
                    gr.DrawLine(secondPen, this.startPointX + this.sizeX, this.startPointY + i * this.sizeY / 2, this.calendarLengh, this.startPointY + i * this.sizeY / 2);
                }
                else
                {
                    gr.DrawLine(firstPen, this.startPointX + this.sizeX, this.startPointY + i * this.sizeY / 2, this.calendarLengh, this.startPointY + i * this.sizeY / 2);
                }
                
            }
        }

        private void CreateUIMeetings()
        {
            List<Meeting> meetings = engine.Employees[this.cbx.SelectedIndex].Meetings.Where(x => x.Start > calendar.Value.Date && x.Start < calendar.Value.Date.AddDays(1)).ToList();
            
            foreach (Meeting meeting in meetings)
            {
                CreateUIForCurrentMeeting(meeting.Start, meeting.Finish, meeting.YPos);
            }
        }

        private void CreateUIForCurrentMeeting(DateTime start, DateTime finish, int yPos)
        {
            int startX = this.startPointX + this.sizeX + 5 + yPos * this.meetingSize;
            int startY = this.startPointY + (start.Hour - 7) * this.sizeY;
            int sizeY = (finish - start).Hours * this.sizeY + (finish - start).Minutes / 30 * this.sizeY / 2;
            
            Label label = new Label();
            label.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E5FF");
            label.Location = new System.Drawing.Point(startX, startY);
            label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label.Size = new System.Drawing.Size(this.meetingSize, sizeY);
            label.Text = string.Format("Day: {0}\nStarts at: {1}\nExpected to end at:{2}", start.Date.ToString("dd.MM.yyy"), start.TimeOfDay, finish.TimeOfDay);
            label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblMeetings.Add(label);
            this.Controls.Add(label);
        }

        private void calendar_ValueChanged(object sender, EventArgs e)
        {
            DisposeCurrentMeetings();
            CreateUIMeetings();
        }

        private void DisposeCurrentMeetings()
        {
            foreach (Label item in this.lblMeetings)
            {
                item.Dispose();
            }
            this.lblMeetings.Clear();
            this.lblMeetings = new List<Label>();
        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeCurrentMeetings();
            CreateUIMeetings();
        }
    }
}
