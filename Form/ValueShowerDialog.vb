Imports System.Windows.Forms

<Serializable()> Public Class ValueShowerDialog


    Public Sub New(paraName As String, rawValue As String, ConversedValue As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Label1.Text = "The value " & paraName & " reads : "


        Me.TextBox1.Text = rawValue
        Me.TextBox2.Text = ConversedValue

    End Sub

    Private Sub OK_Button_Click_1(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
