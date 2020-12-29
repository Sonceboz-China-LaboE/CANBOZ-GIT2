Imports System.IO
Imports Microsoft.Office.Interop

<Serializable()> Public Class MacroPalo

    Private OpenFileDialogIMPORT As OpenFileDialog
    Private SaveFileDialogEXPORT As SaveFileDialog

    Public MyExcelApp As Excel.Application
    Public MyExcelBook As Excel.Workbook

    Public Function ImportFile(extension As String, descip As String, ByRef object2Import As Object) As Boolean
        Try
            OpenFileDialogIMPORT = New OpenFileDialog()
            OpenFileDialogIMPORT.Filter = descip & "(" & "*." & extension & ")" & "|*." & extension
            OpenFileDialogIMPORT.FilterIndex = 1
            If Me.OpenFileDialogIMPORT.ShowDialog() = DialogResult.OK Then

                Dim fileName As String = Me.OpenFileDialogIMPORT.FileName
                Dim fStream As New IO.FileStream(fileName, FileMode.Open)
                Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

                object2Import = sfFormatter.Deserialize(fStream)
                fStream.Close()
                MsgBox("Imported Successfully",, "Infomation")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message,, "Error Writing")
            Return False
        End Try


    End Function

    Public Function ImportFileFromFixedLocation(Fullfilename As String, ByRef object2Import As Object) As Boolean
        Try




            Dim fStream As New IO.FileStream(Fullfilename, FileMode.Open)
            Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

            object2Import = sfFormatter.Deserialize(fStream)
            fStream.Close()
            ' MsgBox("Imported Successfully",, "Infomation")
            Return True


        Catch ex As Exception
            MsgBox(ex.Message,, "Error Writing")
            Return False
        End Try


    End Function

    Public Function ExportFile(extension As String, descip As String, object2Export As Object) As Boolean
        Try
            SaveFileDialogEXPORT = New SaveFileDialog()
            SaveFileDialogEXPORT.Filter = descip & "(" & "*." & extension & ")" & "|*." & extension
            SaveFileDialogEXPORT.FilterIndex = 1

            If SaveFileDialogEXPORT.ShowDialog = DialogResult.OK Then
                Dim sfFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim saveFile As IO.FileStream = New IO.FileStream(SaveFileDialogEXPORT.FileName, IO.FileMode.Create)
                sfFormatter.Serialize(saveFile, object2Export)
                saveFile.Close()
                MsgBox("Exported Successfully",, "Infomation")
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.Message,, "Error Writing")
            Return False
        End Try
    End Function

    Public Function ExportFileInfixedLocation(extension As String, direct As String, object2Export As Object, Filename As String) As Boolean
        Try




            Dim sfFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim saveFile As IO.FileStream = New IO.FileStream(direct & "\" & Filename & "." & extension, IO.FileMode.Create)
            sfFormatter.Serialize(saveFile, object2Export)
            saveFile.Close()

            Return True




        Catch ex As Exception
            MsgBox(ex.Message,, "Error Writing, CANMAX Can not Generate")
            Return False
        End Try
    End Function

    Public Function SaveToTXTInfixedLocation(direct As String, text2Append As String, Filename As String) As Boolean
        Try

            Dim FullName As String = direct & "\" & Filename & "." & "txt"

            If Not System.IO.File.Exists(FullName) Then

                Dim a = System.IO.File.CreateText(FullName)

                a.Close()

            End If

            'Dim sfFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim saveFile As IO.StreamWriter = New IO.StreamWriter(FullName, True, System.Text.Encoding.UTF8)

            saveFile.WriteLine(text2Append)

            saveFile.Close()

            Return True




        Catch ex As Exception
            MsgBox(ex.Message,, "Error Writing, CANMAX Can not Generate")
            Return False
        End Try
    End Function

    Public Function ReadTXTArrayInfixedLocation(direct As String, Filename As String, ByRef textArray As String()) As Boolean
        Try

            Dim FullName As String = direct & "\" & Filename & "." & "txt"

            If Not System.IO.File.Exists(FullName) Then
                'MsgBox("Error reading, File not exists")
                textArray = {}
                Return False

            End If

            'Dim sfFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim saveFile As String() = IO.File.ReadAllLines(FullName, System.Text.Encoding.UTF8)

            textArray = saveFile



            Return True




        Catch ex As Exception
            MsgBox(ex.Message,, "Error Writing, CANMAX Can not Generate")
            textArray = {}
            Return False
        End Try
    End Function

    Public Function CreatExcelSheet(Sheetname As String) As Excel.Worksheet
        Try
            MyExcelApp = New Excel.Application
            If IsNothing(MyExcelApp) Then
                MessageBox.Show("Can not generate Excel file, maybe no Excel application in your PC")
                Return Nothing

            End If

            MyExcelBook = MyExcelApp.Workbooks.Add()

            Dim mySheet As Excel.Worksheet = MyExcelBook.Worksheets(1)


            Return mySheet

        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
            Return Nothing
        End Try

    End Function

    Public Function CreatExcelBook() As Excel.Workbook
        Try
            MyExcelApp = New Excel.Application
            If IsNothing(MyExcelApp) Then
                MessageBox.Show("Can not generate Excel file, maybe no Excel application in your PC")
                Return Nothing

            End If

            MyExcelBook = MyExcelApp.Workbooks.Add()



            Return MyExcelBook

        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
            Return Nothing
        End Try

    End Function

    Public Sub SaveExcel()
        Try
            If SaveFileDialogEXPORT Is Nothing Then
                SaveFileDialogEXPORT = New SaveFileDialog()
            End If

            SaveFileDialogEXPORT.Filter = "Excel Document(*.xlsx)" & "|*.xlsx"
            SaveFileDialogEXPORT.FilterIndex = 1

            If SaveFileDialogEXPORT.ShowDialog = DialogResult.OK Then
                MyExcelBook.SaveAs(SaveFileDialogEXPORT.FileName)



                MyExcelBook.Close()  '关闭工作簿 

                MyExcelBook = Nothing  '释放资源

                MyExcelApp.Quit()  '退出excel应用程序 

                MyExcelApp = Nothing
                MsgBox("Exported Successfully", MsgBoxStyle.OkOnly, "Infomation")

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try


    End Sub

    Public Function SaveExcelToFixLocation(dir As String, Name As String) As String
        Try



            Dim FileName = Application.StartupPath & "\" & dir & "\" & Name & ".xlsx"
            ' MyExcelBook.Title = FileName
            MyExcelBook.SaveAs(FileName)



            MyExcelBook.Close()  '关闭工作簿 

            MyExcelBook = Nothing  '释放资源

            'MyExcelApp.Workbooks.Open(FileName)

            'MsgBox("Exported Successfully", MsgBoxStyle.OkOnly, "Infomation")

            Return FileName

        Catch ex As Exception
            MsgBox(ex.Message,, "Error")

            Return ""
        End Try


    End Function

End Class
