<Serializable()> Public Class ParmeterLog

    Public ParamterInLog As ParameterProperty

    Public DateRecord As Date

    Public IsImported As Boolean = False

    Public SN As String

    Public SWversion As String

    Public ProjectInformation As String


    Public Sub New(Para As ParameterProperty, dateNow As Date, Serial As String, sswversion As String, projectInfo As String, Optional isImpot As Boolean = False)

        ParamterInLog = Para
        DateRecord = dateNow
        IsImported = isImpot

        SN = Serial

        SWversion = sswversion

        ProjectInformation = projectInfo

    End Sub

End Class
