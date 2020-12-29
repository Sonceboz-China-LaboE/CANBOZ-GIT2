Public Class Form_SingleParaChanger

    Private m_DataSource As ParameterProperty
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    Public Property DataSource()
        Get
            Return m_DataSource
        End Get
        Set(value)
            If value IsNot Nothing Then
                m_DataSource = value
                Me.UserControl_ParameterProperties1.DataSource = value
            End If

        End Set
    End Property


End Class