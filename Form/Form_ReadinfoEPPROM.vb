Imports System.Windows.Forms.DataVisualization.Charting

Imports Microsoft.Office.Interop

Public Class Form_ReadinfoEPPROM

    Public CANMatrix As CAN_Matrix = Form1.m_CANMatrix
    Public m_parent As Form1

    Public IsHistogramReadingFinished As Boolean = False
    Public myprogress As Dialog_progress




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        initialseTablesAndCharts(-1)

    End Sub

    Public Sub initialseTablesAndCharts(indexTab As Integer)
        Select Case indexTab
            Case -1 'FIrst initiallisation
                Me.DataGridViewDiagnostic.Rows.Clear()
                Me.DataGridViewDiagnostic.Columns.Clear()

                For i = 0 To 15
                    Me.DataGridViewDiagnostic.Columns.Add(i.ToString, i + 1)
                Next

                For j = 0 To Me.CANMatrix.DiagnoticRowNumber - 1
                    Me.DataGridViewDiagnostic.Rows.Add()
                    Me.DataGridViewDiagnostic.Rows(j).HeaderCell.Value = (j + 1).ToString & ": " & CANMatrix.DignosticsTableRowLabels(j)
                    Me.DataGridViewDiagnostic.RowHeadersVisible = True
                Next

                ''######################################
                Me.DataGridViewRingBuffer1.TopLeftHeaderCell.Value = CANMatrix.ReadRingBuffer(0)
                Me.DataGridViewRingBuffer2.TopLeftHeaderCell.Value = CANMatrix.ReadRingBuffer(1)
                Me.DataGridViewRingBuffer1.Rows.Clear()
                Me.DataGridViewRingBuffer1.Columns.Clear()

                For i = 0 To 15
                    Me.DataGridViewRingBuffer1.Columns.Add(i.ToString, i + 1)
                Next

                For j = 0 To Me.CANMatrix.RingBufferRowNumber - 1
                    Me.DataGridViewRingBuffer1.Rows.Add()

                    Me.DataGridViewRingBuffer1.Rows(j).HeaderCell.Value = (j + 1).ToString

                Next

                Me.DataGridViewRingBuffer2.Rows.Clear()
                Me.DataGridViewRingBuffer2.Columns.Clear()

                For i = 0 To 15
                    Me.DataGridViewRingBuffer2.Columns.Add(i.ToString, i + 1)
                Next

                For j = 0 To Me.CANMatrix.RingBufferRowNumber - 1
                    Me.DataGridViewRingBuffer2.Rows.Add()

                    Me.DataGridViewRingBuffer2.Rows(j).HeaderCell.Value = (j + 1).ToString

                Next

                ''######################################

                Me.DataGridViewHistogram.Rows.Clear()
                Me.DataGridViewHistogram.Columns.Clear()

                IsHistogramReadingFinished = False
                Me.DataGridViewHistogram.Columns.Add("F", "Field")
                Me.DataGridViewHistogram.Columns.Add("R", "Range")
                Me.DataGridViewHistogram.Columns.Add("D", "Data")

                For j = 0 To Me.CANMatrix.HistogramRowNumber - 1
                    Me.DataGridViewHistogram.Rows.Add()

                    Me.DataGridViewHistogram.Rows(j).HeaderCell.Value = (j + 1).ToString
                    Me.DataGridViewHistogram.Rows(j).Cells(1).Value = CANMatrix.HistogramRangeStringArray(j)
                Next
                Me.DataGridViewHistogram.Rows.Item(0).Cells(0).Value = "Temperature"
                Me.DataGridViewHistogram.Rows.Item(5).Cells(0).Value = "Coil Current"
                Me.DataGridViewHistogram.Rows.Item(10).Cells(0).Value = "Position"

                For i = 0 To 4
                    For j = 0 To 2
                        Me.DataGridViewHistogram.Rows.Item(5 + i).Cells(j).Style.BackColor = Color.LightBlue
                    Next

                Next

                Me.DataGridViewHistogram.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue

                For Each item As ParameterProperty In CANMatrix.ParametersList
                    If item.Name = "EE_HISTOAUTOSAVE" Then
                        Me.UserControl_ParameterPropertiesHitogram.m_parent = Form1
                        Me.UserControl_ParameterPropertiesHitogram.DataSource = item

                    End If
                Next


                ChartP.ChartAreas(0).AxisX.Title = "Position(%)"   '设置ChartArea里坐标轴标题
                ChartP.ChartAreas(0).AxisY.Title = "Seconds"
                ChartP.Legends(0).Docking = Docking.Top
                ChartP.Series(0).ChartType = SeriesChartType.Bar         '设置Series的绘图类型
                ChartP.Series(0).BorderWidth = 2
                ChartP.Series(0).Color = Color.Blue
                ChartP.Series(0).XValueType = ChartValueType.String
                ChartP.Series(0).Name = "Position FeedBack"

                ChartT.ChartAreas(0).AxisX.Title = "Temperature"   '设置ChartArea里坐标轴标题
                ChartT.ChartAreas(0).AxisY.Title = "Seconds"
                ChartT.Legends(0).Docking = Docking.Top
                ChartT.Series(0).ChartType = SeriesChartType.Bar         '设置Series的绘图类型
                ChartT.Series(0).BorderWidth = 2
                ChartT.Series(0).Color = Color.Red
                ChartT.Series(0).XValueType = ChartValueType.String
                ChartT.Series(0).Name = "Temperature FeedBack"

                ChartC.ChartAreas(0).AxisX.Title = "Current"   '设置ChartArea里坐标轴标题
                ChartC.ChartAreas(0).AxisY.Title = "Seconds"
                ChartC.Legends(0).Docking = Docking.Top
                ChartC.Series(0).ChartType = SeriesChartType.Bar         '设置Series的绘图类型
                ChartC.Series(0).BorderWidth = 2
                ChartC.Series(0).Color = Color.GreenYellow
                ChartC.Series(0).XValueType = ChartValueType.String
                ChartC.Series(0).Name = "Current FeedBack"

            Case 0
                Me.DataGridViewDiagnostic.Rows.Clear()
                Me.DataGridViewDiagnostic.Columns.Clear()

                For i = 0 To 15
                    Me.DataGridViewDiagnostic.Columns.Add(i.ToString, i + 1)
                Next

                For j = 0 To Me.CANMatrix.DiagnoticRowNumber - 1
                    Me.DataGridViewDiagnostic.Rows.Add()
                    Me.DataGridViewDiagnostic.Rows(j).HeaderCell.Value = (j + 1).ToString & ": " & CANMatrix.DignosticsTableRowLabels(j)
                    Me.DataGridViewDiagnostic.RowHeadersVisible = True
                Next
            Case 1
                Me.DataGridViewRingBuffer1.TopLeftHeaderCell.Value = CANMatrix.ReadRingBuffer(0)
                Me.DataGridViewRingBuffer2.TopLeftHeaderCell.Value = CANMatrix.ReadRingBuffer(1)
                Me.DataGridViewRingBuffer1.Rows.Clear()
                Me.DataGridViewRingBuffer1.Columns.Clear()

                For i = 0 To 15
                    Me.DataGridViewRingBuffer1.Columns.Add(i.ToString, i + 1)
                Next

                For j = 0 To Me.CANMatrix.RingBufferRowNumber - 1
                    Me.DataGridViewRingBuffer1.Rows.Add()
                    Me.DataGridViewRingBuffer1.Rows(j).HeaderCell.Value = (j + 1).ToString

                Next

                Me.DataGridViewRingBuffer2.Rows.Clear()
                Me.DataGridViewRingBuffer2.Columns.Clear()

                For i = 0 To 15
                    Me.DataGridViewRingBuffer2.Columns.Add(i.ToString, i + 1)
                Next

                For j = 0 To Me.CANMatrix.RingBufferRowNumber - 1
                    Me.DataGridViewRingBuffer2.Rows.Add()

                    Me.DataGridViewRingBuffer2.Rows(j).HeaderCell.Value = (j + 1).ToString

                Next
            Case 2
                Me.DataGridViewHistogram.Rows.Clear()
                Me.DataGridViewHistogram.Columns.Clear()
                IsHistogramReadingFinished = False

                Me.DataGridViewHistogram.Columns.Add("F", "Field")
                Me.DataGridViewHistogram.Columns.Add("R", "Range")
                Me.DataGridViewHistogram.Columns.Add("D", "Data")

                For j = 0 To Me.CANMatrix.HistogramRowNumber - 1
                    Me.DataGridViewHistogram.Rows.Add()
                    Me.DataGridViewHistogram.Rows(j).HeaderCell.Value = (j + 1).ToString

                    Me.DataGridViewHistogram.Rows(j).Cells(1).Value = CANMatrix.HistogramRangeStringArray(j)
                Next
                Me.DataGridViewHistogram.Rows.Item(0).Cells(0).Value = "Temperature"
                Me.DataGridViewHistogram.Rows.Item(5).Cells(0).Value = "Coil Current"
                Me.DataGridViewHistogram.Rows.Item(10).Cells(0).Value = "Position"

                For i = 0 To 4
                    For j = 0 To 2
                        Me.DataGridViewHistogram.Rows.Item(5 + i).Cells(j).Style.BackColor = Color.LightBlue
                    Next

                Next

                Me.DataGridViewHistogram.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue

                For Each item As ParameterProperty In CANMatrix.ParametersList
                    If item.Name = "EE_HISTOAUTOSAVE" Then
                        Me.UserControl_ParameterPropertiesHitogram.m_parent = Form1
                        Me.UserControl_ParameterPropertiesHitogram.DataSource = item

                    End If
                Next


                ChartP.ChartAreas(0).AxisX.Title = "Position(%)"   '设置ChartArea里坐标轴标题
                ChartP.ChartAreas(0).AxisY.Title = "Seconds"
                ChartP.Legends(0).Docking = Docking.Top
                ChartP.Series(0).ChartType = SeriesChartType.Bar         '设置Series的绘图类型
                ChartP.Series(0).BorderWidth = 2
                ChartP.Series(0).Color = Color.Blue
                ChartP.Series(0).XValueType = ChartValueType.String
                ChartP.Series(0).Name = "Position FeedBack"

                ChartT.ChartAreas(0).AxisX.Title = "Temperature"   '设置ChartArea里坐标轴标题
                ChartT.ChartAreas(0).AxisY.Title = "Seconds"
                ChartT.Legends(0).Docking = Docking.Top
                ChartT.Series(0).ChartType = SeriesChartType.Bar         '设置Series的绘图类型
                ChartT.Series(0).BorderWidth = 2
                ChartT.Series(0).Color = Color.Red
                ChartT.Series(0).XValueType = ChartValueType.String
                ChartT.Series(0).Name = "Temperature FeedBack"

                ChartC.ChartAreas(0).AxisX.Title = "Current"   '设置ChartArea里坐标轴标题
                ChartC.ChartAreas(0).AxisY.Title = "Seconds"
                ChartC.Legends(0).Docking = Docking.Top
                ChartC.Series(0).ChartType = SeriesChartType.Bar         '设置Series的绘图类型
                ChartC.Series(0).BorderWidth = 2
                ChartC.Series(0).Color = Color.GreenYellow
                ChartC.Series(0).XValueType = ChartValueType.String
                ChartC.Series(0).Name = "Current FeedBack"


        End Select

    End Sub




    Public Sub DisplayAdressOnCells(indexTab As Integer)

        Select Case indexTab
            Case 0
                For row = 0 To Me.CANMatrix.DiagnoticRowNumber - 1

                    For col = 0 To 15
                        Me.DataGridViewDiagnostic.Rows(row).Cells(col).Value = CANMatrix.GetReadEEPROMCommandAdress(0, row, col)
                    Next
                Next

            Case 1
                For row = 0 To Me.CANMatrix.RingBufferRowNumber - 1

                    For col = 0 To 15
                        Me.DataGridViewRingBuffer1.Rows(row).Cells(col).Value = CANMatrix.GetReadEEPROMCommandAdress(1, row, col)
                        Me.DataGridViewRingBuffer2.Rows(row).Cells(col).Value = CANMatrix.GetReadEEPROMCommandAdress(1, row, col, 1)
                    Next
                Next
            Case 2
                For row = 0 To Me.CANMatrix.HistogramRowNumber - 1


                    Me.DataGridViewHistogram.Rows(row).Cells(2).Value = CANMatrix.GetReadEEPROMCommandAdress(2, row)

                Next
        End Select






    End Sub

    Public Function ReadCurrentValueOfPara(Para As ParameterProperty) As String
        If m_parent.ConnectionStatus Then
            Try

                Do

                    Me.m_parent.ReadValue(Para.Name)

                    For i As Integer = 0 To 100000000
                        i = i + 1
                    Next


                Loop Until m_parent.m_FeedBackResults.AdressInACT2Tool = Para.Adress.Replace("_", "")



                'Me.m_parent.ReadValue(Name)


                Dim results As String = m_parent.m_FeedBackResults.TrimACT2ToolMsg(Para.Length)
                Return results
                Para.updateValue(results, results)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End If

    End Function

    Public Sub ReadValues(indexTab As Integer)
        Try


            Select Case indexTab
                Case 0

                    For row = 0 To Me.CANMatrix.DiagnoticRowNumber - 1

                        For col = 0 To 15
                            Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(0, row, col).Replace("_", "")

                                m_parent.ReadValueInEEPROM(0, row, col)

                                For i As Integer = 0 To 10000000
                                    i = i + 1
                                Next


                            Loop


                            If HEX2DECToolStripMenuItem.Checked Then
                                Me.DataGridViewDiagnostic.Rows(row).Cells(col).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(1)
                            ElseIf DEC2HEXToolStripMenuItem.Checked Then
                                Me.DataGridViewDiagnostic.Rows(row).Cells(col).Value = Convert.ToInt32(m_parent.m_FeedBackResults.TrimACT2ToolMsg(1), 16)
                            End If


                        Next
                    Next

                Case 1
                    For row = 0 To Me.CANMatrix.RingBufferRowNumber - 1

                        For col = 0 To 15

                            Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(1, row, col).Replace("_", "")

                                m_parent.ReadValueInEEPROM(1, row, col)

                                For i As Integer = 0 To 10000000
                                    i = i + 1
                                Next


                            Loop


                            If HEX2DECToolStripMenuItem.Checked Then
                                Me.DataGridViewRingBuffer1.Rows(row).Cells(col).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(1)
                            ElseIf DEC2HEXToolStripMenuItem.Checked Then
                                Me.DataGridViewRingBuffer1.Rows(row).Cells(col).Value = Convert.ToInt32(m_parent.m_FeedBackResults.TrimACT2ToolMsg(1), 16)
                            End If

                            Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(1, row, col, 1).Replace("_", "")

                                m_parent.ReadValueInEEPROM(1, row, col, 1)

                                For i As Integer = 0 To 10000000
                                    i = i + 1
                                Next


                            Loop

                            If HEX2DECToolStripMenuItem.Checked Then
                                Me.DataGridViewRingBuffer2.Rows(row).Cells(col).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(1)
                            ElseIf DEC2HEXToolStripMenuItem.Checked Then
                                Me.DataGridViewRingBuffer2.Rows(row).Cells(col).Value = Convert.ToInt32(m_parent.m_FeedBackResults.TrimACT2ToolMsg(1), 16)
                            End If

                        Next
                    Next

                Case 2
                    For row = 0 To Me.CANMatrix.HistogramRowNumber - 1


                        Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(2, row).Replace("_", "")

                            m_parent.ReadValueInEEPROM(2, row)

                            For i As Integer = 0 To 100000000
                                i = i + 1
                            Next


                        Loop



                        If HEX2DECToolStripMenuItem.Checked Then
                            Me.DataGridViewHistogram.Rows(row).Cells(2).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(4)
                        ElseIf DEC2HEXToolStripMenuItem.Checked Then
                            Me.DataGridViewHistogram.Rows(row).Cells(2).Value = Convert.ToInt32(m_parent.m_FeedBackResults.TrimACT2ToolMsg(4), 16)
                        End If

                    Next


                    IsHistogramReadingFinished = True
            End Select


        Catch ex As Exception
            MsgBox(ex.Message,, "Errors")
        End Try
    End Sub

    Private Sub ButtonReadAll_Click(sender As Object, e As EventArgs) Handles ButtonReadAll.Click
        Me.initialseTablesAndCharts(Me.TabControl1.SelectedIndex)

        Dim mythread As New Threading.Thread(AddressOf ReadValues)


        mythread.Start(TabControl1.SelectedIndex)



        'Do Until mythread.ThreadState = Threading.ThreadState.Stopped

        'Loop

        'mythread = Nothing

    End Sub




    Private Sub DrawBarChartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawBarChartToolStripMenuItem.Click
        If IsHistogramReadingFinished Then
            ChartT.Series(0).Points.Clear()
            ChartC.Series(0).Points.Clear()
            ChartP.Series(0).Points.Clear()
            For i = 0 To 4

                ChartT.Series(0).Points.AddXY(Me.DataGridViewHistogram.Rows(i).Cells(1).Value, Convert.ToInt32(Me.DataGridViewHistogram.Rows(i).Cells(2).Value, 16))
                ChartC.Series(0).Points.AddXY(Me.DataGridViewHistogram.Rows(i + 5).Cells(1).Value, Convert.ToInt32(Me.DataGridViewHistogram.Rows(i + 5).Cells(2).Value, 16))
                ChartP.Series(0).Points.AddXY(Me.DataGridViewHistogram.Rows(i + 10).Cells(1).Value, Convert.ToInt32(Me.DataGridViewHistogram.Rows(i + 10).Cells(2).Value, 16))
            Next

        End If
    End Sub

    Private Sub HEX2DECToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HEX2DECToolStripMenuItem.Click
        Me.DEC2HEXToolStripMenuItem.Checked = False

    End Sub

    Private Sub DEC2HEXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DEC2HEXToolStripMenuItem.Click
        Me.HEX2DECToolStripMenuItem.Checked = False

    End Sub



    Private Sub GenerateAnalysisReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateAnalysisReportToolStripMenuItem.Click
        If m_parent.ConnectionStatus Then
            Dim mythread As New Threading.Thread(AddressOf GeneratingReport)
            mythread.SetApartmentState(Threading.ApartmentState.STA)

            mythread.Start()

        Else
            MsgBox("No Communication to CAN bus", MsgBoxStyle.OkOnly, "Information")
        End If










    End Sub

    Public Sub GeneratingReport()


        myprogress = New Dialog_progress
        myprogress.ValueProgress(0, "Start to read Diagnostics Table")
        myprogress.Show()




        ReadValues(0)
        myprogress.ValueProgress(10, "Start to read Ring Buffer")
        ReadValues(1)
        myprogress.ValueProgress(30, "Start to read Histogram")
        ReadValues(2)
        myprogress.ValueProgress(40, "Reading EEPROM finished, Start to generate EXCEL")


        Dim MacroPoloHere = New MacroPalo


        Dim myExcelBook As Excel.Workbook = MacroPoloHere.CreatExcelBook()

        Dim mySheetHistogramm As Excel.Worksheet = myExcelBook.Worksheets(1)
        mySheetHistogramm.Name = "Histogramm"

        Dim mySheetRingBuffer As Excel.Worksheet = myExcelBook.Worksheets.Add()
        mySheetRingBuffer.Name = "RingBuffer"
        Dim mySheetDtable As Excel.Worksheet = myExcelBook.Worksheets.Add()
        mySheetDtable.Name = "Diagnostics Table"
        Dim mySheetSyn As Excel.Worksheet = myExcelBook.Worksheets.Add()
        mySheetSyn.Name = "Synthesis of diagnostics"
        myprogress.ValueProgress(60, "Initialisation of EXCEL file finished")

        FillExcelSheets(mySheetSyn, mySheetDtable, mySheetRingBuffer, mySheetHistogramm)
        myprogress.ValueProgress(100, "Generation of EXCEL file finished")


        MacroPoloHere.SaveExcel()



    End Sub


    Public Sub FillExcelSheets(ByRef SheetS As Excel.Worksheet, ByRef SheetD As Excel.Worksheet, ByRef SheetR As Excel.Worksheet, ByRef SheetH As Excel.Worksheet)
        With SheetS
            .Range("A1:A10").Interior.Color = Color.SkyBlue

            .Cells(1, 1).Value = "Project info"

            .Cells(1, 2).Value = CANMatrix.ClientName & "-" & CANMatrix.ApplicationName & "-" & CANMatrix.OMEName

            .Cells(2, 1).Value = "SW Version in ACT"

            .Cells(2, 2).Value = m_parent.m_SWversionInACT
            .Cells(3, 1).Value = "SN in ACT"
            .Cells(3, 2).Value = m_parent.m_SerialNumberInACT
            .Cells(4, 1).Value = "Date of Reading"
            .Cells(4, 2).Value = Date.Today.ToShortDateString

            .Cells(6, 1).Value = "CANMAX MATCH ?"
            .Cells(6, 2).Value = m_parent.IsCANMAXGood

            .Cells(7, 1).Value = "CANBOZ Version"
            .Cells(7, 2).Value = m_parent.CANBOZ_Config.CanBozVersion

            .Cells(8, 1).Value = "Hours Since Power On"
            .Cells(8, 2).Value = m_parent.TimeSincePowerOn

            .Cells(9, 1).Value = "Power On Times"
            .Cells(9, 2).Value = m_parent.TimesPowerOn

            .Cells(10, 1).Value = "Recorder"
            .Cells(10, 2).Value = "Please Input"
            .Columns(1).AutoFit()
            .Columns(2).AutoFit()

            .Range("A1:B10").HorizontalAlignment = 3
            .Range("A1:B10").VerticalAlignment = 3



        End With

        Dim ParaRange As Excel.Range = SheetS.Range(SheetS.Cells(1, 4), SheetS.Cells(CANMatrix.ParametersList.Count + 1, 8))

        With ParaRange
            .Cells(1, 1).Value = "Parameters"
            .Cells(1, 2).Value = "Default Value"
            .Cells(1, 3).Value = "Current Value in ACT"
            .Cells(1, 4).Value = "Value Modified ?"
            SheetS.Range(.Cells(1, 1), .Cells(1, 4)).Interior.Color = Color.SkyBlue
            Dim index = 2
            For Each para As ParameterProperty In CANMatrix.ParametersList
                Dim currentValue = Me.ReadCurrentValueOfPara(para)
                If currentValue IsNot Nothing Then
                    .Cells(index, 1).Value = para.Name
                    If para.DefaultValue = "" Then
                        .Cells(index, 2).value = "No default value"
                    Else
                        .Cells(index, 2).value = "'" & para.DefaultValue
                    End If

                    .Cells(index, 3).value = "'" & currentValue
                    .Cells(index, 4).value = Not (currentValue = para.DefaultValue)
                    If currentValue = para.DefaultValue Then
                        SheetS.Range(.Cells(index, 1), .Cells(index, 1)).Interior.Color = Color.SkyBlue
                    Else

                        SheetS.Range(.Cells(index, 1), .Cells(index, 1)).Interior.Color = Color.LightPink
                        SheetS.Range(.Cells(index, 4), .Cells(index, 4)).Interior.Color = Color.LightPink
                    End If
                    index = index + 1
                End If

            Next




        End With
        ParaRange.HorizontalAlignment = 1
        ParaRange.VerticalAlignment = 1
        ParaRange.Columns(1).AutoFit
        ParaRange.Columns(2).AutoFit

        ParaRange.Columns(3).AutoFit
        ParaRange.Columns(4).AutoFit



        With SheetD
            ' Preparing layout 

            Dim AllRange As Excel.Range = .Range(.Cells(1, 1), .Cells(17, 17))
            AllRange.VerticalAlignment = 3
            AllRange.HorizontalAlignment = 3

            .Range("A1").Interior.Color = Color.SkyBlue

            For i = 2 To 17
                .Cells(i, 1).Value = Me.DataGridViewDiagnostic.Rows(i - 2).HeaderCell.Value

                .Range(.Cells(i, 1), .Cells(i, 1)).Interior.Color = Color.SkyBlue
            Next
            .Columns(1).AutoFit()
            Dim index As Integer = 2
            For Each item In CANMatrix.DiagnoticTableColumLabels
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Merge()

                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Cells(1, 1).Value = item.Key
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Interior.Color = Color.SkyBlue
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Columns(1).AutoFit()
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).VerticalAlignment = 3
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).HorizontalAlignment = 3
                index = index + item.Value
            Next


            Dim DataRange As Excel.Range = .Range(.Cells(2, 2), .Cells(17, 17))

            For i = 1 To Me.DataGridViewDiagnostic.Rows.Count
                For j = 1 To 16
                    DataRange.Cells(i, j).value = "'" & Me.DataGridViewDiagnostic.Rows(i - 1).Cells(j - 1).Value
                Next
            Next
        End With



        ' Preparing layout 
        'SheetR
        Dim RangePage1 As Excel.Range = SheetR.Range(SheetR.Cells(1, 1), SheetR.Cells(17, 17))


        RangePage1.Range(RangePage1.Cells(1, 1), RangePage1.Cells(1, 1)).Interior.Color = Color.SkyBlue
        RangePage1.Cells(1, 1).value = "Page 1"
        RangePage1.HorizontalAlignment = 3
        RangePage1.VerticalAlignment = 3
        With RangePage1
            For i = 2 To 17
                .Cells(i, 1).Value = Me.DataGridViewRingBuffer1.Rows(i - 2).HeaderCell.Value
                .Range(.Cells(i, 1), .Cells(i, 1)).Interior.Color = Color.SkyBlue
            Next

            Dim index As Integer = 2
            For Each item In CANMatrix.DiagnoticTableColumLabels
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Merge()
                If index = 2 Then
                    .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Cells(1, 1).Value = "Error Type"
                Else
                    .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Cells(1, 1).Value = item.Key
                End If

                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Interior.Color = Color.SkyBlue
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).Columns.AutoFit()
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).VerticalAlignment = 3
                .Range(.Cells(1, index), .Cells(1, index + item.Value - 1)).HorizontalAlignment = 3
                index = index + item.Value
            Next


            Dim DataRange As Excel.Range = .Range(.Cells(2, 2), .Cells(17, 17))

            For i = 1 To Me.DataGridViewDiagnostic.Rows.Count
                For j = 1 To 16
                    DataRange.Cells(i, j).value = "'" & Me.DataGridViewRingBuffer1.Rows(i - 1).Cells(j - 1).Value
                Next
            Next
        End With

        Dim RangePage2 As Excel.Range = SheetR.Range(SheetR.Cells(20, 1), SheetR.Cells(36, 17))


        SheetR.Range(RangePage2.Cells(1, 1), RangePage2.Cells(1, 1)).Interior.Color = Color.SkyBlue
        RangePage2.Cells(1, 1).value = "Page 2"
        RangePage2.HorizontalAlignment = 3
        RangePage2.VerticalAlignment = 3
        With RangePage2
            Dim i = 2
            For i = 2 To 17
                .Cells(i, 1).Value = Me.DataGridViewRingBuffer2.Rows(i - 2).HeaderCell.Value
                SheetR.Range(RangePage2.Cells(i, 1), RangePage2.Cells(i, 1)).Interior.Color = Color.SkyBlue
            Next

            Dim index As Integer = 2
            For Each item In CANMatrix.DiagnoticTableColumLabels
                SheetR.Range(RangePage2.Cells(1, index), RangePage2.Cells(1, index + item.Value - 1)).Merge()
                If index = 2 Then
                    SheetR.Range(RangePage2.Cells(1, index), RangePage2.Cells(1, index + item.Value - 1)).Cells(1, 1).Value = "Error Type"
                Else
                    SheetR.Range(RangePage2.Cells(1, index), RangePage2.Cells(1, index + item.Value - 1)).Cells(1, 1).Value = item.Key
                End If

                SheetR.Range(RangePage2.Cells(1, index), RangePage2.Cells(1, index + item.Value - 1)).Interior.Color = Color.SkyBlue
                SheetR.Range(RangePage2.Cells(1, index), RangePage2.Cells(1, index + item.Value - 1)).Columns(1).AutoFit()

                index = index + item.Value
            Next


            Dim DataRange As Excel.Range = SheetR.Range(RangePage2.Cells(2, 2), RangePage2.Cells(17, 17))

            For i = 1 To Me.DataGridViewDiagnostic.Rows.Count
                For j = 1 To 16
                    DataRange.Cells(i, j).value = "'" & Me.DataGridViewRingBuffer2.Rows(i - 1).Cells(j - 1).Value
                Next
            Next
        End With


        With SheetH

            SheetH.Range("A1:C16").VerticalAlignment = 3
            SheetH.Range("A1:C16").HorizontalAlignment = 3

            .Range("A1:F1").Interior.Color = Color.SkyBlue

            For j = 2 To Me.CANMatrix.HistogramRowNumber + 1
                .Cells(j, 1).Value = Me.DataGridViewHistogram.Rows(j - 2).Cells(0).Value

            Next

            For j = 2 To Me.CANMatrix.HistogramRowNumber + 1
                .Cells(j, 2).Value = Me.DataGridViewHistogram.Rows(j - 2).Cells(1).Value
            Next

            Dim sumTemp As Integer = 0
            For j = 2 To Me.CANMatrix.HistogramRowNumber + 1

                Dim valueToStore As Integer
                If HEX2DECToolStripMenuItem.Checked Then
                    valueToStore = Convert.ToInt32(Me.DataGridViewHistogram.Rows(j - 2).Cells(2).Value, 16)
                ElseIf DEC2HEXToolStripMenuItem.Checked Then
                    valueToStore = Me.DataGridViewHistogram.Rows(j - 2).Cells(2).Value
                End If

                If j >= 7 Then
                    valueToStore = valueToStore * 0.32
                End If

                sumTemp = sumTemp + valueToStore

                If j = 6 Then
                    .Cells(j, 5).Value = sumTemp
                    .Cells(j, 6).Value = sumTemp / 3600
                    sumTemp = 0
                End If

                If j = 11 Then
                    .Cells(j, 5).Value = sumTemp
                    .Cells(j, 6).Value = sumTemp / 3600
                    sumTemp = 0
                End If

                If j = 16 Then
                    .Cells(j, 5).Value = sumTemp
                    .Cells(j, 6).Value = sumTemp / 3600
                    sumTemp = 0
                End If

                .Cells(j, 4).Value = valueToStore
            Next



            For j = 1 To 3
                .Cells(1, j).Value = Me.DataGridViewHistogram.Columns(j - 1).HeaderText

            Next
            .Cells(1, 4).Value = "Time(s)"

            .Cells(1, 5).Value = "Sum(s)"

            .Cells(1, 6).Value = "Sum(h)"
            For i = 2 To 6
                SheetH.Range(.Cells(i + 5, 1), .Cells(i + 5, 6)).Interior.Color = Color.SkyBlue

            Next




            For i = 2 To Me.DataGridViewHistogram.Rows.Count + 1

                .Cells(i, 3).value = "'" & Me.DataGridViewHistogram.Rows(i - 2).Cells(2).Value

            Next
            .Columns(3).Autofit()
            .Columns(2).Autofit()
            .Columns(1).Autofit()
            Try
                Dim chartpage As Excel.Chart
                Dim xlCharts As Excel.ChartObjects
                Dim myChart As Excel.ChartObject
                Dim chartRange As Excel.Range

                xlCharts = .ChartObjects

                myChart = xlCharts.Add(400, 0, 400, 250)
                chartpage = myChart.Chart
                chartRange = .Range("B2: B6, D2: D6")
                chartpage.SetSourceData(Source:=chartRange)
                chartpage.ChartType = Excel.XlChartType.xlBarClustered

                chartpage.HasTitle = True
                chartpage.ChartTitle.Characters.Text = "Temperature"
                chartpage.FullSeriesCollection(1).Format.Fill.ForeColor.RGB = RGB(Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B)
                'chartpage.ChartArea.Interior.Color = RGB(Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B)
                chartpage.HasLegend = False
                chartpage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasTitle = False
                chartpage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasTitle = True

                chartpage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = "Time (s)"
                chartpage.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementDataLabelInsideEnd)


                myChart = xlCharts.Add(0, 250, 400, 250)
                chartpage = myChart.Chart
                chartRange = .Range("B7: B11, D7: D11")
                chartpage.SetSourceData(Source:=chartRange)
                chartpage.ChartType = Excel.XlChartType.xlBarClustered

                chartpage.HasTitle = True
                chartpage.ChartTitle.Characters.Text = "Coil Current"
                chartpage.FullSeriesCollection(1).Format.Fill.ForeColor.RGB = RGB(Color.Green.R, Color.Green.G, Color.Green.B)
                'chartpage.ChartArea.Interior.Color = RGB(Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B)
                chartpage.HasLegend = False
                chartpage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasTitle = False
                chartpage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasTitle = True

                chartpage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = "Time (s)"
                chartpage.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementDataLabelInsideEnd)

                myChart = xlCharts.Add(400, 250, 400, 250)
                chartpage = myChart.Chart
                chartRange = .Range("B12: B16, D12: D16")
                chartpage.SetSourceData(Source:=chartRange)
                chartpage.ChartType = Excel.XlChartType.xlBarClustered

                chartpage.HasTitle = True
                chartpage.ChartTitle.Characters.Text = "Position"
                chartpage.FullSeriesCollection(1).Format.Fill.ForeColor.RGB = RGB(Color.BlueViolet.R, Color.BlueViolet.G, Color.BlueViolet.B)
                'chartpage.ChartArea.Interior.Color = RGB(Color.OrangeRed.R, Color.OrangeRed.G, Color.OrangeRed.B)
                chartpage.HasLegend = False
                chartpage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasTitle = False
                chartpage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasTitle = True

                chartpage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = "Time (s)"
                chartpage.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementDataLabelInsideEnd)


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



        End With

        'Generate the Synthsis Sheet. 

        ' To be done 

    End Sub

    Private Sub releaseObject(Obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.Release(Obj)
            Obj = Nothing
        Catch ex As Exception
            Obj = Nothing

        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub DebugModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugModeToolStripMenuItem.Click

        If Not Me.m_parent.ConnectionStatus Then
            MsgBox("No Communication to CAN bus", MsgBoxStyle.OkOnly, "Information")
            Return
        End If
        Me.initialseTablesAndCharts(Me.TabControl1.SelectedIndex)

        Dim mythread As New Threading.Thread(AddressOf ReadValuesDebugMod)


        mythread.Start(TabControl1.SelectedIndex)

    End Sub

    Public Sub ReadValuesDebugMod(indexTab As Integer)
        Try


            Select Case indexTab
                Case 0

                    For row = 0 To Me.CANMatrix.DiagnoticRowNumber - 1

                        For col = 0 To 15
                            Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(0, row, col).Replace("_", "")

                                m_parent.ReadValueInEEPROM(0, row, col)

                                For i As Integer = 0 To 10000000
                                    i = i + 1
                                Next


                            Loop



                            Me.DataGridViewDiagnostic.Rows(row).Cells(col).Value = m_parent.m_FeedBackResults.AdressInACT2Tool



                        Next
                    Next

                Case 1
                    For row = 0 To Me.CANMatrix.RingBufferRowNumber - 1

                        For col = 0 To 15

                            Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(1, row, col).Replace("_", "")

                                m_parent.ReadValueInEEPROM(1, row, col)

                                For i As Integer = 0 To 10000000
                                    i = i + 1
                                Next


                            Loop



                            Me.DataGridViewRingBuffer1.Rows(row).Cells(col).Value = m_parent.m_FeedBackResults.AdressInACT2Tool


                            Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(1, row, col, 1).Replace("_", "")

                                m_parent.ReadValueInEEPROM(1, row, col, 1)

                                For i As Integer = 0 To 10000000
                                    i = i + 1
                                Next


                            Loop


                            Me.DataGridViewRingBuffer2.Rows(row).Cells(col).Value = m_parent.m_FeedBackResults.AdressInACT2Tool


                        Next
                    Next

                Case 2
                    For row = 0 To Me.CANMatrix.HistogramRowNumber - 1


                        Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = CANMatrix.GetReadEEPROMCommandAdress(2, row).Replace("_", "")

                            m_parent.ReadValueInEEPROM(2, row)

                            For i As Integer = 0 To 10000000
                                i = i + 1
                            Next


                        Loop




                        Me.DataGridViewHistogram.Rows(row).Cells(2).Value = m_parent.m_FeedBackResults.AdressInACT2Tool


                    Next


                    IsHistogramReadingFinished = True
            End Select


        Catch ex As Exception
            MsgBox(ex.Message,, "Errors")
        End Try
    End Sub
End Class