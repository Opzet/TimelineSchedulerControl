using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimelineSchedulerControl.Chart.EventBars;
using TimelineSchedulerControl.Scheduler;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DateTime today = DateTime.Now;


            TimelineScheduler schedule = new TimelineScheduler(DateTime.Now, DateTime.Now.AddDays(1));
            schedule.Events.Add(new EventBar() { StartDate = today.AddHours (1), EndDate = today.AddHours(5), Row = 0, Text = "Task 1" });
            schedule.Events.Add(new EventBar() { StartDate = today.AddHours(6), EndDate = today.AddHours(8), Row = 1, Text = "Task 2" });
            schedule.Events.Add(new EventBar() { StartDate = today.AddHours(9), EndDate = today.AddHours(11), Row = 2, Text = "Task 3" });

            timelineSchedulerControl1.Init(schedule);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
