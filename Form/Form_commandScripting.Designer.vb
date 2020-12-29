<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_commandScripting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_commandScripting))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonScript4 = New System.Windows.Forms.Button()
        Me.LabelConnectionStatus = New System.Windows.Forms.Label()
        Me.ButtonScript1 = New System.Windows.Forms.Button()
        Me.ButtonScript2 = New System.Windows.Forms.Button()
        Me.ButtonScript3 = New System.Windows.Forms.Button()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonSmallMove = New System.Windows.Forms.Button()
        Me.ButtonSmallMoveUP = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ChartPosition = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ChartTempureture = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartMotorEffort = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonExportData = New System.Windows.Forms.Button()
        Me.ButtonRecord = New System.Windows.Forms.Button()
        Me.TimerConnectionSataus = New System.Windows.Forms.Timer(Me.components)
        Me.TimerFleshChart = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRecord = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CustomizeScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.ChartPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.ChartTempureture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartMotorEffort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1035, 409)
        Me.SplitContainer1.SplitterDistance = 343
        Me.SplitContainer1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.24242!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.75758!))
        Me.TableLayoutPanel1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonScript4, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelConnectionStatus, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonScript1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonScript2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonScript3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonStop, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSmallMove, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSmallMoveUP, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.56097!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.43903!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(343, 409)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonScript4
        '
        Me.ButtonScript4.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonScript4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonScript4.Location = New System.Drawing.Point(171, 195)
        Me.ButtonScript4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonScript4.Name = "ButtonScript4"
        Me.ButtonScript4.Size = New System.Drawing.Size(169, 108)
        Me.ButtonScript4.TabIndex = 5
        Me.ButtonScript4.Text = "Full Stroke(Slow)"
        Me.ButtonScript4.UseVisualStyleBackColor = False
        '
        'LabelConnectionStatus
        '
        Me.LabelConnectionStatus.AutoSize = True
        Me.LabelConnectionStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LabelConnectionStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelConnectionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConnectionStatus.Location = New System.Drawing.Point(3, 0)
        Me.LabelConnectionStatus.Name = "LabelConnectionStatus"
        Me.LabelConnectionStatus.Size = New System.Drawing.Size(162, 92)
        Me.LabelConnectionStatus.TabIndex = 0
        Me.LabelConnectionStatus.Text = "Label1"
        Me.LabelConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonScript1
        '
        Me.ButtonScript1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonScript1.Location = New System.Drawing.Point(171, 2)
        Me.ButtonScript1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonScript1.Name = "ButtonScript1"
        Me.ButtonScript1.Size = New System.Drawing.Size(169, 88)
        Me.ButtonScript1.TabIndex = 1
        Me.ButtonScript1.Text = "Sinus"
        Me.ButtonScript1.UseVisualStyleBackColor = True
        '
        'ButtonScript2
        '
        Me.ButtonScript2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonScript2.Location = New System.Drawing.Point(3, 94)
        Me.ButtonScript2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonScript2.Name = "ButtonScript2"
        Me.ButtonScript2.Size = New System.Drawing.Size(162, 97)
        Me.ButtonScript2.TabIndex = 3
        Me.ButtonScript2.Text = "Sinus Slow"
        Me.ButtonScript2.UseVisualStyleBackColor = True
        '
        'ButtonScript3
        '
        Me.ButtonScript3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonScript3.Location = New System.Drawing.Point(3, 195)
        Me.ButtonScript3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonScript3.Name = "ButtonScript3"
        Me.ButtonScript3.Size = New System.Drawing.Size(162, 108)
        Me.ButtonScript3.TabIndex = 4
        Me.ButtonScript3.Text = "Full Stroke(Fast)"
        Me.ButtonScript3.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonStop.Location = New System.Drawing.Point(171, 307)
        Me.ButtonStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(169, 100)
        Me.ButtonStop.TabIndex = 7
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonSmallMove
        '
        Me.ButtonSmallMove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSmallMove.Location = New System.Drawing.Point(171, 94)
        Me.ButtonSmallMove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonSmallMove.Name = "ButtonSmallMove"
        Me.ButtonSmallMove.Size = New System.Drawing.Size(169, 97)
        Me.ButtonSmallMove.TabIndex = 8
        Me.ButtonSmallMove.Text = "Small Move Low"
        Me.ButtonSmallMove.UseVisualStyleBackColor = True
        '
        'ButtonSmallMoveUP
        '
        Me.ButtonSmallMoveUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSmallMoveUP.Location = New System.Drawing.Point(3, 308)
        Me.ButtonSmallMoveUP.Name = "ButtonSmallMoveUP"
        Me.ButtonSmallMoveUP.Size = New System.Drawing.Size(162, 98)
        Me.ButtonSmallMoveUP.TabIndex = 9
        Me.ButtonSmallMoveUP.Text = "Small Move High"
        Me.ButtonSmallMoveUP.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.SplitContainer2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.3242!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.675799!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(688, 409)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 2)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChartPosition)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(682, 369)
        Me.SplitContainer2.SplitterDistance = 422
        Me.SplitContainer2.TabIndex = 0
        '
        'ChartPosition
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartPosition.ChartAreas.Add(ChartArea1)
        Me.ChartPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.ChartPosition.Legends.Add(Legend1)
        Me.ChartPosition.Location = New System.Drawing.Point(0, 0)
        Me.ChartPosition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartPosition.Name = "ChartPosition"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartPosition.Series.Add(Series1)
        Me.ChartPosition.Size = New System.Drawing.Size(422, 369)
        Me.ChartPosition.TabIndex = 0
        Me.ChartPosition.Text = "Chart1"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ChartTempureture)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.ChartMotorEffort)
        Me.SplitContainer3.Size = New System.Drawing.Size(256, 369)
        Me.SplitContainer3.SplitterDistance = 175
        Me.SplitContainer3.TabIndex = 0
        '
        'ChartTempureture
        '
        ChartArea2.Name = "ChartArea1"
        Me.ChartTempureture.ChartAreas.Add(ChartArea2)
        Me.ChartTempureture.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.ChartTempureture.Legends.Add(Legend2)
        Me.ChartTempureture.Location = New System.Drawing.Point(0, 0)
        Me.ChartTempureture.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartTempureture.Name = "ChartTempureture"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartTempureture.Series.Add(Series2)
        Me.ChartTempureture.Size = New System.Drawing.Size(256, 175)
        Me.ChartTempureture.TabIndex = 0
        Me.ChartTempureture.Text = "Chart1"
        '
        'ChartMotorEffort
        '
        ChartArea3.Name = "ChartArea1"
        Me.ChartMotorEffort.ChartAreas.Add(ChartArea3)
        Me.ChartMotorEffort.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Name = "Legend1"
        Me.ChartMotorEffort.Legends.Add(Legend3)
        Me.ChartMotorEffort.Location = New System.Drawing.Point(0, 0)
        Me.ChartMotorEffort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartMotorEffort.Name = "ChartMotorEffort"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.ChartMotorEffort.Series.Add(Series3)
        Me.ChartMotorEffort.Size = New System.Drawing.Size(256, 190)
        Me.ChartMotorEffort.TabIndex = 0
        Me.ChartMotorEffort.Text = "Chart1"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.8982!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.1018!))
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonExportData, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonRecord, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 375)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(682, 32)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'ButtonExportData
        '
        Me.ButtonExportData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonExportData.Location = New System.Drawing.Point(350, 2)
        Me.ButtonExportData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonExportData.Name = "ButtonExportData"
        Me.ButtonExportData.Size = New System.Drawing.Size(329, 28)
        Me.ButtonExportData.TabIndex = 1
        Me.ButtonExportData.Text = "Export Excel"
        Me.ButtonExportData.UseVisualStyleBackColor = True
        '
        'ButtonRecord
        '
        Me.ButtonRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRecord.Location = New System.Drawing.Point(3, 2)
        Me.ButtonRecord.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonRecord.Name = "ButtonRecord"
        Me.ButtonRecord.Size = New System.Drawing.Size(341, 28)
        Me.ButtonRecord.TabIndex = 0
        Me.ButtonRecord.Text = "Record"
        Me.ButtonRecord.UseVisualStyleBackColor = True
        '
        'TimerConnectionSataus
        '
        Me.TimerConnectionSataus.Enabled = True
        '
        'TimerFleshChart
        '
        Me.TimerFleshChart.Enabled = True
        Me.TimerFleshChart.Interval = 20
        '
        'TimerRecord
        '
        Me.TimerRecord.Interval = 1000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeScriptToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 48)
        '
        'CustomizeScriptToolStripMenuItem
        '
        Me.CustomizeScriptToolStripMenuItem.Name = "CustomizeScriptToolStripMenuItem"
        Me.CustomizeScriptToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CustomizeScriptToolStripMenuItem.Text = "Customize Script"
        '
        'Form_commandScripting
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 409)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form_commandScripting"
        Me.Text = "Scripting and Monitor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.ChartPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.ChartTempureture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartMotorEffort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelConnectionStatus As Label
    Friend WithEvents ButtonScript1 As Button
    Friend WithEvents TimerConnectionSataus As Timer
    Friend WithEvents TimerFleshChart As Timer
    Friend WithEvents ButtonScript2 As Button
    Friend WithEvents ButtonScript3 As Button
    Friend WithEvents ChartPosition As DataVisualization.Charting.Chart
    Friend WithEvents ButtonScript4 As Button
    Friend WithEvents ButtonStop As Button
    Friend WithEvents ButtonSmallMove As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents ChartTempureture As DataVisualization.Charting.Chart
    Friend WithEvents ChartMotorEffort As DataVisualization.Charting.Chart
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents ButtonExportData As Button
    Friend WithEvents ButtonRecord As Button
    Friend WithEvents TimerRecord As Timer
    Friend WithEvents ButtonSmallMoveUP As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CustomizeScriptToolStripMenuItem As ToolStripMenuItem
End Class
