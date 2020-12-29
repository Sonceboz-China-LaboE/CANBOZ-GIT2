Public Class Form_keyFinder
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim paraPro As New ParameterProperty("Please input the correct values", "00_00", "00_00", 4)
        Me.UserControl_KeyFinder1.DataSource = paraPro
    End Sub


End Class