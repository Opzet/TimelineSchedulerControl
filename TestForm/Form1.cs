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
            TimelineScheduler schedule = new TimelineScheduler(DateTime.Now, DateTime.Now.AddDays(35));
            schedule.Events.Add(new EventBar() { StartDate = new DateTime(2018,5,8), EndDate = new DateTime(2018, 5, 12), Row = 0, Text = "Hello" });
            schedule.Events.Add(new EventBar() { StartDate = new DateTime(2018, 5, 10), EndDate = new DateTime(2018, 5, 11), Row = 1, Text = "Hello" });
            schedule.Events.Add(new EventBar() { StartDate = new DateTime(2018, 5, 15), EndDate = new DateTime(2018, 6, 11), Row = 2, Text = "Hello" });

            timelineSchedulerControl1.Init(schedule);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
