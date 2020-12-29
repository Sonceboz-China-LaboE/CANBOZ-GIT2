<Serializable> Public Class CANMAX

    Public m_CANMatrix As CAN_Matrix

    Public m_FeedBack As FeedbackResults



    Public Sub New(CANAM As CAN_Matrix, feed As FeedbackResults, parentForm As Form1)

        m_CANMatrix = CANAM
        m_FeedBack = feed

        'parentForm.m_CANMatrix = CANAM
        'parentForm.m_FeedBackResults = feed
    End Sub

    Public Sub New()

    End Sub

End Class
