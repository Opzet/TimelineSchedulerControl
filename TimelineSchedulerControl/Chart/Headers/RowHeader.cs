using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineSchedulerControl.Chart.Headers
{
    public class RowHeader
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<RectangleF> Rectangles { get; set; } = new List<RectangleF>();
        public List<PointF> Lines { get; set; } = new List<PointF>();
    }
}
