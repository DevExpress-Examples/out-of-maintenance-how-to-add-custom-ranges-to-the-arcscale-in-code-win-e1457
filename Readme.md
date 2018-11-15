<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Q205964/Form1.cs) (VB: [Form1.vb](./VB/Q205964/Form1.vb))
<!-- default file list end -->
# How to add custom ranges to the ArcScale in code (Win)


<p>The <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraGaugesCoreModelArcScaletopic">ArcScale</a> element has the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGaugesCoreModelArcScale_Rangestopic">Ranges</a> property, providing access to the collection of custom ranges. You can populate this collection with instances of the ArcScaleRange class. This class has the following properties:</p><p>The <strong>AppearanceRange</strong> property provides the capability to define the BorderColor, BorderWidth and ContentColor of the ArcScaleRange.<br />
The <strong>StartValue</strong> and <strong>EndValue</strong> properties allow you to set coordinates of the start and end points of the ArcScaleRange. These coordinates depend on the ArcScaleComponent.MinValue and ArcScaleComponent.MaxValue properties. Suppose, the ArcScaleComponent.MinValue = 30 and ArcScaleComponent.MaxValue = 90. For example, you can create two ArcScaleRange elements and set these StartValue and EndValue properties to the (30, 60) and (60, 90) to have two ranges, splitting the scale into two even parts.<br />
The <strong>StartThickness</strong> and <strong>EndThickness</strong> properties allow you to define the thickness of the start and end of the ArcScaleRange.<br />
The <strong>ShapeOffset</strong> property represents the spacing between the ArcScaleRange and the scale's edge. Setting negative values to this property moves the range to the center.</p>

<br/>


