Imports System.Text

' Inclusion of PEAK PCAN-Basic namespace
'
Imports Peak.Can.Basic
Imports TPCANHandle = System.UInt16
Imports TPCANBitrateFD = System.String
Imports TPCANTimestampFD = System.UInt64
Imports System.Threading
Imports System.IO
Imports Microsoft.Office.Interop

Public Class Form1

    Public Sub New()
        ' Initializes Form's component
        '
        InitializeComponent()
        ' Initializes specific components
        initializeDataBase()
        InitializeBasicComponents()
        MainForm = Me

    End Sub



    Public Enum ReadRequestInGUI As Integer
        ComputedStroke = 0
        FixedSpan = 1
        Config_CAN_Learn_CMD = 2
    End Enum

    Public ReadRequestName As String() = {"EE_COMPUTEDSTROKE", "EE_ FIXEDSPAN", "EE_CONFIG_CAN_LEARN_CMD"}



#Region "Delegates"
    ''' <summary>
    ''' Read-Delegate Handler
    ''' </summary>
    Private Delegate Sub ReadDelegateHandler()
#End Region

#Region "Members"
    ''' <summary>
    ''' Saves the desired connection mode
    ''' </summary>
    Public MainForm As Form1

    Public MarcoPaola As New MacroPalo
    Private m_IsFD As Boolean
    ''' <summary>
    ''' Saves the handle of a PCAN hardware
    ''' </summary>
    Private m_PcanHandle As TPCANHandle
    ''' <summary>
    ''' Saves the baudrate register for a conenction
    ''' </summary>
    Private m_Baudrate As TPCANBaudrate
    ''' <summary>
    ''' Saves the type of a non-plug-and-play hardware
    ''' </summary>
    Private m_HwType As TPCANType
    ''' <summary>
    ''' Stores the status of received messages for its display
    ''' </summary>
    Public m_LastMsgsList As System.Collections.ArrayList
    ''' <summary>
    ''' Read Delegate for calling the function "ReadMessages"
    ''' </summary>
    Private m_ReadDelegate As ReadDelegateHandler
    ''' <summary>
    ''' Receive-Event
    ''' </summary>
    Private m_ReceiveEvent As System.Threading.AutoResetEvent
    ''' <summary>
    ''' Thread for message reading (using events)
    ''' </summary>
    Public m_ReadThread As System.Threading.Thread

    Public m_SendTread As Thread
    ''' <summary>
    ''' Handles of the current available PCAN-Hardware
    ''' </summary>
    Private m_HandlesArray As TPCANHandle()


    Private m_isCyclycal As Boolean

    Public m_FeedBackResults As FeedbackResults


    Public m_CANMatrix As CAN_Matrix

    Public ConnectionStatus As Boolean = False

    Public DiagScrptingMonitro As Form_commandScripting

    Public IsSriptForceStopped As Boolean = True
    Public m_SWversionInACT As String
    Public m_SerialNumberInACT As String
    Public m_IsCANMAXGood As Boolean = False

    Public m_MyCanMaxFromImport As Object


    Public ParameterChangeringLogs As New ParamterLogList

    Public m_TimeSincePowerOn As String
    Public m_TimesPowerOn As String

    Public CANBOZ_Config As New ConfigOfCANBOZ

    Public isCommucationStopped As Boolean = False

    Public CurrentACT_Property As New ActutatorProperties

    Public Property TimeSincePowerOn As String
        Get
            Return m_TimeSincePowerOn
        End Get
        Set(value As String)
            m_TimeSincePowerOn = value

        End Set
    End Property


    Public Property TimesPowerOn As String
        Get
            Return m_TimesPowerOn
        End Get
        Set(value As String)
            m_TimesPowerOn = value

        End Set
    End Property


    Public Property SWVersionInACT As String
        Get
            Return m_SWversionInACT
        End Get
        Set(value As String)
            m_SWversionInACT = value
            Me.ToolStripStatusLabelSWVersion.Text = "* SW Version: " & value

        End Set
    End Property

    Public Property SerialNumberInACT As String
        Get
            Return m_SerialNumberInACT
        End Get
        Set(value As String)
            m_SerialNumberInACT = value
            Me.ToolStripStatusLabelSeralNumber.Text = "* Serial Number: " & value

        End Set
    End Property


    Public Property IsCANMAXGood As Boolean
        Get
            Return m_IsCANMAXGood
        End Get
        Set(value As Boolean)
            m_IsCANMAXGood = value

            If value Then
                Me.ToolStripStatusLabelCANMAXGood.BackColor = Color.GreenYellow
                Me.ToolStripStatusLabelCANMAXGood.Text = "CANMAX MATCH"

            Else
                Me.ToolStripStatusLabelCANMAXGood.BackColor = Color.Yellow
                Me.ToolStripStatusLabelCANMAXGood.Text = "CANMAX NOT MATCH"
            End If

        End Set
    End Property

#End Region

#Region "Methods"

#Region "UI Handler"

    Public Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
        Dim stsResult As TPCANStatus

        ' Connects a selected PCAN-Basic channel
        '

        stsResult = PCANBasic.Initialize(m_PcanHandle, m_Baudrate)


        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then

            If stsResult <> TPCANStatus.PCAN_ERROR_CAUTION Then


                MessageBox.Show(GetFormatedError(stsResult))
            Else
                IncludeTextMessage("******************************************************")
                IncludeTextMessage("The bitrate being used is different than the given one")
                IncludeTextMessage("******************************************************")
                stsResult = TPCANStatus.PCAN_ERROR_OK
            End If

        Else
            ' Prepares the PCAN-Basic's PCAN-Trace file
            '
            ConfigureTraceFile()
        End If

        ' Sets the connection status of the main-form
        '
        Me.ConnectionStatus = (stsResult = TPCANStatus.PCAN_ERROR_OK)
        SetConnectionStatus(stsResult = TPCANStatus.PCAN_ERROR_OK)
    End Sub

    Private Sub cbbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbChannel.SelectedIndexChanged
        Dim bNonPnP As Boolean
        Dim strTemp As String

        ' Get the handle fromt he text being shown
        strTemp = cbbChannel.Text
        If strTemp = "" Then
            Exit Sub
        End If
        strTemp = strTemp.Substring(strTemp.IndexOf("("c) + 1, 3)

        strTemp = strTemp.Replace("h", " ").Trim(" ")

        ' Determines if the handle belong to a No Plug&Play hardware 
        '
        m_PcanHandle = Convert.ToUInt16(strTemp, 16)
        bNonPnP = m_PcanHandle <= PCANBasic.PCAN_DNGBUS1

        ' Activates/deactivates configuration controls according with the 
        ' kind of hardware
        '

    End Sub

    Private Sub btnHwRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHwRefresh.Click
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus
        Dim isFD As Boolean

        ' Clears the Channel combioBox and fill it againa with 
        ' the PCAN-Basic handles for no-Plug&Play hardware and
        ' the detected Plug&Play hardware
        '
        cbbChannel.Items.Clear()
        Try
            For i As Integer = 0 To m_HandlesArray.Length - 1
                ' Includes all no-Plug&Play Handles
                If m_HandlesArray(i) <= PCANBasic.PCAN_DNGBUS1 Then
                    cbbChannel.Items.Add(FormatChannelName(m_HandlesArray(i)))
                Else
                    ' Checks for a Plug&Play Handle and, according with the return value, includes it
                    ' into the list of available hardware channels.
                    '

                    stsResult = PCANBasic.GetValue(m_HandlesArray(i), TPCANParameter.PCAN_CHANNEL_CONDITION, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                    If (stsResult = TPCANStatus.PCAN_ERROR_OK) AndAlso ((iBuffer And PCANBasic.PCAN_CHANNEL_AVAILABLE) = PCANBasic.PCAN_CHANNEL_AVAILABLE) Then
                        stsResult = PCANBasic.GetValue(m_HandlesArray(i), TPCANParameter.PCAN_CHANNEL_FEATURES, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                        isFD = (stsResult = TPCANStatus.PCAN_ERROR_OK) And ((iBuffer And PCANBasic.FEATURE_FD_CAPABLE) = PCANBasic.FEATURE_FD_CAPABLE)
                        cbbChannel.Items.Add(FormatChannelName(m_HandlesArray(i), isFD))
                    End If


                End If
            Next
            If cbbChannel.Items.Count = 0 Then
                cbbChannel.Items.Add(FormatChannelName(m_HandlesArray(0)))
            End If
            cbbChannel.SelectedIndex = cbbChannel.Items.Count - 1
        Catch ex As DllNotFoundException
            MessageBox.Show("Unable to find the library: PCANBasic.dll !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End Try

    End Sub

    Private Sub cbbBaudrates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbBaudrates.SelectedIndexChanged
        ' Saves the current selected baudrate register code
        '
        Select Case cbbBaudrates.SelectedIndex
            Case 0
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_1M
                Exit Select
            Case 1
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_800K
                Exit Select
            Case 2
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_500K
                Exit Select
            Case 3
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_250K
                Exit Select
            Case 4
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_125K
                Exit Select
            Case 5
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_100K
                Exit Select
            Case 6
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_95K
                Exit Select
            Case 7
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_83K
                Exit Select
            Case 8
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_50K
                Exit Select
            Case 9
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_47K
                Exit Select
            Case 10
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_33K
                Exit Select
            Case 11
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_20K
                Exit Select
            Case 12
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_10K
                Exit Select
            Case 13
                m_Baudrate = TPCANBaudrate.PCAN_BAUD_5K
                Exit Select
        End Select
    End Sub

    Public Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        ' Releases a current connected PCAN-Basic channel
        '
        PCANBasic.Uninitialize(m_PcanHandle)
        tmrRead.Enabled = False
        If m_ReadThread IsNot Nothing Then
            m_ReadThread.Abort()
            m_ReadThread.Join()
            m_ReadThread = Nothing
        End If

        ' Sets the connection status of the main-form
        '
        Me.ConnectionStatus = False
        SetConnectionStatus(False)

    End Sub

    Private Sub chbFilterExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFilterExt.CheckedChanged
        Dim iMaxValue As Integer

        iMaxValue = If((chbFilterExt.Checked), &H1FFFFFFF, &H7FF)

        ' We check that the maximum value for a selected filter 
        ' mode is used
        '
        If nudIdTo.Value > iMaxValue Then
            nudIdTo.Value = iMaxValue
        End If
        nudIdTo.Maximum = iMaxValue

        If (nudIdFrom.Value > iMaxValue) Then
            nudIdFrom.Value = iMaxValue
        End If
        nudIdFrom.Maximum = iMaxValue
    End Sub

    Private Sub btnFilterApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterApply.Click
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        ' Gets the current status of the message filter
        '
        If Not GetFilterStatus(iBuffer) Then
            Return
        End If

        ' Configures the message filter for a custom range of messages
        '
        If rdbFilterCustom.Checked Then
            ' Sets the custom filter
            '
            stsResult = PCANBasic.FilterMessages(m_PcanHandle, Convert.ToUInt32(nudIdFrom.Value), Convert.ToUInt32(nudIdTo.Value), If(chbFilterExt.Checked, TPCANMode.PCAN_MODE_EXTENDED, TPCANMode.PCAN_MODE_STANDARD))
            ' If success, an information message is written, if it is not, an error message is shown
            '
            If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                IncludeTextMessage(String.Format("The filter was customized. IDs from {0:X} to {1:X} will be received", nudIdFrom.Text, nudIdTo.Text))
            Else
                MessageBox.Show(GetFormatedError(stsResult))
            End If

            Return
        End If

        ' The filter will be full opened or complete closed
        '
        If rdbFilterClose.Checked Then
            iBuffer = PCANBasic.PCAN_FILTER_CLOSE
        Else
            iBuffer = PCANBasic.PCAN_FILTER_OPEN
        End If

        ' The filter is configured
        '
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_MESSAGE_FILTER, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))

        ' If success, an information message is written, if it is not, an error message is shown
        '
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage(String.Format("The filter was successfully {0}", If(rdbFilterClose.Checked, "closed.", "opened.")))
        Else
            MessageBox.Show(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub btnFilterQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterQuery.Click
        Dim iBuffer As UInt32

        ' Queries the current status of the message filter
        '
        If GetFilterStatus(iBuffer) Then
            Select Case iBuffer
                ' The filter is closed
                '
                Case PCANBasic.PCAN_FILTER_CLOSE
                    IncludeTextMessage("The Status of the filter is: closed.")
                    Exit Select
                    ' The filter is fully opened
                    '
                Case PCANBasic.PCAN_FILTER_OPEN
                    IncludeTextMessage("The Status of the filter is: full opened.")
                    Exit Select
                    ' The filter is customized
                    '
                Case PCANBasic.PCAN_FILTER_CUSTOM
                    IncludeTextMessage("The Status of the filter is: customized.")
                    Exit Select
                Case Else
                    ' The status of the filter is undefined. (Should never happen)
                    '
                    IncludeTextMessage("The Status of the filter is: Invalid.")
                    Exit Select
            End Select
        End If
    End Sub






    Private Sub rdbTimer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTimer.CheckedChanged, rdbManual.CheckedChanged, rdbEvent.CheckedChanged
        ''Checks Form Initialization is complete 
        '      If Not isFormInitCompleted Then
        '           Return
        '        End If

        If Not btnRelease.Enabled Then
            Return
        End If

        ' According with the kind of reading, a timer, a thread or a button will be enabled
        '
        If rdbTimer.Checked Then
            ' Abort Read Thread if it exists
            '
            If m_ReadThread IsNot Nothing Then
                m_ReadThread.Abort()
                m_ReadThread.Join()
                m_ReadThread = Nothing
            End If

            ' Enable Timer
            '
            tmrRead.Enabled = btnRelease.Enabled
        End If
        If rdbEvent.Checked Then
            ' Disable Timer
            '
            tmrRead.Enabled = False
            ' Create and start the tread to read CAN Message using SetRcvEvent()
            '
            Dim threadDelegate As New System.Threading.ThreadStart(AddressOf Me.CANReadThreadFunc)
            m_ReadThread = New System.Threading.Thread(threadDelegate)
            m_ReadThread.IsBackground = True
            m_ReadThread.Start()
        End If
        If rdbManual.Checked Then
            ' Abort Read Thread if it exists
            '
            If m_ReadThread IsNot Nothing Then
                m_ReadThread.Abort()
                m_ReadThread.Join()
                m_ReadThread = Nothing
            End If
            ' Disable Timer
            '
            tmrRead.Enabled = False
            btnRead.Enabled = btnRelease.Enabled AndAlso rdbManual.Checked
        End If
    End Sub

    Private Sub chbShowPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbShowPeriod.CheckedChanged
        ' According with the check-value of this checkbox,
        ' the recieved time of a messages will be interpreted as 
        ' period (time between the two last messages) or as time-stamp
        ' (the elapsed time since windows was started)
        '
        SyncLock m_LastMsgsList.SyncRoot
            For Each msg As MessageStatus In m_LastMsgsList
                msg.ShowingPeriod = chbShowPeriod.Checked
            Next
        End SyncLock
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        Dim stsResult As TPCANStatus

        ' We execute the "Read" function of the PCANBasic                
        '
        stsResult = If(m_IsFD, ReadMessageFD(), ReadMessage())
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            ' If an error occurred, an information message is included
            '
            IncludeTextMessage(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub btnMsgClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMsgClear.Click
        ' The information contained in the messages List-View
        ' is cleared
        '
        SyncLock m_LastMsgsList.SyncRoot
            lstMessages.Items.Clear()
            m_LastMsgsList.Clear()
        End SyncLock
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress, txtData7.KeyPress, txtData6.KeyPress, txtData5.KeyPress, txtData4.KeyPress, txtData3.KeyPress, txtData2.KeyPress, txtData1.KeyPress, txtData0.KeyPress
        Dim chCheck As Int16

        ' We convert the Character to its Upper case equivalent
        '
        chCheck = Microsoft.VisualBasic.Asc(e.KeyChar.ToString().ToUpper())

        ' The Key is the Delete (Backspace) Key
        '
        If chCheck = 8 Then
            Return
        End If
        ' The Key is a number between 0-9
        '
        If (chCheck > 47) AndAlso (chCheck < 58) Then
            Return
        End If
        ' The Key is a character between A-F
        '
        If (chCheck > 64) AndAlso (chCheck < 71) Then
            Return
        End If

        ' Is neither a number nor a character between A(a) and F(f)
        '
        e.Handled = True

    End Sub

    Private Sub txtID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.Leave
        Dim iTextLength As Integer
        Dim uiMaxValue As UInteger

        ' Calculates the text length and Maximum ID value according
        ' with the Message Type
        '
        iTextLength = If((chbExtended.Checked), 8, 3)
        uiMaxValue = If((chbExtended.Checked), CUInt(&H1FFFFFFF), CUInt(&H7FF))

        ' The Textbox for the ID is represented with 3 characters for 
        ' Standard and 8 characters for extended messages.
        ' Therefore if the Length of the text is smaller than TextLength,  
        ' we add "0"
        '
        While txtID.Text.Length <> iTextLength
            txtID.Text = ("0" & txtID.Text)
        End While

        ' We check that the ID is not bigger than current maximum value
        '
        If Convert.ToUInt32(txtID.Text, 16) > uiMaxValue Then
            txtID.Text = String.Format("{0:X" & iTextLength.ToString() & "}", uiMaxValue)
        End If
    End Sub

    Private Sub chbExtended_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbExtended.CheckedChanged
        Dim uiTemp As UInteger

        txtID.MaxLength = If((chbExtended.Checked), 8, 3)

        ' the only way that the text length can be bigger als MaxLength
        ' is when the change is from Extended to Standard message Type.
        ' We have to handle this and set an ID not bigger than the Maximum
        ' ID value for a Standard Message (0x7FF)
        '
        If txtID.Text.Length > txtID.MaxLength Then
            uiTemp = Convert.ToUInt32(txtID.Text, 16)
            txtID.Text = If((uiTemp < &H7FF), String.Format("{0:X3}", uiTemp), "7FF")
        End If

        txtID_Leave(Me, New EventArgs())
    End Sub



    Private Sub txtData0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtData7.Leave, txtData6.Leave, txtData5.Leave, txtData4.Leave, txtData3.Leave, txtData2.Leave, txtData1.Leave, txtData0.Leave
        Dim txtbCurrentTextbox As TextBox

        ' all the Textbox Data fields are represented with 2 characters.
        ' Therefore if the Length of the text is smaller than 2, we add
        ' a "0"
        '
        If sender.[GetType]().Name = "TextBox" Then
            txtbCurrentTextbox = DirectCast(sender, TextBox)
            While txtbCurrentTextbox.Text.Length <> 2
                txtbCurrentTextbox.Text = ("0" & txtbCurrentTextbox.Text)
            End While
        End If
    End Sub

    Private Function WriteFrame(Msg As Object)


        Try

            Dim MsgBody As MsgContainer = TryCast(Msg, MsgContainer)

            ' We get so much data as the Len of the message
            '
            'For I As Integer = 0 To GetLengthFromDLC(CANMsg.LEN, True) - 1
            'txtbCurrentTextBox = DirectCast(Me.Controls.Find("txtData" + I.ToString(), True)(0), TextBox)
            'CANMsg.DATA(I) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
            'Next

            If MsgBody.is_Cyclycal Then
                Do
                    Thread.Sleep(MsgBody.Interval)

                    PCANBasic.Write(m_PcanHandle, MsgBody.CANMsg)


                Loop Until PCANBasic.Write(m_PcanHandle, MsgBody.CANMsg) <> TPCANStatus.PCAN_ERROR_OK And Me.m_isCyclycal <> True
                Return TPCANStatus.PCAN_ERROR_OK

            End If

            ' The message is sent to the configured hardware
            '
            Return PCANBasic.Write(m_PcanHandle, MsgBody.CANMsg)
            'If (stsresult = TPCANStatus.PCAN_ERROR_OK) Then
            'IncludeTextMessage("message was successfully sent")
            'Else
            ' an error occurred.  we show the error.
            '
            'MessageBox.Show(GetFormatedError(stsresult))
            'End If

        Catch ex As Exception
            Return TPCANStatus.PCAN_ERROR_UNKNOWN
        End Try

    End Function

    Private Function WriteFrameSpecial(Msg As Object)


        Try

            Dim MsgBody As MsgContainer = TryCast(Msg, MsgContainer)

            ' We get so much data as the Len of the message
            '
            'For I As Integer = 0 To GetLengthFromDLC(CANMsg.LEN, True) - 1
            'txtbCurrentTextBox = DirectCast(Me.Controls.Find("txtData" + I.ToString(), True)(0), TextBox)
            'CANMsg.DATA(I) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
            'Next

            If MsgBody.is_Cyclycal Then
                Do


                    Thread.Sleep(MsgBody.Interval)

                    PCANBasic.Write(m_PcanHandle, MsgBody.CANMsg)



                Loop Until PCANBasic.Write(m_PcanHandle, MsgBody.CANMsg) <> TPCANStatus.PCAN_ERROR_OK


            End If

            ' The message is sent to the configured hardware
            '
            Return PCANBasic.Write(m_PcanHandle, MsgBody.CANMsg)
            'If (stsresult = TPCANStatus.PCAN_ERROR_OK) Then
            'IncludeTextMessage("message was successfully sent")
            'Else
            ' an error occurred.  we show the error.
            '
            'MessageBox.Show(GetFormatedError(stsresult))
            'End If

        Catch ex As Exception
            Return TPCANStatus.PCAN_ERROR_UNKNOWN
        End Try

    End Function

    'Public Sub WriteFrameWithPara(ID As String, len As Int32, isExtend As Boolean, data As String, is_cyclic As Boolean, interval As Integer)
    '    Dim CANMsg As TPCANMsg


    '    ' We create a TPCANMsg message structure 
    '    '
    '    CANMsg = New TPCANMsg()
    '    CANMsg.DATA = CType(Array.CreateInstance(GetType(Byte), 8), Byte())

    '    ' We configurate the Message.  The ID,
    '    ' Length of the Data, Message Type
    '    ' and die data
    '    '
    '    CANMsg.ID = Convert.ToInt32(ID, 16)
    '    CANMsg.LEN = Convert.ToByte(len)
    '    CANMsg.MSGTYPE = If(isExtend, TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)
    '    ' If a remote frame will be sent, the data bytes are not important.
    '    '

    '    ' We get so much data as the Len of the message
    '    '
    '    Dim datas As String() = data.Split("_")
    '    For I As Integer = 0 To GetLengthFromDLC(CANMsg.LEN, True) - 1


    '        Dim strTemps As String = datas(I)

    '        CANMsg.DATA(I) = Convert.ToByte(datas(I), 16)


    '    Next
    '    If is_cyclic Then
    '        Do
    '            Thread.Sleep(interval)
    '            PCANBasic.Write(m_PcanHandle, CANMsg)
    '        Loop Until PCANBasic.Write(m_PcanHandle, CANMsg) <> TPCANStatus.PCAN_ERROR_OK And Me.m_isCyclycal <> True

    '    End If


    '    ' The message is sent to the configured hardware
    '    '

    'End Sub

    Private Function WriteFrameFD()
        Dim CANMsg As TPCANMsgFD
        Dim txtbCurrentTextBox As TextBox
        Dim iLength As Integer

        ' We create a TPCANMsg message structure 
        '
        CANMsg = New TPCANMsgFD()
        CANMsg.DATA = CType(Array.CreateInstance(GetType(Byte), 64), Byte())

        ' We configurate the Message.  The ID,
        ' Length of the Data, Message Type
        ' and die data
        '
        CANMsg.ID = Convert.ToInt32(txtID.Text, 16)
        CANMsg.DLC = Convert.ToByte(nudLength.Value)
        CANMsg.MSGTYPE = If(chbExtended.Checked, TPCANMessageType.PCAN_MESSAGE_EXTENDED, TPCANMessageType.PCAN_MESSAGE_STANDARD)


        ' If a remote frame will be sent, the data bytes are not important.
        '

        ' We get so much data as the Len of the message
        '
        iLength = GetLengthFromDLC(CANMsg.DLC, (CANMsg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_FD) = 0)
        For I As Integer = 0 To iLength - 1
            txtbCurrentTextBox = DirectCast(Me.Controls.Find("txtData" + I.ToString(), True)(0), TextBox)
            CANMsg.DATA(I) = Convert.ToByte(txtbCurrentTextBox.Text, 16)
        Next



        ' The message is sent to the configured hardware
        '
        Return PCANBasic.WriteFD(m_PcanHandle, CANMsg)
    End Function

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click

        Dim timeIntervall As Integer
        Dim txtbCurrentTextBox As TextBox
        Try

            timeIntervall = CInt(Me.tetBoxCycleTime.Text)
        Catch ex As Exception

            timeIntervall = 0

        End Try

        If m_SendTread IsNot Nothing Then
            m_SendTread.Abort()
        End If

        If Me.m_isCyclycal And timeIntervall <> 0 Then

            Dim dataString As String = ""
            For I As Integer = 0 To CInt(nudLength.Text) - 1
                txtbCurrentTextBox = DirectCast(Me.Controls.Find("txtData" + I.ToString(), True)(0), TextBox)
                dataString = dataString & txtbCurrentTextBox.Text

            Next

            Dim MyMsg As New MsgContainer(Me.txtID.Text, dataString, CInt(nudLength.Text), m_isCyclycal, timeIntervall, m_CANMatrix)

            m_SendTread = New Thread(AddressOf WriteFrame)
            m_SendTread.Start(MyMsg)
            Me.btnWrite.Enabled = False
            Me.ButtonStopCyclic.Enabled = True
            Me.checkBox1.Enabled = False
            Me.tetBoxCycleTime.Enabled = False
        Else

            Dim dataString As String = ""
            For I As Integer = 0 To CInt(nudLength.Text) - 1
                txtbCurrentTextBox = DirectCast(Me.Controls.Find("txtData" + I.ToString(), True)(0), TextBox)
                dataString = dataString & txtbCurrentTextBox.Text

            Next

            Dim MyMsg As New MsgContainer(Me.txtID.Text, dataString, CInt(nudLength.Text), m_CANMatrix)

            m_SendTread = New Thread(AddressOf WriteFrame)
            m_SendTread.Start(MyMsg)



            ' The message was successfully sent
        End If

    End Sub

    Private Sub btnGetVersions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetVersions.Click
        Dim stsResult As TPCANStatus
        Dim strTemp As StringBuilder
        Dim strArrayVersion As String()

        strTemp = New StringBuilder(256)

        ' We get the vesion of the PCAN-Basic API
        '
        stsResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_API_VERSION, strTemp, 256)
        If stsResult = TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage("API Version: " & strTemp.ToString())
            ' We get the driver version of the channel being used
            '
            stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_CHANNEL_VERSION, strTemp, 256)
            If stsResult = TPCANStatus.PCAN_ERROR_OK Then
                ' Because this information contains line control characters (several lines)
                ' we split this also in several entries in the Information List-Box
                '
                strArrayVersion = strTemp.ToString().Split(New Char() {ControlChars.Lf})
                IncludeTextMessage("Channel/Driver Version: ")
                For i As Integer = 0 To strArrayVersion.Length - 1
                    IncludeTextMessage("     * " & strArrayVersion(i))
                Next
            End If
        End If

        ' If an error ccurred, a message is shown
        '
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
        End If
    End Sub

    Private Sub btnInfoClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoClear.Click
        ' The information contained in the Information List-Box 
        ' is cleared
        lbxInfo.Items.Clear()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Releases the used PCAN-Basic channel
        '
        If (btnRelease.Enabled) Then
            btnRelease_Click(Me, New EventArgs())
        End If
    End Sub

    Private Sub tmrRead_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRead.Tick
        '' Checks if in the receive-queue are currently messages for read
        ReadMessages()

    End Sub

    Private Sub tmrDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDisplay.Tick

        DisplayMessages()
        UpdateFeedbackUIs()
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nudLength.Value = 8
        chbShowPeriod.Checked = True

        rdbTimer.Checked = True
        rdbFilterOpen.Checked = True
    End Sub

    Private Sub lstMessages_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMessages.DoubleClick
        ' Clears the content of the Message List-View
        '
        btnMsgClear_Click(Me, New EventArgs())
    End Sub

    Private Sub lbxInfo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxInfo.Click
        ' Clears the content of the Information List-Box
        '
        btnInfoClear_Click(Me, New EventArgs())
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim stsResult As TPCANStatus

        ' Resets the receive and transmit queues of a PCAN Channel.
        '
        stsResult = PCANBasic.Reset(m_PcanHandle)

        ' If it fails, a error message is shown
        '
        If (stsResult <> TPCANStatus.PCAN_ERROR_OK) Then
            MessageBox.Show(GetFormatedError(stsResult))
        Else
            IncludeTextMessage("Receive and transmit queues successfully reset")
        End If

    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim stsResult As TPCANStatus
        Dim errorName As String

        ' Gets the current BUS status of a PCAN Channel.
        '
        stsResult = PCANBasic.GetStatus(m_PcanHandle)

        ' Switch On Error Name
        '
        Select Case stsResult
            Case TPCANStatus.PCAN_ERROR_INITIALIZE
                errorName = "PCAN_ERROR_INITIALIZE"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_BUSLIGHT
                errorName = "PCAN_ERROR_BUSLIGHT"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_BUSHEAVY ' TPCANStatus.PCAN_ERROR_BUSWARNING
                errorName = If(m_IsFD, "PCAN_ERROR_BUSWARNING", "PCAN_ERROR_BUSHEAVY")
                Exit Select

            Case TPCANStatus.PCAN_ERROR_BUSPASSIVE
                errorName = "PCAN_ERROR_BUSPASSIVE"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_BUSOFF
                errorName = "PCAN_ERROR_BUSOFF"
                Exit Select

            Case TPCANStatus.PCAN_ERROR_OK
                errorName = "PCAN_ERROR_OK"
                Exit Select
            Case Else
                errorName = "See Documentation"
                Exit Select
        End Select

        ' Display Message
        '
        IncludeTextMessage(String.Format("Status: {0} ({1:X}h)", errorName, stsResult))
    End Sub

    Private Sub nudLength_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLength.ValueChanged
        Dim txtbCurrentTextBox As TextBox
        Dim iLength As Integer

        txtbCurrentTextBox = txtData0
        iLength = GetLengthFromDLC(nudLength.Value, True)
        laLength.Text = String.Format("{0} B.", iLength)

        For i As Integer = 0 To 8
            txtbCurrentTextBox.Enabled = i <= iLength
            If (i < 8) Then
                txtbCurrentTextBox = DirectCast(Me.Controls.Find("txtData" + i.ToString(), True)(0), TextBox)
            End If
        Next
    End Sub




#End Region

#Region "Help functions"
    ''' <summary>
    ''' Convert a CAN DLC value into the actual data length of the CAN/CAN-FD frame.
    ''' </summary>
    ''' <param name="dlc">A value between 0 and 15 (CAN and FD DLC range)</param>
    ''' <param name="isSTD">A value indicating if the msg is a standard CAN (FD Flag not checked)</param>
    ''' <returns>The length represented by the DLC</returns>
    Public Shared Function GetLengthFromDLC(ByVal dlc As Integer, ByVal isSTD As Boolean)
        If dlc <= 8 Then
            Return dlc
        End If

        If (isSTD) Then
            Return 8
        End If

        Select Case dlc
            Case 9
                Return 12
            Case 10
                Return 16
            Case 11
                Return 20
            Case 12
                Return 24
            Case 13
                Return 32
            Case 14
                Return 48
            Case 15
                Return 64
            Case Else
                Return dlc
        End Select
    End Function

    ''' <summary>
    ''' Initialization of PCAN-Basic components
    ''' </summary>
    ''' 
    Private Sub initializeDataBase()
        m_CANMatrix = New CAN_Matrix
        m_FeedBackResults = New FeedbackResults(m_CANMatrix)

    End Sub
    Public Sub InitializeBasicComponents()
        ' Creates the list for received messages
        '
        m_LastMsgsList = New System.Collections.ArrayList()
        ' Creates the delegate used for message reading
        '
        m_ReadDelegate = New ReadDelegateHandler(AddressOf ReadMessages)
        ' Creates the event used for signalize incomming messages 
        '
        m_ReceiveEvent = New System.Threading.AutoResetEvent(False)
        ' Creates an array with all possible PCAN-Channels
        '
        m_HandlesArray = New TPCANHandle() {PCANBasic.PCAN_USBBUS1, PCANBasic.PCAN_USBBUS2, PCANBasic.PCAN_USBBUS3, PCANBasic.PCAN_USBBUS4, PCANBasic.PCAN_USBBUS5, PCANBasic.PCAN_USBBUS6,
         PCANBasic.PCAN_USBBUS7, PCANBasic.PCAN_USBBUS8, PCANBasic.PCAN_USBBUS9, PCANBasic.PCAN_USBBUS10, PCANBasic.PCAN_USBBUS11, PCANBasic.PCAN_USBBUS12,
         PCANBasic.PCAN_USBBUS13, PCANBasic.PCAN_USBBUS14, PCANBasic.PCAN_USBBUS15, PCANBasic.PCAN_USBBUS16}

        ' Fills and configures the Data of several comboBox components
        '
        FillComboBoxData()
        Me.chbExtended.Checked = True

        Me.treeView1.Nodes(0).Nodes.Clear()
        For Each a In m_FeedBackResults.StatusList
            Me.treeView1.Nodes(0).Nodes.Add(a)
        Next

        Me.treeView1.Nodes(1).Nodes.Clear()
        For Each b In m_FeedBackResults.ErrorsList
            Me.treeView1.Nodes(1).Nodes.Add(b)
        Next
        Me.treeView1.ExpandAll()

        Me.ButtonStopCyclic.Enabled = False

        Me.txtID.Text = Me.m_CANMatrix.Actuator_Command
        Me.txtData2.Text = "01"
        Me.txtData3.Text = "FF"
        Me.txtData4.Text = "FF"
        Me.txtData5.Text = "FF"
        Me.txtData6.Text = "FF"
        Me.txtData7.Text = "FF"


        Me.SetConnectionStatus(False)
        ' Prepares the PCAN-Basic's debug-Log file

        ConfigureLogFile()

        Me.TreeViewCommands.Nodes.Clear()

        For Each NameKey In m_CANMatrix.ACT_CommandDict.Keys
            Me.TreeViewCommands.Nodes.Add(NameKey)
        Next
        Me.TreeViewCommands.Nodes.Add("Calibration")

        Try
            If Not Directory.Exists("CANMAX Library") Then
                Directory.CreateDirectory("CANMAX Library")
            End If

            Dim CANMM As CANMAX = New CANMAX(m_CANMatrix, m_FeedBackResults, Me)

            Dim NameFile As String = m_CANMatrix.ClientName & "_" & m_CANMatrix.OMEName & "_" & m_CANMatrix.ApplicationName & "_" & m_CANMatrix.SWVersion & "_" & "TCI_" & m_CANMatrix.TCIVersion

            Me.MarcoPaola.ExportFileInfixedLocation("CANMAX", "CANMAX Library", CANMM, NameFile)
        Catch ex As Exception
            MsgBox("CANMAX Library can not be created, Failure of system access")
        End Try

        Try
            If Not Directory.Exists("Log") Then
                Directory.CreateDirectory("Log")


                Try
                    Dim NameFile As String = m_CANMatrix.ClientName & "_" & m_CANMatrix.OMEName & "_" & m_CANMatrix.ApplicationName & "_" & m_CANMatrix.SWVersion & "_" & "TCI_" & m_CANMatrix.TCIVersion
                    Me.MarcoPaola.ExportFileInfixedLocation("paralist", "Log", Me.m_CANMatrix.ParametersList, NameFile)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else
                If IO.Directory.GetFiles("Log", "*.paralog").Length <> 0 Then
                    Dim fileinfo As IO.FileInfo = New IO.FileInfo(IO.Directory.GetFiles("Log", "*.paralog")(0))



                    Try
                        MarcoPaola.ImportFileFromFixedLocation(fileinfo.FullName, ParameterChangeringLogs)
                        ParameterChangeringLogs.isUpdated = False

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

                Try
                    Dim NameFile As String = m_CANMatrix.ClientName & "_" & m_CANMatrix.OMEName & "_" & m_CANMatrix.ApplicationName & "_" & m_CANMatrix.SWVersion & "_" & "TCI_" & m_CANMatrix.TCIVersion
                    Me.MarcoPaola.ExportFileInfixedLocation("paralist", "Log", Me.m_CANMatrix.ParametersList, NameFile)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            End If


        Catch ex As Exception
            MsgBox("Log can not be created, Failure of system access")
        End Try


    End Sub

    ''' <summary>
    ''' Configures the Debug-Log file of PCAN-Basic
    ''' </summary>
    Private Sub ConfigureLogFile()
        Dim iBuffer As UInt32

        ' Sets the mask to catch all events
        '
        iBuffer = PCANBasic.LOG_FUNCTION_ALL

        ' Configures the log file. 
        ' NOTE: The Log capability is to be used with the NONEBUS Handle. Other handle than this will 
        ' cause the function fail.
        '
        PCANBasic.SetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_CONFIGURE, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
    End Sub

    ''' <summary>
    ''' Configures the Debug-Log file of PCAN-Basic
    ''' </summary>
    Private Sub ConfigureTraceFile()
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        ' Configure the maximum size of a trace file to 5 megabytes
        '
        iBuffer = 5
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage(GetFormatedError(stsResult))
        End If

        ' Configure the way how trace files are created: 
        ' * Standard name is used
        ' * Existing file is ovewritten,
        ' * Only one file is created.
        ' * Recording stopts when the file size reaches 5 megabytes.
        '
        iBuffer = PCANBasic.TRACE_FILE_SINGLE Or PCANBasic.TRACE_FILE_OVERWRITE
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            IncludeTextMessage(GetFormatedError(stsResult))
        End If
    End Sub

    ''' <summary>
    ''' Help Function used to get an error as text
    ''' </summary>
    ''' <param name="error">Error code to be translated</param>
    ''' <returns>A text with the translated error</returns>
    Private Function GetFormatedError(ByVal [error] As TPCANStatus) As String
        Dim strTemp As StringBuilder

        ' Creates a buffer big enough for a error-text
        '
        strTemp = New StringBuilder(256)
        ' Gets the text using the GetErrorText API function
        ' If the function success, the translated error is returned. If it fails,
        ' a text describing the current error is returned.
        '
        If PCANBasic.GetErrorText([error], 0, strTemp) <> TPCANStatus.PCAN_ERROR_OK Then
            Return String.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", [error])
        Else
            Return strTemp.ToString()
        End If
    End Function

    ''' <summary>
    ''' Includes a new line of text into the information Listview
    ''' </summary>
    ''' <param name="strMsg">Text to be included</param>
    Private Sub IncludeTextMessage(ByVal strMsg As String)
        lbxInfo.Items.Add(strMsg)
        lbxInfo.SelectedIndex = lbxInfo.Items.Count - 1
    End Sub

    ''' <summary>
    ''' Gets the current status of the PCAN-Basic message filter
    ''' </summary>
    ''' <param name="status">Buffer to retrieve the filter status</param>
    ''' <returns>If calling the function was successfull or not</returns>
    Private Function GetFilterStatus(ByRef status As UInteger) As Boolean
        Dim stsResult As TPCANStatus

        ' Tries to get the sttaus of the filter for the current connected hardware
        '
        stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_MESSAGE_FILTER, status, CType(System.Runtime.InteropServices.Marshal.SizeOf(status), UInteger))

        ' If it fails, a error message is shown
        '
        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult))
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Configures the data of all ComboBox components of the main-form
    ''' </summary>
    Private Sub FillComboBoxData()
        ' Channels will be check
        '
        btnHwRefresh_Click(Me, New EventArgs())

        ' FD Bitrate: 
        '      Arbitration: 1 Mbit/sec 
        '      Data: 2 Mbit/sec
        '
        '        txtBitrate.Text = "f_clock_mhz=20, nom_brp=5, nom_tseg1=2, nom_tseg2=1, nom_sjw=1, data_brp=2, data_tseg1=3, data_tseg2=1, data_sjw=1"

        ' Baudrates 
        '
        cbbBaudrates.SelectedIndex = 3 ' 500 K
        ' Hardware Type for no plugAndplay hardware
        '
        '        cbbHwType.SelectedIndex = 0
        '
        '        ' Interrupt for no plugAndplay hardware
        '        '
        '        cbbInterrupt.SelectedIndex = 0
        '
        '        ' IO Port for no plugAndplay hardware
        '        '
        '        cbbIO.SelectedIndex = 0
        '
        '        ' Parameters for GetValue and SetValue function calls
        '        '
        '        cbbParameter.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Activates/deaactivates the different controls of the main-form according
    ''' with the current connection status
    ''' </summary>
    ''' <param name="bConnected">Current status. True if connected, false otherwise</param>
    Private Sub SetConnectionStatus(ByVal bConnected As Boolean)
        ' Buttons
        '
        btnInit.Enabled = Not bConnected
        btnRead.Enabled = bConnected AndAlso rdbManual.Checked
        btnWrite.Enabled = bConnected
        btnRelease.Enabled = bConnected
        btnFilterApply.Enabled = bConnected
        btnFilterQuery.Enabled = bConnected
        btnGetVersions.Enabled = bConnected
        btnHwRefresh.Enabled = Not bConnected
        btnStatus.Enabled = bConnected
        btnReset.Enabled = bConnected

        ' ComboBoxs
        '
        cbbBaudrates.Enabled = Not bConnected
        cbbChannel.Enabled = Not bConnected
        ' Hardware configuration and read mode
        '
        If Not bConnected Then
            cbbChannel_SelectedIndexChanged(Me, New EventArgs())
        Else
            rdbTimer_CheckedChanged(Me, New EventArgs())
        End If

        ' Display messages in grid
        '
        tmrDisplay.Enabled = bConnected

        timerLogging.Enabled = bConnected

        If bConnected Then
            timerLogging.Start()
        Else
            timerLogging.Stop()
        End If




        If bConnected Then
            Me.label_connectStatus.Text = "Connected"
            Me.label_connectStatus.BackColor = Color.YellowGreen

            Me.ToolStripStatusLabelProjectInfo.Text = Me.m_CANMatrix.ClientName & "-" & Me.m_CANMatrix.ApplicationName & "-" & Me.m_CANMatrix.OMEName

            '
            If m_SendTread IsNot Nothing Then
                m_SendTread.Abort()
                m_SendTread.Join()
                m_SendTread = Nothing

            End If


            m_SendTread = New Thread(AddressOf SpecificCommandReadSequence)
            m_SendTread.Start()
            Me.TextBoxLog.Text = "Welcome to CANBOZ"


        Else

            Me.label_connectStatus.Text = "No Connection"
            Me.label_connectStatus.BackColor = Color.Red

            '
            Me.ToolStripStatusLabelSWVersion.Text = "* SW version: Not Connected"
            Me.ToolStripStatusLabelSeralNumber.Text = "* Serial Number: Not Connected"
            Me.ToolStripStatusLabelCANMAXGood.BackColor = Color.Red
            Me.ToolStripStatusLabelCANMAXGood.Text = "No Connection"
            Me.ToolStripStatusLabelProjectInfo.Text = ""

        End If


        For Each CON As Control In Me.groupBox3.Controls
            CON.Enabled = bConnected

        Next

        For Each CON As Control In Me.groupBox5.Controls
            CON.Enabled = bConnected

        Next
        For Each CON As Control In Me.groupBox6.Controls
            CON.Enabled = bConnected

        Next

        For Each CON As Control In Me.splitContainer1.Controls
            CON.Enabled = bConnected

        Next




    End Sub

    ''' <summary>
    ''' Gets the formated text for a CPAN-Basic channel handle
    ''' </summary>
    ''' <param name="handle">PCAN-Basic Handle to format</param>
    ''' <param name="isFD">If the channel is FD capable</param>
    ''' <returns>The formatted text for a channel</returns>
    Private Function FormatChannelName(ByVal handle As TPCANHandle, ByVal isFD As Boolean) As String
        Dim devDevice As TPCANDevice
        Dim byChannel As Byte

        ' Gets the owner device and channel for a 
        ' PCAN-Basic handle
        '
        If CType(handle, UShort) < &H100 Then
            devDevice = DirectCast(CType(handle >> 4, Byte), TPCANDevice)
            byChannel = CByte((handle And &HF))
        Else
            devDevice = DirectCast(CType(handle >> 8, Byte), TPCANDevice)
            byChannel = CByte((handle And &HFF))
        End If

        ' Constructs the PCAN-Basic Channel name and return it
        '
        If (isFD) Then
            Return String.Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle)
        Else
            Return String.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle)
        End If
    End Function

    ''' <summary>
    ''' Gets the formated text for a CPAN-Basic channel handle
    ''' </summary>
    ''' <param name="handle">PCAN-Basic Handle to format</param>
    ''' <returns>The formatted text for a channel</returns>
    Private Function FormatChannelName(ByVal handle As TPCANHandle) As String
        Return FormatChannelName(handle, False)
    End Function
#End Region

#Region "Message-proccessing functions"
    ''' <summary>
    ''' Display CAN messages in the Message-ListView
    ''' </summary>
    Private Sub DisplayMessages()
        Dim lviCurrentItem As ListViewItem

        SyncLock m_LastMsgsList.SyncRoot
            For Each msgStatus As MessageStatus In m_LastMsgsList
                ' Get the data to actualize
                '
                '                If msgStatus.MarkedAsUpdated Then
                '                    msgStatus.MarkedAsUpdated = False

                lviCurrentItem = lstMessages.Items(msgStatus.Position)

                lviCurrentItem.SubItems(2).Text = GetLengthFromDLC(msgStatus.CANMsg.DLC, (msgStatus.CANMsg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_FD) = 0).ToString()
                lviCurrentItem.SubItems(3).Text = msgStatus.Count.ToString()
                lviCurrentItem.SubItems(4).Text = msgStatus.TimeString
                lviCurrentItem.SubItems(5).Text = msgStatus.DataString
                '                End If
            Next
        End SyncLock



        Me.Text = "CANBOZ  (" & " Time since Power ON : " & m_TimeSincePowerOn & " h   ,  " & "Amount of Power on times : " & m_TimesPowerOn & " )"

    End Sub

    ''' <summary>
    ''' Inserts a new entry for a new message in the Message-ListView
    ''' </summary>
    ''' <param name="newMsg">The messasge to be inserted</param>
    ''' <param name="timeStamp">The Timesamp of the new message</param>
    Private Sub InsertMsgEntry(ByVal newMsg As TPCANMsgFD, ByVal timeStamp As TPCANTimestampFD)
        Dim lviCurrentItem As ListViewItem
        Dim msgStsCurrentMsg As MessageStatus

        SyncLock m_LastMsgsList.SyncRoot
            ' We add this status in the last message list
            '
            msgStsCurrentMsg = New MessageStatus(newMsg, timeStamp, lstMessages.Items.Count)
            msgStsCurrentMsg.ShowingPeriod = chbShowPeriod.Checked

            m_LastMsgsList.Add(msgStsCurrentMsg)

            m_FeedBackResults.ReadResults(msgStsCurrentMsg)
            ' Add the new ListView Item with the Type of the message
            '	
            Dim TypeStr As String = m_FeedBackResults.getFeedBackTypeStr(msgStsCurrentMsg.IdString)

            lviCurrentItem = lstMessages.Items.Add(TypeStr)

            lviCurrentItem.BackColor = m_FeedBackResults.getFeedBackTypeColor(msgStsCurrentMsg.IdString)
            ' We set the ID of the message
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.IdString)
            ' We set the length of the Message
            '
            lviCurrentItem.SubItems.Add(GetLengthFromDLC(newMsg.DLC, (newMsg.MSGTYPE And TPCANMessageType.PCAN_MESSAGE_FD) = 0).ToString())
            ' we set the message count message (this is the First, so count is 1)            
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.Count.ToString())
            ' Add time stamp information if needed
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.TimeString)
            ' We set the data of the message. 	
            '
            lviCurrentItem.SubItems.Add(msgStsCurrentMsg.DataString)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Processes a received message, in order to show it in the Message-ListView
    ''' </summary>
    ''' <param name="theMsg">The received PCAN-Basic message</param>
    ''' <param name="itsTimeStamp">The Timestamp of the received message</param>
    Private Sub ProcessMessage(ByVal theMsg As TPCANMsgFD, ByVal itsTimeStamp As TPCANTimestampFD)
        ' We search if a message (Same ID and Type) is 
        ' already received or if this is a new message
        '
        SyncLock m_LastMsgsList.SyncRoot
            For Each msg As MessageStatus In m_LastMsgsList
                If (msg.CANMsg.ID = theMsg.ID) And (msg.CANMsg.MSGTYPE = theMsg.MSGTYPE) Then
                    ' Messages of this kind are already received; we do an update
                    '

                    msg.Update(theMsg, itsTimeStamp)
                    msg.MarkedAsUpdated = True
                    m_FeedBackResults.ReadResults(msg)
                    Exit Sub
                End If
            Next

            ' Message not found. It will created
            '
            InsertMsgEntry(theMsg, itsTimeStamp)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Processes a received message, in order to show it in the Message-ListView
    ''' </summary>
    ''' <param name="theMsg">The received PCAN-Basic message</param>
    ''' <param name="itsTimeStamp">The Timestamp of the received message</param>
    Private Sub ProcessMessage(ByVal theMsg As TPCANMsg, ByVal itsTimeStamp As TPCANTimestamp)
        Dim newMsg As TPCANMsgFD
        Dim newTimestamp As TPCANTimestampFD

        newMsg = New TPCANMsgFD()
        newMsg.DATA = CType(Array.CreateInstance(GetType(Byte), 64), Byte())
        newMsg.ID = theMsg.ID
        newMsg.DLC = theMsg.LEN
        For i As Integer = 0 To If(theMsg.LEN > 8, 7, theMsg.LEN - 1)
            newMsg.DATA(i) = theMsg.DATA(i)
        Next
        newMsg.MSGTYPE = theMsg.MSGTYPE

        newTimestamp = Convert.ToUInt64(itsTimeStamp.micros + 1000 * itsTimeStamp.millis + &H100000000 * 1000 * itsTimeStamp.millis_overflow)
        ProcessMessage(newMsg, newTimestamp)
    End Sub

    ''' <summary>
    ''' Thread-Function used for reading PCAN-Basic messages
    ''' </summary>
    Private Sub CANReadThreadFunc()
        Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus

        iBuffer = Convert.ToUInt32(m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32())
        ' Sets the handle of the Receive-Event.
        '
        stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))

        If stsResult <> TPCANStatus.PCAN_ERROR_OK Then
            MessageBox.Show(GetFormatedError(stsResult), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' While this mode is selected
        While rdbEvent.Checked
            ' Waiting for Receive-Event
            ' 
            If m_ReceiveEvent.WaitOne(50) Then
                ' Process Receive-Event using .NET Invoke function
                ' in order to interact with Winforms UI (calling the 
                ' function ReadMessages)
                ' 
                Me.Invoke(m_ReadDelegate)
            End If
        End While
    End Sub

    ''' <summary>
    ''' Function for reading messages on FD devices
    ''' </summary>
    ''' <returns>A TPCANStatus error code</returns>
    Private Function ReadMessageFD() As TPCANStatus
        Dim CANMsg As TPCANMsgFD = Nothing
        Dim CANTimeStamp As TPCANTimestampFD
        Dim stsResult As TPCANStatus

        ' We execute the "Read" function of the PCANBasic 
        '
        stsResult = PCANBasic.ReadFD(m_PcanHandle, CANMsg, CANTimeStamp)
        If (stsResult <> TPCANStatus.PCAN_ERROR_QRCVEMPTY) Then
            ' We process the received message
            '
            ProcessMessage(CANMsg, CANTimeStamp)
        End If

        Return stsResult
    End Function

    ''' <summary>
    ''' Function for reading CAN messages on normal CAN devices
    ''' </summary>
    ''' <returns>A TPCANStatus error code</returns>
    Private Function ReadMessage() As TPCANStatus
        Dim CANMsg As TPCANMsg = Nothing
        Dim CANTimeStamp As TPCANTimestamp
        Dim stsResult As TPCANStatus

        ' We execute the "Read" function of the PCANBasic 
        '
        stsResult = PCANBasic.Read(m_PcanHandle, CANMsg, CANTimeStamp)
        If (stsResult <> TPCANStatus.PCAN_ERROR_QRCVEMPTY) Then
            ' We process the received message
            '

            ProcessMessage(CANMsg, CANTimeStamp)

        End If

        Return stsResult
    End Function

    ''' <summary>
    ''' Function for reading PCAN-Basic messages
    ''' </summary>
    Private Sub ReadMessages()
        Dim stsResult As TPCANStatus

        ' We read at least one time the queue looking for messages.
        ' If a message is found, we look again trying to find more.
        ' If the queue is empty or an error occurr, we get out from
        ' the dowhile statement.
        '			
        Do
            ' We execute the "Read" or "ReadFD" function of the PCANBasic
            '
            stsResult = ReadMessage()

            If (stsResult = TPCANStatus.PCAN_ERROR_ILLOPERATION) Then
                Exit Do
            End If

        Loop While btnRelease.Enabled AndAlso (Not Convert.ToBoolean(stsResult And TPCANStatus.PCAN_ERROR_QRCVEMPTY))


    End Sub
#End Region

#End Region



    Sub CheckBox1CheckedChanged(sender As Object, e As EventArgs) Handles checkBox1.CheckedChanged
        Me.m_isCyclycal = Me.checkBox1.Checked

        Me.tetBoxCycleTime.Enabled = Me.m_isCyclycal

        Me.ButtonStopCyclic.Enabled = Me.m_isCyclycal

    End Sub



    Sub TetBoxCycleTimeKeyPress(sender As Object, e As KeyPressEventArgs) Handles tetBoxCycleTime.KeyPress
        Dim chCheck As Int16

        ' We convert the Character to its Upper case equivalent
        '
        chCheck = Microsoft.VisualBasic.Asc(e.KeyChar.ToString().ToUpper())

        ' The Key is the Delete (Backspace) Key
        '
        If chCheck = 8 Then
            Me.tetBoxCycleTime.BackColor = Color.White
            Return

        End If
        ' The Key is a number between 0-9
        '
        If (chCheck > 47) AndAlso (chCheck < 58) Then
            Me.tetBoxCycleTime.BackColor = Color.White
            Return
        End If
        ' The Key is a character between A-F
        '


        ' Is neither a number nor a character between A(a) and F(f)
        Me.tetBoxCycleTime.BackColor = Color.Yellow
        e.Handled = True

    End Sub

    Public Sub ReadValue(typeRead1 As String)

        Dim Request As String = m_CANMatrix.GetACT2ToolCommand_Read(typeRead1)

        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub

    Public Sub ReadValueByPara(para As ParameterProperty)

        Dim Request As String = m_CANMatrix.GetACT2ToolCommand_ReadbyPara(para)

        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub


    Public Sub ReadValueInEEPROM(Para As Integer, IndexRow As Integer, Optional IndexColum As Integer = 0, Optional RingBufferZone As Integer = 0)

        Dim Request As String = m_CANMatrix.GetReadEEPROMCommand(Para, IndexRow, IndexColum, RingBufferZone)

        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub

    Public Sub UnlockValue(typeRead As String)

        Dim Request As String = m_CANMatrix.GetACT2ToolCommand_Unlock(typeRead)

        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub

    Public Sub UnlockValueByPara(para As ParameterProperty)

        Dim Request As String = m_CANMatrix.GetACT2ToolCommand_UnlockByPara(para)

        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub

    Public Sub WriteValue(typeRead As String, data As String)

        Dim Request As String = m_CANMatrix.GetACT2ToolCommand_Write(typeRead, data)

        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub

    Public Sub WriteValueByPara(para As ParameterProperty)

        Dim Request As String = m_CANMatrix.GetACT2ToolCommandWriteByPara(para)


        If Request IsNot Nothing Then
            Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

            WriteFrame(MyMsg)
        End If

    End Sub

    Sub SendResquest(typeRequest As String)
        If m_SendTread IsNot Nothing Then
            m_SendTread.Abort()
            m_SendTread.Join()
            m_SendTread = Nothing

        End If

        Try
            If typeRequest = m_CANMatrix.ListOfCommandName(0) Then 'Position

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)
                Dim PositionArray As String() = PositionRequest.Split("_")

                Dim a As String
                Dim Postionbyte As Int32 = Convert.ToInt32(Me.trackBarPosition.Value * 10, 16)

                a = String.Format("{0:X4}", Me.trackBarPosition.Value * 10)

                PositionArray(0) = a.Substring(2, 2)
                PositionArray(1) = a.Substring(0, 2)

                PositionRequest = String.Join("_", PositionArray)


                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)
            ElseIf typeRequest = m_CANMatrix.ListOfCommandName(1) Then ' Learn

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)

                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)
                ' The message was successfully sen

            ElseIf typeRequest = m_CANMatrix.ListOfCommandName(2) Then ' Self-Calibration

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)
                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)

            ElseIf typeRequest = m_CANMatrix.ListOfCommandName(3) Then 'Wiping Cycle"

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)

                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)

            ElseIf typeRequest = m_CANMatrix.ListOfCommandName(5) Then 'Override

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)

                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)

            ElseIf typeRequest = m_CANMatrix.ListOfCommandName(4) Then 'Electrical failsafe

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)

                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)

            ElseIf typeRequest = m_CANMatrix.ListOfCommandName(6) Then 'Electrical failsafe then override

                Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(typeRequest)

                Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)

                m_SendTread = New Thread(AddressOf WriteFrame)
                m_SendTread.Start(MyMsg)

            End If

        Catch ex As Exception
            MsgBox("Error apears, please contact SW supplier", MsgBoxStyle.OkOnly, "Errors")

        End Try





    End Sub



    Sub SendPositionResquest(targetPostion As Integer)
        If m_SendTread IsNot Nothing Then
            m_SendTread.Abort()
            m_SendTread.Join()
            m_SendTread = Nothing
        End If


        Dim PositionRequest As String = m_CANMatrix.ACT_CommandDict.Item(m_CANMatrix.ListOfCommandName(0))
        Dim PositionArray As String() = PositionRequest.Split("_")

        Dim a As String


        Dim Postionbyte As Int32 = Convert.ToInt32(targetPostion * 10, 16)

        a = String.Format("{0:X4}", targetPostion * 10)

        PositionArray(0) = a.Substring(2, 2)
        PositionArray(1) = a.Substring(0, 2)

        PositionRequest = String.Join("_", PositionArray)


        Dim MyMsg As New MsgContainer(m_CANMatrix.Actuator_Command, PositionRequest.Replace("_", ""), 8, True, m_CANMatrix.CycleTimeMs, m_CANMatrix)


        'WriteFrame(MyMsg)
        m_SendTread = New Thread(AddressOf WriteFrameSpecial)
        m_SendTread.Start(MyMsg)




    End Sub

    'Sub TimerFeedbackTick(sender As Object, e As EventArgs) Handles timerFeedback.Tick
    '    Dim ListTemp As ArrayList = m_LastMsgsList


    '    SyncLock ListTemp.SyncRoot
    '        For Each msgStatus As MessageStatus In ListTemp


    '            m_FeedBackResults.ReadResults(msgStatus)


    '            '                End If
    '        Next
    '    End SyncLock


    'End Sub

    Public Sub UpdateFeedbackUIs()

        If Me.isCommucationStopped Then
            Me.buttonIsFault.BackColor = Color.Gray
            Me.buttonIsFault.Text = "No communication"
            Exit Sub
        End If

        If m_FeedBackResults.isUpdated Then
            If m_FeedBackResults.is_Error Then
                Me.buttonIsFault.BackColor = Color.Red
                Me.buttonIsFault.Text = "Fault Warning"
                Me.progressBarPositionFeedback.Value = 0
                Me.labelPostionFeedback.Text = String.Format("Position Feedback : NULL")

                Me.LabelMotorEffot.Text = "Motor Efforts：" & m_FeedBackResults.CurrentMotorEffort & "%"
                Me.LabelTemperature.Text = "Temperature: " & m_FeedBackResults.CurrentTemperature & "℃"
                For Each node As TreeNode In Me.treeView1.Nodes(0).Nodes
                    If node.Index = m_FeedBackResults.MappingStatus_Index Then
                        node.BackColor = Color.YellowGreen
                    Else
                        node.BackColor = Color.White
                    End If
                Next

                If m_FeedBackResults.FaultsColorMapping.Count = Me.treeView1.Nodes(1).Nodes.Count - 1 Then
                    For i = 0 To m_FeedBackResults.FaultsColorMapping.Count - 1
                        Me.treeView1.Nodes(1).Nodes(i).BackColor = m_FeedBackResults.FaultsColorMapping(i)
                    Next
                End If





            Else
                Me.buttonIsFault.BackColor = Color.YellowGreen
                Me.buttonIsFault.Text = "No Fault"
                Me.treeView1.Enabled = True

                Me.progressBarPositionFeedback.Value = m_FeedBackResults.PositionFeedback
                Me.labelPostionFeedback.Text = String.Format("Position Feedback : {0:D1}%", Me.progressBarPositionFeedback.Value)
                Me.LabelMotorEffot.Text = "Motor Efforts：" & m_FeedBackResults.CurrentMotorEffort & "%"

                Me.LabelTemperature.Text = "Temperature: " & m_FeedBackResults.CurrentTemperature & "℃"


                For Each node As TreeNode In Me.treeView1.Nodes(0).Nodes
                    If node.Index = m_FeedBackResults.MappingStatus_Index Then
                        node.BackColor = Color.YellowGreen
                    Else
                        node.BackColor = Color.White
                    End If
                Next

                If m_FeedBackResults.FaultsColorMapping.Count = Me.treeView1.Nodes(1).Nodes.Count - 1 Then
                    For i = 0 To m_FeedBackResults.FaultsColorMapping.Count - 1
                        Me.treeView1.Nodes(1).Nodes(i + 1).BackColor = m_FeedBackResults.FaultsColorMapping(i)
                    Next
                End If



            End If



        End If

        Try
            If Me.m_CANMatrix.SWVersion = Me.SWVersionInACT Then
                Me.IsCANMAXGood = True
            Else
                Me.IsCANMAXGood = False
            End If



        Catch ex As Exception

        End Try

    End Sub

    Sub ForceReleaseChannelToolStripMenuItemClick(sender As Object, e As EventArgs) Handles forceReleaseChannelToolStripMenuItem.Click
        Dim NewForm As New Form_keyFinder
        NewForm.UserControl_KeyFinder1.m_parent = Me
        NewForm.Show()
    End Sub

    Private Sub ButtonStopCyclic_Click(sender As Object, e As EventArgs) Handles ButtonStopCyclic.Click

        If m_SendTread IsNot Nothing Then
            m_SendTread.Abort()
        End If

        Me.btnWrite.Enabled = True
        Me.ButtonStopCyclic.Enabled = False
        Me.checkBox1.Enabled = True
        Me.tetBoxCycleTime.Enabled = True
    End Sub

    Private Sub trackBarPosition_ValueChanged(sender As Object, e As EventArgs) Handles trackBarPosition.ValueChanged
        Me.label_positionCommand.Text = String.Format("Position: {0:D1}%", Me.trackBarPosition.Value)
        'Me.SendResquest(TypeRequestInGUI.PositionCommand)

    End Sub

    Private Sub Button_GoPosition_Click(sender As Object, e As EventArgs) Handles Button_GoPosition.Click
        Me.SendResquest(m_CANMatrix.ListOfCommandName(0))
    End Sub

    Private Sub buttonLearn_Click(sender As Object, e As EventArgs)
        Me.SendResquest(m_CANMatrix.ListOfCommandName(1))
    End Sub


    Public Sub buttonCalibration_Click(sender As Object, e As EventArgs)
        'Me.SendResquest(m_CANMatrix.ListOfCommandName(2))
        Dim myThread As Thread
        myThread = New Thread(AddressOf CalibrationSequence)
        myThread.Start()



    End Sub

    Public Sub CalibrationSequence()

        Dim PositionRequest As String = m_CANMatrix.Specific_CommandDict.Item("CAN Calibration")

        Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, PositionRequest.Replace("_", ""), 8, m_CANMatrix)

        WriteFrame(MyMsg)



        PositionRequest = m_CANMatrix.Specific_CommandDict.Item("Restart Sequence")

        Dim MyMsg1 As New MsgContainer(m_CANMatrix.ToolToActuator, PositionRequest.Replace("_", ""), 8, m_CANMatrix)
        Thread.Sleep(7000)
        WriteFrame(MyMsg1)
        'myThread.Abort()
        'myThread = Nothing
        'Dim myThread2 As Thread
        ' myThread2 = New Thread(AddressOf WriteFrame)

        'myThread2.Start(MyMsg1)
        ' Do Until myThread2.ThreadState = ThreadState.Stopped

        'Loop

        'myThread2.Abort()
        ' myThread2 = Nothing
    End Sub

    Public Sub SpecificCommandReadSequence()

        Dim countTotal As Integer = 0
        Dim limite As Integer = 2000000
        Dim Request As String = m_CANMatrix.Specific_CommandDict.Item("SW Version 1")

        Dim MyMsg As New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)

        WriteFrame(MyMsg)
        countTotal = 0
        Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)
            countTotal += 1
            If countTotal >= limite Then
                Exit Sub
            End If

        Loop

        Dim SWversion1 As String = m_FeedBackResults.TrimACT2ToolMsg(4)
        Dim byte1 As String = SWversion1.Substring(0, 2)
        Dim byte2 As String = SWversion1.Substring(2, 2)
        Dim byte3 As String = SWversion1.Substring(4, 2)
        Dim byte4 As String = SWversion1.Substring(6, 2)

        SWversion1 = Chr(Convert.ToInt16(byte1, 16)) & Chr(Convert.ToInt16(byte2, 16)) & Chr(Convert.ToInt16(byte3, 16)) & Chr(Convert.ToInt16(byte4, 16))


        Request = m_CANMatrix.Specific_CommandDict.Item("SW Version 2")
        MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
        WriteFrame(MyMsg)
        countTotal = 0
        Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)

            countTotal += 1
            If countTotal >= limite Then
                Exit Sub
            End If
        Loop
        Dim SWversion2 As String = m_FeedBackResults.TrimACT2ToolMsg(4)
        byte1 = SWversion2.Substring(0, 2)
        byte2 = SWversion2.Substring(2, 2)
        byte3 = SWversion2.Substring(4, 2)
        byte4 = SWversion2.Substring(6, 2)

        SWversion2 = Chr(Convert.ToInt16(byte1, 16)) & Chr(Convert.ToInt16(byte2, 16)) & Chr(Convert.ToInt16(byte3, 16)) & Chr(Convert.ToInt16(byte4, 16))



        Request = m_CANMatrix.Specific_CommandDict.Item("SW Version 3")
        MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
        WriteFrame(MyMsg)
        countTotal = 0
        Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)
            countTotal += 1
            If countTotal >= limite Then
                Exit Sub
            End If

        Loop
        Dim SWversion3 As String = m_FeedBackResults.TrimACT2ToolMsg(4)
        byte1 = SWversion3.Substring(0, 2)
        byte2 = SWversion3.Substring(2, 2)
        byte3 = SWversion3.Substring(4, 2)
        byte4 = SWversion3.Substring(6, 2)

        SWversion3 = Chr(Convert.ToInt16(byte1, 16)) & Chr(Convert.ToInt16(byte2, 16)) & Chr(Convert.ToInt16(byte3, 16)) & Chr(Convert.ToInt16(byte4, 16))





        Me.SWVersionInACT = SWversion1 & SWversion2 & SWversion3

        Me.CurrentACT_Property.SW_Version = Me.SWVersionInACT

        Request = m_CANMatrix.Specific_CommandDict.Item("Serial Number 1")
        MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
        WriteFrame(MyMsg)
        countTotal = 0
        Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)
            countTotal += 1
            If countTotal >= limite Then
                Exit Sub
            End If

        Loop
        Dim SN1 As String = m_FeedBackResults.TrimACT2ToolMsg(4)
        byte1 = SN1.Substring(0, 2)
        byte2 = SN1.Substring(2, 2)
        byte3 = SN1.Substring(4, 2)
        byte4 = SN1.Substring(6, 2)

        SN1 = Chr(Convert.ToInt16(byte1, 16)) & Chr(Convert.ToInt16(byte2, 16)) & Chr(Convert.ToInt16(byte3, 16)) & Chr(Convert.ToInt16(byte4, 16))

        Request = m_CANMatrix.Specific_CommandDict.Item("Serial Number 2")
        MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
        WriteFrame(MyMsg)
        countTotal = 0
        Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)

            countTotal += 1
            If countTotal >= limite Then
                Exit Sub
            End If
        Loop
        Dim SN2 As String = m_FeedBackResults.TrimACT2ToolMsg(4)
        byte1 = SN2.Substring(0, 2)
        byte2 = SN2.Substring(2, 2)
        byte3 = SN2.Substring(4, 2)
        byte4 = SN2.Substring(6, 2)

        SN2 = Chr(Convert.ToInt16(byte1, 16)) & Chr(Convert.ToInt16(byte2, 16)) & Chr(Convert.ToInt16(byte3, 16)) & Chr(Convert.ToInt16(byte4, 16))

        Request = m_CANMatrix.Specific_CommandDict.Item("Serial Number 3")
        MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
        WriteFrame(MyMsg)
        countTotal = 0
        Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)
            countTotal += 1
            If countTotal >= limite Then
                Exit Sub
            End If

        Loop
        Dim SN3 As String = m_FeedBackResults.TrimACT2ToolMsg(2)
        byte1 = SN3.Substring(0, 2)
        byte2 = SN3.Substring(2, 2)


        SN3 = Chr(Convert.ToInt16(byte1, 16)) & Chr(Convert.ToInt16(byte2, 16))

        Me.SerialNumberInACT = SN1 & SN2 & SN3

        Me.CurrentACT_Property.SN = Me.SerialNumberInACT

        'Juge if CANMAX match 

        Try
            Request = m_CANMatrix.Specific_CommandDict.Item("Operating Time")
            MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
            WriteFrame(MyMsg)
            countTotal = 0
            Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)
                countTotal += 1
                If countTotal >= limite Then
                    Exit Sub
                End If

            Loop

            Dim Masg As String = m_FeedBackResults.TrimACT2ToolMsg(4)

            Me.TimeSincePowerOn = Convert.ToInt16(Masg, 16)

            Request = m_CANMatrix.Specific_CommandDict.Item("Amount of Power On")
            MyMsg = New MsgContainer(m_CANMatrix.ToolToActuator, Request.Replace("_", ""), 8, m_CANMatrix)
            WriteFrame(MyMsg)
            countTotal = 0
            Do Until m_FeedBackResults.AdressInACT2Tool = Request.Replace("_", "").Substring(0, 4)

                countTotal += 1
                If countTotal >= limite Then
                    Exit Sub
                End If
            Loop

            Dim Masg1 As String = m_FeedBackResults.TrimACT2ToolMsg(4)

            Me.TimesPowerOn = Convert.ToInt16(Masg1, 16)
        Catch ex As Exception

        End Try







    End Sub



    Private Sub buttonWiping_Click(sender As Object, e As EventArgs)
        Me.SendResquest(m_CANMatrix.ListOfCommandName(3))
    End Sub

    Private Sub buttonEFailSafe_Click(sender As Object, e As EventArgs)
        Me.SendResquest(m_CANMatrix.ListOfCommandName(4))
    End Sub

    Public Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click


        Me.ReadValue("EE_COMPUTEDSTROKE")

        Dim mythread As New Thread(AddressOf ShowReadDiag)

        mythread.Start(0)


    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click

        Me.ReadValue("EE_FIXEDSPAN")
        Dim mythread As New Thread(AddressOf ShowReadDiag)

        mythread.Start(1)

    End Sub

    Public Sub ShowReadDiag(index As Object)
        Dim indexHere As Integer = CInt(index)
        Thread.Sleep(100)
        Try
            Select Case index
                Case 0

                    Dim diag As New ValueShowerDialog(Me.ReadRequestName(index), m_FeedBackResults.TrimACT2ToolMsg(2), m_FeedBackResults.TrimACT2ToolMsgIntoInt(2) * 0.244)
                    diag.StartPosition = FormStartPosition.CenterScreen
                    diag.ShowDialog()
                Case 1
                    Dim diag As New ValueShowerDialog(Me.ReadRequestName(index), m_FeedBackResults.TrimACT2ToolMsg(2), m_FeedBackResults.TrimACT2ToolMsgIntoInt(2) * 0.244)
                    diag.StartPosition = FormStartPosition.CenterScreen
                    diag.ShowDialog()
                Case 2

                    Dim diag As New ValueShowerDialog(Me.ReadRequestName(index), m_FeedBackResults.TrimACT2ToolMsg(1), m_FeedBackResults.TrimACT2ToolMsgIntoInt(1))
                    diag.StartPosition = FormStartPosition.CenterScreen
                    diag.ShowDialog()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message,, "Error")
        End Try





    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs)
        Me.ReadValue("EE_CONFIG_CAN_LEARN_CMD")
        Dim mythread As New Thread(AddressOf ShowReadDiag)

        mythread.Start(2)
    End Sub

    Private Sub exportCANDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exportCANDescriptionToolStripMenuItem.Click
        If m_MyCanMaxFromImport Is Nothing Then
            m_MyCanMaxFromImport = New CANMAX(m_CANMatrix, m_FeedBackResults, Me)
        End If
        Me.MarcoPaola.ExportFile("CANMAX", "Sonceboz CAN Matrix File", m_MyCanMaxFromImport)


    End Sub

    Private Sub importCANDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles importCANDescriptionToolStripMenuItem.Click

        Dim Diag As New Form_LoadCANMAX(Me)

        Diag.ShowDialog()





        'Dim CanMaxFromImport = New CANMAX(m_CANMatrix, m_FeedBackResults, Me)


        'Try
        '    Me.MarcoPaola.ImportFile("CANMAX", "Sonceboz CAN Matrix File", CanMaxFromImport)

        '    m_MyCanMaxFromImport = New CANMAX(CanMaxFromImport.m_CANMatrix, CanMaxFromImport.m_FeedBack, Me)

        '    InitializeBasicComponents()
        '    Me.btnRelease_Click(Me, New EventArgs)
        '    Me.btnInit_Click(Me, New EventArgs)
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub parametersWriterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles parametersWriterToolStripMenuItem.Click
        If Not Me.CANBOZ_Config.IsForCustom Then


            Dim formPara As New ParametersModifier
            formPara.DataSouce = Me.m_CANMatrix.ParametersList

            formPara.Show()

        Else
            MsgBox("This Feature is not allowed in this release, Please contact provider to have further information", MsgBoxStyle.OkOnly, "Information")
        End If



    End Sub

    Private Sub scriptingAndMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles scriptingAndMonitorToolStripMenuItem.Click

        If Not Me.CANBOZ_Config.IsForCustom Then


            DiagScrptingMonitro = New Form_commandScripting(Me)

            DiagScrptingMonitro.Show()

        Else
            MsgBox("This Feature is not allowed in this release, Please contact provider to have further information", MsgBoxStyle.OkOnly, "Information")
        End If

    End Sub

    Private Sub softwareWriterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles softwareWriterToolStripMenuItem.Click

        If Not Me.CANBOZ_Config.IsForCustom Then


            Dim Diag As New Form_ReadinfoEPPROM
            Diag.m_parent = Me
            Diag.ShowDialog()

        Else
            MsgBox("This Feature is not allowed in this release, Please contact provider to have further information", MsgBoxStyle.OkOnly, "Information")
        End If



    End Sub

    Public tickTime = 0

    Private Sub AssemblingWizardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssemblingWizardToolStripMenuItem.Click
        If Not Me.CANBOZ_Config.IsForCustom Then



            Dim Diag As New Form_AssemblingWizard

            Diag.ShowDialog()

        Else
            MsgBox("This Feature is not allowed in this release, Please contact provider to have further information", MsgBoxStyle.OkOnly, "Information")
        End If

    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Dim text As String = "SW Version: " & Me.SWVersionInACT & Chr(13) + Chr(10) & "SN: " & Me.SerialNumberInACT
        Clipboard.SetText(text)

    End Sub

    Private Sub TreeViewCommands_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewCommands.NodeMouseDoubleClick

        If e.Node.Text = "Calibration" Then
            Me.SendResquest("Position Control")
            Dim myThread As Thread
            myThread = New Thread(AddressOf CalibrationSequence)
            myThread.Start()

        Else

            Me.SendResquest(e.Node.Text)
        End If

    End Sub

    Private Sub timerLogging_Tick(sender As Object, e As EventArgs) Handles timerLogging.Tick
        If Me.ParameterChangeringLogs.isUpdated = True Then
            Try

                Me.MarcoPaola.ExportFileInfixedLocation("paralog", "Log", Me.ParameterChangeringLogs, "Parameters_log")
                Me.ParameterChangeringLogs.isUpdated = False
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub configurateCANBusParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles configurateCANBusParametersToolStripMenuItem.Click
        Dim diag1 As New Form_CANBUS_config
        diag1.DataSource = New CANMAX(m_CANMatrix, m_FeedBackResults, Me)
        diag1.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLog.TextChanged

    End Sub

    Private Sub ChangeStepsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeStepsToolStripMenuItem.Click
        Dim diag1 As New Form_SingleParaChanger
        Dim DataS As ParameterProperty = New ParameterProperty("EE_ALLWDDIFMNSPN_Garrett 30 steps", "00_1D", "9A_E6", 1, "05")
        Me.m_CANMatrix.ParametersList.Add(DataS)
        diag1.UserControl_ParameterProperties1.m_parent = Me
        diag1.UserControl_ParameterProperties1.showAccessCode = False
        diag1.DataSource = DataS
        diag1.UserControl_ParameterProperties1.SetForceMode(True, "1E")
        diag1.ShowDialog()


        Me.m_CANMatrix.ParametersList.Remove(DataS)
    End Sub

    Private Sub AppendSWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppendSWToolStripMenuItem.Click
        Dim strArr As String()
        Dim index As Integer = 0
        Me.MarcoPaola.ReadTXTArrayInfixedLocation("Log", "SN and SW Records", strArr)
        index = strArr.Length + 1
        For Each line As String In strArr
            If line = "" Then Return
            Dim a As String() = line.Split(",")
            If Me.CurrentACT_Property.SN.Trim() = a(1).Trim Then Return


        Next

        Dim str As String = index & "," & Me.CurrentACT_Property.SN & "," & Me.CurrentACT_Property.SW_Version & "," & Today.Now

        Me.MarcoPaola.SaveToTXTInfixedLocation("Log", str, "SN and SW Records")

    End Sub

    Private Sub AppendSNOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppendSNOnlyToolStripMenuItem.Click
        Dim strArr As String()
        Dim index As Integer = 0
        Me.MarcoPaola.ReadTXTArrayInfixedLocation("Log", "SN and SW Records", strArr)
        index = strArr.Length + 1
        Dim str As String = index & "," & Me.CurrentACT_Property.SN & "," & "No SW version" & "," & Today.Now
        Me.MarcoPaola.SaveToTXTInfixedLocation("Log", str, "SN and SW Records")
        Me.TextBoxLog.AppendText("SN and SW saved")
    End Sub

    Private Sub AppendSWOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppendSWOnlyToolStripMenuItem.Click
        Dim strArr As String()
        Dim index As Integer = 0
        Me.MarcoPaola.ReadTXTArrayInfixedLocation("Log", "SN and SW Records", strArr)
        index = strArr.Length + 1
        Dim str As String = index & "," & "No SN" & "," & Me.CurrentACT_Property.SW_Version & "," & Today.Now

        Me.MarcoPaola.SaveToTXTInfixedLocation("Log", str, "SN and SW Records")
    End Sub

    Private Sub ShowSNAndSWRecordsInEXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSNAndSWRecordsInEXCELToolStripMenuItem.Click


        Dim myExcelBook As Excel.Workbook = MarcoPaola.CreatExcelBook()

        Dim mySheetRecords As Excel.Worksheet = myExcelBook.Worksheets(1)
        mySheetRecords.Name = "SN and SW records"


        Dim strArr As String()

        Me.MarcoPaola.ReadTXTArrayInfixedLocation("Log", "SN and SW Records", strArr)
        Dim index As Integer = 0

        mySheetRecords.Cells(1, 1).Value = "SN"
        mySheetRecords.Cells(1, 2).Value = "SW Version"
        mySheetRecords.Cells(1, 3).Value = "Time and Date"
        For Each line As String In strArr
            If line = "" Then Return
            Dim a As String() = line.Split(",")
            mySheetRecords.Cells(index + 2, 1).Value = a(1)

            mySheetRecords.Cells(index + 2, 2).Value = a(2)
            mySheetRecords.Cells(index + 2, 3).Value = a(3)

            index = index + 1
        Next


        ' Dim FileName = "Log" & "\" & "SN and SW records" & ".xlsx"
        ' MyExcelBook.Title = FileName
        'myExcelBook.SaveAs(FileName)



        'myExcelBook.Close()  '关闭工作簿 

        'myExcelBook = Nothing  '释放资源

        'MyExcelApp.Workbooks.Open(FileName)
        Dim n As String = MarcoPaola.SaveExcelToFixLocation("Log", "SN and SW records")
        Try
            Dim ap As New Excel.Application
            ap.Visible = True
            ap.Workbooks.Open(n)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
End Class
