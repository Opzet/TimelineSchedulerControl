using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineSchedulerControl.Chart.EventBars;
using TimelineSchedulerControl.Chart.Headers;

namespace TimelineSchedulerControl.Chart
{
    public class TimelineChart
    {
        public ColumnHeader MajorHeader { get; set; } = new ColumnHeader();
        public ColumnHeader MinorHeader { get; set; } = new ColumnHeader();
        public RowHeader RowHeader { get; set; } = new RowHeader();
        public List<EventBar> EventBars { get; set; } = new List<EventBar>();

        public float Scale { get; set; } = 20;
        public float Height { get; private set; } = 600;
        public float Width { get; private set; }

        private DateTime startDate;
        private DateTime endDate;
        private TimeSpan chartSpan;

        TimelineSchedulerControl control;

        public TimelineChart(TimelineSchedulerControl control)
        {
            this.control = control;
        }
        public void GenerateChart(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            chartSpan = endDate - startDate;
            Width = GetPixelSpan(chartSpan);

            GenerateMajorHeader();
            GenerateRowHeader();
            GenerateEventBars();
        }

        private void GenerateMajorHeader()
        {
            DateTime currMonth;
            int daysInMonth;
            int numMonth = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
            PointF headerLoc = new PointF(0, 0);
            SizeF headerSize = new SizeF(0, control.HeaderOneHeight);
            PointF columnLoc = new PointF(0, control.HeaderOneHeight);
            SizeF columnSize = new SizeF(0, Height - control.HeaderOneHeight);
            for (int i = 0; i <= numMonth; i++)
            {
                currMonth = startDate.AddMonths(i);
                MajorHeader.Dates.Add(currMonth);
                daysInMonth = DateTime.DaysInMonth(currMonth.Year, currMonth.Month);
                headerSize.Width = GetPixelSpan(TimeSpan.FromDays(daysInMonth));
                columnSize.Width = headerSize.Width;
                MajorHeader.Rectangles.Add(new RectangleF(headerLoc, headerSize));
                MajorHeader.Columns.Add(new RectangleF(columnLoc, columnSize));
                GenerateMinorHeader(daysInMonth, new PointF(headerLoc.X, headerLoc.Y + headerSize.Height));
                headerLoc.X = MajorHeader.Rectangles[i].Right;
                columnLoc.X = headerLoc.X;

            }
        }
        private void GenerateMinorHeader(int daysNumb, PointF startLoc)
        {
            SizeF headerSize = new SizeF(GetPixelSpan(TimeSpan.FromDays(1)), control.HeaderTwoHeight);
            PointF columnLoc = new PointF(startLoc.X, control.HeaderOneHeight + control.HeaderTwoHeight);
            SizeF columnSize = new SizeF(GetPixelSpan(TimeSpan.FromDays(1)), Height - control.HeaderOneHeight - control.HeaderTwoHeight);
            for (int i = 0; i < daysNumb; i++)
            {
                var rect = new RectangleF(startLoc, headerSize);
                MinorHeader.Rectangles.Add(rect);
                startLoc.X = rect.Right;
                MinorHeader.Columns.Add(new RectangleF(columnLoc, columnSize));
                columnLoc.X = rect.Right;
            }
        }
        private void GenerateRowHeader()
        {

        }
        private void GenerateEventBars()
        {

        }

        private TimeSpan GetTimeSpan(float width)
        {
            return TimeSpan.FromDays(width / Scale);
        }
        private float GetPixelSpan(TimeSpan span)
        {
            return (float)span.TotalDays * Scale;
        }
    }
}
