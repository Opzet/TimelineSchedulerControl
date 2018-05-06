﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using TimelineSchedulerControl.Chart;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimelineSchedulerControl.Chart.Formats;
using TimelineSchedulerControl.Painter;
using TimelineSchedulerControl.Scheduler;

namespace TimelineSchedulerControl
{
    public partial class TimelineSchedulerControl : UserControl
    {
        #region Properties
        [Category("Header")]
        public int HeaderOneHeight { get; set; } = 32;
        [Category("Header")]
        public int HeaderTwoHeight { get; set; } = 20;
        [Category("Header"), DisplayName("Header Format")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HeaderFormat HeaderFormat { get; set; } = new HeaderFormat()
        {
            Color = Brushes.Black,
            Border = new Pen(SystemColors.ActiveBorder),
            GradientLight = SystemColors.ButtonHighlight,
            GradientDark = SystemColors.ButtonFace
        };
        [Category("Header"), DisplayName("Headers Label Format")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LabelFormat LabelsFormat { get; set; } = new LabelFormat()
        {
            Font = new Font("Arial", 8, FontStyle.Bold),
            Color = Brushes.Black,
            Margin = 3,
            Aligment = StringAlignment.Center
        };
        [Category("Bars")]
        public int BarSpacing { get; set; } = 10;
        [Category("Bars")]
        public int BarHeight { get; set; } = 20;
        [Category("Bars")]
        public bool ShowBarLabels { get; set; } = true;
        [Category("Bars")]
        public bool ShowSlack { get; set; } = true;
        [Category("Bars"), DisplayName("Bar Format")]

        public int MinorWidth { get; set; } = 20;
        public int MajorWidth { get; set; } = 140;
        #endregion
        public TimelineScheduler Scheduler { get; set; }

        private TimelineChart chart;
        private ChartPainter painter;


        public TimelineSchedulerControl()
        {
            InitializeComponent();
            chart = new TimelineChart(this);
            painter = new ChartPainter(this);
        }

        public void Init(TimelineScheduler scheduler)
        {
            Scheduler = scheduler;
            chart.GenerateChart(scheduler.StartDate, scheduler.EndDate);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!this.DesignMode)
            {
                chart.GenerateChart(Scheduler.StartDate, Scheduler.EndDate);
                painter.PaintChart(e.Graphics, chart);
            }
                
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
    }
}
