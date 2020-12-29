Public Class Form_LoadCANMAX
    Public myparent As Form1
    Public Sub New(ByRef parentForm As Form1)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        myparent = parentForm
        If IO.Directory.Exists("CANMAX Library") Then
            For Each filename As String In IO.Directory.GetFiles("CANMAX Library", "*.CANMAX")
                Me.TreeView1.Nodes.Add(filename)
            Next
        End If





    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Dim fileinfo As IO.FileInfo = New IO.FileInfo(e.Node.Text)

        Dim CanMaxFromImport = New CANMAX()

        Try
            myparent.MarcoPaola.ImportFileFromFixedLocation(fileinfo.FullName, CanMaxFromImport)


            myparent.m_MyCanMaxFromImport = New CANMAX(CanMaxFromImport.m_CANMatrix, CanMaxFromImport.m_FeedBack, myparent)

            myparent.InitializeBasicComponents()
            myparent.btnRelease_Click(myparent, New EventArgs)
            myparent.btnInit_Click(myparent, New EventArgs)
            Me.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        Dim CanMaxFromImport = New CANMAX()


        Try
            If myparent.MarcoPaola.ImportFile("CANMAX", "Sonceboz CAN Matrix File", CanMaxFromImport) Then
                myparent.m_MyCanMaxFromImport = New CANMAX(CanMaxFromImport.m_CANMatrix, CanMaxFromImport.m_FeedBack, myparent)

                myparent.InitializeBasicComponents()
                myparent.btnRelease_Click(myparent, New EventArgs)
                myparent.btnInit_Click(myparent, New EventArgs)
                Me.Close()
            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub ButtonExit_Click(sender As Object, e As EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub
End Class