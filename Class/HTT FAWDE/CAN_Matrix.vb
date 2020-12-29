﻿<Serializable()> Public Class CAN_Matrix
    Public ClientName = "HTT SH"
    Public OMEName = "FAWDE WUXI"
    Public ACTSerial = "5846R519"
    Public ApplicationName = "EWG"
    Public SWVersion = "5846S206.100"
    Public TCIVersion = "V2.8"

    Public CycleTimeMs As Integer = 10

    Public DateToday As Long = Date.Today.ToFileTime
    Public Actuator_Command As String = "08FF8200"
    Public Actuator_Status As String = "08FF1082"
    Public Actuator_Fault_Codes As String = "18FF0A82"
    Public ToolToActuator As String = "18FF8203"
    Public ActuatorToTool As String = "18FF0D82"

    Public ReadDiagnosticTable As String = "09"
    Public ReadRingBuffer As String() = {"0A", "1A"}
    Public ReadHistogram As String = "0B"

    Public DiagnosticStartByte As Integer = 0
    Public DiagnoticRowNumber As Integer = 16



    Public RingBufferStartByte As Integer = 0
    Public RingBufferRowNumber As Integer = 16


    Public HistogramAdressArray As String() = {"08", "0C", "10", "14", "18", "1C", "20", "24", "28", "2C", "30", "34", "38", "3C", "40"}
    Public HistogramRowNumber As Integer = HistogramAdressArray.Length
    Public HistogramRangeStringArray As String() = {"<-10°C", "-10°C - 85°C", "85°C - 115°C", "115°C - 150 °C", ">150°C", "<2A", "2A - 4A", "4A - 5A", "5A - 10A", ">10A", "<10%", "10% - 30%", "30% - 70%", "70% - 90%", ">90%"}
    Public WriteProblemCode As String = "FF"
    Public ReadProblemCode As String = "FF"

    Public ListOfCommandName As String()

    Public DignosticsTableRowLabels1 As String（） = {"EEPROM Error", "CAN Error: Not Received", "CAN Erro: Never Received", "Position Deviation", "Temperature Warning", "Over Temperature", "Overvoltage", "Undervoltage", "Cablibration Error: Span too Small", "Learn Error: Span too Big", "Learn Error: Span too Small",
       "Hardstop Search Timeout", "Voltage Measuring Error", "Current Measuring Error", "Temperature Measuring Error", "Sensor Error", "Cablibration Error: Span too Big", "Undefined"}
    Public DignosticsTableRowLabels As String（） = {"Temperature", "CAN Msg", "CAN Bus", "Over voltage", "Hall Sensor", "Position Deviation", "Learn Errors", "High current", "Stack", "Reserved", "Reserved",
       "Reserved", "Reserved", "Reserved", "reserved", "reserved", "reserved", "reserved"}


    Public DiagnoticTableColumLabels As New Dictionary(Of String, Integer)
    Public CountRequest As Integer = 8

    Public ReadRequestInGUI As String() = {"ComputedStroke", "FixedSpan", " Config_CAN_Learn_CMD"}

    'Public Enum ReadRequestInGUI As Integer
    '    ComputedStroke = 0
    '    FixedSpan = 1
    '    Config_CAN_Learn_CMD = 2


    'End Enum

    Public ACT_CommandDict As New Dictionary(Of String, String)

    Public Specific_CommandDict As New Dictionary(Of String, String)

    Public ParametersList As New List(Of ParameterProperty)




    Public Sub New()


        ACT_CommandDict.Add("Position Control", "00_00_01_FF_FF_FF_FF_FF")
        ACT_CommandDict.Add("Learn", "00_00_03_FF_FF_FF_FF_FF")
        ACT_CommandDict.Add("Wiping Cycle", "00_00_05_FF_FF_FF_FF_FF")
        ACT_CommandDict.Add("Override", "00_00_06_FF_FF_FF_FF_FF")
        ACT_CommandDict.Add("Electrical failsafe", "00_00_07_FF_FF_FF_FF_FF")
        ACT_CommandDict.Add("Electrical failsafe then override", "00_00_08_FF_FF_FF_FF_FF")


        Specific_CommandDict.Add("CAN Calibration", "C5_07_00_02_01_00_00_00")
        Specific_CommandDict.Add("Restart Sequence", "C5_07_00_02_00_00_00_00")
        Specific_CommandDict.Add("SW Version 1", "04_00_01_04_00_00_00_00")
        Specific_CommandDict.Add("SW Version 2", "04_04_01_04_00_00_00_00")
        Specific_CommandDict.Add("SW Version 3", "04_08_01_04_00_00_00_00")

        Specific_CommandDict.Add("Serial Number 1", "04_1B_01_04_00_00_00_00")
        Specific_CommandDict.Add("Serial Number 2", "04_1F_01_04_00_00_00_00")
        Specific_CommandDict.Add("Serial Number 3", "04_23_01_02_00_00_00_00")

        Specific_CommandDict.Add("Operating Time", "08_00_01_04_00_00_00_00")
        Specific_CommandDict.Add("Amount of Power On", "08_0C_01_04_00_00_00_00")

        DiagnoticTableColumLabels.Add("Number of Occurances", 1)
        DiagnoticTableColumLabels.Add("CRC 16", 2)
        DiagnoticTableColumLabels.Add("Temperature", 1)
        DiagnoticTableColumLabels.Add("Voltage", 1)
        DiagnoticTableColumLabels.Add("Number of Power on cycles", 3)
        DiagnoticTableColumLabels.Add("Working time", 2)
        DiagnoticTableColumLabels.Add("Time since Power on", 2)
        DiagnoticTableColumLabels.Add("Actual Position", 1)
        DiagnoticTableColumLabels.Add("Coil Current", 2)
        DiagnoticTableColumLabels.Add("Reserved", 1)

        Me.ListOfCommandName = {"Position Control", "Learn", "Self-Calibration", "Wiping Cycle", "Electrical failsafe", "Override", "Electrical failsafe then override"}

        ParametersList.Add(New ParameterProperty("EE_POWER_ON_COMMANDS", "00_51", "56_6D", 2, "0080"))
        ParametersList.Add(New ParameterProperty("EE_CONFIG_CAN_LEARN_CMD", "00_1E", "69_27", 1, "10"))
        ParametersList.Add(New ParameterProperty("EE_FIXEDSPAN", "00_6B", "0C_68", 2, "00EF"))
        ParametersList.Add(New ParameterProperty("EE_COMPUTEDSTROKE", "00_5A", "2D_6C", 2))
        ParametersList.Add(New ParameterProperty("EE_CALIBENABLED", "00_16", "21_26", 1, "55"))
        ParametersList.Add(New ParameterProperty("EE_MAXSPNALLWD", "00_15", "12_26", 1, "57"))
        ParametersList.Add(New ParameterProperty("EE_MINSPNALLWD", "00_14", "C3_27", 1, "3D"))
        ParametersList.Add(New ParameterProperty("EE_ALLWDDIFMXSPN", "00_75", "B2_2F", 1, "52"))
        ParametersList.Add(New ParameterProperty("EE_ALLWDDIFMNSPN", "00_1D", "5A_27", 1, "05"))
        ParametersList.Add(New ParameterProperty("EE_HISTOAUTOSAVE", "00_74", "63_2E", 1, "01"))

        ParametersList.Add(New ParameterProperty("EE_ACTCOMM_CYCTIM", "00_4D", "0A_2B", 1, "01"))
        ParametersList.Add(New ParameterProperty("EE_LOCKBYTE", "00_35", "72_21", 1, "00"))


    End Sub

    Public Function GetReadEEPROMCommand(Para As Integer, IndexRow As Integer, Optional IndexColum As Integer = 0, Optional RingBufferZone As Integer = 0) As String


        Select Case Para
            Case 0 ' Diagnostic Table 
                Dim adressCode As String = Me.ReadDiagnosticTable & "_" & String.Format("{0:X1}", IndexRow) & String.Format("{0:X1}", IndexColum)
                Dim Name = "Diagnostic Table @" & adressCode
                Dim ParaNew As New ParameterProperty(Name, adressCode, 1)

                Dim command As String = ParaNew.Adress & "_01_0" & ParaNew.Length & "_00_00_00_00"
                Return command.Trim


            Case 1 ' RingBuffer

                Dim adressCode As String = Me.ReadRingBuffer(RingBufferZone) & "_" & String.Format("{0:X1}", IndexRow) & String.Format("{0:X1}", IndexColum)
                Dim Name = "Ring Buffer @" & adressCode
                Dim ParaNew As New ParameterProperty(Name, adressCode, 1)

                Dim command As String = ParaNew.Adress & "_01_0" & ParaNew.Length & "_00_00_00_00"
                Return command.Trim

            Case 2 ' Histogram
                If IndexRow <= Me.HistogramAdressArray.Length - 1 Then
                    Dim adressCode As String = Me.ReadHistogram & "_" & Me.HistogramAdressArray(IndexRow)
                    Dim Name = "Histogram @" & adressCode
                    Dim ParaNew As New ParameterProperty(Name, adressCode, 4)

                    Dim command As String = ParaNew.Adress & "_01_0" & ParaNew.Length & "_00_00_00_00"
                    Return command.Trim

                Else Return Nothing
                End If

            Case Else
                Return Nothing


        End Select


    End Function

    Public Function GetReadEEPROMCommandAdress(Para As Integer, IndexRow As Integer, Optional IndexColum As Integer = 0, Optional RingBufferZone As Integer = 0) As String


        Select Case Para
            Case 0 ' Diagnostic Table 
                Dim adressCode As String = Me.ReadDiagnosticTable & "_" & String.Format("{0:X1}", IndexRow) & String.Format("{0:X1}", IndexColum)


                Return adressCode


            Case 1 ' RingBuffer

                Dim adressCode As String = Me.ReadRingBuffer(RingBufferZone) & "_" & String.Format("{0:X1}", IndexRow) & String.Format("{0:X1}", IndexColum)

                Return adressCode

            Case 2 ' Histogram
                If IndexRow <= Me.HistogramAdressArray.Length - 1 Then
                    Dim adressCode As String = Me.ReadHistogram & "_" & Me.HistogramAdressArray(IndexRow)

                    Return adressCode

                Else Return Nothing
                End If

            Case Else
                Return Nothing


        End Select


    End Function

    Public Function DEC_to_HEX(Dec As Long) As String
        Dim a As String
        DEC_to_HEX = ""
        Do While Dec > 0
            a = CStr(Dec Mod 16)
            Select Case a
                Case "10" : a = "A"
                Case "11" : a = "B"
                Case "12" : a = "C"
                Case "13" : a = "D"
                Case "14" : a = "E"
                Case "15" : a = "F"
            End Select
            DEC_to_HEX = a & DEC_to_HEX
            Dec = Dec / 16

        Loop

        Return DEC_to_HEX
    End Function
    Public Function GetACT2ToolCommand_Read(NamePara As String) As String

        If Me.ParametersList.Count = 0 Then
            Return Nothing
        End If
        For Each item As ParameterProperty In ParametersList
            If item.Name = NamePara Then
                Dim command As String = item.Adress & "_01_0" & item.Length & "_00_00_00_00"
                Return command.Trim


            End If
        Next
        Return Nothing


    End Function

    Public Function GetACT2ToolCommand_ReadbyPara(Para As ParameterProperty) As String



        Dim command As String = Para.Adress & "_01_0" & Para.Length & "_00_00_00_00"
        Return command.Trim





    End Function

    Public Function GetACT2ToolCommand_Write(NamePara As String, data As String) As String

        If Me.ParametersList.Count = 0 Then
            Return Nothing
        End If

        If data.Split("_").Length <> 4 Then

            Return Nothing

        End If

        For Each item As ParameterProperty In ParametersList
            If item.Name = NamePara Then
                Dim command As String = item.Adress & "_00_0" & item.Length & "_" & data
                Return command.Trim

            End If
        Next
        Return Nothing
    End Function

    Public Function GetACT2ToolCommandWriteByPara(para As ParameterProperty) As String


        Dim command As String = para.Adress & "_00_0" & para.Length & "_" & para.ValueToWrite
        Return command.Trim


    End Function

    Public Function GetACT2ToolCommand_Unlock(NamePara As String) As String

        If Me.ParametersList.Count = 0 Then
            Return Nothing
        End If
        For Each item As ParameterProperty In ParametersList
            If item.Name = NamePara Then
                Dim command As String = item.Adress & "_52_0" & item.Length & "_" & item.AccessKey & "_00_00"
                Return command.Trim


            End If
        Next
        Return Nothing



    End Function



    Public Function GetACT2ToolCommand_UnlockByPara(para As ParameterProperty) As String


        Dim command As String = para.Adress & "_52_0" & para.Length & "_" & para.AccessKey & "_00_00"
        Return command.Trim


    End Function






End Class
