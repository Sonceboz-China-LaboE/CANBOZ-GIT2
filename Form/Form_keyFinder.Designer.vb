<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_keyFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_keyFinder))
        Me.UserControl_KeyFinder1 = New UserControl_KeyFinder()
        Me.SuspendLayout()
        '
        'UserControl_KeyFinder1
        '
        Me.UserControl_KeyFinder1.DataSource = Nothing
        Me.UserControl_KeyFinder1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserControl_KeyFinder1.Location = New System.Drawing.Point(0, 0)
        Me.UserControl_KeyFinder1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.UserControl_KeyFinder1.Name = "UserControl_KeyFinder1"
        Me.UserControl_KeyFinder1.Size = New System.Drawing.Size(710, 397)
        Me.UserControl_KeyFinder1.TabIndex = 0
        '
        'Form_keyFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 397)
        Me.Controls.Add(Me.UserControl_KeyFinder1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form_keyFinder"
        Me.Text = "Key Finder"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserControl_KeyFinder1 As UserControl_KeyFinder
End Class
