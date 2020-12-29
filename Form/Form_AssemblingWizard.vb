Public Class Form_AssemblingWizard

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Me.TabPage1.Enabled = False
        Me.TabPageStep2.Enabled = False
        Me.TabPageStep3.Enabled = False

        Me.TabPageStep4.Enabled = False
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.TabPage1.Enabled = True
        Me.Tabcontrol.SelectedIndex = 1
    End Sub

    Private Sub ButtonStep1_Click(sender As Object, e As EventArgs) Handles ButtonStep1.Click
        Me.TabPageStep2.Enabled = True
        Me.Tabcontrol.SelectedIndex = 2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.TabPageStep3.Enabled = True
        Me.Tabcontrol.SelectedIndex = 3
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.TabPageStep4.Enabled = True
        Me.Tabcontrol.SelectedIndex = 4
    End Sub

    Private Sub ButtonStep1_1_Click(sender As Object, e As EventArgs) Handles ButtonStep1_1.Click
        Form1.buttonCalibration_Click(sender, e)
        sender.BackColor = Color.GreenYellow

    End Sub

    Private Sub ButtonStep1_2_Click(sender As Object, e As EventArgs) Handles ButtonStep1_2.Click
        Form1.button1_Click(sender, e)
        sender.BackColor = Color.GreenYellow
    End Sub

    Private Sub ButtonStep2_1_Click(sender As Object, e As EventArgs) Handles ButtonStep2_1.Click
        Form1.SendResquest("Override")
        sender.BackColor = Color.GreenYellow
    End Sub
End Class