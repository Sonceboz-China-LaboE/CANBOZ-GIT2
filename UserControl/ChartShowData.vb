Imports System.Windows.Forms.DataVisualization.Charting

Public Class ChartShowData
    Public ChartAreas1 As New ChartArea("Tracing")
    Public ChartAreas2 As New ChartArea("Temperature Monitor")    '定义新的ChartArea
    Public ChartAreas3 As New ChartArea("Motor Effots Monitor")
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



    End Sub

    Public Sub InitialiseChart()
        ChartMain.ChartAreas.Clear()
        '定义新的ChartArea
        ChartMain.ChartAreas.Add(ChartAreas1)                 '将新定义的ChartArea加入Chart1
        ChartMain.ChartAreas(0).AxisX.Title = "Time(ms)"   '设置ChartArea里坐标轴标题
        ChartMain.ChartAreas(0).AxisY.Title = "Position(%)"
        ChartMain.Legends(0).Docking = Docking.Top



        ChartAuxilary.ChartAreas.Clear() '清空ChartArea
        '定义新的ChartArea
        ChartAuxilary.ChartAreas.Add(ChartAreas2)                 '将新定义的ChartArea加入Chart1
        ChartAuxilary.ChartAreas.Add(ChartAreas3)
        ChartAuxilary.Legends(0).Docking = Docking.Top


        ChartMain.Series.Clear()


        Dim series1 As New Series("Position Feedback")
        series1.ChartType = SeriesChartType.Line         '设置Series的绘图类型
        series1.BorderWidth = 1
        series1.Color = Color.Red
        series1.XValueType = ChartValueType.Time
        series1.ChartArea = "Tracing"
        ChartMain.Series.Add(series1)
    End Sub

    Public Sub AddCurveToChartMain()

    End Sub

End Class
