<Serializable()> Public Class ParametersModifier
    Private m_dataSource As List(Of ParameterProperty)

    Public ListOfParaSelectedInMarco As New List(Of ParameterProperty)

    Public ListParaItem As New List(Of UserControl_ListItemParameterWriter)


    Public Property DataSouce As List(Of ParameterProperty)
        Get
            Return m_dataSource
        End Get
        Set(value As List(Of ParameterProperty))
            If value IsNot Nothing Then
                m_dataSource = value
                UpdateGUI(m_dataSource)
            End If
        End Set
    End Property

    Public Sub UpdateGUI(Data As List(Of ParameterProperty))
        TreeViewPara.Nodes.Clear()

        For Each item As ParameterProperty In Data
            TreeViewPara.Nodes.Add(item.Name)
        Next
        Try
            Me.UserControl_ParameterProperties1.m_parent = Form1
            Me.UserControl_ParameterProperties1.DataSource = Data.Item(0)
            Me.ButtonApply.Enabled = Form1.CANBOZ_Config.IsChangeParaAllowed And Form1.ConnectionStatus
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewPara.NodeMouseClick
        Try
            For Each item As TreeNode In Me.TreeViewPara.Nodes
                item.BackColor = Color.White
                item.ForeColor = Color.Black
            Next

            e.Node.ForeColor = Color.White
            e.Node.BackColor = Color.YellowGreen

            Me.UserControl_ParameterProperties1.m_parent = Form1
            Me.UserControl_ParameterProperties1.DataSource = m_dataSource.Item(e.Node.Index)
            Dim Strhere = "Adress: " + m_dataSource.Item(e.Node.Index).Adress
            Me.ToolStripStatusLabel1.Text = Strhere
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub




    Private Sub ExportMarcroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportMarcroToolStripMenuItem.Click

        'If Not Form1.ConnectionStatus Then
        '    MsgBox("no connection to can bus", , "warning")
        '    Exit Sub
        'End If
        Dim MarcoPaola As New MacroPalo
        MarcoPaola.ExportFile("ParaMacro", "Sonceboz parameter Marco File", Me.ListOfParaSelectedInMarco)
    End Sub


    Public Sub UpdateMarcoFlowView()
        Try
            Me.FlowLayoutPanel1.Controls.Clear()

            If Me.ListParaItem.Count <> 0 Then
                For Each item As UserControl_ListItemParameterWriter In Me.ListParaItem
                    Me.FlowLayoutPanel1.Controls.Add(item)
                    item.UpdateGUI(item.DataSource)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles ButtonApply.Click
        If Me.ListParaItem.Count = 0 Then
            MsgBox("No Macro, Please add parameters or import one Macro", , "Warning")
            Exit Sub
        End If

        If Form1.ConnectionStatus = False Then
            MsgBox("No CAN Bus Connection", , "Warning")
            Exit Sub
        End If

        If MsgBox("Are you sure to excute this Macro ?", MsgBoxStyle.OkCancel, "Information") = MsgBoxResult.Ok Then

            For Each item As UserControl_ListItemParameterWriter In Me.ListParaItem

                Dim mythread As New Threading.Thread(AddressOf item.WriteValue)

                mythread.Start()

                Do Until mythread.ThreadState = Threading.ThreadState.Stopped

                Loop

            Next
            Dim marcoSuccess As Boolean = True
            For Each item As UserControl_ListItemParameterWriter In Me.ListParaItem
                If Not item.is_WritedSuccessfully Then
                    MsgBox("Writing parameters has some errors, please try again", , "Warning")
                    marcoSuccess = False
                End If
            Next

            If marcoSuccess Then
                MsgBox("Marco executed successfully, please verify them", , "Information")
            End If



        End If

    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        If Me.TreeViewPara.SelectedNode.Index = -1 Then
            Exit Sub
        End If

        If Me.DataSouce(Me.TreeViewPara.SelectedNode.Index).Read_only Then
            MsgBox("This Parameter is read only", MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        Dim ParaItem As New UserControl_ListItemParameterWriter(Form1, Me, Me.DataSouce(Me.TreeViewPara.SelectedNode.Index))
        ' If Not ParaItem.m_parent.ConnectionStatus Then
        ' MsgBox("No Connection to CAN bus", , "Warning")
        'Exit Sub
        'End If
        For Each para As UserControl_ListItemParameterWriter In Me.ListParaItem
            If para.DataSource.Name = ParaItem.DataSource.Name Then

                Exit Sub
            End If
        Next



        Me.ListParaItem.Add(ParaItem)
        Me.ListOfParaSelectedInMarco.Add(Me.DataSouce(Me.TreeViewPara.SelectedNode.Index))
        UpdateMarcoFlowView()
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs)

        UpdateMarcoFlowView()
    End Sub

    Private Sub ImportMarcoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportMarcoToolStripMenuItem.Click
        Dim MarcoPaola As New MacroPalo
        Dim ListFromImported As New List(Of ParameterProperty)
        If MarcoPaola.ImportFile("ParaMacro", "Sonceboz parameter Marco File", ListFromImported) Then
            Me.ListOfParaSelectedInMarco = ListFromImported
            If Me.ListOfParaSelectedInMarco.Count > 0 Then
                Me.ListParaItem.Clear()

                For Each para As ParameterProperty In Me.ListOfParaSelectedInMarco
                    Dim ParaItem As New UserControl_ListItemParameterWriter(Form1.MainForm, Me, para)
                    'If Not ParaItem.m_parent.ConnectionStatus Then
                    '    MsgBox("No Connection to CAN bus", , "Warning")
                    '    Exit Sub
                    'End If
                    Me.ListParaItem.Add(ParaItem)

                Next

                UpdateMarcoFlowView()

            End If
        End If



    End Sub

    Private Sub ExportLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportLogToolStripMenuItem.Click
        Dim diag1 As New Form_Log_manager(Form1)
        diag1.DataSource = Form1.ParameterChangeringLogs
        diag1.Show()
    End Sub

    Private Sub AddParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddParametersToolStripMenuItem.Click
        Dim diag1 As New Form_ParaAdder(0, Form1, Me)
        diag1.Show()

    End Sub

    Private Sub ModifyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifyToolStripMenuItem.Click
        Dim diag1 As New Form_ParaAdder(1, Form1, Me)
        diag1.DataSource = m_dataSource(Me.TreeViewPara.SelectedNode.Index)
        diag1.Show()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            m_dataSource.RemoveAt(Me.TreeViewPara.SelectedNode.Index)
            Me.UpdateGUI(m_dataSource)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TreeViewPara_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TreeViewPara.KeyPress
        Dim chCheck As Int16

        ' We convert the Character to its Upper case equivalent
        '
        chCheck = Microsoft.VisualBasic.Asc(e.KeyChar.ToString().ToUpper())

        ' The Key is the Delete (Backspace) Key
        '
        If chCheck = 8 Then
            DeleteToolStripMenuItem_Click(Me.TreeViewPara, New EventArgs)
        End If
    End Sub

    Private Sub ExportCurrentParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportCurrentParametersToolStripMenuItem.Click
        Try
            Form1.MarcoPaola.ExportFile("paralist", "Sonceboz BLDC parameters", m_dataSource)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ImportParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportParametersToolStripMenuItem.Click
        Dim paralistFromImport As New List(Of ParameterProperty)

        Try
            If Form1.MarcoPaola.ImportFile("paralist", "Sonceboz BLDC parameters", paralistFromImport) Then
                Form1.m_CANMatrix.ParametersList.AddRange(paralistFromImport)

                Me.DataSouce = Form1.m_CANMatrix.ParametersList
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class