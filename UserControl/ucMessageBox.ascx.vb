
Partial Class UserControl_ucMessageBox
    Inherits System.Web.UI.UserControl

    Enum MessageType
        Info
        Success
        Warning
        ErrorMsg
        Validation
    End Enum

    Dim _Message As String = String.Empty
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            litMsg.Text = value
            Me.Visible = True
        End Set
    End Property

    Dim _Type As MessageType
    Public Property Type() As MessageType
        Get
            Return _Type
        End Get
        Set(ByVal value As MessageType)
            Select Case value
                Case MessageType.Info
                    WebMsgBox.Attributes.Add("class", "info")
                Case MessageType.Success
                    WebMsgBox.Attributes.Add("class", "success")
                Case MessageType.Warning
                    WebMsgBox.Attributes.Add("class", "warning")
                Case MessageType.ErrorMsg
                    WebMsgBox.Attributes.Add("class", "error")
                Case MessageType.Validation
                    WebMsgBox.Attributes.Add("class", "validation")
            End Select
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If _Message.Trim() = String.Empty Then
            Me.Visible = False
        End If
    End Sub

End Class
