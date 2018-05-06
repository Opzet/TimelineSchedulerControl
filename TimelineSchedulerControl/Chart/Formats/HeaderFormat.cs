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
    public class HeaderFormat
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Brush Color { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Pen Border { get; set; }
        public Color GradientLight { get; set; }
        public Color GradientDark { get; set; }
    }
}
