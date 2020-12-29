<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CANBUS_config
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_CANBUS_config))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxIDACTCOMMADN = New System.Windows.Forms.TextBox()
        Me.TextBoxIDTool2ACT = New System.Windows.Forms.TextBox()
        Me.TextBoxCycleTimeACT_command = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.ButtonActive = New System.Windows.Forms.Button()
        Me.LabelActive = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Act_Command"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID Tool2Act"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cycle Time Act_Command(ms)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 12)
        Me.Label4.TabIndex = 3
        '
        'TextBoxIDACTCOMMADN
        '
        Me.TextBoxIDACTCOMMADN.Location = New System.Drawing.Point(223, 31)
        Me.TextBoxIDACTCOMMADN.Name = "TextBoxIDACTCOMMADN"
        Me.TextBoxIDACTCOMMADN.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxIDACTCOMMADN.TabIndex = 4
        '
        'TextBoxIDTool2ACT
        '
        Me.TextBoxIDTool2ACT.Location = New System.Drawing.Point(223, 66)
        Me.TextBoxIDTool2ACT.Name = "TextBoxIDTool2ACT"
        Me.TextBoxIDTool2ACT.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxIDTool2ACT.TabIndex = 5
        '
        'TextBoxCycleTimeACT_command
        '
        Me.TextBoxCycleTimeACT_command.Location = New System.Drawing.Point(223, 105)
        Me.TextBoxCycleTimeACT_command.Name = "TextBoxCycleTimeACT_command"
        Me.TextBoxCycleTimeACT_command.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxCycleTimeACT_command.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(183, 219)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Apply"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(273, 219)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(74, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Location = New System.Drawing.Point(26, 145)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(41, 12)
        Me.LabelInfo.TabIndex = 9
        Me.LabelInfo.Text = "Label5"
        '
        'ButtonActive
        '
        Me.ButtonActive.Location = New System.Drawing.Point(221, 169)
        Me.ButtonActive.Name = "ButtonActive"
        Me.ButtonActive.Size = New System.Drawing.Size(125, 23)
        Me.ButtonActive.TabIndex = 10
        Me.ButtonActive.Text = "Activate"
        Me.ButtonActive.UseVisualStyleBackColor = True
        '
        'LabelActive
        '
        Me.LabelActive.AutoSize = True
        Me.LabelActive.Location = New System.Drawing.Point(24, 179)
        Me.LabelActive.Name = "LabelActive"
        Me.LabelActive.Size = New System.Drawing.Size(185, 12)
        Me.LabelActive.TabIndex = 11
        Me.LabelActive.Text = "Software Status: not activated"
        '
        'Form_CANBUS_config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 265)
        Me.Controls.Add(Me.LabelActive)
        Me.Controls.Add(Me.ButtonActive)
        Me.Controls.Add(Me.LabelInfo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBoxCycleTimeACT_command)
        Me.Controls.Add(Me.TextBoxIDTool2ACT)
        Me.Controls.Add(Me.TextBoxIDACTCOMMADN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_CANBUS_config"
        Me.Text = "CAN Bus Configuration of CANBOZ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxIDACTCOMMADN As TextBox
    Friend WithEvents TextBoxIDTool2ACT As TextBox
    Friend WithEvents TextBoxCycleTimeACT_command As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents LabelInfo As Label
    Friend WithEvents ButtonActive As Button
    Friend WithEvents LabelActive As Label
End Class
