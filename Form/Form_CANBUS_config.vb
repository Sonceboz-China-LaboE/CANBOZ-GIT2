Public Class Form_CANBUS_config

    Private m_dataSource As CANMAX

    Public Property DataSource As CANMAX
        Get
            Return m_dataSource
        End Get
        Set(value As CANMAX)
            m_dataSource = value
            UpdateGUI()

        End Set
    End Property

    Private Sub UpdateGUI()
        If Form1.CANBOZ_Config.IsForCustom Then
            Me.LabelActive.Text = "Software Status: not activated"
            Me.ButtonActive.Enabled = True
        Else
            Me.LabelActive.Text = "Software Status: activated"
            Me.ButtonActive.Enabled = False
        End If
        Me.TextBoxIDACTCOMMADN.Text = m_dataSource.m_CANMatrix.Actuator_Command

        Me.TextBoxIDTool2ACT.Text = m_dataSource.m_CANMatrix.ToolToActuator

        Me.TextBoxCycleTimeACT_command.Text = m_dataSource.m_CANMatrix.CycleTimeMs
        Me.LabelInfo.Text = m_dataSource.m_CANMatrix.ClientName & "-" & m_dataSource.m_CANMatrix.ApplicationName & "-" & m_dataSource.m_CANMatrix.OMEName & "-" & m_dataSource.m_CANMatrix.SWVersion & "-" & m_dataSource.m_CANMatrix.ACTSerial

    End Sub

    Public Sub readFromGUI()
        m_dataSource.m_CANMatrix.Actuator_Command = Me.TextBoxIDACTCOMMADN.Text
        m_dataSource.m_CANMatrix.ToolToActuator = Me.TextBoxIDTool2ACT.Text
        m_dataSource.m_CANMatrix.CycleTimeMs = Me.TextBoxCycleTimeACT_command.Text
    End Sub

    Private Sub TextBoxIDACTCOMMADN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxIDACTCOMMADN.KeyPress, TextBoxIDTool2ACT.KeyPress
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

    Private Sub TextBoxIDACTCOMMADN_Leave(sender As Object, e As EventArgs) Handles TextBoxIDACTCOMMADN.Leave, TextBoxIDTool2ACT.Leave
        Dim iTextLength As Integer
        Dim uiMaxValue As UInteger

        ' Calculates the text length and Maximum ID value according
        ' with the Message Type
        '
        iTextLength = 8
        uiMaxValue = CUInt(&H1FFFFFFF)

        ' The Textbox for the ID is represented with 3 characters for 
        ' Standard and 8 characters for extended messages.
        ' Therefore if the Length of the text is smaller than TextLength,  
        ' we add "0"
        '
        While sender.Text.Length <> iTextLength
            sender.Text = ("0" & sender.Text)
        End While

        ' We check that the ID is not bigger than current maximum value
        '
        If Convert.ToUInt32(sender.Text, 16) > uiMaxValue Then
            sender.Text = String.Format("{0:X" & iTextLength.ToString() & "}", uiMaxValue)
        End If
    End Sub

    Private Sub TextBoxCycleTimeACT_command_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCycleTimeACT_command.KeyPress
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


        ' Is neither a number nor a character between A(a) and F(f)
        '
        e.Handled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Please recheck the value, any inappropriate value can cause unexpected function of CANBOZ, if confirmed, please click Yes", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then

            readFromGUI()
            Form1.m_CANMatrix = Me.DataSource.m_CANMatrix

            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonActive.Click
        Dim diag1 As New Dialog_PassWordInput


        If diag1.ShowDialog() = DialogResult.OK Then
            Form1.CANBOZ_Config.IsChangeParaAllowed = True
            Form1.CANBOZ_Config.IsForCustom = False
            Me.LabelActive.Text = "Software Status: activated"
            Me.ButtonActive.Enabled = False
        Else
            Me.LabelActive.Text = "Software Status: not activated"
            Me.ButtonActive.Enabled = True
        End If
    End Sub
End Class