Imports System.Windows.Forms

Public Class Dialog_PassWordInput

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If Me.TextBox1.Text = Form1.CANBOZ_Config.PassWord Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Else
            MsgBox("Password incorrect !", MsgBoxStyle.OkOnly, "Warning")
            Me.TextBox1.Select()
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
