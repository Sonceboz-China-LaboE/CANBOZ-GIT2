Imports System.Windows.Forms

Public Class Dialog_progress




    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。



    End Sub

    Public Sub ValueProgress(value As Integer, Optional state As String = "")



        Me.ProgressBar1.Value = value

        Me.LabelStateText.Text = state


        If value = 100 Then
            Me.Close()
        End If
    End Sub

    Public Sub CancelEnable(StateofButton As Boolean)
        Me.Cancel_Button.Enabled = StateofButton

    End Sub


End Class
