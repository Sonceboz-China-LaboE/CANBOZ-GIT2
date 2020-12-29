Imports Peak.Can.Basic
Imports TPCANHandle = System.UInt16
Imports TPCANBitrateFD = System.String
Imports TPCANTimestampFD = System.UInt64

<Serializable()> Public Class MessageStatus
    Private m_Msg As TPCANMsgFD
    Private m_TimeStamp As TPCANTimestampFD
    Private m_oldTimeStamp As TPCANTimestampFD
    Private m_iIndex As Integer
    Private m_Count As Integer
    Private m_bShowPeriod As Boolean
    Public m_bWasChanged As Boolean

    Public Sub New(ByVal canMsg As TPCANMsgFD, ByVal canTimestamp As TPCANTimestampFD, ByVal listIndex As Integer)
        m_Msg = canMsg
        m_TimeStamp = canTimestamp
        m_oldTimeStamp = canTimestamp
        m_iIndex = listIndex
        m_Count = 1
        m_bShowPeriod = True
        m_bWasChanged = False

    End Sub

    Public Sub Update(ByVal canMsg As TPCANMsgFD, ByVal canTimestamp As TPCANTimestampFD)
        m_Msg = canMsg
        m_oldTimeStamp = m_TimeStamp
        m_TimeStamp = canTimestamp
        m_bWasChanged = True
        m_Count += 1
    End Sub

    Private Function GetMsgTypeString() As String
        Dim strTemp As String

        If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_STATUS) = TPCANMessageType.PCAN_MESSAGE_STATUS Then
            Return "STATUS"
        End If

        If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_ERRFRAME) = TPCANMessageType.PCAN_MESSAGE_ERRFRAME Then
            Return "ERROR"
        End If

        If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_EXTENDED) = TPCANMessageType.PCAN_MESSAGE_EXTENDED Then
            strTemp = "EXT"
        Else
            strTemp = "STD"
        End If

        If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_RTR) = TPCANMessageType.PCAN_MESSAGE_RTR Then
            strTemp += "/RTR"
        Else
            If (m_Msg.MSGTYPE > TPCANMessageType.PCAN_MESSAGE_EXTENDED) Then
                strTemp += " [ "
                If ((m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_FD) = TPCANMessageType.PCAN_MESSAGE_FD) Then
                    strTemp += " FD"
                End If
                If ((m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_BRS) = TPCANMessageType.PCAN_MESSAGE_BRS) Then
                    strTemp += " BRS"
                End If
                If ((m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_ESI) = TPCANMessageType.PCAN_MESSAGE_ESI) Then
                    strTemp += " ESI"
                End If
                strTemp += " ]"
            End If
        End If

        Return strTemp
    End Function

    Private Function GetIdString() As String
        If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_EXTENDED) = TPCANMessageType.PCAN_MESSAGE_EXTENDED Then
            Return String.Format("{0:X8}h", m_Msg.ID)
        Else
            Return String.Format("{0:X3}h", m_Msg.ID)
        End If
    End Function

    Private Function GetDataString() As String
        Dim strTemp As String

        strTemp = ""

        If (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_RTR) = TPCANMessageType.PCAN_MESSAGE_RTR Then
            strTemp = "Remote Request"
        Else
            For i As Integer = 0 To Form1.GetLengthFromDLC(m_Msg.DLC, (m_Msg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_FD) = 0) - 1
                strTemp += String.Format("{0:X2} ", m_Msg.DATA(i))
            Next
        End If

        Return strTemp
    End Function

    Private Function GetTimeString() As String
        Dim fTime As Double

        fTime = (m_TimeStamp / 1000.0R)
        If m_bShowPeriod Then
            fTime -= (m_oldTimeStamp / 1000.0R)
        End If

        Return fTime.ToString("F1")
    End Function

    Public ReadOnly Property CANMsg() As TPCANMsgFD
        Get
            Return m_Msg
        End Get
    End Property

    Public ReadOnly Property Timestamp() As TPCANTimestampFD
        Get
            Return m_TimeStamp
        End Get
    End Property

    Public ReadOnly Property Position() As Integer
        Get
            Return m_iIndex
        End Get
    End Property

    Public ReadOnly Property TypeString() As String
        Get
            Return GetMsgTypeString()
        End Get
    End Property

    Public ReadOnly Property IdString() As String
        Get
            Return GetIdString()
        End Get
    End Property

    Public ReadOnly Property DataString() As String
        Get
            Return GetDataString()
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return m_Count
        End Get
    End Property

    Public Property ShowingPeriod() As Boolean
        Get
            Return m_bShowPeriod
        End Get
        Set(ByVal value As Boolean)
            If m_bShowPeriod Xor value Then
                m_bShowPeriod = value
                m_bWasChanged = True
            End If
        End Set
    End Property

    Public Property MarkedAsUpdated() As Boolean
        Get
            Return m_bWasChanged
        End Get
        Set(ByVal value As Boolean)
            m_bWasChanged = value
        End Set
    End Property

    Public ReadOnly Property TimeString() As String
        Get
            Return GetTimeString()
        End Get
    End Property
End Class

