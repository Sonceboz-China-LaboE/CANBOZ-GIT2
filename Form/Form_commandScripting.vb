Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Office.Interop

Public Class Form_commandScripting

    Public ForceStoped As Boolean = True
    Public m_Thread As Threading.Thread

    Public IsRecord As Boolean = False

    Public MarcoPaolo As New MacroPalo

    Public ListOfRecordInfo As New List(Of RecordInfo)

    Public timerRecordTicksCount As Integer = 0

    Public TimeElapsed As Double = 0

    Public progressOngoing As Boolean
    Public ButtonBefore As Button
    Public m_parent As Form1

    Public Sub New(parent As Form1)

        ' This call is required by the designer.
        InitializeComponent()

        m_parent = parent

        ' Add any initialization after the InitializeComponent() call.
        '将新定义的ChartArea加入Chart1
        ChartPosition.ChartAreas(0).AxisX.Title = "Time(ms)"   '设置ChartArea里坐标轴标题
        ChartPosition.ChartAreas(0).AxisY.Title = "Position(%)"
        ChartPosition.Legends(0).Docking = Docking.Top
        ChartPosition.Series(0).ChartType = SeriesChartType.Line         '设置Series的绘图类型
        ChartPosition.Series(0).BorderWidth = 2
        ChartPosition.Series(0).Color = Color.Red
        ChartPosition.Series(0).XValueType = ChartValueType.Time
        ChartPosition.Series(0).Name = "Position FeedBack"

        ChartTempureture.ChartAreas(0).AxisX.Title = "Time(ms)"   '设置ChartArea里坐标轴标题
        ChartTempureture.ChartAreas(0).AxisX.Enabled = AxisEnabled.False
        ChartTempureture.ChartAreas(0).AxisY.Title = "Temperature(°C)"
        ChartTempureture.Legends(0).Docking = Docking.Top
        ChartTempureture.Series(0).ChartType = SeriesChartType.SplineArea         '设置Series的绘图类型
        ChartTempureture.Series(0).BorderWidth = 2

        ChartTempureture.Series(0).Color = Color.Blue

        ChartTempureture.Series(0).Name = "Actuator Temperature"


        ChartMotorEffort.ChartAreas(0).AxisX.Title = "Time(ms)"   '设置ChartArea里坐标轴标题
        ChartMotorEffort.ChartAreas(0).AxisX.Enabled = AxisEnabled.False
        ChartMotorEffort.ChartAreas(0).AxisY.Title = "Motor Effort(%)"
        ChartMotorEffort.Legends(0).Docking = Docking.Top
        ChartMotorEffort.Series(0).ChartType = SeriesChartType.Line         '设置Series的绘图类型
        ChartMotorEffort.Series(0).BorderWidth = 2

        ChartMotorEffort.Series(0).Color = Color.DarkOrange
        ChartMotorEffort.Series(0).XValueType = ChartValueType.Time
        ChartMotorEffort.Series(0).Name = "Actuator Motor Effort"

        For Each bbt As Control In TableLayoutPanel1.Controls
            bbt.BackColor = SystemColors.Control
        Next

    End Sub
    Private Sub TimerConnectionSataus_Tick(sender As Object, e As EventArgs) Handles TimerConnectionSataus.Tick
        If Form1.ConnectionStatus Then
            Me.LabelConnectionStatus.BackColor = Color.GreenYellow
            Me.LabelConnectionStatus.Text = "Actuator Connected"
            Me.ButtonRecord.Enabled = True
            Me.ButtonExportData.Enabled = True
            If Me.IsRecord Then
                Me.ButtonRecord.Text = "Recording"
                Me.ButtonRecord.BackColor = Color.Pink
                Me.ButtonRecord.Enabled = False

            Else
                Me.ButtonRecord.Text = "Record"
                Me.ButtonRecord.BackColor = SystemColors.Control

                Me.timerRecordTicksCount = 0
                Me.TimeElapsed = 0
            End If

        Else
            Me.LabelConnectionStatus.BackColor = Color.OrangeRed
            Me.LabelConnectionStatus.Text = "No connection"
            Me.ButtonRecord.Enabled = False
            Me.ButtonExportData.Enabled = False
        End If
    End Sub

    Private Sub ButtonScript1_Click(sender As Object, e As EventArgs) Handles ButtonScript1.Click
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = False
        Form1.IsSriptForceStopped = False
        Dim intervall As Integer = 25
        Dim Xvalue As Integer() = LinSpace(0, CInt(200 * Math.PI), intervall)
        Dim Points(Xvalue.Length - 1) As Point3D

        For i = 0 To Xvalue.Length - 1
            Dim NewPoint3D As New Point3D
            NewPoint3D.X = Xvalue(i)
            NewPoint3D.Y = CInt((-50 * Math.Cos(Xvalue(i) / 100) + 50) * 0.9)
            NewPoint3D.Z = intervall
            Points(i) = NewPoint3D
        Next
        Me.UpdateButtonUI(True, sender)

        m_Thread = New Threading.Thread(AddressOf RunScript)

        m_Thread.Start(Points)

    End Sub

    Public Function LinSpace(FromValue As Integer, ToValue As Integer, Intervall As Integer) As Integer()

        If FromValue > ToValue Then

            Return Nothing
        End If
        Dim LengthOfResult As Integer = CInt((ToValue - FromValue) \ Intervall + 1)
        Dim Result(LengthOfResult - 1) As Integer


        If LengthOfResult = 0 Then
            Return Nothing
        End If

        Result(0) = FromValue
        For i = 1 To LengthOfResult - 1
            Result(i) = Result(i - 1) + Intervall
        Next


        Return Result

    End Function



    Public Sub RunScript(Points As Point3D())

        Do
            For Each point As Point3D In Points
                m_parent.SendPositionResquest(point.Y)
                Threading.Thread.Sleep(point.Z)

            Next
        Loop While ForceStoped = False


    End Sub

    Private Sub Form_commandScripting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Form1.ConnectionStatus Then
            Form1.btnRelease_Click(Form1, New EventArgs)
            Form1.btnInit_Click(Form1, New EventArgs)
            ForceStoped = True
        End If




    End Sub

    Private Sub ButtonScript2_Click(sender As Object, e As EventArgs) Handles ButtonScript2.Click
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = False
        Form1.IsSriptForceStopped = False
        Dim intervall As Integer = 25
        Dim Xvalue As Integer() = LinSpace(0, CInt(2 * 500 * Math.PI), intervall)
        Dim Points(Xvalue.Length - 1) As Point3D

        For i = 0 To Xvalue.Length - 1
            Dim NewPoint3D As New Point3D
            NewPoint3D.X = Xvalue(i)
            NewPoint3D.Y = CInt((-50 * Math.Cos(Xvalue(i) / 500) + 50) * 0.9)
            NewPoint3D.Z = intervall
            Points(i) = NewPoint3D
        Next
        Me.UpdateButtonUI(True, sender)
        m_Thread = New Threading.Thread(AddressOf RunScript)

        m_Thread.Start(Points)
    End Sub

    Private Sub ButtonScript3_Click(sender As Object, e As EventArgs) Handles ButtonScript3.Click
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = False
        Form1.IsSriptForceStopped = False
        Dim intervall As Integer = 300
        Dim Xvalue As Integer() = {0, intervall}
        Dim Yvalue As Integer() = {0, 95}
        Dim Points(Xvalue.Length - 1) As Point3D

        For i = 0 To Xvalue.Length - 1
            Dim NewPoint3D As New Point3D
            NewPoint3D.X = Xvalue(i)
            NewPoint3D.Y = Yvalue(i)
            NewPoint3D.Z = intervall
            Points(i) = NewPoint3D
        Next
        Me.UpdateButtonUI(True, sender)
        m_Thread = New Threading.Thread(AddressOf RunScript)

        m_Thread.Start(Points)
    End Sub

    Private Sub TimerFleshChart_Tick(sender As Object, e As EventArgs) Handles TimerFleshChart.Tick
        Dim PostionFeedback As Integer = Form1.m_FeedBackResults.PositionFeedback
        Dim Temperatrure As Integer = Form1.m_FeedBackResults.CurrentTemperature
        Dim MotorEffort As Integer = Form1.m_FeedBackResults.CurrentMotorEffort



        Dim timeStamp As DateTime = DateTime.Now
        Dim removeBefore As Double = timeStamp.AddSeconds((CDbl(15) * -1)).ToOADate
        'remove oldest values to maintain a constant number of data points 


        ChartPosition.Series(0).Points.AddXY(timeStamp.ToOADate, PostionFeedback)
        ChartPosition.ChartAreas(0).AxisX.Minimum = ChartPosition.Series(0).Points(0).XValue
        ChartPosition.ChartAreas(0).AxisX.Maximum = DateTime.FromOADate(ChartPosition.Series(0).Points(0).XValue).AddSeconds(30).ToOADate()
        ChartPosition.ChartAreas(0).AxisY.Minimum = 0
        ChartPosition.ChartAreas(0).AxisY.Maximum = 110

        ChartTempureture.Series(0).Points.AddXY(timeStamp.ToOADate, Temperatrure)
        ChartTempureture.ChartAreas(0).AxisX.Minimum = ChartPosition.Series(0).Points(0).XValue
        ChartTempureture.ChartAreas(0).AxisX.Maximum = DateTime.FromOADate(ChartPosition.Series(0).Points(0).XValue).AddSeconds(30).ToOADate()
        ChartTempureture.ChartAreas(0).AxisY.Minimum = 0
        ChartTempureture.ChartAreas(0).AxisY.Maximum = 140


        ChartMotorEffort.Series(0).Points.AddXY(timeStamp.ToOADate, MotorEffort)
        ChartMotorEffort.ChartAreas(0).AxisX.Minimum = ChartPosition.Series(0).Points(0).XValue
        ChartMotorEffort.ChartAreas(0).AxisX.Maximum = DateTime.FromOADate(ChartPosition.Series(0).Points(0).XValue).AddSeconds(30).ToOADate()
        ChartMotorEffort.ChartAreas(0).AxisY.Minimum = -100
        ChartMotorEffort.ChartAreas(0).AxisY.Maximum = 100

        While ChartPosition.Series(0).Points(0).XValue < removeBefore
            ChartPosition.Series(0).Points.RemoveAt(0)
            ' 
            ChartTempureture.Series(0).Points.RemoveAt(0)

            ChartMotorEffort.Series(0).Points.RemoveAt(0)
        End While

    End Sub

    Private Sub ButtonScript4_Click(sender As Object, e As EventArgs) Handles ButtonScript4.Click
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = False
        Form1.IsSriptForceStopped = False
        Dim intervall As Integer = 1000
        Dim Xvalue As Integer() = {0, intervall}
        Dim Yvalue As Integer() = {0, 95}
        Dim Points(Xvalue.Length - 1) As Point3D

        For i = 0 To Xvalue.Length - 1
            Dim NewPoint3D As New Point3D
            NewPoint3D.X = Xvalue(i)
            NewPoint3D.Y = Yvalue(i)
            NewPoint3D.Z = intervall
            Points(i) = NewPoint3D
        Next
        Me.UpdateButtonUI(True, sender)
        m_Thread = New Threading.Thread(AddressOf RunScript)

        m_Thread.Start(Points)
    End Sub

    Private Sub ButtonStop_Click_1(sender As Object, e As EventArgs) Handles ButtonStop.Click
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = True
        Me.UpdateButtonUI(False, sender)
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
    End Sub

    Private Sub UpdateButtonUI(IsRuning As Boolean, sender As Button)



        sender.BackColor = Color.YellowGreen


        Me.ButtonScript1.Enabled = Not IsRuning
        Me.ButtonScript2.Enabled = Not IsRuning
        Me.ButtonScript3.Enabled = Not IsRuning
        Me.ButtonScript4.Enabled = Not IsRuning
        Me.ButtonSmallMove.Enabled = Not IsRuning
        Me.ButtonSmallMoveUP.Enabled = Not IsRuning
        Me.ButtonStop.Enabled = IsRuning


        If ButtonBefore Is Nothing Then
            ButtonBefore = sender
        Else
            ButtonBefore.BackColor = SystemColors.Control
            ButtonBefore = sender
        End If


    End Sub

    Private Sub ButtonSmallMove_Click(sender As Object, e As EventArgs) Handles ButtonSmallMove.Click
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = False
        Form1.IsSriptForceStopped = False
        Dim intervall As Integer = 200
        Dim Xvalue As Integer() = {0, intervall}
        Dim Yvalue As Integer() = {20, 40}
        Dim Points(Xvalue.Length - 1) As Point3D

        For i = 0 To Xvalue.Length - 1
            Dim NewPoint3D As New Point3D
            NewPoint3D.X = Xvalue(i)
            NewPoint3D.Y = Yvalue(i)
            NewPoint3D.Z = intervall
            Points(i) = NewPoint3D
        Next
        Me.UpdateButtonUI(True, sender)
        m_Thread = New Threading.Thread(AddressOf RunScript)

        m_Thread.Start(Points)
    End Sub

    Private Sub ButtonRecord_Click(sender As Object, e As EventArgs) Handles ButtonRecord.Click
        Me.IsRecord = True
        Me.ListOfRecordInfo.Clear()
        Me.TimerRecord.Enabled = True
        Me.TimerRecord.Start()
    End Sub

    Private Sub ButtonExportData_Click(sender As Object, e As EventArgs) Handles ButtonExportData.Click
        If MsgBox("Stop recording?", MsgBoxStyle.OkCancel, "Information") = MsgBoxResult.Ok Then
            Me.IsRecord = False
            Me.TimerRecord.Enabled = False
            Me.TimerRecord.Stop()
            Try
                Dim newprogress As New Dialog_progress
                newprogress.Show()

                Dim myWeekSheet As Excel.Worksheet = MarcoPaolo.CreatExcelSheet("Record Informations")

                myWeekSheet.Cells(1, 1).Value = "Time"
                myWeekSheet.Cells(1, 2).Value = "Error Occurs?"
                myWeekSheet.Cells(1, 3).Value = "Position Feedback"
                myWeekSheet.Cells(1, 4).Value = "Temperature"
                myWeekSheet.Cells(1, 5).Value = "Motor Effort"
                myWeekSheet.Cells(1, 6).Value = "Type Error"
                myWeekSheet.Cells(1, 7).Value = "Fault Code"

                myWeekSheet.Cells(1, 1 + 10).Value = "Time"
                myWeekSheet.Cells(1, 2 + 10).Value = "Error Occurs?"
                myWeekSheet.Cells(1, 3 + 10).Value = "Position Feedback"
                myWeekSheet.Cells(1, 4 + 10).Value = "Temperature"
                myWeekSheet.Cells(1, 5 + 10).Value = "Motor Effort"
                myWeekSheet.Cells(1, 6 + 10).Value = "Type Error"
                myWeekSheet.Cells(1, 7 + 10).Value = "Fault Code"

                Dim index As Integer = 2
                Dim errorCount As Integer = 1
                newprogress.ProgressBar1.Value = 10
                For Each item As RecordInfo In ListOfRecordInfo
                    myWeekSheet.Cells(index, 1).Value = item.Time
                    myWeekSheet.Cells(index, 2).Value = item.IsError
                    myWeekSheet.Cells(index, 3).Value = item.PositionFeedback
                    myWeekSheet.Cells(index, 4).Value = item.Tempereture
                    myWeekSheet.Cells(index, 5).Value = item.MotorEffort
                    myWeekSheet.Cells(index, 6).Value = item.TypeError
                    myWeekSheet.Cells(index, 7).Value = item.FaultCode

                    If item.IsError Then
                        errorCount = errorCount + 1
                        myWeekSheet.Range(myWeekSheet.Cells(index, 1), myWeekSheet.Cells(index, 7)).Interior.Color = Color.Red

                        myWeekSheet.Range(myWeekSheet.Cells(index, 1), myWeekSheet.Cells(index, 7)).Copy()

                        myWeekSheet.Range(myWeekSheet.Cells(errorCount, 1 + 10), myWeekSheet.Cells(errorCount, 7 + 10)).PasteSpecial()

                    End If
                    index = index + 1
                Next
                newprogress.ProgressBar1.Value = 70
                MarcoPaolo.SaveExcel()
                newprogress.ProgressBar1.Value = 100
            Catch ex As Exception
                MsgBox(ex.Message,, "Error")
                Exit Sub
            End Try





        End If
    End Sub

    Private Sub TimerRecord_Tick(sender As Object, e As EventArgs) Handles TimerRecord.Tick
        Dim PostionFeedback As Integer = Form1.m_FeedBackResults.PositionFeedback
        Dim Temperatrure As Integer = Form1.m_FeedBackResults.CurrentTemperature
        Dim MotorEffort As Integer = Form1.m_FeedBackResults.CurrentMotorEffort



        Dim timeStamp As DateTime = DateTime.Now

        'remove oldest values to maintain a constant number of data points 
        timerRecordTicksCount = timerRecordTicksCount + 1
        TimeElapsed = timerRecordTicksCount * TimerRecord.Interval


        Dim newRecordInfo As New RecordInfo
            newRecordInfo.Time = TimeElapsed
            newRecordInfo.PositionFeedback = PostionFeedback
            newRecordInfo.MotorEffort = MotorEffort
            newRecordInfo.Tempereture = Temperatrure
            newRecordInfo.IsError = Form1.m_FeedBackResults.is_Error
            newRecordInfo.TypeError = Form1.m_FeedBackResults.ReturnFaultInfo
            newRecordInfo.FaultCode = Form1.m_FeedBackResults.Msg_FaultsCode

            ListOfRecordInfo.Add(newRecordInfo)


    End Sub

    Private Sub ButtonSmallMoveUP_Click(sender As Object, e As EventArgs) Handles ButtonSmallMoveUP.Click
        Form1.btnRelease_Click(Form1, New EventArgs)
        Form1.btnInit_Click(Form1, New EventArgs)
        If m_Thread IsNot Nothing Then
            m_Thread.Abort()
            m_Thread = Nothing
        End If
        If Not Form1.ConnectionStatus Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ForceStoped = False
        Form1.IsSriptForceStopped = False
        Dim intervall As Integer = 200
        Dim Xvalue As Integer() = {0, intervall}
        Dim Yvalue As Integer() = {70, 90}
        Dim Points(Xvalue.Length - 1) As Point3D

        For i = 0 To Xvalue.Length - 1
            Dim NewPoint3D As New Point3D
            NewPoint3D.X = Xvalue(i)
            NewPoint3D.Y = Yvalue(i)
            NewPoint3D.Z = intervall
            Points(i) = NewPoint3D
        Next
        Me.UpdateButtonUI(True, sender)
        m_Thread = New Threading.Thread(AddressOf RunScript)

        m_Thread.Start(Points)
    End Sub

    Private Sub CustomizeScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomizeScriptToolStripMenuItem.Click

    End Sub
End Class