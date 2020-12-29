Public Class Form_ParaAdder
    Public AddOrModify As Integer
    Private m_dataSource As ParameterProperty
    Public m_parent As Form1
    Public m_parent2 As ParametersModifier
    Private m_HasEditingError As Boolean = False

    Public Sub New(isAddorModify As Integer, parent As Form1, parent2 As ParametersModifier) ' 0 Add 1 Modify

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AddOrModify = isAddorModify
        m_parent = parent
        m_parent2 = parent2
        If isAddorModify = 0 Then
            Me.Button1.Text = "Add"
            Me.Text = "Add Parameter"
            DataSource = New ParameterProperty("EXAMPLE", "FF_FF", "FF_FF", 2, "0000")
        Else
            Me.Button1.Text = "Apply"
            Me.Text = "Modify Parameter"
        End If



    End Sub

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


    Public Sub ClearGridView()
        Me.DataGridView1.Rows.Clear()

        For i = 0 To 4
            Me.DataGridView1.Rows.Add()
        Next

        Me.DataGridView1.Rows.Item(0).Cells(0).Value = "Parameter"
        Me.DataGridView1.Rows.Item(1).Cells(0).Value = "Address"
        Me.DataGridView1.Rows.Item(2).Cells(0).Value = "Length"
        Me.DataGridView1.Rows.Item(3).Cells(0).Value = "Access Key"
        Me.DataGridView1.Rows.Item(4).Cells(0).Value = "Default Value"

    End Sub

    Public Sub UpdateGUI(Data As ParameterProperty)
        ClearGridView()
        'Me.ButtonWrite.Enabled = Not Data.Read_only And m_parent.ConnectionStatus
        'Me.ButtonRead.Enabled = m_parent.ConnectionStatus

        Me.DataGridView1.Rows.Item(0).Cells(1).Value = Data.Name
        Me.DataGridView1.Rows.Item(1).Cells(1).Value = Data.Adress
        Me.DataGridView1.Rows.Item(2).Cells(1).Value = Data.Length
        Me.DataGridView1.Rows.Item(3).Cells(1).Value = Data.AccessKey
        Me.DataGridView1.Rows.Item(4).Cells(1).Value = Data.DefaultValue
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        Dim myValue As String = Me.DataGridView1.Rows.Item(e.RowIndex).Cells(e.ColumnIndex).Value
        Dim myCell As DataGridViewCell = Me.DataGridView1.Rows.Item(e.RowIndex).Cells(e.ColumnIndex)
        Select Case e.RowIndex

            Case 1
                If myValue.Contains("_") And myValue.Length = 5 And myValue.IndexOf("_") = 2 Then
                    Me.m_HasEditingError = False

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 2
                If myValue.Length = 1 Then
                    Me.m_HasEditingError = False

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 3
                If myValue.Contains("_") And myValue.Length = 5 And myValue.IndexOf("_") = 2 Then
                    Me.m_HasEditingError = False

                Else
                    Me.m_HasEditingError = True
                    myCell.ErrorText = "Input Invalide"

                End If

            Case 4
                Try
                    If myValue.Length = Me.DataGridView1.Rows.Item(2).Cells(e.ColumnIndex).Value * 2 Then
                        Me.m_HasEditingError = False

                    Else
                        Me.m_HasEditingError = True
                        myCell.ErrorText = "Input Invalide"

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try



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

        If chCheck = 189 Then
            Return
        End If

        If chCheck = 16 Then
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

    Public Function ReadGUI() As ParameterProperty

        Dim Para As New ParameterProperty(Me.DataGridView1.Rows.Item(0).Cells(1).Value, Me.DataGridView1.Rows.Item(1).Cells(1).Value, Me.DataGridView1.Rows.Item(3).Cells(1).Value, Me.DataGridView1.Rows.Item(2).Cells(1).Value, Me.DataGridView1.Rows.Item(4).Cells(1).Value)
        Return Para
    End Function

    Public Sub UpdateDataSource()
        Me.m_dataSource.Name = Me.DataGridView1.Rows.Item(0).Cells(1).Value
        Me.m_dataSource.Adress = Me.DataGridView1.Rows.Item(1).Cells(1).Value
        Me.m_dataSource.Length = Me.DataGridView1.Rows.Item(2).Cells(1).Value
        Me.m_dataSource.AccessKey = Me.DataGridView1.Rows.Item(3).Cells(1).Value
        Me.m_dataSource.DefaultValue = Me.DataGridView1.Rows.Item(4).Cells(1).Value
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure to apply ?", MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Ok Then
            Dim paraRead = ReadGUI()

            If AddOrModify = 0 Then
                For Each para As ParameterProperty In Me.m_parent.m_CANMatrix.ParametersList
                    If para.Name = paraRead.Name Then
                        MsgBox("Parameter exists, Please check", MsgBoxStyle.OkCancel, "Information")
                        Exit Sub
                    End If
                Next
                Me.m_parent.m_CANMatrix.ParametersList.Add(paraRead)

                Me.m_parent2.DataSouce = Me.m_parent.m_CANMatrix.ParametersList
            Else
                UpdateDataSource()
                Me.m_parent2.DataSouce = Me.m_parent.m_CANMatrix.ParametersList

            End If

        End If

    End Sub
End Class