
Partial Class Ads
    Inherits System.Web.UI.Page

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim action As New Software.BLL.Contact
        Dim blnResult As Boolean = action.Insert(txtFn.Text.Trim(), txtEmail.Text.Trim(), txtNote.Text.Trim())
        If blnResult Then
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
            ucMessageBox1.Message = "پیام شما با موفقیت ارسال گردید."
            Call ClearForm()
        Else
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در ارسال پیام! دوباره تلاش کنید."
        End If

    End Sub

    Private Sub ClearForm()
        txtFn.Text = String.Empty
        txtEmail.Text = String.Empty
        txtNote.Text = String.Empty
    End Sub

End Class
