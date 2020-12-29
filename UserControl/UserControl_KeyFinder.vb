
Public Class UserControl_KeyFinder

    Private m_dataSource As ParameterProperty

    Private m_HasEditingError As Boolean = False
    Public m_parent As Form1
    Public keyFound As String

    Public ValueInside As String

    Public Property DataSource As ParameterProperty
        Get
            Return m_dataSource
        End Get
        Set(value As ParameterProperty)
            If value IsNot Nothing Then
                m_dataSource = value
                UpdateGUI(m_dataSource)
            End If
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        For i = 0 To 4
            Me.DataGridView1.Rows.Add()
        Next

        Me.DataGridView1.Rows.Item(0).Cells(0).Value = "Parameter"
        Me.DataGridView1.Rows.Item(1).Cells(0).Value = "Address"
        Me.DataGridView1.Rows.Item(2).Cells(0).Value = "Length"
        Me.DataGridView1.Rows.Item(3).Cells(0).Value = "Access Key"
        Me.DataGridView1.Rows.Item(4).Cells(0).Value = "Current Value"


        Me.DataGridView1.Rows.Item(1).Cells(0).ReadOnly = True
        Me.DataGridView1.Rows.Item(2).Cells(0).ReadOnly = True



    End Sub

    Public Sub ClearGridView()
        Me.DataGridView1.Rows.Clear()

        For i = 0 To 4
            Me.DataGridView1.Rows.Add()
        Next

        Me.DataGridView1.Rows.Item(0).Cells(0).Value = "Parameter"
        Me.DataGridView1.Rows.Item(1).Cells(0).Value = "Address"
        Me.DataGridView1.Rows.Item(2).Cells(0).Value = "Length"
        Me.DataGridView1.Rows.Item(3).Cells(0).Value = "Access Key"
        Me.DataGridView1.Rows.Item(4).Cells(0).Value = "Current Value"



        Me.DataGridView1.Rows.Item(1).Cells(0).ReadOnly = True
        Me.DataGridView1.Rows.Item(2).Cells(0).ReadOnly = True

    End Sub

    Public Sub UpdateGUI(ByRef Data As ParameterProperty)
        ClearGridView()
        'Me.ButtonWrite.Enabled = Not Data.Read_only And m_parent.ConnectionStatus
        'Me.ButtonRead.Enabled = m_parent.ConnectionStatus

        Me.DataGridView1.Rows.Item(0).Cells(1).Value = Data.Name
        Me.DataGridView1.Rows.Item(1).Cells(1).Value = Data.Adress
        Me.DataGridView1.Rows.Item(2).Cells(1).Value = Data.Length
        Me.DataGridView1.Rows.Item(3).Cells(1).Value = Data.AccessKey

        'If m_parent.ConnectionStatus Then
        '    Dim mythread As New Threading.Thread(AddressOf ReadCurrentValue)

        '    mythread.Start(Data.Name)
        'End If


    End Sub

    Public Sub ReadFromGUI()

        DataSource.Name = Me.DataGridView1.Rows.Item(0).Cells(1).Value
        DataSource.Adress = Me.DataGridView1.Rows.Item(1).Cells(1).Value
        DataSource.Length = Me.DataGridView1.Rows.Item(2).Cells(1).Value

    End Sub

    Public Function InputValide() As Boolean
        If Me.DataGridView1.Rows.Item(1).Cells(1).ErrorText = "" And Me.DataGridView1.Rows.Item(1).Cells(1).ErrorText = "" Then
            Return True
        Else
            Return False

        End If
    End Function

    Public Sub ReadCurrentValue(Para As ParameterProperty)
        If m_parent.ConnectionStatus Then
            Try
                Dim countRead As Integer = 0
                Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = m_dataSource.Adress.Replace("_", "")

                    Me.DataGridView1.Rows.Item(4).Cells(1).Value = "XX"
                    countRead = countRead + 1
                    If countRead > 100 Then
                        MsgBox("Reading fails",, "Errors")
                        Exit Sub

                    End If
                    Form1.ReadValueByPara(Para)

                    For i As Integer = 0 To 10000000
                        i = i + 1
                    Next

                Loop



                'Me.m_parent.ReadValue(Name)


                Me.DataGridView1.Rows.Item(4).Cells(1).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(Me.DataSource.Length)

                m_dataSource.updateValue(ConverseInputValue(Me.DataGridView1.Rows.Item(4).Cells(1).Value), ConverseInputValue(Me.DataGridView1.Rows.Item(4).Cells(1).Value))

            Catch ex As Exception
            End Try

        End If

    End Sub

    Public Sub WriteValue(data As String)
        If m_parent.ConnectionStatus Then
            Try
                m_parent.UnlockValue(m_dataSource.Name)
                For i = 0 To 10000000
                    i = i + 1
                Next
                m_parent.WriteValue(m_dataSource.Name, data)
                For i = 0 To 10000000
                    i = i + 1
                Next
                If m_parent.m_FeedBackResults.Msg_ACT2Tool.Substring(0, 2) = m_parent.m_CANMatrix.WriteProblemCode Then
                    MsgBox("Write Error, Please check the Access code or the value to write", , "Warning")
                End If
                MsgBox("Value modified successfully, Please read 2 times in order to show the right value, and power off  and re-power on the actuator so that the value takes effect",, "Information")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub


    Public Function ConverseInputValue(valueWrite As String) As String
        Dim valueString As String = ""
        Dim Numbyte = m_dataSource.Length

        For i = 0 To Numbyte - 1
            valueString = valueString & valueWrite.Substring(i * 2, 2) & "_"
        Next

        If Numbyte < 4 Then
            For j = 0 To 4 - Numbyte - 1
                valueString = valueString & "00_"
            Next

        End If

        Return valueString.Remove(valueString.Length - 1, 1)


    End Function

    Public Sub CrackKey()
        If m_parent.ConnectionStatus Then
            Try
                For indexRow As Integer = 0 To 255
                    For IndexColum As Integer = 0 To 255
                        Dim key As String = String.Format("{0:X2}", indexRow) & "_" & String.Format("{0:X2}", IndexColum)
                        Me.DataGridView1.Rows.Item(3).Cells(1).Value = key
                        Me.DataGridView1.Rows.Item(3).Cells(1).Style.BackColor = Color.Red
                        Me.DataSource.AccessKey = key

                        m_parent.UnlockValueByPara(m_dataSource)
                        For i = 0 To 60000000
                            i = i + 1
                        Next

                        m_parent.WriteValueByPara(m_dataSource)

                        For i = 0 To 60000000
                            i = i + 1
                        Next
                        If m_parent.m_FeedBackResults.Msg_ACT2Tool.Substring(0, 2) <> Form1.m_CANMatrix.WriteProblemCode Then
                            keyFound = key
                            Me.DataGridView1.Rows.Item(3).Cells(1).Value = key
                            Me.DataGridView1.Rows.Item(3).Cells(1).Style.BackColor = Color.YellowGreen
                            Exit Sub
                        End If



                    Next
                Next




            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        If m_parent.ConnectionStatus = False Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Me.ReadFromGUI()
        'ReadCurrentValue(m_dataSource.Name)
        Dim mythread As New Threading.Thread(AddressOf ReadCurrentValue)

        mythread.Start(m_dataSource)

        'Do Until mythread.ThreadState = Threading.ThreadState.Stopped

        'Loop

        'mythread = Nothing
    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs)
        If m_parent.ConnectionStatus = False Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Try
            Dim diag As New DialogWriteValue(Me.DataSource.Length)
            diag.TextBox1.Text = Me.DataGridView1.Rows.Item(4).Cells(1).Value
            If diag.ShowDialog = DialogResult.OK Then

                Dim valueToWrite As String = diag.ConverseInputValue
                Dim mythread As New Threading.Thread(AddressOf WriteValue)

                mythread.Start(valueToWrite)





            End If


        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim myValue As String = Me.DataGridView1.Rows.Item(e.RowIndex).Cells(e.ColumnIndex).Value
        Dim myCell As DataGridViewCell = Me.DataGridView1.Rows.Item(e.RowIndex).Cells(e.ColumnIndex)
        If e.RowIndex = 4 Then
            Exit Sub
        End If

        If myValue Is Nothing Then
            Me.m_HasEditingError = True
            myCell.ErrorText = "Input Invalide"
            Exit Sub
        End If





        Select Case e.RowIndex

            Case 1
                If myValue.Contains("_") And myValue.Length = 5 And myValue.IndexOf("_") = 2 Then
                    Me.m_HasEditingError = False
                    myCell.ErrorText = ""

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 2
                If myValue.Length = 1 Then
                    Me.m_HasEditingError = False
                    myCell.ErrorText = ""
                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 3
                If myValue.Contains("_") And myValue.Length = 5 And myValue.IndexOf("_") = 2 Then
                    Me.m_HasEditingError = False
                    myCell.ErrorText = ""
                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If


        End Select


    End Sub

    Private Sub ButtonFinder_Click(sender As Object, e As EventArgs) Handles ButtonFinder.Click
        If m_parent.ConnectionStatus = False Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If

        Me.ButtonRead_Click(Me, New EventArgs)
        Try
            If Me.DataGridView1.Rows.Item(4).Cells(1).Value Is Nothing Or Me.DataGridView1.Rows.Item(4).Cells(1).Value = "" Then
                Exit Sub
            End If

        Catch ex As Exception
            Exit Sub
        End Try

        Me.ValueInside = Me.DataGridView1.Rows.Item(4).Cells(1).Value


        Try


            Dim mythread As New Threading.Thread(AddressOf CrackKey)

            mythread.Start()

            ' Do Until mythread.ThreadState = Threading.ThreadState.Stopped

            'Loop
            'mythread = Nothing


        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try





    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        Dim chCheck As Int16

        ' We convert the Character to its Upper case equivalent
        '
        chCheck = Microsoft.VisualBasic.Asc(e.KeyChar.ToString().ToUpper())

        ' The Key is the Delete (Backspace) Key
        '
        If chCheck = 8 Then
            Return
        End If


        ' The Key is a number between 0-9
        '
        If (chCheck > 47) AndAlso (chCheck < 58) Then
            Return
        End If
        ' The Key is a character between A-F
        '
        If (chCheck > 64) AndAlso (chCheck < 71) Then
            Return
        End If

        ' Is neither a number nor a character between A(a) and F(f)
        '
        e.Handled = True
    End Sub
End Class

