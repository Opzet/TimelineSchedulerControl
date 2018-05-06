using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineSchedulerControl.Chart.Formats;

namespace TimelineSchedulerControl.Chart.EventBars
{
    public class EventBar
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Text { get; set; }
        public int Row { get; set; }
        public RectangleF EventRectangle { get; set; }
        public EventBarFormat Format { get; set; } = new EventBarFormat()
        {
            Color = Brushes.Black,
            Border = Pens.Maroon,
            BackFill = Brushes.MediumSlateBlue,
            ForeFill = Brushes.YellowGreen,
            SlackFill = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Blue, Color.Transparent)
        };
    }
}
