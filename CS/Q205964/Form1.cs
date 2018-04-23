using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Gauges.Circular;
using DevExpress.XtraGauges.Base;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Core.Drawing;

namespace Q205964 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            CreateCircularGauge();
        }

        private void CreateCircularGauge() {
            GaugeControl gaugeControl = new GaugeControl();
            CircularGauge gauge = (CircularGauge)gaugeControl.AddGauge(GaugeType.Circular);
            gauge.AddDefaultElements();
            ArcScaleComponent scale = gauge.Scales[0];
            scale.BeginUpdate();
            scale.Ranges.AddRange(CreateRanges(scale.MaxValue - scale.MinValue, scale.MinValue));
            scale.EndUpdate();
            gaugeControl.Dock = DockStyle.Fill;
            Controls.Add(gaugeControl);
        }

        private Color[] rangeContentColors = { Color.Red, Color.Yellow, Color.Green };

        private IRange[] CreateRanges(float ticks, float start) {
            int range = (int)Math.Floor((double)(ticks / rangeContentColors.Length));
            List<IRange> ranges = new List<IRange>();
            for (int i = 0; i < rangeContentColors.Length; )
                ranges.Add(CreateRange(rangeContentColors[i], (int)(range * i + start), (int)(range * ++i + start)));
            return ranges.ToArray();
        }

        private IRange CreateRange(Color contentColor, int startValue, int endValue) {
            IRange result = new ArcScaleRange();
            result.AppearanceRange.ContentBrush = new SolidBrushObject(contentColor);
            result.StartValue = startValue;
            result.EndValue = endValue;
            result.StartThickness = 0f;
            result.EndThickness = 50f;
            return result;
        }
    }
}