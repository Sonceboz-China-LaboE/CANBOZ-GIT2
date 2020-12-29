Imports System.Windows.Forms

<Serializable()> Public Class DialogWriteValue

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public valueTowrite As String
    Public Numbyte As Integer

    Public Sub New(Num As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.TextBox1.MaxLength = 2 * Num
        Numbyte = Num

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Public Function ConverseInputValue() As String
        Dim valueString As String = ""

        For i = 0 To Numbyte - 1
            valueString = valueString & TextBox1.Text.Substring(i * 2, 2) & "_"
        Next

        If Numbyte < 4 Then
            For j = 0 To 4 - Numbyte - 1
                valueString = valueString & "00_"
            Next

        End If

        Return valueString.Remove(valueString.Length - 1, 1)


    End Function

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        While TextBox1.Text.Length <> Numbyte * 2
            TextBox1.Text = ("0" & TextBox1.Text)
        End While
    End Sub


End Class
