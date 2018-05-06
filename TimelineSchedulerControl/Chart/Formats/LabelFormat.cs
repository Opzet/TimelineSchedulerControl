using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineSchedulerControl.Chart.Formats
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LabelFormat
    {
        public Font Font { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Brush Color { get; set; }
        //public ChartTextAlign TextAlign { get; set; }
        public float Margin { get; set; }

    }
}
