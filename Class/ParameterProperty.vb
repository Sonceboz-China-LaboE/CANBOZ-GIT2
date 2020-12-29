<Serializable()> Public Class ParameterProperty

    Public Name As String
    Public Adress As String
    Public AccessKey As String
    Public Length As Integer
    Public Read_only As Boolean

    Public CurrentValue As String

    Public ValueToWrite As String

    Public hasReadValue As Boolean = False
    Public DefaultValue As String

    Public Sub New(Na As String, Ad As String, Ac As String, Le As Integer, Optional Deval As String = "")
        Me.Name = Na
        Adress = Ad
        AccessKey = Ac
        Length = Le
        Me.Read_only = False
        DefaultValue = Deval

    End Sub



    Public Sub New(Na As String, Ad As String, Le As Integer, Optional Deval As String = "")
        Me.Name = Na
        Adress = Ad

        Length = Le
        Me.Read_only = True
        DefaultValue = Deval
        AccessKey = "XX_XX"

    End Sub



    Public Sub updateValue(current_Value As String, value_ToWrite As String)
        CurrentValue = current_Value
        ValueToWrite = value_ToWrite
        Me.hasReadValue = True

    End Sub
End Class
