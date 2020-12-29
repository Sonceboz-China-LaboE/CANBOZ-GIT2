Imports Peak.Can.Basic

<Serializable()> Public Class MsgContainer

    Public Enum TypeRequest As Integer
        ACTCommand = 0

        ACT2TOOL = 1

        Undefined = -1
    End Enum
    Public CANMsg As TPCANMsg
    Public ID As String
    Public is_Cyclycal As Boolean = False

    Public MsgBady As String

    Public BodyLen As Integer

    Public Interval As Integer

    Public myCAN_Matrix As CAN_Matrix

    Public Function getRequestType(ID As String) As TypeRequest

        ID = ID.Replace("h", " ")
        ID = ID.TrimEnd()
        If ID = myCAN_Matrix.Actuator_Command Then
            Return TypeRequest.ACTCommand

        ElseIf ID = myCAN_Matrix.ActuatorToTool Then
            Return TypeRequest.ACT2TOOL
        Else
            Return TypeRequest.Undefined
        End If
    End Function



    Public Sub New(Id As String, Data As String, DataLen As Integer, myCANMatrix As CAN_Matrix)
        Me.ID = Id
        Me.MsgBady = Data
        Me.is_Cyclycal = False
        Me.BodyLen = DataLen
        UpdateCanMsg()

        Me.myCAN_Matrix = myCANMatrix
    End Sub

    Public Sub New(Id As String, Data As String, DataLen As Integer, isCyc As Boolean, intervallYY As Integer, myCANMatrix As CAN_Matrix)
        Me.ID = Id
        Me.MsgBady = Data
        Me.is_Cyclycal = isCyc
        Me.Interval = intervallYY
        Me.BodyLen = DataLen
        UpdateCanMsg()
        Me.myCAN_Matrix = myCANMatrix
    End Sub


    Public Sub UpdateCanMsg()
        CANMsg = New TPCANMsg()
        CANMsg.DATA = CType(Array.CreateInstance(GetType(Byte), 8), Byte())
        CANMsg.ID = Convert.ToInt32(Me.ID, 16)
        CANMsg.LEN = Convert.ToByte(BodyLen)

        CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_EXTENDED
        Dim index = 0


        For I As Integer = 0 To CANMsg.LEN - 1

            CANMsg.DATA(I) = Convert.ToByte(MsgBady.Substring(index, 2), 16)
            index = index + 2
        Next

    End Sub



End Class
