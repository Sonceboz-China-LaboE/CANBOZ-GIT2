<Serializable()> Public Class UserControl_ParameterProperties

    Private m_dataSource As ParameterProperty
    Public m_parent As Form1

    Private m_IsForceMode As Boolean = False

    Public ForcedValue As String
    Public showAccessCode As Boolean = True
    Private m_IsModifiable As Boolean = False
    Private m_HasEditingError As Boolean = False

    Public Property Ismodifiabble() As Boolean
        Get
            Return m_IsModifiable
        End Get
        Set(ByVal value As Boolean)
            m_IsModifiable = value
            UpdateModifieable(m_IsModifiable)
        End Set
    End Property

    Public Property IsForceMode As Boolean
        Get
            Return m_IsForceMode
        End Get
        Set(value As Boolean)
            m_IsForceMode = value

        End Set
    End Property

    Public Function SetForceMode(isForce As Boolean, Optional mForcedvalue As String = "00")
        IsForceMode = isForce
        ForcedValue = mForcedvalue
    End Function

    Private Sub UpdateModifieable(flag As Boolean)

        Me.DataGridView1.Rows.Item(1).Cells(1).ReadOnly = flag
        Me.DataGridView1.Rows.Item(2).Cells(1).ReadOnly = flag
        Me.DataGridView1.Rows.Item(3).Cells(1).ReadOnly = flag
    End Sub

    Public Property HasEditingError() As Boolean
        Get
            Return m_HasEditingError
        End Get
        Set(value As Boolean)
            m_HasEditingError = value


        End Set
    End Property

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

    End Sub

    Public Sub UpdateGUI(Data As ParameterProperty)
        ClearGridView()
        'Me.ButtonWrite.Enabled = Not Data.Read_only And m_parent.ConnectionStatus
        'Me.ButtonRead.Enabled = m_parent.ConnectionStatus

        Me.DataGridView1.Rows.Item(0).Cells(1).Value = Data.Name
        Me.DataGridView1.Rows.Item(1).Cells(1).Value = Data.Adress
        Me.DataGridView1.Rows.Item(2).Cells(1).Value = Data.Length
        If Data.Read_only Or Not m_parent.CANBOZ_Config.IsChangeParaAllowed Or Not Me.showAccessCode Then
            Me.DataGridView1.Rows.Item(3).Cells(1).Value = "****"
            Me.ButtonWrite.Enabled = False
        Else


            Me.DataGridView1.Rows.Item(3).Cells(1).Value = Data.AccessKey
            Me.ButtonWrite.Enabled = True
        End If
        Me.ButtonWrite.Enabled = m_parent.CANBOZ_Config.IsChangeParaAllowed And Not Me.m_dataSource.Read_only


        If m_parent.ConnectionStatus Then

            Dim mythread As New Threading.Thread(AddressOf ReadCurrentValue)

            mythread.Start(Data.Name)
        End If




    End Sub

    Public Sub ReadCurrentValue(Name As String)
        If m_parent.ConnectionStatus Then
            Try
                Dim count As Integer = 0
                Do

                    Me.m_parent.ReadValue(Name)

                    For i As Integer = 0 To 100000000
                        i = i + 1
                    Next

                    Me.DataGridView1.Rows.Item(4).Cells(1).Value = "XX"
                    count = count + 1
                Loop Until m_parent.m_FeedBackResults.AdressInACT2Tool = m_dataSource.Adress.Replace("_", "") Or count = 100



                'Me.m_parent.ReadValue(Name)


                Me.DataGridView1.Rows.Item(4).Cells(1).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(Me.DataSource.Length)
                m_dataSource.updateValue(Me.DataGridView1.Rows.Item(4).Cells(1).Value, Me.DataGridView1.Rows.Item(4).Cells(1).Value)


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Public Sub WriteValue(data As String)
        If m_parent.ConnectionStatus Then
            Try
                Me.m_parent.UnlockValue(m_dataSource.Name)
                For i As Integer = 0 To 100000000
                    i = i + 1
                Next
                Me.m_parent.WriteValue(m_dataSource.Name, data)
                For i As Integer = 0 To 100000000
                    i = i + 1
                Next

                If m_parent.m_FeedBackResults.Msg_ACT2Tool.Substring(0, 2) = m_parent.m_CANMatrix.WriteProblemCode Then
                    MsgBox("Write Error, Please check the Access code or the value to write", , "Warning")
                Else

                    MsgBox("Value modified successfully, Please read 2 times in order to show the right value, and power off  and re-power on the actuator so that the value takes effect",, "Information")

                    Dim paralog As New ParmeterLog(Me.DataSource, Today, m_parent.SerialNumberInACT, m_parent.SWVersionInACT, m_parent.ToolStripStatusLabelProjectInfo.Text)
                    m_parent.ParameterChangeringLogs.ParaList.Add(paralog)
                    m_parent.ParameterChangeringLogs.isUpdated = True

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        If Form1.ConnectionStatus = False Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If

        'ReadCurrentValue(m_dataSource.Name)
        Dim mythread As New Threading.Thread(AddressOf ReadCurrentValue)

        mythread.Start(m_dataSource.Name)

        'Do Until mythread.ThreadState = Threading.ThreadState.Stopped

        'Loop

        'mythread = Nothing
    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles ButtonWrite.Click
        If Form1.ConnectionStatus = False Then
            MsgBox("No Connection to CAN bus", , "Warning")
            Exit Sub
        End If
        Try
            If Me.IsForceMode Then
                Dim diag As New DialogWriteValue(Me.DataSource.Length)
                diag.TextBox1.Text = Me.ForcedValue
                diag.TextBox1.Enabled = Not IsForceMode
                If diag.ShowDialog = DialogResult.OK Then

                    Dim valueToWrite As String = diag.ConverseInputValue
                    Dim mythread As New Threading.Thread(AddressOf WriteValue)

                    mythread.Start(valueToWrite)





                End If
            Else
                Dim diag As New DialogWriteValue(Me.DataSource.Length)
                diag.TextBox1.Text = Me.DataGridView1.Rows.Item(4).Cells(1).Value
                If diag.ShowDialog = DialogResult.OK Then

                    Dim valueToWrite As String = diag.ConverseInputValue
                    Dim mythread As New Threading.Thread(AddressOf WriteValue)

                    mythread.Start(valueToWrite)





                End If
            End If



        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        Dim myValue As String = Me.DataGridView1.Rows.Item(e.RowIndex).Cells(e.ColumnIndex).Value
        Dim myCell As DataGridViewCell = Me.DataGridView1.Rows.Item(e.RowIndex).Cells(e.ColumnIndex)
        Select Case e.RowIndex

            Case 1
                If myValue.Contains("-") And myValue.Length = 5 And myValue.IndexOf("-") = 2 Then
                    Me.m_HasEditingError = False

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 2
                If myValue.Length = 2 Then
                    Me.m_HasEditingError = False

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 3
                If myValue.Contains("-") And myValue.Length = 5 And myValue.IndexOf("-") = 2 Then
                    Me.m_HasEditingError = False

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If


        End Select



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

        If chCheck = 109 Then
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
