<Serializable()> Public Class ParamterLogList
    Public ParaList As New List(Of ParmeterLog)
    Public isUpdated As Boolean = False

    Public Sub AddRange(parali As List(Of ParmeterLog))

        ParaList.AddRange(parali)

    End Sub


End Class
