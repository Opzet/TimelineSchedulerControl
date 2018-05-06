using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineSchedulerControl.Chart.Headers
{
    public class ColumnHeader
    {
        public Dictionary<RectangleF, DateTime> HeaderItems { get; set; } = new Dictionary<RectangleF, DateTime>();
        //public List<RectangleF> Rectangles { get; set; } = new List<RectangleF>();
        //public List<DateTime> Dates { get; set; } = new List<DateTime>();
        public List<RectangleF> Columns { get; set; } = new List<RectangleF>();
    }
}
