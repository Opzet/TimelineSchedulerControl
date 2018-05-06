using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineSchedulerControl.Chart;
using TimelineSchedulerControl.Chart.Formats;

namespace TimelineSchedulerControl.Painter
{
    public class ChartPainter
    {
        private TimelineSchedulerControl control;

        public ChartPainter(TimelineSchedulerControl control)
        {
            this.control = control;
        }

        public void PaintChart(Graphics gfx, TimelineChart chart)
        {
            PaintMajorHeader(gfx, chart);
            PaintMinorHeader(gfx, chart);
            PaintEventBars(gfx, chart);
        }



        private void PaintMinorHeader(Graphics gfx, TimelineChart chart)
        {
            var stringFormat = new StringFormat() { Alignment = control.LabelsFormat.Aligment };
            stringFormat.LineAlignment = StringAlignment.Center;
            foreach (var rectangle in chart.MinorHeader.HeaderItems)
            {
                PaintHeaderRectangle(gfx, rectangle.Key);
                gfx.DrawString(rectangle.Value.Day.ToString(), control.Font, control.LabelsFormat.Color, rectangle.Key, stringFormat);
            }
            foreach (var rectangle in chart.MinorHeader.Columns)
            {
                PaintHeaderRectangle(gfx, rectangle);
            }
        }

        private void PaintMajorHeader(Graphics gfx, TimelineChart chart)
        {
            var stringFormat = new StringFormat() { Alignment = control.LabelsFormat.Aligment };
            stringFormat.LineAlignment = StringAlignment.Center;
            foreach (var rectangle in chart.MajorHeader.HeaderItems)
            {
                PaintHeaderRectangle(gfx, rectangle.Key);
                gfx.DrawString(rectangle.Value.ToString("MMMM"), control.Font, control.LabelsFormat.Color, rectangle.Key, stringFormat);
            }
            foreach (var rectangle in chart.MajorHeader.Columns)
            {
                PaintHeaderRectangle(gfx, rectangle);
            }

        }
        private void PaintHeaderRectangle(Graphics gfx, RectangleF rectangle)
        {
            var brush = new LinearGradientBrush(rectangle, control.HeaderFormat.GradientLight, control.HeaderFormat.GradientDark, LinearGradientMode.Vertical);
            gfx.FillRectangle(brush, rectangle);
            gfx.DrawRectangle(control.HeaderFormat.Border, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        private void PaintEventBars(Graphics gfx, TimelineChart chart)
        {
            foreach(var eventBar in control.Scheduler.Events)
            {
                gfx.FillRectangle(eventBar.Format.ForeFill, eventBar.EventRectangle);
                gfx.DrawRectangle(eventBar.Format.Border, eventBar.EventRectangle.X, eventBar.EventRectangle.Y, eventBar.EventRectangle.Width, eventBar.EventRectangle.Height);
            }

        }

    }
}
