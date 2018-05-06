namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timelineSchedulerControl1 = new TimelineSchedulerControl.TimelineSchedulerControl();
            this.SuspendLayout();
            // 
            // timelineSchedulerControl1
            // 
            this.timelineSchedulerControl1.BarHeight = 15;
            this.timelineSchedulerControl1.BarSpacing = 10;
            this.timelineSchedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timelineSchedulerControl1.HeaderOneHeight = 32;
            this.timelineSchedulerControl1.HeaderTwoHeight = 20;
            this.timelineSchedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.timelineSchedulerControl1.MajorWidth = 140;
            this.timelineSchedulerControl1.MinorWidth = 20;
            this.timelineSchedulerControl1.Name = "timelineSchedulerControl1";
            this.timelineSchedulerControl1.Scheduler = null;
            this.timelineSchedulerControl1.ShowBarLabels = true;
            this.timelineSchedulerControl1.ShowSlack = true;
            this.timelineSchedulerControl1.Size = new System.Drawing.Size(800, 450);
            this.timelineSchedulerControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timelineSchedulerControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TimelineSchedulerControl.TimelineSchedulerControl timelineSchedulerControl1;
    }
}

