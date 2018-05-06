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
        }

        private void PaintMinorHeader(Graphics gfx, TimelineChart chart)
        {
            foreach (var rectangle in chart.MinorHeader.Rectangles)
            {
                PaintHeaderRectangle(gfx, rectangle);
            }
            foreach (var rectangle in chart.MinorHeader.Columns)
            {
                PaintHeaderRectangle(gfx, rectangle);
            }
        }

        private void PaintMajorHeader(Graphics gfx, TimelineChart chart)
        {
            foreach (var rectangle in chart.MajorHeader.Rectangles)
            {
                PaintHeaderRectangle(gfx, rectangle);
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
    }
}
