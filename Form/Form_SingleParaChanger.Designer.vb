<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SingleParaChanger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SingleParaChanger))
        Me.UserControl_ParameterProperties1 = New UserControl_ParameterProperties()
        Me.SuspendLayout()
        '
        'UserControl_ParameterProperties1
        '
        Me.UserControl_ParameterProperties1.DataSource = Nothing
        Me.UserControl_ParameterProperties1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserControl_ParameterProperties1.HasEditingError = False
        Me.UserControl_ParameterProperties1.IsForceMode = False
        Me.UserControl_ParameterProperties1.Ismodifiabble = False
        Me.UserControl_ParameterProperties1.Location = New System.Drawing.Point(0, 0)
        Me.UserControl_ParameterProperties1.Name = "UserControl_ParameterProperties1"
        Me.UserControl_ParameterProperties1.Size = New System.Drawing.Size(499, 328)
        Me.UserControl_ParameterProperties1.TabIndex = 0
        '
        'Form_SingleParaChanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 328)
        Me.Controls.Add(Me.UserControl_ParameterProperties1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_SingleParaChanger"
        Me.Text = "Singer Parameters Modifier"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserControl_ParameterProperties1 As UserControl_ParameterProperties
End Class
