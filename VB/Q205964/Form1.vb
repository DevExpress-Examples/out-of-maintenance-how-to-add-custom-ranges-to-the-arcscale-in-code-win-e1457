Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGauges.Win
Imports DevExpress.XtraGauges.Win.Gauges.Circular
Imports DevExpress.XtraGauges.Base
Imports DevExpress.XtraGauges.Core.Model
Imports DevExpress.XtraGauges.Core.Drawing

Namespace Q205964
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			CreateCircularGauge()
		End Sub

		Private Sub CreateCircularGauge()
			Dim gaugeControl As New GaugeControl()
			Dim gauge As CircularGauge = CType(gaugeControl.AddGauge(GaugeType.Circular), CircularGauge)
			gauge.AddDefaultElements()
			Dim scale As ArcScaleComponent = gauge.Scales(0)
			scale.BeginUpdate()
			scale.Ranges.AddRange(CreateRanges(scale.MaxValue - scale.MinValue, scale.MinValue))
			scale.EndUpdate()
			gaugeControl.Dock = DockStyle.Fill
			Controls.Add(gaugeControl)
		End Sub

		Private rangeContentColors() As Color = { Color.Red, Color.Yellow, Color.Green }

		Private Function CreateRanges(ByVal ticks As Single, ByVal start As Single) As IRange()
			Dim range As Integer = CInt(Fix(Math.Floor(CDbl(ticks / rangeContentColors.Length))))
			Dim ranges As New List(Of IRange)()
			Dim i As Integer = 0
			Do While i < rangeContentColors.Length
'INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
'ORIGINAL LINE: ranges.Add(CreateRange(rangeContentColors[i], (int)(range * i + start), (int)(range * ++i + start)));
				ranges.Add(CreateRange(rangeContentColors(i), CInt(Fix(range * i + start)), CInt(Fix(range * ++i + start))))
			Loop
			Return ranges.ToArray()
		End Function

		Private Function CreateRange(ByVal contentColor As Color, ByVal startValue As Integer, ByVal endValue As Integer) As IRange
			Dim result As IRange = New ArcScaleRange()
			result.AppearanceRange.ContentBrush = New SolidBrushObject(contentColor)
			result.StartValue = startValue
			result.EndValue = endValue
			result.StartThickness = 0f
			result.EndThickness = 50f
			Return result
		End Function
	End Class
End Namespace