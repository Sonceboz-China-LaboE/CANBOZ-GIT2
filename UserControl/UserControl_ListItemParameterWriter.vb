<Serializable()> Public Class UserControl_ListItemParameterWriter
    Private m_dataSource As ParameterProperty
    Public m_parent As Form1

    Public m_smallParent As ParametersModifier
    Public is_WritedSuccessfully As Boolean = False
    Public Selected As Boolean = False
    Public Property DataSource As ParameterProperty
        Get
            Return m_dataSource
        End Get
        Set(value As ParameterProperty)
            If value IsNot Nothing Then
                Me.m_dataSource = value
                UpdateGUI(m_dataSource)
            End If
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If m_parent.ConnectionStatus = False Then
        '    MsgBox("No Connection to CAN bus", , "Warning")
        '    Exit Sub
        'End If
        Try
            Dim diag As New DialogWriteValue(Me.DataSource.Length)
            diag.TextBox1.Text = Me.DataGridView1.Rows.Item(0).Cells(1).Value
            If diag.ShowDialog = DialogResult.OK Then
                Me.DataGridView1.Rows.Item(0).Cells(1).Value = diag.TextBox1.Text

                Me.m_dataSource.updateValue(Me.DataGridView1.Rows.Item(0).Cells(1).Value, Me.DataGridView1.Rows.Item(0).Cells(1).Value)

            End If


        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try

    End Sub
    Public Sub New(ParentForm As Form1, smallParent As ParametersModifier, data_Source As ParameterProperty)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_parent = ParentForm

        m_smallParent = smallParent
        Me.DataGridView1.Rows.Add()

        Me.DataSource = data_Source


    End Sub

    Public Sub UpdateGUI(Data As ParameterProperty)

        'Me.ButtonWrite.Enabled = Not Data.Read_only And m_parent.ConnectionStatus
        'Me.ButtonRead.Enabled = m_parent.ConnectionStatus
        Me.DataGridView1.Rows.Item(0).Cells(0).Value = Data.Name
        Me.DataGridView1.Rows.Item(0).Cells(1).Value = Data.ValueToWrite
        'If m_parent.ConnectionStatus Then


        'Dim mythread As New Threading.Thread(AddressOf ReadCurrentValue)

        ' mythread.Start()





        'Do Until mythread.ThreadState = Threading.ThreadState.Stopped

        'Loop

        'mythread.Abort()
        'mythread = Nothing



        ' End If





    End Sub
    Public Sub UpdateGUINoThread(Data As ParameterProperty)

        'Me.ButtonWrite.Enabled = Not Data.Read_only And m_parent.ConnectionStatus
        'Me.ButtonRead.Enabled = m_parent.ConnectionStatus
        Me.DataGridView1.Rows.Item(0).Cells(0).Value = Data.Name

        If m_parent.ConnectionStatus Then
            If Me.DataSource.hasReadValue Then
                Me.DataGridView1.Rows.Item(0).Cells(1).Value = m_dataSource.CurrentValue


            Else
                Dim myThread As New Threading.Thread(AddressOf ReadCurrentValue)

                myThread.Start()




            End If


            'Do Until mythread.ThreadState = Threading.ThreadState.Stopped

            'Loop

            'mythread.Abort()
            'mythread = Nothing



        End If





    End Sub

    Public Sub ReadCurrentValue()
        If m_parent.ConnectionStatus Then
            Try


                If m_dataSource.hasReadValue Then
                    Me.DataGridView1.Rows.Item(0).Cells(1).Value = m_dataSource.ValueToWrite

                Else

                    Do Until m_parent.m_FeedBackResults.AdressInACT2Tool = m_dataSource.Adress.Replace("_", "")
                        Me.DataGridView1.Rows.Item(0).Cells(1).Value = "XX"
                        Me.m_parent.ReadValue(m_dataSource.Name)

                        For i As Integer = 0 To 100000000
                            i = i + 1
                        Next


                    Loop

                    Me.DataGridView1.Rows.Item(0).Cells(1).Value = m_parent.m_FeedBackResults.TrimACT2ToolMsg(Me.DataSource.Length)

                    Me.DataSource.updateValue(Me.DataGridView1.Rows.Item(0).Cells(1).Value, Me.DataGridView1.Rows.Item(0).Cells(1).Value)
                End If




                'Me.m_parent.ReadValue(m_dataSource.Name)






            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Public Function WriteValue() As Boolean
        If m_parent.ConnectionStatus Then
            Try
                Dim diag As New DialogWriteValue(Me.m_dataSource.Length)
                diag.TextBox1.Text = m_dataSource.ValueToWrite
                Me.m_parent.UnlockValue(m_dataSource.Name)
                For i As Integer = 0 To 100000000
                    i = i + 1
                Next

                Me.m_parent.WriteValue(m_dataSource.Name, diag.ConverseInputValue)
                For i As Integer = 0 To 100000000
                    i = i + 1
                Next

                If m_parent.m_FeedBackResults.Msg_ACT2Tool.Substring(0, 2) = m_parent.m_CANMatrix.WriteProblemCode Then
                    ''MsgBox("Write Error, Please check the Access code or the value to write", , "Warning")
                    Me.is_WritedSuccessfully = False

                    Return False

                Else
                    Me.is_WritedSuccessfully = True

                    Me.DataSource.updateValue(Me.DataGridView1.Rows.Item(0).Cells(1).Value, Me.DataGridView1.Rows.Item(0).Cells(1).Value)
                    Me.UpdateGUI(Me.DataSource)

                    Dim paralog As New ParmeterLog(Me.DataSource, Today, m_parent.SerialNumberInACT, m_parent.SWVersionInACT, m_parent.ToolStripStatusLabelProjectInfo.Text)
                    m_parent.ParameterChangeringLogs.ParaList.Add(paralog)
                    m_parent.ParameterChangeringLogs.isUpdated = True

                    Return True

                End If


            Catch ex As Exception
                MsgBox(ex.Message)
                Me.is_WritedSuccessfully = False
                Return False
            End Try

        End If
        Return False
    End Function

    Private Sub UserControl_ListItemParameterWriter_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Me.BackColor = Color.Blue

    End Sub

    Private Sub UserControl_ListItemParameterWriter_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Me.BackColor = SystemColors.Control

    End Sub

    Private Sub ButtonX_Click(sender As Object, e As EventArgs) Handles ButtonX.Click
        Try
            Dim indexOfME = Me.m_smallParent.ListParaItem.IndexOf(Me)
            Me.m_smallParent.ListParaItem.Remove(Me)
            Me.m_smallParent.ListOfParaSelectedInMarco.RemoveAt(indexOfME)
            Me.m_smallParent.UpdateMarcoFlowView()
        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try



    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        m_dataSource.hasReadValue = False
        UpdateGUI(m_dataSource)

    End Sub
End Class
