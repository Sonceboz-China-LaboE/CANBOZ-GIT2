<Serializable()> Public Class FeedbackResults

    Public ID_ACTstatus As String
    Private m_msg_ACTstatus As String
    Public ID_FaultsCode As String

    Private m_msg_FaultsCode As String
    Public TypeStructureCommand As Integer = 0 '0-2 feedbacks, 1-1 feedbacks
    Public isUpdated As Boolean = False

    Public FaultsCodeBinaryList As New List(Of Boolean)
    Public FaultsColorMapping As New List(Of Color)

    Public MyCanMatrix As CAN_Matrix
    Public ID_ACT2Tool As String
    Private m_msg_ACT2Tool As String

    Public DataInACT2Tool_Raw As String = ""
    Public DataInACT2Tool_Integer As Integer = 0
    Public AdressInACT2Tool As String = ""


    Public PositionFeedback As Integer

    Public PositionTarget As Integer

    Public is_Error As Boolean

    Public CurrentActStatus As Integer



    Public CurrentTemperature As Integer

    Public CurrentMotorEffort As Integer
    Public MapplingStatusIndexlist As List(Of Integer) = New List(Of Integer)


    Public Property Msg_ACT2Tool As String
        Get
            Return m_msg_ACT2Tool
        End Get
        Set(value As String)
            m_msg_ACT2Tool = value.Replace(" ", "")
            AnalyseMsg_ACT2Tool()
        End Set
    End Property

    Private Sub AnalyseMsg_ACT2Tool()
        Dim Byte1 As String = m_msg_ACT2Tool.Substring(0, 2)
        Dim Byte2 As String = m_msg_ACT2Tool.Substring(2, 2)
        Dim Byte3 As String = m_msg_ACT2Tool.Substring(4, 2)
        Dim Byte4 As String = m_msg_ACT2Tool.Substring(6, 2)
        Dim Byte5 As String = m_msg_ACT2Tool.Substring(8, 2)
        Dim Byte6 As String = m_msg_ACT2Tool.Substring(10, 2)

        Dim Tool2ACTFeedback As String = Byte3 & Byte4 & Byte5 & Byte6
        Me.DataInACT2Tool_Raw = Tool2ACTFeedback
        Me.DataInACT2Tool_Integer = Convert.ToInt32(Tool2ACTFeedback, 16)
        Me.AdressInACT2Tool = Byte1 & Byte2
    End Sub

    Public Property Msg_FaultsCode As String
        Get
            Return m_msg_FaultsCode
        End Get
        Set(value As String)
            m_msg_FaultsCode = value.Replace(" ", "")
            Select Case Me.TypeStructureCommand
                Case 0
                    AnalyseMsg_FaultsType0()
                Case 1
                    AnalyseMsg_FaultsType1()
                Case 2
                    AnalyseMsg_FaultsType2()
            End Select
        End Set
    End Property

    'Public Enum Errors As Integer
    '    Undervoltage = 0
    '    Overvoltage = 1
    '    Over_Temperature = 2
    '    Temperature_Warning = 3
    '    Position_Deviation = 4
    '    CAN_Error_NeverReceived = 5
    '    CAN_Error_NotReceived = 6
    '    EEPROM_Error = 7
    '    Sensor_Error = 8
    '    Temperature_Measuring_Error = 9
    '    Current_Measuring_Error = 10
    '    Voltage_Measuring_Error = 11
    '    Hardstop_Search_Timeout = 12
    '    Learn_Error_SpanSmall = 13
    '    Learn_Error_SpanBig = 14
    '    Cablibration_Error_SpanSmall = 15
    '    Cablibration_Error_SpanBig = 16
    '    Undefined = 17
    'End Enum



    Public StatusList As String() = {"Position control", "Calibration", "Learn", "Wiping cycle", "Override", "Electrical failsafe", "Electrical failsafe override", "Undefined"}

    'Public StatusIndexMappingList As List(Of Integer) = {1, 3, 5, 6, 7, 8, -1}


    Public ErrorsList As String() = {"EEPROM Error", "CAN Error: Not Received", "CAN Erro: Never Received", "Position Deviation", "Temperature Warning", "Over Temperature", "Overvoltage", "Undervoltage", "Cablibration Error: Span too Small", "Learn Error: Span too Big", "Learn Error: Span too Small",
       "Hardstop Search Timeout", "Voltage Measuring Error", "Current Measuring Error", "Temperature Measuring Error", "Sensor Error", "Cablibration Error: Span too Big", "Undefined"}






    Public Function MappingStatus_Index() As Integer
        MapplingStatusIndexlist.Clear()
        MapplingStatusIndexlist.AddRange({1, 2, 3, 5, 6, 7, 8, -1})
        If MapplingStatusIndexlist.Contains(CurrentActStatus) Then
            Return MapplingStatusIndexlist.IndexOf(CurrentActStatus)
        Else
            Return MapplingStatusIndexlist.Count - 1
        End If



    End Function

    Public Enum TypeFeedback As Integer
        ActStatus = 0
        ACT2Tool = 2
        FaultsCode = 1
        NotFind = -1
    End Enum

    Public TypeFeedbackStrList As String() = {"ACT_STAT", "ACT2TOOL", "FAULTSCODE"}

    Public Property Msg_ACTstatus As String
        Get
            Return m_msg_ACTstatus
        End Get
        Set(value As String)
            m_msg_ACTstatus = value.Replace(" ", "")
            Select Case Me.TypeStructureCommand
                Case 0
                    Me.AnalyseMsg_Status()
                Case 1
                    Me.AnalyseMsg_Status1()
                Case 2
                    Me.AnalyseMsg_Status()
            End Select

        End Set
    End Property


    Public Sub AnalyseMsg_Status()

        Dim Byte1 As String = m_msg_ACTstatus.Substring(0, 2)
        Dim Byte2 As String = m_msg_ACTstatus.Substring(2, 2)
        Dim Byte3 As String = m_msg_ACTstatus.Substring(4, 2)
        Dim Byte4 As String = m_msg_ACTstatus.Substring(6, 2)
        Dim Byte5 As String = m_msg_ACTstatus.Substring(8, 2)
        Dim Byte6 As String = m_msg_ACTstatus.Substring(10, 2)
        Dim Byte7 As String = m_msg_ACTstatus.Substring(12, 2)
        Dim Byte8 As String = m_msg_ACTstatus.Substring(14, 2)


        Dim PositionFeedBackSTR As String = Byte3 & Byte2
        PositionFeedback = Convert.ToInt32(PositionFeedBackSTR, 16) * 0.1

        Dim PositionTargetSTR As String = Byte7 & Byte6
        Me.PositionTarget = Convert.ToInt32(PositionTargetSTR, 16) * 0.1

        CurrentActStatus = Convert.ToInt32(Byte1, 16)

        Me.CurrentTemperature = Convert.ToInt32(Byte4, 16) - 55

        Me.CurrentMotorEffort = Convert.ToInt32(Byte8, 16) - 100

        If Byte5 = "00" Then
            is_Error = False
        Else
            is_Error = True
        End If

    End Sub

    Public Sub AnalyseMsg_Status1()

        Dim Byte1 As String = m_msg_ACTstatus.Substring(0, 2)
        Dim Byte2 As String = m_msg_ACTstatus.Substring(2, 2)
        Dim Byte3 As String = m_msg_ACTstatus.Substring(4, 2)
        Dim Byte4 As String = m_msg_ACTstatus.Substring(6, 2)
        Dim Byte5 As String = m_msg_ACTstatus.Substring(8, 2)
        Dim Byte6 As String = m_msg_ACTstatus.Substring(10, 2)
        Dim Byte7 As String = m_msg_ACTstatus.Substring(12, 2)
        Dim Byte8 As String = m_msg_ACTstatus.Substring(14, 2)


        Dim PositionFeedBackSTR As String = Byte2 & Byte1
        PositionFeedback = Convert.ToInt32(PositionFeedBackSTR, 16) * 0.1



        CurrentActStatus = Convert.ToInt32(Byte3, 16)

        Me.CurrentTemperature = Convert.ToInt32(Byte5, 16) - 40

        Me.CurrentMotorEffort = Convert.ToInt32(Byte6, 16) * 0.8 - 100

        If Byte8 = "00" Then
            is_Error = False
        Else
            is_Error = True
        End If

        Dim BinaryString As String = Me.DecimalToBinary(Convert.ToInt32(Byte8, 16), 16)
        Do Until BinaryString.Length = 24
            BinaryString = "0" & BinaryString
        Loop

        Dim bit As Boolean
        Dim colr As Color
        For i = 0 To 15

            If BinaryString(i) = "0" Then
                bit = False
                colr = Color.White
            Else
                bit = True
                colr = Color.Red
            End If
            FaultsCodeBinaryList.Add(bit)
            FaultsColorMapping.Add(colr)
        Next

    End Sub


    Public Sub AnalyseMsg_FaultsType0()
        FaultsColorMapping.Clear()
        FaultsCodeBinaryList.Clear()
        Dim BytesFault As String = m_msg_FaultsCode.Substring(0, 6)

        Dim BinaryString As String = Me.DecimalToBinary(Convert.ToInt32(BytesFault, 16), 16)
        Do Until BinaryString.Length = 24
            BinaryString = "0" & BinaryString
        Loop

        Dim bit As Boolean
        Dim colr As Color
        For i = 0 To 15

            If BinaryString(i) = "0" Then
                bit = False
                colr = Color.White
            Else
                bit = True
                colr = Color.Red
            End If
            FaultsCodeBinaryList.Add(bit)
            FaultsColorMapping.Add(colr)
        Next

        If BinaryString(BinaryString.Length - 1) = "0" Then
            bit = False
            colr = Color.White
        Else
            bit = True
            colr = Color.Red
        End If

        FaultsCodeBinaryList.Add(bit)
        FaultsColorMapping.Add(colr)


    End Sub


    Public Sub AnalyseMsg_FaultsType2()
        FaultsColorMapping.Clear()
        FaultsCodeBinaryList.Clear()
        Dim BytesFault As String = m_msg_FaultsCode.Substring(0, 8)

        Dim BinaryString As String = Me.DecimalToBinary(Convert.ToInt64(BytesFault, 16), 16)
        Do Until BinaryString.Length = 32
            BinaryString = "0" & BinaryString
        Loop

        Dim bit As Boolean
        Dim colr As Color
        For i = 3 To 7

            If BinaryString(i) = "0" Then
                bit = False
                colr = Color.White
            Else
                bit = True
                colr = Color.Red
            End If
            FaultsCodeBinaryList.Add(bit)
            FaultsColorMapping.Add(colr)
        Next

        For i = 16 To 23

            If BinaryString(i) = "0" Then
                bit = False
                colr = Color.White
            Else
                bit = True
                colr = Color.Red
            End If
            FaultsCodeBinaryList.Add(bit)
            FaultsColorMapping.Add(colr)
        Next

        For i = 28 To 31

            If BinaryString(i) = "0" Then
                bit = False
                colr = Color.White
            Else
                bit = True
                colr = Color.Red
            End If
            FaultsCodeBinaryList.Add(bit)
            FaultsColorMapping.Add(colr)
        Next



    End Sub


    Public Sub AnalyseMsg_FaultsType1() ' Feedbacks BHKS Sinotruck


    End Sub

    Public Function ReturnFaultInfo() As String
        If is_Error Then
            Dim Mystring As String = ""
            For i = 0 To FaultsCodeBinaryList.Count - 1
                If FaultsCodeBinaryList(i) Then
                    Mystring = Mystring & ErrorsList(i) & "_"
                End If
            Next
            If Mystring.Replace("_", "") = "" Then

                Mystring = "Error undefined "
            End If
            Return Mystring
        End If
        Return "No Error"
    End Function

    Public Function DecimalToBinary(DecimalValue As Long, MinimumDigits As Integer) As String

        ' Returns a string containing the binary
        ' representation of a positive integer.

        Dim result As String
        Dim ExtraDigitsNeeded As Integer

        ' Make sure value is not negative.
        DecimalValue = Math.Abs(DecimalValue)

        ' Construct the binary value.
        Do
            result = CStr(DecimalValue Mod 2) & result
            DecimalValue = DecimalValue \ 2
        Loop While DecimalValue > 0

        ' Add leading zeros if needed.

        ExtraDigitsNeeded = MinimumDigits - Len(result)
        If ExtraDigitsNeeded > 0 Then
            For i As Integer = 0 To ExtraDigitsNeeded - 1
                result = "0" & result
            Next

        End If

        DecimalToBinary = result

    End Function






    Public Function getFeedBackType(ID As String) As TypeFeedback
        ID = ID.Replace("h", " ")
        ID = ID.TrimEnd()

        If ID = MyCanMatrix.Actuator_Status Then
            Return TypeFeedback.ActStatus


        ElseIf ID = MyCanMatrix.Actuator_Fault_Codes Then
            Return TypeFeedback.FaultsCode


        ElseIf ID = MyCanMatrix.ActuatorToTool Then
            Return TypeFeedback.ACT2Tool

        Else
            Return TypeFeedback.NotFind

        End If
    End Function

    Public Function getFeedBackTypeStr(ID As String) As String
        ID = ID.Replace("h", " ")
        ID = ID.TrimEnd()

        If ID = MyCanMatrix.Actuator_Status Then
            Return "ACT_STAT"


        ElseIf ID = MyCanMatrix.Actuator_Fault_Codes Then
            Return "FAULTSCODE"

        ElseIf ID = MyCanMatrix.ActuatorToTool Then
            Return "ACT2TOOL"

        Else
            Return "INT"

        End If
    End Function

    Public Function getFeedBackTypeColor(ID As String) As Color
        ID = ID.Replace("h", " ")
        ID = ID.TrimEnd()

        If ID = MyCanMatrix.Actuator_Status Then
            Return Color.LightSkyBlue


        ElseIf ID = MyCanMatrix.Actuator_Fault_Codes Then
            Return Color.OrangeRed

        ElseIf ID = MyCanMatrix.ActuatorToTool Then
            Return Color.LightSeaGreen

        Else
            Return Color.Gray

        End If
    End Function

    Public Function ReadResults(Msg As MessageStatus) As Boolean




        Select Case getFeedBackType(Msg.IdString)

            Case TypeFeedback.ActStatus
                Me.ID_ACTstatus = Msg.IdString.Replace("h", " ")
                Me.Msg_ACTstatus = Msg.DataString
                isUpdated = True
                Return True
            Case TypeFeedback.FaultsCode

                Me.ID_FaultsCode = Msg.IdString.Replace("h", " ")
                Me.Msg_FaultsCode = Msg.DataString
                isUpdated = True
                Return True

            Case TypeFeedback.ACT2Tool
                Me.ID_ACT2Tool = Msg.IdString.Replace("h", " ")
                Me.Msg_ACT2Tool = Msg.DataString
                isUpdated = True
                Return True
            Case Else
                Return False
        End Select


        '                End

    End Function

    Public Sub New(CANmatrix As CAN_Matrix)
        MyCanMatrix = CANmatrix

    End Sub

    Public Function TrimACT2ToolMsg(ActiveByteNum As Integer) As String


        Dim newStr As String = Me.DataInACT2Tool_Raw.Substring(0, 2 * ActiveByteNum)

        Return newStr
    End Function

    Public Function TrimACT2ToolMsgIntoInt(ActiveByteNum As Integer) As Integer

        Dim newStr As String = Me.DataInACT2Tool_Raw.Substring(0, 2 * ActiveByteNum)
        Dim NewInt = Convert.ToInt32(newStr, 16)
        Return NewInt
    End Function
End Class
