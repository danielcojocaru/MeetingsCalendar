namespace MeetingsCalendar
{
    partial class CalendarUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbx = new System.Windows.Forms.ComboBox();
            this.calendar = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee Id:";
            // 
            // cbx
            // 
            this.cbx.FormattingEnabled = true;
            this.cbx.Location = new System.Drawing.Point(89, 6);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(129, 21);
            this.cbx.TabIndex = 2;
            this.cbx.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(12, 33);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(206, 20);
            this.calendar.TabIndex = 3;
            this.calendar.ValueChanged += new System.EventHandler(this.calendar_ValueChanged);
            // 
            // CalendarUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 720);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.cbx);
            this.Controls.Add(this.label1);
            this.Name = "CalendarUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meetings Calendar";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CalendarUI_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx;
        private System.Windows.Forms.DateTimePicker calendar;
    }
}