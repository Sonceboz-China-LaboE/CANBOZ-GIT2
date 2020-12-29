<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ReadinfoEPPROM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ReadinfoEPPROM))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonReadAll = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridViewDiagnostic = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewRingBuffer2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewRingBuffer1 = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.UserControl_ParameterPropertiesHitogram = New UserControl_ParameterProperties()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ChartC = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DrawBarChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChartP = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.DataGridViewHistogram = New System.Windows.Forms.DataGridView()
        Me.ChartT = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateAnalysisReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HEX2DECToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEC2HEXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridViewDiagnostic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DataGridViewRingBuffer2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewRingBuffer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.ChartC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ChartP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewHistogram, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.6091!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonReadAll, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.4!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.6!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1121, 538)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonReadAll
        '
        Me.ButtonReadAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonReadAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonReadAll.Location = New System.Drawing.Point(3, 488)
        Me.ButtonReadAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonReadAll.Name = "ButtonReadAll"
        Me.ButtonReadAll.Size = New System.Drawing.Size(1115, 48)
        Me.ButtonReadAll.TabIndex = 0
        Me.ButtonReadAll.Text = "Read All"
        Me.ButtonReadAll.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 2)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1115, 482)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridViewDiagnostic)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(1107, 456)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DIAGNOSTIC TABLE"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridViewDiagnostic
        '
        Me.DataGridViewDiagnostic.AllowUserToAddRows = False
        Me.DataGridViewDiagnostic.AllowUserToDeleteRows = False
        Me.DataGridViewDiagnostic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewDiagnostic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDiagnostic.Location = New System.Drawing.Point(3, 2)
        Me.DataGridViewDiagnostic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewDiagnostic.Name = "DataGridViewDiagnostic"
        Me.DataGridViewDiagnostic.ReadOnly = True
        Me.DataGridViewDiagnostic.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridViewDiagnostic.Size = New System.Drawing.Size(1101, 452)
        Me.DataGridViewDiagnostic.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(1107, 456)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "RING BUFFER"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.5931!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.4069!))
        Me.TableLayoutPanel3.Controls.Add(Me.DataGridViewRingBuffer2, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DataGridViewRingBuffer1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1101, 452)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'DataGridViewRingBuffer2
        '
        Me.DataGridViewRingBuffer2.AllowUserToAddRows = False
        Me.DataGridViewRingBuffer2.AllowUserToDeleteRows = False
        Me.DataGridViewRingBuffer2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewRingBuffer2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRingBuffer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewRingBuffer2.Location = New System.Drawing.Point(527, 2)
        Me.DataGridViewRingBuffer2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewRingBuffer2.Name = "DataGridViewRingBuffer2"
        Me.DataGridViewRingBuffer2.ReadOnly = True
        Me.DataGridViewRingBuffer2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridViewRingBuffer2.Size = New System.Drawing.Size(571, 448)
        Me.DataGridViewRingBuffer2.TabIndex = 2
        '
        'DataGridViewRingBuffer1
        '
        Me.DataGridViewRingBuffer1.AllowUserToAddRows = False
        Me.DataGridViewRingBuffer1.AllowUserToDeleteRows = False
        Me.DataGridViewRingBuffer1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewRingBuffer1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRingBuffer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewRingBuffer1.Location = New System.Drawing.Point(3, 2)
        Me.DataGridViewRingBuffer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewRingBuffer1.Name = "DataGridViewRingBuffer1"
        Me.DataGridViewRingBuffer1.ReadOnly = True
        Me.DataGridViewRingBuffer1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DataGridViewRingBuffer1.Size = New System.Drawing.Size(518, 448)
        Me.DataGridViewRingBuffer1.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Size = New System.Drawing.Size(1107, 456)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "HISTOGRAM STORAGE"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 2)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.UserControl_ParameterPropertiesHitogram)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1101, 452)
        Me.SplitContainer1.SplitterDistance = 366
        Me.SplitContainer1.TabIndex = 0
        '
        'UserControl_ParameterPropertiesHitogram
        '
        Me.UserControl_ParameterPropertiesHitogram.DataSource = Nothing
        Me.UserControl_ParameterPropertiesHitogram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserControl_ParameterPropertiesHitogram.HasEditingError = False
        Me.UserControl_ParameterPropertiesHitogram.Ismodifiabble = False
        Me.UserControl_ParameterPropertiesHitogram.Location = New System.Drawing.Point(0, 0)
        Me.UserControl_ParameterPropertiesHitogram.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.UserControl_ParameterPropertiesHitogram.Name = "UserControl_ParameterPropertiesHitogram"
        Me.UserControl_ParameterPropertiesHitogram.Size = New System.Drawing.Size(366, 452)
        Me.UserControl_ParameterPropertiesHitogram.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ChartC, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ChartP, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridViewHistogram, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ChartT, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(731, 452)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'ChartC
        '
        ChartArea4.Name = "ChartArea1"
        Me.ChartC.ChartAreas.Add(ChartArea4)
        Me.ChartC.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ChartC.Dock = System.Windows.Forms.DockStyle.Fill
        Legend4.Name = "Legend1"
        Me.ChartC.Legends.Add(Legend4)
        Me.ChartC.Location = New System.Drawing.Point(368, 228)
        Me.ChartC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartC.Name = "ChartC"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.ChartC.Series.Add(Series4)
        Me.ChartC.Size = New System.Drawing.Size(360, 222)
        Me.ChartC.TabIndex = 5
        Me.ChartC.Text = "Chart1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DrawBarChartToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(166, 26)
        '
        'DrawBarChartToolStripMenuItem
        '
        Me.DrawBarChartToolStripMenuItem.Name = "DrawBarChartToolStripMenuItem"
        Me.DrawBarChartToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DrawBarChartToolStripMenuItem.Text = "Draw Bar Chart"
        '
        'ChartP
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartP.ChartAreas.Add(ChartArea1)
        Me.ChartP.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ChartP.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.ChartP.Legends.Add(Legend1)
        Me.ChartP.Location = New System.Drawing.Point(3, 228)
        Me.ChartP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartP.Name = "ChartP"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartP.Series.Add(Series1)
        Me.ChartP.Size = New System.Drawing.Size(359, 222)
        Me.ChartP.TabIndex = 4
        Me.ChartP.Text = "Chart1"
        '
        'DataGridViewHistogram
        '
        Me.DataGridViewHistogram.AllowUserToAddRows = False
        Me.DataGridViewHistogram.AllowUserToDeleteRows = False
        Me.DataGridViewHistogram.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewHistogram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewHistogram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewHistogram.Location = New System.Drawing.Point(3, 2)
        Me.DataGridViewHistogram.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewHistogram.Name = "DataGridViewHistogram"
        Me.DataGridViewHistogram.ReadOnly = True
        Me.DataGridViewHistogram.Size = New System.Drawing.Size(359, 222)
        Me.DataGridViewHistogram.TabIndex = 2
        '
        'ChartT
        '
        ChartArea2.Name = "ChartArea1"
        Me.ChartT.ChartAreas.Add(ChartArea2)
        Me.ChartT.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ChartT.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.ChartT.Legends.Add(Legend2)
        Me.ChartT.Location = New System.Drawing.Point(368, 2)
        Me.ChartT.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartT.Name = "ChartT"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartT.Series.Add(Series2)
        Me.ChartT.Size = New System.Drawing.Size(360, 222)
        Me.ChartT.TabIndex = 3
        Me.ChartT.Text = "Chart1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1121, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateAnalysisReportToolStripMenuItem, Me.HEX2DECToolStripMenuItem, Me.DEC2HEXToolStripMenuItem, Me.DebugModeToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(52, 21)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'GenerateAnalysisReportToolStripMenuItem
        '
        Me.GenerateAnalysisReportToolStripMenuItem.Name = "GenerateAnalysisReportToolStripMenuItem"
        Me.GenerateAnalysisReportToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.GenerateAnalysisReportToolStripMenuItem.Text = "Generate Analysis Report"
        '
        'HEX2DECToolStripMenuItem
        '
        Me.HEX2DECToolStripMenuItem.Checked = True
        Me.HEX2DECToolStripMenuItem.CheckOnClick = True
        Me.HEX2DECToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HEX2DECToolStripMenuItem.Name = "HEX2DECToolStripMenuItem"
        Me.HEX2DECToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.HEX2DECToolStripMenuItem.Text = "HEX"
        '
        'DEC2HEXToolStripMenuItem
        '
        Me.DEC2HEXToolStripMenuItem.CheckOnClick = True
        Me.DEC2HEXToolStripMenuItem.Name = "DEC2HEXToolStripMenuItem"
        Me.DEC2HEXToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.DEC2HEXToolStripMenuItem.Text = "DEC"
        '
        'DebugModeToolStripMenuItem
        '
        Me.DebugModeToolStripMenuItem.Name = "DebugModeToolStripMenuItem"
        Me.DebugModeToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.DebugModeToolStripMenuItem.Text = "Debug Mode"
        '
        'Form_ReadinfoEPPROM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 562)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form_ReadinfoEPPROM"
        Me.Text = "Read informations in EEPROM"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridViewDiagnostic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.DataGridViewRingBuffer2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewRingBuffer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.ChartC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ChartP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewHistogram, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ButtonReadAll As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridViewDiagnostic As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents DataGridViewRingBuffer1 As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents UserControl_ParameterPropertiesHitogram As UserControl_ParameterProperties
    Friend WithEvents DataGridViewHistogram As DataGridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ChartC As DataVisualization.Charting.Chart
    Friend WithEvents ChartP As DataVisualization.Charting.Chart
    Friend WithEvents ChartT As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents DataGridViewRingBuffer2 As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DrawBarChartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateAnalysisReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HEX2DECToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DEC2HEXToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DebugModeToolStripMenuItem As ToolStripMenuItem
End Class
