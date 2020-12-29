<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Serializable()> Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Actuator Status")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EEPROM error")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Position deviation")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Others")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Over Temperature")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Calibration error: Span too big")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Calibration error: Span too small")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Learn error: Span too big")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Learn error: Span too small")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Undervoltage")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Overvoltage")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAN error")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sensor Error")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Faults", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.chbShowPeriod = New System.Windows.Forms.CheckBox()
        Me.rdbManual = New System.Windows.Forms.RadioButton()
        Me.rdbEvent = New System.Windows.Forms.RadioButton()
        Me.lstMessages = New System.Windows.Forms.ListView()
        Me.clhType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhRcvTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnMsgClear = New System.Windows.Forms.Button()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdbTimer = New System.Windows.Forms.RadioButton()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.groupBox6 = New System.Windows.Forms.GroupBox()
        Me.ButtonStopCyclic = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tetBoxCycleTime = New System.Windows.Forms.TextBox()
        Me.checkBox1 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.laLength = New System.Windows.Forms.Label()
        Me.chbExtended = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.nudLength = New System.Windows.Forms.NumericUpDown()
        Me.txtData7 = New System.Windows.Forms.TextBox()
        Me.txtData6 = New System.Windows.Forms.TextBox()
        Me.txtData5 = New System.Windows.Forms.TextBox()
        Me.txtData4 = New System.Windows.Forms.TextBox()
        Me.txtData3 = New System.Windows.Forms.TextBox()
        Me.txtData2 = New System.Windows.Forms.TextBox()
        Me.txtData1 = New System.Windows.Forms.TextBox()
        Me.txtData0 = New System.Windows.Forms.TextBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.Labeltest2 = New System.Windows.Forms.Label()
        Me.Labeltest = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.btnGetVersions = New System.Windows.Forms.Button()
        Me.lbxInfo = New System.Windows.Forms.ListBox()
        Me.btnInfoClear = New System.Windows.Forms.Button()
        Me.cbbChannel = New System.Windows.Forms.ComboBox()
        Me.btnHwRefresh = New System.Windows.Forms.Button()
        Me.btnFilterQuery = New System.Windows.Forms.Button()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.chbFilterExt = New System.Windows.Forms.CheckBox()
        Me.nudIdTo = New System.Windows.Forms.NumericUpDown()
        Me.nudIdFrom = New System.Windows.Forms.NumericUpDown()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.rdbFilterOpen = New System.Windows.Forms.RadioButton()
        Me.rdbFilterCustom = New System.Windows.Forms.RadioButton()
        Me.rdbFilterClose = New System.Windows.Forms.RadioButton()
        Me.btnFilterApply = New System.Windows.Forms.Button()
        Me.tmrRead = New System.Windows.Forms.Timer(Me.components)
        Me.cbbBaudrates = New System.Windows.Forms.ComboBox()
        Me.laBaudrate = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnInit = New System.Windows.Forms.Button()
        Me.btnRelease = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label_connectStatus = New System.Windows.Forms.Label()
        Me.tmrDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.importCANDescriptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportCANDescriptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.configurateCANBusParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.parametersWriterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.softwareWriterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.scriptingAndMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.forceReleaseChannelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssemblingWizardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeStepsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.helpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.tableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.label_positionCommand = New System.Windows.Forms.Label()
        Me.trackBarPosition = New System.Windows.Forms.TrackBar()
        Me.Button_GoPosition = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TreeViewCommands = New System.Windows.Forms.TreeView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TextBoxLog = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.labelPostionFeedback = New System.Windows.Forms.Label()
        Me.progressBarPositionFeedback = New System.Windows.Forms.ProgressBar()
        Me.buttonIsFault = New System.Windows.Forms.Button()
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelTemperature = New System.Windows.Forms.Label()
        Me.LabelMotorEffot = New System.Windows.Forms.Label()
        Me.timerLogging = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialogIMPORT = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ContextMenuStripCopyInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppendSWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppendSNOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppendSWOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSNAndSWRecordsInEXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabelSWVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelSeralNumber = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelCANMAXGood = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelProjectInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.groupBox5.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        CType(Me.nudLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.nudIdTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIdFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.tableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.trackBarPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStripCopyInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbShowPeriod
        '
        Me.chbShowPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbShowPeriod.AutoSize = True
        Me.chbShowPeriod.Location = New System.Drawing.Point(374, 15)
        Me.chbShowPeriod.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chbShowPeriod.Name = "chbShowPeriod"
        Me.chbShowPeriod.Size = New System.Drawing.Size(123, 17)
        Me.chbShowPeriod.TabIndex = 75
        Me.chbShowPeriod.Text = "Timestamp as period"
        Me.chbShowPeriod.UseVisualStyleBackColor = True
        '
        'rdbManual
        '
        Me.rdbManual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbManual.AutoSize = True
        Me.rdbManual.Location = New System.Drawing.Point(276, 14)
        Me.rdbManual.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbManual.Name = "rdbManual"
        Me.rdbManual.Size = New System.Drawing.Size(89, 17)
        Me.rdbManual.TabIndex = 74
        Me.rdbManual.Text = "Manual Read"
        Me.rdbManual.UseVisualStyleBackColor = True
        '
        'rdbEvent
        '
        Me.rdbEvent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbEvent.AutoSize = True
        Me.rdbEvent.Location = New System.Drawing.Point(131, 14)
        Me.rdbEvent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbEvent.Name = "rdbEvent"
        Me.rdbEvent.Size = New System.Drawing.Size(139, 17)
        Me.rdbEvent.TabIndex = 73
        Me.rdbEvent.Text = "Reading using an Event"
        Me.rdbEvent.UseVisualStyleBackColor = True
        '
        'lstMessages
        '
        Me.lstMessages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clhType, Me.clhID, Me.clhLength, Me.clhCount, Me.clhRcvTime, Me.clhData})
        Me.lstMessages.FullRowSelect = True
        Me.lstMessages.HideSelection = False
        Me.lstMessages.Location = New System.Drawing.Point(8, 37)
        Me.lstMessages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lstMessages.MultiSelect = False
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.Size = New System.Drawing.Size(602, 84)
        Me.lstMessages.TabIndex = 28
        Me.lstMessages.UseCompatibleStateImageBehavior = False
        Me.lstMessages.View = System.Windows.Forms.View.Details
        '
        'clhType
        '
        Me.clhType.Text = "Type"
        Me.clhType.Width = 110
        '
        'clhID
        '
        Me.clhID.Text = "ID"
        Me.clhID.Width = 90
        '
        'clhLength
        '
        Me.clhLength.Text = "Length"
        Me.clhLength.Width = 50
        '
        'clhCount
        '
        Me.clhCount.Text = "Count"
        Me.clhCount.Width = 49
        '
        'clhRcvTime
        '
        Me.clhRcvTime.Text = "Rcv Time"
        Me.clhRcvTime.Width = 70
        '
        'clhData
        '
        Me.clhData.Text = "Data"
        Me.clhData.Width = 170
        '
        'btnMsgClear
        '
        Me.btnMsgClear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMsgClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMsgClear.Location = New System.Drawing.Point(650, 87)
        Me.btnMsgClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMsgClear.Name = "btnMsgClear"
        Me.btnMsgClear.Size = New System.Drawing.Size(94, 29)
        Me.btnMsgClear.TabIndex = 50
        Me.btnMsgClear.Text = "Clear"
        Me.btnMsgClear.UseVisualStyleBackColor = True
        '
        'groupBox5
        '
        Me.groupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox5.Controls.Add(Me.chbShowPeriod)
        Me.groupBox5.Controls.Add(Me.rdbManual)
        Me.groupBox5.Controls.Add(Me.rdbEvent)
        Me.groupBox5.Controls.Add(Me.lstMessages)
        Me.groupBox5.Controls.Add(Me.btnMsgClear)
        Me.groupBox5.Controls.Add(Me.rdbTimer)
        Me.groupBox5.Controls.Add(Me.btnRead)
        Me.groupBox5.Controls.Add(Me.groupBox6)
        Me.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox5.Location = New System.Drawing.Point(5, 163)
        Me.groupBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox5.Size = New System.Drawing.Size(760, 134)
        Me.groupBox5.TabIndex = 56
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = " Messages Reading "
        '
        'rdbTimer
        '
        Me.rdbTimer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbTimer.AutoSize = True
        Me.rdbTimer.Location = New System.Drawing.Point(8, 14)
        Me.rdbTimer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbTimer.Name = "rdbTimer"
        Me.rdbTimer.Size = New System.Drawing.Size(117, 17)
        Me.rdbTimer.TabIndex = 72
        Me.rdbTimer.Text = "Read using a Timer"
        Me.rdbTimer.UseVisualStyleBackColor = True
        '
        'btnRead
        '
        Me.btnRead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRead.Enabled = False
        Me.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRead.Location = New System.Drawing.Point(650, 37)
        Me.btnRead.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(94, 28)
        Me.btnRead.TabIndex = 49
        Me.btnRead.Text = "Read"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'groupBox6
        '
        Me.groupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox6.Controls.Add(Me.ButtonStopCyclic)
        Me.groupBox6.Controls.Add(Me.label2)
        Me.groupBox6.Controls.Add(Me.tetBoxCycleTime)
        Me.groupBox6.Controls.Add(Me.checkBox1)
        Me.groupBox6.Controls.Add(Me.Label12)
        Me.groupBox6.Controls.Add(Me.laLength)
        Me.groupBox6.Controls.Add(Me.chbExtended)
        Me.groupBox6.Controls.Add(Me.Label13)
        Me.groupBox6.Controls.Add(Me.Label14)
        Me.groupBox6.Controls.Add(Me.txtID)
        Me.groupBox6.Controls.Add(Me.nudLength)
        Me.groupBox6.Controls.Add(Me.txtData7)
        Me.groupBox6.Controls.Add(Me.txtData6)
        Me.groupBox6.Controls.Add(Me.txtData5)
        Me.groupBox6.Controls.Add(Me.txtData4)
        Me.groupBox6.Controls.Add(Me.txtData3)
        Me.groupBox6.Controls.Add(Me.txtData2)
        Me.groupBox6.Controls.Add(Me.txtData1)
        Me.groupBox6.Controls.Add(Me.txtData0)
        Me.groupBox6.Controls.Add(Me.label11)
        Me.groupBox6.Controls.Add(Me.btnWrite)
        Me.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox6.Location = New System.Drawing.Point(10, 62)
        Me.groupBox6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox6.Size = New System.Drawing.Size(64, 54)
        Me.groupBox6.TabIndex = 57
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "Send Messages"
        Me.groupBox6.Visible = False
        '
        'ButtonStopCyclic
        '
        Me.ButtonStopCyclic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonStopCyclic.Enabled = False
        Me.ButtonStopCyclic.Location = New System.Drawing.Point(-32, 21)
        Me.ButtonStopCyclic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonStopCyclic.Name = "ButtonStopCyclic"
        Me.ButtonStopCyclic.Size = New System.Drawing.Size(84, 27)
        Me.ButtonStopCyclic.TabIndex = 147
        Me.ButtonStopCyclic.Text = "Stop"
        Me.ButtonStopCyclic.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(153, 74)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(84, 13)
        Me.label2.TabIndex = 146
        Me.label2.Text = "Cycle Time (ms):"
        '
        'tetBoxCycleTime
        '
        Me.tetBoxCycleTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tetBoxCycleTime.Enabled = False
        Me.tetBoxCycleTime.Location = New System.Drawing.Point(260, 67)
        Me.tetBoxCycleTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tetBoxCycleTime.Name = "tetBoxCycleTime"
        Me.tetBoxCycleTime.Size = New System.Drawing.Size(112, 20)
        Me.tetBoxCycleTime.TabIndex = 145
        '
        'checkBox1
        '
        Me.checkBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.checkBox1.Location = New System.Drawing.Point(386, 67)
        Me.checkBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(73, 0)
        Me.checkBox1.TabIndex = 144
        Me.checkBox1.Text = "Cyclical "
        Me.checkBox1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(466, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 143
        Me.Label12.Text = "Length:"
        '
        'laLength
        '
        Me.laLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.laLength.AutoSize = True
        Me.laLength.Location = New System.Drawing.Point(519, 70)
        Me.laLength.Name = "laLength"
        Me.laLength.Size = New System.Drawing.Size(26, 13)
        Me.laLength.TabIndex = 142
        Me.laLength.Text = "8 B."
        '
        'chbExtended
        '
        Me.chbExtended.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbExtended.Cursor = System.Windows.Forms.Cursors.Default
        Me.chbExtended.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbExtended.Location = New System.Drawing.Point(387, 37)
        Me.chbExtended.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chbExtended.Name = "chbExtended"
        Me.chbExtended.Size = New System.Drawing.Size(77, 0)
        Me.chbExtended.TabIndex = 136
        Me.chbExtended.Text = "Extended"
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(493, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 141
        Me.Label13.Text = "DLC:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(260, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 140
        Me.Label14.Text = "ID (Hex):"
        '
        'txtID
        '
        Me.txtID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Location = New System.Drawing.Point(260, 37)
        Me.txtID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtID.MaxLength = 3
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(112, 20)
        Me.txtID.TabIndex = 134
        Me.txtID.Text = "0"
        '
        'nudLength
        '
        Me.nudLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudLength.BackColor = System.Drawing.Color.White
        Me.nudLength.Location = New System.Drawing.Point(493, 40)
        Me.nudLength.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nudLength.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudLength.Name = "nudLength"
        Me.nudLength.ReadOnly = True
        Me.nudLength.Size = New System.Drawing.Size(41, 20)
        Me.nudLength.TabIndex = 135
        '
        'txtData7
        '
        Me.txtData7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData7.Location = New System.Drawing.Point(220, 38)
        Me.txtData7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData7.MaxLength = 2
        Me.txtData7.Name = "txtData7"
        Me.txtData7.Size = New System.Drawing.Size(24, 20)
        Me.txtData7.TabIndex = 77
        Me.txtData7.Text = "00"
        Me.txtData7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData6
        '
        Me.txtData6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData6.Location = New System.Drawing.Point(190, 38)
        Me.txtData6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData6.MaxLength = 2
        Me.txtData6.Name = "txtData6"
        Me.txtData6.Size = New System.Drawing.Size(24, 20)
        Me.txtData6.TabIndex = 76
        Me.txtData6.Text = "00"
        Me.txtData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData5
        '
        Me.txtData5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData5.Location = New System.Drawing.Point(160, 38)
        Me.txtData5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData5.MaxLength = 2
        Me.txtData5.Name = "txtData5"
        Me.txtData5.Size = New System.Drawing.Size(24, 20)
        Me.txtData5.TabIndex = 75
        Me.txtData5.Text = "00"
        Me.txtData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData4
        '
        Me.txtData4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData4.Location = New System.Drawing.Point(130, 38)
        Me.txtData4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData4.MaxLength = 2
        Me.txtData4.Name = "txtData4"
        Me.txtData4.Size = New System.Drawing.Size(24, 20)
        Me.txtData4.TabIndex = 74
        Me.txtData4.Text = "00"
        Me.txtData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData3
        '
        Me.txtData3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData3.Location = New System.Drawing.Point(100, 38)
        Me.txtData3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData3.MaxLength = 2
        Me.txtData3.Name = "txtData3"
        Me.txtData3.Size = New System.Drawing.Size(24, 20)
        Me.txtData3.TabIndex = 73
        Me.txtData3.Text = "00"
        Me.txtData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData2
        '
        Me.txtData2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData2.Location = New System.Drawing.Point(71, 38)
        Me.txtData2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData2.MaxLength = 2
        Me.txtData2.Name = "txtData2"
        Me.txtData2.Size = New System.Drawing.Size(24, 20)
        Me.txtData2.TabIndex = 72
        Me.txtData2.Text = "00"
        Me.txtData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData1
        '
        Me.txtData1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData1.Location = New System.Drawing.Point(41, 38)
        Me.txtData1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData1.MaxLength = 2
        Me.txtData1.Name = "txtData1"
        Me.txtData1.Size = New System.Drawing.Size(24, 20)
        Me.txtData1.TabIndex = 71
        Me.txtData1.Text = "00"
        Me.txtData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData0
        '
        Me.txtData0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtData0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData0.Location = New System.Drawing.Point(10, 38)
        Me.txtData0.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtData0.MaxLength = 2
        Me.txtData0.Name = "txtData0"
        Me.txtData0.Size = New System.Drawing.Size(24, 20)
        Me.txtData0.TabIndex = 70
        Me.txtData0.Text = "00"
        Me.txtData0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label11
        '
        Me.label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(7, 15)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(61, 13)
        Me.label11.TabIndex = 32
        Me.label11.Text = "Data (Hex):"
        '
        'btnWrite
        '
        Me.btnWrite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWrite.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnWrite.Enabled = False
        Me.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnWrite.Location = New System.Drawing.Point(-129, 20)
        Me.btnWrite.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(88, 28)
        Me.btnWrite.TabIndex = 36
        Me.btnWrite.Text = "Send"
        '
        'groupBox4
        '
        Me.groupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox4.Controls.Add(Me.Labeltest2)
        Me.groupBox4.Controls.Add(Me.Labeltest)
        Me.groupBox4.Controls.Add(Me.btnReset)
        Me.groupBox4.Controls.Add(Me.btnStatus)
        Me.groupBox4.Controls.Add(Me.btnGetVersions)
        Me.groupBox4.Controls.Add(Me.lbxInfo)
        Me.groupBox4.Controls.Add(Me.btnInfoClear)
        Me.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox4.Location = New System.Drawing.Point(7, 1141)
        Me.groupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox4.Size = New System.Drawing.Size(758, 115)
        Me.groupBox4.TabIndex = 55
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Information"
        '
        'Labeltest2
        '
        Me.Labeltest2.AutoSize = True
        Me.Labeltest2.Location = New System.Drawing.Point(433, 25)
        Me.Labeltest2.Name = "Labeltest2"
        Me.Labeltest2.Size = New System.Drawing.Size(39, 13)
        Me.Labeltest2.TabIndex = 65
        Me.Labeltest2.Text = "Label3"
        '
        'Labeltest
        '
        Me.Labeltest.AutoSize = True
        Me.Labeltest.Location = New System.Drawing.Point(369, 25)
        Me.Labeltest.Name = "Labeltest"
        Me.Labeltest.Size = New System.Drawing.Size(39, 13)
        Me.Labeltest.TabIndex = 64
        Me.Labeltest.Text = "Label3"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Enabled = False
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReset.Location = New System.Drawing.Point(685, 44)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(65, 14)
        Me.btnReset.TabIndex = 63
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnStatus
        '
        Me.btnStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStatus.Enabled = False
        Me.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStatus.Location = New System.Drawing.Point(614, 44)
        Me.btnStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(65, 14)
        Me.btnStatus.TabIndex = 62
        Me.btnStatus.Text = "Status"
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'btnGetVersions
        '
        Me.btnGetVersions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetVersions.Enabled = False
        Me.btnGetVersions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGetVersions.Location = New System.Drawing.Point(614, 15)
        Me.btnGetVersions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGetVersions.Name = "btnGetVersions"
        Me.btnGetVersions.Size = New System.Drawing.Size(65, 24)
        Me.btnGetVersions.TabIndex = 60
        Me.btnGetVersions.Text = "Versions"
        Me.btnGetVersions.UseVisualStyleBackColor = True
        '
        'lbxInfo
        '
        Me.lbxInfo.FormattingEnabled = True
        Me.lbxInfo.Items.AddRange(New Object() {"Select a Hardware and a configuration for it. Then click ""Initialize"" button", "When activated, the Debug-Log file will be found in the same directory as this ap" &
                "plication", "When activated, the PCAN-Trace file will be found in the same directory as this a" &
                "pplication"})
        Me.lbxInfo.Location = New System.Drawing.Point(5, 15)
        Me.lbxInfo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lbxInfo.Name = "lbxInfo"
        Me.lbxInfo.ScrollAlwaysVisible = True
        Me.lbxInfo.Size = New System.Drawing.Size(335, 43)
        Me.lbxInfo.TabIndex = 61
        '
        'btnInfoClear
        '
        Me.btnInfoClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInfoClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnInfoClear.Location = New System.Drawing.Point(685, 15)
        Me.btnInfoClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInfoClear.Name = "btnInfoClear"
        Me.btnInfoClear.Size = New System.Drawing.Size(65, 24)
        Me.btnInfoClear.TabIndex = 59
        Me.btnInfoClear.Text = "Clear"
        Me.btnInfoClear.UseVisualStyleBackColor = True
        '
        'cbbChannel
        '
        Me.cbbChannel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbChannel.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbChannel.Items.AddRange(New Object() {"None", "USB-Channel 1", "USB-Channel 2", "USB-Channel 3", "USB-Channel 4", "USB-Channel 5", "USB-Channel 6", "USB-Channel 7", "USB-Channel 8"})
        Me.cbbChannel.Location = New System.Drawing.Point(8, 31)
        Me.cbbChannel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbbChannel.Name = "cbbChannel"
        Me.cbbChannel.Size = New System.Drawing.Size(206, 21)
        Me.cbbChannel.TabIndex = 32
        '
        'btnHwRefresh
        '
        Me.btnHwRefresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHwRefresh.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHwRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnHwRefresh.Location = New System.Drawing.Point(235, 28)
        Me.btnHwRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHwRefresh.Name = "btnHwRefresh"
        Me.btnHwRefresh.Size = New System.Drawing.Size(59, 24)
        Me.btnHwRefresh.TabIndex = 45
        Me.btnHwRefresh.Text = "Refresh"
        '
        'btnFilterQuery
        '
        Me.btnFilterQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterQuery.Enabled = False
        Me.btnFilterQuery.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFilterQuery.Location = New System.Drawing.Point(689, 26)
        Me.btnFilterQuery.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilterQuery.Name = "btnFilterQuery"
        Me.btnFilterQuery.Size = New System.Drawing.Size(65, 24)
        Me.btnFilterQuery.TabIndex = 55
        Me.btnFilterQuery.Text = "Query"
        Me.btnFilterQuery.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.Controls.Add(Me.btnFilterQuery)
        Me.groupBox3.Controls.Add(Me.chbFilterExt)
        Me.groupBox3.Controls.Add(Me.nudIdTo)
        Me.groupBox3.Controls.Add(Me.nudIdFrom)
        Me.groupBox3.Controls.Add(Me.label8)
        Me.groupBox3.Controls.Add(Me.label7)
        Me.groupBox3.Controls.Add(Me.rdbFilterOpen)
        Me.groupBox3.Controls.Add(Me.rdbFilterCustom)
        Me.groupBox3.Controls.Add(Me.rdbFilterClose)
        Me.groupBox3.Controls.Add(Me.btnFilterApply)
        Me.groupBox3.Location = New System.Drawing.Point(5, 98)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox3.Size = New System.Drawing.Size(760, 59)
        Me.groupBox3.TabIndex = 53
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = " Message Filtering "
        '
        'chbFilterExt
        '
        Me.chbFilterExt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbFilterExt.AutoSize = True
        Me.chbFilterExt.Location = New System.Drawing.Point(10, 33)
        Me.chbFilterExt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chbFilterExt.Name = "chbFilterExt"
        Me.chbFilterExt.Size = New System.Drawing.Size(103, 17)
        Me.chbFilterExt.TabIndex = 44
        Me.chbFilterExt.Text = "Extended Frame"
        Me.chbFilterExt.UseVisualStyleBackColor = True
        '
        'nudIdTo
        '
        Me.nudIdTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudIdTo.Hexadecimal = True
        Me.nudIdTo.Location = New System.Drawing.Point(438, 28)
        Me.nudIdTo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nudIdTo.Maximum = New Decimal(New Integer() {2047, 0, 0, 0})
        Me.nudIdTo.Name = "nudIdTo"
        Me.nudIdTo.Size = New System.Drawing.Size(69, 20)
        Me.nudIdTo.TabIndex = 6
        Me.nudIdTo.Value = New Decimal(New Integer() {2047, 0, 0, 0})
        '
        'nudIdFrom
        '
        Me.nudIdFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudIdFrom.Hexadecimal = True
        Me.nudIdFrom.Location = New System.Drawing.Point(363, 28)
        Me.nudIdFrom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.nudIdFrom.Maximum = New Decimal(New Integer() {536870911, 0, 0, 0})
        Me.nudIdFrom.Name = "nudIdFrom"
        Me.nudIdFrom.Size = New System.Drawing.Size(69, 20)
        Me.nudIdFrom.TabIndex = 5
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(436, 11)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(28, 24)
        Me.label8.TabIndex = 43
        Me.label8.Text = "To:"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(361, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(38, 24)
        Me.label7.TabIndex = 42
        Me.label7.Text = "From:"
        '
        'rdbFilterOpen
        '
        Me.rdbFilterOpen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbFilterOpen.Location = New System.Drawing.Point(120, 33)
        Me.rdbFilterOpen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbFilterOpen.Name = "rdbFilterOpen"
        Me.rdbFilterOpen.Size = New System.Drawing.Size(53, 17)
        Me.rdbFilterOpen.TabIndex = 2
        Me.rdbFilterOpen.Text = "Open"
        Me.rdbFilterOpen.UseVisualStyleBackColor = True
        '
        'rdbFilterCustom
        '
        Me.rdbFilterCustom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbFilterCustom.Location = New System.Drawing.Point(238, 33)
        Me.rdbFilterCustom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbFilterCustom.Name = "rdbFilterCustom"
        Me.rdbFilterCustom.Size = New System.Drawing.Size(104, 17)
        Me.rdbFilterCustom.TabIndex = 1
        Me.rdbFilterCustom.Text = "Custom (expand)"
        Me.rdbFilterCustom.UseVisualStyleBackColor = True
        '
        'rdbFilterClose
        '
        Me.rdbFilterClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdbFilterClose.Location = New System.Drawing.Point(177, 33)
        Me.rdbFilterClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbFilterClose.Name = "rdbFilterClose"
        Me.rdbFilterClose.Size = New System.Drawing.Size(58, 17)
        Me.rdbFilterClose.TabIndex = 0
        Me.rdbFilterClose.Text = "Close"
        Me.rdbFilterClose.UseVisualStyleBackColor = True
        '
        'btnFilterApply
        '
        Me.btnFilterApply.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterApply.Enabled = False
        Me.btnFilterApply.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFilterApply.Location = New System.Drawing.Point(618, 26)
        Me.btnFilterApply.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFilterApply.Name = "btnFilterApply"
        Me.btnFilterApply.Size = New System.Drawing.Size(65, 24)
        Me.btnFilterApply.TabIndex = 44
        Me.btnFilterApply.Text = "Apply"
        Me.btnFilterApply.UseVisualStyleBackColor = True
        '
        'tmrRead
        '
        Me.tmrRead.Interval = 10
        '
        'cbbBaudrates
        '
        Me.cbbBaudrates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbBaudrates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBaudrates.Items.AddRange(New Object() {"1 MBit/sec", "800 kBit/sec", "500 kBit/sec", "250 kBit/sec", "125 kKBit/sec", "100 kBit/sec", "95,238 kBit/sec", "83,333 kBit/sec", "50 kBit/sec", "47,619 kBit/sec", "33,333 kBit/sec", "20 kBit/sec", "10 kBit/sec", "5 kBit/sec"})
        Me.cbbBaudrates.Location = New System.Drawing.Point(334, 30)
        Me.cbbBaudrates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbbBaudrates.Name = "cbbBaudrates"
        Me.cbbBaudrates.Size = New System.Drawing.Size(234, 21)
        Me.cbbBaudrates.TabIndex = 36
        '
        'laBaudrate
        '
        Me.laBaudrate.Location = New System.Drawing.Point(334, 15)
        Me.laBaudrate.Name = "laBaudrate"
        Me.laBaudrate.Size = New System.Drawing.Size(56, 28)
        Me.laBaudrate.TabIndex = 41
        Me.laBaudrate.Text = "Baudrate:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(7, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(56, 24)
        Me.label1.TabIndex = 40
        Me.label1.Text = "Hardware:"
        '
        'btnInit
        '
        Me.btnInit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnInit.Location = New System.Drawing.Point(660, 11)
        Me.btnInit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInit.Name = "btnInit"
        Me.btnInit.Size = New System.Drawing.Size(94, 28)
        Me.btnInit.TabIndex = 34
        Me.btnInit.Text = "Initialize"
        '
        'btnRelease
        '
        Me.btnRelease.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelease.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRelease.Enabled = False
        Me.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRelease.Location = New System.Drawing.Point(660, 38)
        Me.btnRelease.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(94, 24)
        Me.btnRelease.TabIndex = 35
        Me.btnRelease.Text = "Release"
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.label_connectStatus)
        Me.groupBox1.Controls.Add(Me.btnHwRefresh)
        Me.groupBox1.Controls.Add(Me.cbbChannel)
        Me.groupBox1.Controls.Add(Me.cbbBaudrates)
        Me.groupBox1.Controls.Add(Me.laBaudrate)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.btnInit)
        Me.groupBox1.Controls.Add(Me.btnRelease)
        Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox1.Location = New System.Drawing.Point(5, 27)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox1.Size = New System.Drawing.Size(760, 65)
        Me.groupBox1.TabIndex = 52
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = " Connection "
        '
        'label_connectStatus
        '
        Me.label_connectStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_connectStatus.BackColor = System.Drawing.Color.Red
        Me.label_connectStatus.Location = New System.Drawing.Point(587, 21)
        Me.label_connectStatus.Name = "label_connectStatus"
        Me.label_connectStatus.Size = New System.Drawing.Size(61, 31)
        Me.label_connectStatus.TabIndex = 46
        Me.label_connectStatus.Text = "Need to connect"
        Me.label_connectStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrDisplay
        '
        Me.tmrDisplay.Interval = 150
        '
        'menuStrip1
        '
        Me.menuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.helpToolStripMenuItem, Me.helpToolStripMenuItem1})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(770, 24)
        Me.menuStrip1.TabIndex = 58
        Me.menuStrip1.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.importCANDescriptionToolStripMenuItem, Me.exportCANDescriptionToolStripMenuItem, Me.configurateCANBusParametersToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'importCANDescriptionToolStripMenuItem
        '
        Me.importCANDescriptionToolStripMenuItem.Name = "importCANDescriptionToolStripMenuItem"
        Me.importCANDescriptionToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.importCANDescriptionToolStripMenuItem.Text = "Import CAN Description"
        '
        'exportCANDescriptionToolStripMenuItem
        '
        Me.exportCANDescriptionToolStripMenuItem.Name = "exportCANDescriptionToolStripMenuItem"
        Me.exportCANDescriptionToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.exportCANDescriptionToolStripMenuItem.Text = "Export CAN Description"
        '
        'configurateCANBusParametersToolStripMenuItem
        '
        Me.configurateCANBusParametersToolStripMenuItem.Name = "configurateCANBusParametersToolStripMenuItem"
        Me.configurateCANBusParametersToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.configurateCANBusParametersToolStripMenuItem.Text = "Configurate CAN bus Parameters"
        '
        'helpToolStripMenuItem
        '
        Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.parametersWriterToolStripMenuItem, Me.softwareWriterToolStripMenuItem, Me.scriptingAndMonitorToolStripMenuItem, Me.forceReleaseChannelToolStripMenuItem, Me.AssemblingWizardToolStripMenuItem, Me.ChangeStepsToolStripMenuItem})
        Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
        Me.helpToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.helpToolStripMenuItem.Text = "Tools"
        '
        'parametersWriterToolStripMenuItem
        '
        Me.parametersWriterToolStripMenuItem.Name = "parametersWriterToolStripMenuItem"
        Me.parametersWriterToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.parametersWriterToolStripMenuItem.Text = "Write Parameters"
        '
        'softwareWriterToolStripMenuItem
        '
        Me.softwareWriterToolStripMenuItem.Name = "softwareWriterToolStripMenuItem"
        Me.softwareWriterToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.softwareWriterToolStripMenuItem.Text = "Read Diagnostics"
        '
        'scriptingAndMonitorToolStripMenuItem
        '
        Me.scriptingAndMonitorToolStripMenuItem.Name = "scriptingAndMonitorToolStripMenuItem"
        Me.scriptingAndMonitorToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.scriptingAndMonitorToolStripMenuItem.Text = "Scripting and Monitor"
        '
        'forceReleaseChannelToolStripMenuItem
        '
        Me.forceReleaseChannelToolStripMenuItem.Name = "forceReleaseChannelToolStripMenuItem"
        Me.forceReleaseChannelToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.forceReleaseChannelToolStripMenuItem.Text = "Key Finder"
        Me.forceReleaseChannelToolStripMenuItem.Visible = False
        '
        'AssemblingWizardToolStripMenuItem
        '
        Me.AssemblingWizardToolStripMenuItem.Name = "AssemblingWizardToolStripMenuItem"
        Me.AssemblingWizardToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.AssemblingWizardToolStripMenuItem.Text = "Assembling Wizard"
        Me.AssemblingWizardToolStripMenuItem.Visible = False
        '
        'ChangeStepsToolStripMenuItem
        '
        Me.ChangeStepsToolStripMenuItem.Enabled = False
        Me.ChangeStepsToolStripMenuItem.Name = "ChangeStepsToolStripMenuItem"
        Me.ChangeStepsToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ChangeStepsToolStripMenuItem.Text = "Change Steps"
        '
        'helpToolStripMenuItem1
        '
        Me.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1"
        Me.helpToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.helpToolStripMenuItem1.Text = "Help"
        '
        'splitContainer1
        '
        Me.splitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitContainer1.Location = New System.Drawing.Point(5, 291)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.tableLayoutPanel2)
        Me.splitContainer1.Size = New System.Drawing.Size(760, 521)
        Me.splitContainer1.SplitterDistance = 387
        Me.splitContainer1.TabIndex = 59
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tableLayoutPanel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox7)
        Me.SplitContainer2.Size = New System.Drawing.Size(387, 521)
        Me.SplitContainer2.SplitterDistance = 452
        Me.SplitContainer2.TabIndex = 0
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.24352!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.75648!))
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox2, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Button_GoPosition, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.GroupBox8, 0, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.54965!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.45035!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(387, 452)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.tableLayoutPanel4)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(278, 69)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupBox2.Size = New System.Drawing.Size(105, 380)
        Me.groupBox2.TabIndex = 3
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Actutor2Tool"
        '
        'tableLayoutPanel4
        '
        Me.tableLayoutPanel4.ColumnCount = 1
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel4.Controls.Add(Me.button2, 0, 1)
        Me.tableLayoutPanel4.Controls.Add(Me.button1, 0, 0)
        Me.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel4.Location = New System.Drawing.Point(3, 15)
        Me.tableLayoutPanel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tableLayoutPanel4.Name = "tableLayoutPanel4"
        Me.tableLayoutPanel4.RowCount = 2
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tableLayoutPanel4.Size = New System.Drawing.Size(99, 363)
        Me.tableLayoutPanel4.TabIndex = 4
        '
        'button2
        '
        Me.button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.button2.Location = New System.Drawing.Point(3, 183)
        Me.button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(93, 178)
        Me.button2.TabIndex = 1
        Me.button2.Text = "Read FixedSpan"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.button1.Location = New System.Drawing.Point(3, 2)
        Me.button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(93, 177)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Read ComputeStroke"
        Me.button1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.label_positionCommand, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.trackBarPosition, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(4, 3)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(267, 61)
        Me.TableLayoutPanel5.TabIndex = 4
        '
        'label_positionCommand
        '
        Me.label_positionCommand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label_positionCommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_positionCommand.Location = New System.Drawing.Point(3, 30)
        Me.label_positionCommand.Name = "label_positionCommand"
        Me.label_positionCommand.Size = New System.Drawing.Size(261, 31)
        Me.label_positionCommand.TabIndex = 2
        Me.label_positionCommand.Text = "Position Target: 0%"
        Me.label_positionCommand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trackBarPosition
        '
        Me.trackBarPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trackBarPosition.Location = New System.Drawing.Point(3, 2)
        Me.trackBarPosition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.trackBarPosition.Maximum = 100
        Me.trackBarPosition.Name = "trackBarPosition"
        Me.trackBarPosition.Size = New System.Drawing.Size(261, 26)
        Me.trackBarPosition.TabIndex = 1
        '
        'Button_GoPosition
        '
        Me.Button_GoPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_GoPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_GoPosition.Location = New System.Drawing.Point(278, 3)
        Me.Button_GoPosition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_GoPosition.Name = "Button_GoPosition"
        Me.Button_GoPosition.Size = New System.Drawing.Size(105, 61)
        Me.Button_GoPosition.TabIndex = 5
        Me.Button_GoPosition.Text = "GO"
        Me.Button_GoPosition.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TreeViewCommands)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Location = New System.Drawing.Point(4, 70)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(267, 378)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Double click node to run the command"
        '
        'TreeViewCommands
        '
        Me.TreeViewCommands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewCommands.Location = New System.Drawing.Point(3, 16)
        Me.TreeViewCommands.Name = "TreeViewCommands"
        Me.TreeViewCommands.Size = New System.Drawing.Size(261, 359)
        Me.TreeViewCommands.TabIndex = 6
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TextBoxLog)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(387, 65)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Log tracing"
        '
        'TextBoxLog
        '
        Me.TextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxLog.Enabled = False
        Me.TextBoxLog.Location = New System.Drawing.Point(3, 16)
        Me.TextBoxLog.Multiline = True
        Me.TextBoxLog.Name = "TextBoxLog"
        Me.TextBoxLog.Size = New System.Drawing.Size(381, 46)
        Me.TextBoxLog.TabIndex = 1
        Me.TextBoxLog.Text = "本软件版权为SONCEBOZ所有" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作者 张磊"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 0
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tableLayoutPanel2.ColumnCount = 2
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.69863!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.30137!))
        Me.tableLayoutPanel2.Controls.Add(Me.labelPostionFeedback, 1, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.progressBarPositionFeedback, 0, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.buttonIsFault, 1, 2)
        Me.tableLayoutPanel2.Controls.Add(Me.treeView1, 0, 2)
        Me.tableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 3
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.60564!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.39437!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 413.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(369, 521)
        Me.tableLayoutPanel2.TabIndex = 0
        '
        'labelPostionFeedback
        '
        Me.labelPostionFeedback.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelPostionFeedback.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPostionFeedback.Location = New System.Drawing.Point(274, 1)
        Me.labelPostionFeedback.Name = "labelPostionFeedback"
        Me.labelPostionFeedback.Size = New System.Drawing.Size(91, 70)
        Me.labelPostionFeedback.TabIndex = 2
        Me.labelPostionFeedback.Text = "Position Feedback: 0%"
        Me.labelPostionFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progressBarPositionFeedback
        '
        Me.progressBarPositionFeedback.Dock = System.Windows.Forms.DockStyle.Fill
        Me.progressBarPositionFeedback.Location = New System.Drawing.Point(4, 3)
        Me.progressBarPositionFeedback.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.progressBarPositionFeedback.Name = "progressBarPositionFeedback"
        Me.progressBarPositionFeedback.Size = New System.Drawing.Size(263, 66)
        Me.progressBarPositionFeedback.TabIndex = 0
        '
        'buttonIsFault
        '
        Me.buttonIsFault.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.buttonIsFault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonIsFault.Location = New System.Drawing.Point(274, 108)
        Me.buttonIsFault.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.buttonIsFault.Name = "buttonIsFault"
        Me.buttonIsFault.Size = New System.Drawing.Size(91, 410)
        Me.buttonIsFault.TabIndex = 5
        Me.buttonIsFault.Text = "No Fault"
        Me.buttonIsFault.UseVisualStyleBackColor = False
        '
        'treeView1
        '
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView1.Location = New System.Drawing.Point(4, 108)
        Me.treeView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.treeView1.Name = "treeView1"
        TreeNode1.Name = "Node3"
        TreeNode1.Text = "Actuator Status"
        TreeNode2.Name = "Node0"
        TreeNode2.Text = "EEPROM error"
        TreeNode3.Name = "Node1"
        TreeNode3.Text = "Position deviation"
        TreeNode4.Name = "Node11"
        TreeNode4.Text = "Others"
        TreeNode5.Name = "Node10"
        TreeNode5.Text = "Over Temperature"
        TreeNode6.Name = "Node9"
        TreeNode6.Text = "Calibration error: Span too big"
        TreeNode7.Name = "Node8"
        TreeNode7.Text = "Calibration error: Span too small"
        TreeNode8.Name = "Node7"
        TreeNode8.Text = "Learn error: Span too big"
        TreeNode9.Name = "Node6"
        TreeNode9.Text = "Learn error: Span too small"
        TreeNode10.Name = "Node5"
        TreeNode10.Text = "Undervoltage"
        TreeNode11.Name = "Node4"
        TreeNode11.Text = "Overvoltage"
        TreeNode12.Name = "Node3"
        TreeNode12.Text = "CAN error"
        TreeNode13.Name = "Node2"
        TreeNode13.Text = "Sensor Error"
        TreeNode14.Name = "Node0"
        TreeNode14.Text = "Faults"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode14})
        Me.treeView1.Size = New System.Drawing.Size(263, 410)
        Me.treeView1.TabIndex = 6
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.97701!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.02299!))
        Me.TableLayoutPanel6.Controls.Add(Me.LabelTemperature, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelMotorEffot, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(4, 75)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(263, 27)
        Me.TableLayoutPanel6.TabIndex = 7
        '
        'LabelTemperature
        '
        Me.LabelTemperature.AutoSize = True
        Me.LabelTemperature.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTemperature.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelTemperature.Location = New System.Drawing.Point(3, 0)
        Me.LabelTemperature.Name = "LabelTemperature"
        Me.LabelTemperature.Size = New System.Drawing.Size(114, 27)
        Me.LabelTemperature.TabIndex = 5
        Me.LabelTemperature.Text = "Temperature: "
        '
        'LabelMotorEffot
        '
        Me.LabelMotorEffot.AutoSize = True
        Me.LabelMotorEffot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMotorEffot.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelMotorEffot.Location = New System.Drawing.Point(123, 0)
        Me.LabelMotorEffot.Name = "LabelMotorEffot"
        Me.LabelMotorEffot.Size = New System.Drawing.Size(137, 27)
        Me.LabelMotorEffot.TabIndex = 6
        Me.LabelMotorEffot.Text = "Motor Efforts: "
        '
        'timerLogging
        '
        Me.timerLogging.Interval = 2000
        '
        'OpenFileDialogIMPORT
        '
        Me.OpenFileDialogIMPORT.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ContextMenuStrip = Me.ContextMenuStripCopyInfo
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelSWVersion, Me.ToolStripStatusLabelSeralNumber, Me.ToolStripStatusLabelCANMAXGood, Me.ToolStripStatusLabelProjectInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 819)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(770, 24)
        Me.StatusStrip1.TabIndex = 60
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ContextMenuStripCopyInfo
        '
        Me.ContextMenuStripCopyInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToClipboardToolStripMenuItem, Me.AppendSWToolStripMenuItem, Me.AppendSNOnlyToolStripMenuItem, Me.AppendSWOnlyToolStripMenuItem, Me.ShowSNAndSWRecordsInEXCELToolStripMenuItem})
        Me.ContextMenuStripCopyInfo.Name = "ContextMenuStripCopyInfo"
        Me.ContextMenuStripCopyInfo.Size = New System.Drawing.Size(256, 114)
        '
        'CopyToClipboardToolStripMenuItem
        '
        Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
        Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.CopyToClipboardToolStripMenuItem.Text = "Copy to Clipboard"
        '
        'AppendSWToolStripMenuItem
        '
        Me.AppendSWToolStripMenuItem.Name = "AppendSWToolStripMenuItem"
        Me.AppendSWToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AppendSWToolStripMenuItem.Text = "Append all to file"
        '
        'AppendSNOnlyToolStripMenuItem
        '
        Me.AppendSNOnlyToolStripMenuItem.Name = "AppendSNOnlyToolStripMenuItem"
        Me.AppendSNOnlyToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AppendSNOnlyToolStripMenuItem.Text = "Append SN only"
        '
        'AppendSWOnlyToolStripMenuItem
        '
        Me.AppendSWOnlyToolStripMenuItem.Name = "AppendSWOnlyToolStripMenuItem"
        Me.AppendSWOnlyToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.AppendSWOnlyToolStripMenuItem.Text = "Append SW only"
        '
        'ShowSNAndSWRecordsInEXCELToolStripMenuItem
        '
        Me.ShowSNAndSWRecordsInEXCELToolStripMenuItem.Name = "ShowSNAndSWRecordsInEXCELToolStripMenuItem"
        Me.ShowSNAndSWRecordsInEXCELToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ShowSNAndSWRecordsInEXCELToolStripMenuItem.Text = "Show SN and SW records in EXCEL"
        '
        'ToolStripStatusLabelSWVersion
        '
        Me.ToolStripStatusLabelSWVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelSWVersion.Name = "ToolStripStatusLabelSWVersion"
        Me.ToolStripStatusLabelSWVersion.Size = New System.Drawing.Size(123, 19)
        Me.ToolStripStatusLabelSWVersion.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabelSeralNumber
        '
        Me.ToolStripStatusLabelSeralNumber.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelSeralNumber.Name = "ToolStripStatusLabelSeralNumber"
        Me.ToolStripStatusLabelSeralNumber.Size = New System.Drawing.Size(123, 19)
        Me.ToolStripStatusLabelSeralNumber.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabelCANMAXGood
        '
        Me.ToolStripStatusLabelCANMAXGood.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelCANMAXGood.Name = "ToolStripStatusLabelCANMAXGood"
        Me.ToolStripStatusLabelCANMAXGood.Size = New System.Drawing.Size(123, 19)
        Me.ToolStripStatusLabelCANMAXGood.Text = "ToolStripStatusLabel3"
        '
        'ToolStripStatusLabelProjectInfo
        '
        Me.ToolStripStatusLabelProjectInfo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelProjectInfo.Name = "ToolStripStatusLabelProjectInfo"
        Me.ToolStripStatusLabelProjectInfo.Size = New System.Drawing.Size(4, 19)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 843)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.menuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CANBOZ"
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox6.PerformLayout()
        CType(Me.nudLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.nudIdTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIdFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.tableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.trackBarPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStripCopyInfo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents forceReleaseChannelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents treeView1 As System.Windows.Forms.TreeView
    Private WithEvents buttonIsFault As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents tableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents timerLogging As System.Windows.Forms.Timer
    Private WithEvents progressBarPositionFeedback As System.Windows.Forms.ProgressBar
    Private WithEvents labelPostionFeedback As System.Windows.Forms.Label
    Private WithEvents tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents label_connectStatus As System.Windows.Forms.Label
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
    Private WithEvents tetBoxCycleTime As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents scriptingAndMonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents helpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents softwareWriterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents parametersWriterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents configurateCANBusParametersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents exportCANDescriptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents importCANDescriptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents chbShowPeriod As System.Windows.Forms.CheckBox
    Private WithEvents rdbManual As System.Windows.Forms.RadioButton
    Private WithEvents rdbEvent As System.Windows.Forms.RadioButton
    Private WithEvents lstMessages As System.Windows.Forms.ListView
    Private WithEvents clhType As System.Windows.Forms.ColumnHeader
    Private WithEvents clhID As System.Windows.Forms.ColumnHeader
    Private WithEvents clhLength As System.Windows.Forms.ColumnHeader
    Private WithEvents clhData As System.Windows.Forms.ColumnHeader
    Private WithEvents clhCount As System.Windows.Forms.ColumnHeader
    Private WithEvents clhRcvTime As System.Windows.Forms.ColumnHeader
    Private WithEvents btnMsgClear As System.Windows.Forms.Button
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents rdbTimer As System.Windows.Forms.RadioButton
    Private WithEvents btnRead As System.Windows.Forms.Button
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents btnWrite As System.Windows.Forms.Button
    Private WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents cbbChannel As System.Windows.Forms.ComboBox
    Private WithEvents btnHwRefresh As System.Windows.Forms.Button
    Private WithEvents btnFilterQuery As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents chbFilterExt As System.Windows.Forms.CheckBox
    Private WithEvents nudIdTo As System.Windows.Forms.NumericUpDown
    Private WithEvents nudIdFrom As System.Windows.Forms.NumericUpDown
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents rdbFilterOpen As System.Windows.Forms.RadioButton
    Private WithEvents rdbFilterCustom As System.Windows.Forms.RadioButton
    Private WithEvents rdbFilterClose As System.Windows.Forms.RadioButton
    Private WithEvents btnFilterApply As System.Windows.Forms.Button
    Private WithEvents cbbBaudrates As System.Windows.Forms.ComboBox
    Private WithEvents laBaudrate As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnInit As System.Windows.Forms.Button
    Private WithEvents btnRelease As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tmrRead As System.Windows.Forms.Timer
    Private WithEvents tmrDisplay As System.Windows.Forms.Timer
    Private WithEvents txtData7 As System.Windows.Forms.TextBox
    Private WithEvents txtData6 As System.Windows.Forms.TextBox
    Private WithEvents txtData5 As System.Windows.Forms.TextBox
    Private WithEvents txtData4 As System.Windows.Forms.TextBox
    Private WithEvents txtData3 As System.Windows.Forms.TextBox
    Private WithEvents txtData2 As System.Windows.Forms.TextBox
    Private WithEvents txtData1 As System.Windows.Forms.TextBox
    Private WithEvents txtData0 As System.Windows.Forms.TextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents laLength As System.Windows.Forms.Label
    Private WithEvents chbExtended As System.Windows.Forms.CheckBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents txtID As System.Windows.Forms.TextBox
    Private WithEvents nudLength As System.Windows.Forms.NumericUpDown
    Private WithEvents btnReset As System.Windows.Forms.Button
    Private WithEvents btnStatus As System.Windows.Forms.Button
    Private WithEvents btnGetVersions As System.Windows.Forms.Button
    Private WithEvents lbxInfo As System.Windows.Forms.ListBox
    Private WithEvents btnInfoClear As System.Windows.Forms.Button


    Sub ParametersWriterToolStripMenuItemClick(sender As Object, e As EventArgs)

    End Sub

    Sub ConfigurateCANBusParametersToolStripMenuItemClick(sender As Object, e As EventArgs)

    End Sub

    Friend WithEvents ButtonStopCyclic As Button
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Private WithEvents label_positionCommand As Label
    Private WithEvents trackBarPosition As TrackBar
    Friend WithEvents Button_GoPosition As Button
    Friend WithEvents OpenFileDialogIMPORT As OpenFileDialog
    Friend WithEvents Labeltest As Label
    Friend WithEvents Labeltest2 As Label
    Friend WithEvents AssemblingWizardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelSWVersion As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelSeralNumber As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelCANMAXGood As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelProjectInfo As ToolStripStatusLabel
    Friend WithEvents ContextMenuStripCopyInfo As ContextMenuStrip
    Friend WithEvents CopyToClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents LabelTemperature As Label
    Friend WithEvents LabelMotorEffot As Label
    Friend WithEvents TreeViewCommands As TreeView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TextBoxLog As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ChangeStepsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppendSWToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppendSNOnlyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppendSWOnlyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowSNAndSWRecordsInEXCELToolStripMenuItem As ToolStripMenuItem
End Class
