'
' Created by SharpDevelop.
' User: lzh
' Date: 8/7/2018
' Time: 12:40 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class Form_ForceReleaseChannel
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ForceReleaseChannel))
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.listBox1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.label1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.button1, 0, 2)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 3
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2449!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.7551!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(543, 496)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'listBox1
        '
        Me.listBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listBox1.FormattingEnabled = True
        Me.listBox1.ItemHeight = 15
        Me.listBox1.Location = New System.Drawing.Point(4, 58)
        Me.listBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(535, 391)
        Me.listBox1.TabIndex = 0
        '
        'label1
        '
        Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(4, 0)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(535, 55)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Choose one Channel to release"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'button1
        '
        Me.button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.button1.Location = New System.Drawing.Point(4, 455)
        Me.button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(535, 38)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Release"
        Me.button1.UseVisualStyleBackColor = True
        '
        'Form_ForceReleaseChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 496)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Form_ForceReleaseChannel"
        Me.Text = "Force Release Channel"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private button1 As System.Windows.Forms.Button
	Private label1 As System.Windows.Forms.Label
	Private listBox1 As System.Windows.Forms.ListBox
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
