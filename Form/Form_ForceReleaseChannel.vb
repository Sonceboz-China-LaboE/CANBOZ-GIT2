'
' Created by SharpDevelop.
' User: lzh
' Date: 8/7/2018
' Time: 12:40 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports Peak.Can.Basic
Imports TPCANHandle = System.UInt16
Imports TPCANBitrateFD = System.String
Imports TPCANTimestampFD = System.UInt64
<Serializable()> Public Partial Class Form_ForceReleaseChannel
	
	Private m_HandlesArray As TPCANHandle()
	
	Private m_HandleOccupied As TPCANHandle
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		UpdateListBox()
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Public Sub UpdateListBox()
		
		 Dim iBuffer As UInt32
        Dim stsResult As TPCANStatus
      
		
		 m_HandlesArray = New TPCANHandle() {PCANBasic.PCAN_USBBUS1, PCANBasic.PCAN_USBBUS2, PCANBasic.PCAN_USBBUS3, PCANBasic.PCAN_USBBUS4, PCANBasic.PCAN_USBBUS5, PCANBasic.PCAN_USBBUS6, _
         PCANBasic.PCAN_USBBUS7, PCANBasic.PCAN_USBBUS8, PCANBasic.PCAN_USBBUS9, PCANBasic.PCAN_USBBUS10, PCANBasic.PCAN_USBBUS11, PCANBasic.PCAN_USBBUS12, _
         PCANBasic.PCAN_USBBUS13, PCANBasic.PCAN_USBBUS14, PCANBasic.PCAN_USBBUS15, PCANBasic.PCAN_USBBUS16}
		 
		 Me.listBox1.Items.Clear()
        Try
            For i As Integer = 0 To m_HandlesArray.Length - 1
               
                    ' Checks for a Plug&Play Handle and, according with the return value, includes it
                    ' into the list of available hardware channels.
                    '
                     listBox1.Items.Add(FormatChannelName(m_HandlesArray(i)))
                    stsResult = PCANBasic.GetValue(m_HandlesArray(i), TPCANParameter.PCAN_CHANNEL_CONDITION, iBuffer, CType(System.Runtime.InteropServices.Marshal.SizeOf(iBuffer), UInteger))
                   
                
            Next
            listBox1.SelectedIndex = listBox1.Items.Count - 1
        Catch ex As DllNotFoundException
            MessageBox.Show("Unable to find the library: PCANBasic.dll !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End Try
	End Sub
	
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




    'Sub Button1Click(sender As Object, e As EventArgs) Handles button1.Click
    '    For i As Integer = 0 To m_HandlesArray.Length - 1
    '        Dim stsResult As TPCANStatus
    '        ' Checks for a Plug&Play Handle and, according with the return value, includes it
    '        ' into the list of available hardware channels.
    '        stsResult = PCANBasic.Uninitialize(m_HandlesArray(i))


    '    Next



    'End Sub
End Class
