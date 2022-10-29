using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineSchedulerControl.Chart.EventBars;

namespace TimelineSchedulerControl.Scheduler
{
    public class TimelineScheduler
    {
        public List<EventBar> Events { get; set; } = new List<EventBar>();
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddHours(1);

        public TimelineScheduler()
        {
          
        }
        public TimelineScheduler(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
