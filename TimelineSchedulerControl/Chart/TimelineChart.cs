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
        public float Height { get; private set; }
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
            this.startDate = new DateTime(startDate.Year, startDate.Month, 1);
            this.endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
            chartSpan = endDate - startDate;
            Width = GetPixelSpan(chartSpan);
            Height = control.Height;
            MajorHeader.HeaderItems.Clear();
            MinorHeader.HeaderItems.Clear();
            EventBars.Clear();

            GenerateMajorHeader();
            GenerateRowHeader();
            GenerateEventBars();
        }

        private void GenerateMajorHeader()
        {
            DateTime currentDate = new DateTime(startDate.Year, startDate.Month, 1);
            RectangleF headerRect, columnRect;
            int numMonth = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
            PointF headerLoc = new PointF(0, 0);
            SizeF headerSize = new SizeF(0, control.HeaderOneHeight);
            PointF columnLoc = new PointF(0, control.HeaderOneHeight);
            SizeF columnSize = new SizeF(0, Height - control.HeaderOneHeight);
            for (int i = 0; i <= numMonth; i++)
            {
                currentDate = currentDate.AddMonths(i);
                var daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

                headerSize.Width = GetPixelSpan(TimeSpan.FromDays(daysInMonth));
                columnSize.Width = headerSize.Width;
                headerRect = new RectangleF(headerLoc, headerSize);
                columnRect = new RectangleF(columnLoc, columnSize);
                MajorHeader.HeaderItems.Add(headerRect, currentDate);
                MajorHeader.Columns.Add(columnRect);

                GenerateMinorHeader(currentDate, new PointF(headerLoc.X, headerLoc.Y + headerSize.Height));
                headerLoc.X = headerRect.Right;
                columnLoc.X = headerLoc.X;
            }
        }
        private void GenerateMinorHeader(DateTime date, PointF startLoc)
        {
            SizeF headerSize = new SizeF(GetPixelSpan(TimeSpan.FromDays(1)), control.HeaderTwoHeight);
            PointF columnLoc = new PointF(startLoc.X, control.HeaderOneHeight + control.HeaderTwoHeight);
            SizeF columnSize = new SizeF(GetPixelSpan(TimeSpan.FromDays(1)), Height - control.HeaderOneHeight - control.HeaderTwoHeight);
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            for (int i = 0; i < daysInMonth; i++)
            {
                var rect = new RectangleF(startLoc, headerSize);
                MinorHeader.HeaderItems.Add(rect, date.AddDays(i));
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
            float headerBotom = control.HeaderOneHeight + control.HeaderTwoHeight;
            PointF barLocation = new PointF(0, 0);
            SizeF barSize = new SizeF(0, control.BarHeight);
            foreach (var eventBar in control.Scheduler.Events)
            {
                barLocation.X = GetPixelSpan(eventBar.StartDate - startDate);
                barLocation.Y = (eventBar.Row * (control.BarHeight + control.BarSpacing)) + headerBotom + control.BarSpacing;
                barSize.Width = GetPixelSpan(eventBar.EndDate - eventBar.StartDate);
                eventBar.EventRectangle = new RectangleF(barLocation, barSize);
            }
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
