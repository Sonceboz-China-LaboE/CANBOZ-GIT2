<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartShowData
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ChartMain = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartAuxilary = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ChartMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartAuxilary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.90962!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.09038!))
        Me.TableLayoutPanel1.Controls.Add(Me.ChartMain, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ChartAuxilary, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonExport, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.50381!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.49618!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(686, 524)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ChartMain
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartMain.ChartAreas.Add(ChartArea1)
        Me.ChartMain.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.ChartMain.Legends.Add(Legend1)
        Me.ChartMain.Location = New System.Drawing.Point(3, 3)
        Me.ChartMain.Name = "ChartMain"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartMain.Series.Add(Series1)
        Me.ChartMain.Size = New System.Drawing.Size(453, 462)
        Me.ChartMain.TabIndex = 0
        Me.ChartMain.Text = "Chart1"
        '
        'ChartAuxilary
        '
        ChartArea2.Name = "ChartArea1"
        Me.ChartAuxilary.ChartAreas.Add(ChartArea2)
        Me.ChartAuxilary.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.ChartAuxilary.Legends.Add(Legend2)
        Me.ChartAuxilary.Location = New System.Drawing.Point(462, 3)
        Me.ChartAuxilary.Name = "ChartAuxilary"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartAuxilary.Series.Add(Series2)
        Me.ChartAuxilary.Size = New System.Drawing.Size(221, 462)
        Me.ChartAuxilary.TabIndex = 1
        Me.ChartAuxilary.Text = "Chart1"
        '
        'ButtonExport
        '
        Me.ButtonExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonExport.Location = New System.Drawing.Point(462, 471)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(221, 50)
        Me.ButtonExport.TabIndex = 2
        Me.ButtonExport.Text = "Export datas"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'ChartShowData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ChartShowData"
        Me.Size = New System.Drawing.Size(686, 524)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ChartMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartAuxilary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ChartMain As DataVisualization.Charting.Chart
    Friend WithEvents ChartAuxilary As DataVisualization.Charting.Chart
    Friend WithEvents ButtonExport As Button
End Class
