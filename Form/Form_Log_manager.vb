Imports Microsoft.Office.Interop

Public Class Form_Log_manager

    Private m_dataSource As ParamterLogList
    Private myparent As Form1

    Public Property DataSource As ParamterLogList
        Get
            Return m_dataSource
        End Get
        Set(value As ParamterLogList)
            If value.ParaList.Count = 0 Then
                Exit Property
            End If
            m_dataSource = value
            UpdateGUI()
        End Set
    End Property

    Public Sub New(my_parent As Form1)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        myparent = my_parent

    End Sub
    Public Sub UpdateGUI()
        Me.DataGridView1.Rows.Clear()


        Me.DataGridView1.Columns(0).HeaderText = "Parameter"
        Me.DataGridView1.Columns(1).HeaderText = "Default Value"
        Me.DataGridView1.Columns(2).HeaderText = "Changed to"
        Me.DataGridView1.Columns(3).HeaderText = "Date"
        Me.DataGridView1.Columns(4).HeaderText = "SN"
        Me.DataGridView1.Columns(5).HeaderText = "SW Version"
        Me.DataGridView1.Columns(6).HeaderText = "Project"
        For i = 0 To m_dataSource.ParaList.Count - 1
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(i).Cells(0).Value = m_dataSource.ParaList(i).ParamterInLog.Name
            Me.DataGridView1.Rows(i).Cells(1).Value = m_dataSource.ParaList(i).ParamterInLog.DefaultValue
            Me.DataGridView1.Rows(i).Cells(2).Value = m_dataSource.ParaList(i).ParamterInLog.CurrentValue
            Me.DataGridView1.Rows(i).Cells(3).Value = m_dataSource.ParaList(i).DateRecord.ToShortDateString
            Me.DataGridView1.Rows(i).Cells(4).Value = m_dataSource.ParaList(i).SN
            Me.DataGridView1.Rows(i).Cells(5).Value = m_dataSource.ParaList(i).SWversion
            Me.DataGridView1.Rows(i).Cells(6).Value = m_dataSource.ParaList(i).ProjectInformation
        Next

    End Sub



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dim paraLogList As New ParamterLogList
            myparent.MarcoPaola.ImportFile("paralog", "Parameters Log file", paraLogList)

            Me.DataSource = paraLogList


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.DataSource = myparent.ParameterChangeringLogs
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim paraLogList As New ParamterLogList
            myparent.MarcoPaola.ImportFile("paralog", "Parameters Log file", paraLogList)
            myparent.ParameterChangeringLogs.AddRange(paraLogList.ParaList)
            myparent.ParameterChangeringLogs.isUpdated = True
            Me.DataSource = myparent.ParameterChangeringLogs
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Me.DataSource.ParaList.Count = 0 Then
            MsgBox("No log file found", MsgBoxStyle.OkOnly, "Information")
        End If
        Dim MacroPoloHere = New MacroPalo


        Dim myExcelBook As Excel.Workbook = MacroPoloHere.CreatExcelBook()
        Dim projectNamesList As New List(Of String)
        Dim sheetsList As New List(Of Excel.Worksheet)
        projectNamesList.Add(DataSource.ParaList(0).ProjectInformation)

        For Each paralog As ParmeterLog In Me.DataSource.ParaList
            If Not projectNamesList.Contains(paralog.ProjectInformation) Then
                projectNamesList.Add(paralog.ProjectInformation)
            End If
        Next
        Dim count = 0
        For Each projectName In projectNamesList
            If projectName = Nothing Then
                projectName = "No Defined" & count
            End If
            Dim mySheet As Excel.Worksheet = myExcelBook.Worksheets.Add()
            mySheet.Name = projectName
            sheetsList.Add(mySheet)
            count = count + 1
        Next


        For Each sheetExcel As Excel.Worksheet In sheetsList
            sheetExcel.Cells(1, 1).value = "Parameter"
            sheetExcel.Cells(1, 2).value = "From value"
            sheetExcel.Cells(1, 3).value = "To value"
            sheetExcel.Cells(1, 4).value = "SW Version"
            sheetExcel.Cells(1, 5).value = "SN"

            sheetExcel.Cells(1, 6).value = "Date of record"
            sheetExcel.Range(sheetExcel.Cells(1, 1), sheetExcel.Cells(1, 6)).Interior.Color = Color.GreenYellow

            Dim rowIndex As Integer = 1
            For Each paralog As ParmeterLog In Me.DataSource.ParaList
                If sheetExcel.Name = paralog.ProjectInformation Then
                    rowIndex = rowIndex + 1
                    AddItemInsheet(paralog, sheetExcel, rowIndex)
                ElseIf sheetExcel.Name.Contains("No Defined") Then
                    rowIndex = rowIndex + 1
                    AddItemInsheet(paralog, sheetExcel, rowIndex)
                End If
            Next

            sheetExcel.Columns(1).Autofit()
            sheetExcel.Columns(2).Autofit()
            sheetExcel.Columns(3).Autofit()
            sheetExcel.Columns(4).Autofit()
            sheetExcel.Columns(5).Autofit()
            sheetExcel.Columns(6).Autofit()
        Next




        MacroPoloHere.SaveExcel()
    End Sub

    Public Sub AddItemInsheet(para As ParmeterLog, sheet As Excel.Worksheet, rowIndex As Integer)
        With sheet
            .Cells(rowIndex, 1).value = para.ParamterInLog.Name
            .Cells(rowIndex, 2).value = "'" & para.ParamterInLog.DefaultValue
            .Cells(rowIndex, 3).value = "'" & para.ParamterInLog.CurrentValue
            .Cells(rowIndex, 4).value = "'" & para.SWversion
            .Cells(rowIndex, 5).value = "'" & para.SN
            .Cells(rowIndex, 6).value = para.DateRecord.ToLongDateString
        End With
    End Sub
End Class