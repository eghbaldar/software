
Partial Class Management_Admin_admin_software_AddNews
    Inherits System.Web.UI.Page


    Protected Sub btnSaveNews_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveNews.Click
        '
        'Try
        Dim NewsBll As New Software.BLL.News
        Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/News/")
        Dim ImageName(3) As String

        If FileUpload1.HasFile Then ImageName(0) = Portal.Utilities.GenerateFileName(FileUpload1.FileName)
        If FileUpload2.HasFile Then ImageName(1) = Portal.Utilities.GenerateFileName(FileUpload2.FileName)
        If FileUpload3.HasFile Then ImageName(2) = Portal.Utilities.GenerateFileName(FileUpload3.FileName)
        If FileUpload4.HasFile Then ImageName(3) = Portal.Utilities.GenerateFileName(FileUpload4.FileName)

        If FileUpload1.HasFile Then FileUpload1.SaveAs(strServerPath & ImageName(0))
        If FileUpload2.HasFile Then FileUpload2.SaveAs(strServerPath & ImageName(1))
        If FileUpload3.HasFile Then FileUpload3.SaveAs(strServerPath & ImageName(2))
        If FileUpload4.HasFile Then FileUpload4.SaveAs(strServerPath & ImageName(3))


        ''TODO : نام کاربر در قسمت زیر وارد شود
        Dim Username As String = ""
        Dim bolResult As Boolean = NewsBll.Insert(txtNewsTitle.Text.Trim, txtNewsLid.Text.Trim, txtNewsBody.Text.Trim, rblShowStatus.SelectedValue, Username, ImageName(0), ImageName(1), ImageName(2), ImageName(3))
        If bolResult = True Then
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
            ucMessageBox1.Message = "خبر جدید با موفقیت ذخیره گردید."
        Else
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در درج خبر"
        End If
        gvNewsList.DataBind()
        Call ClearForm()
        'Catch ex As Exception
        'lblMessage.Text = "خطا در درج خبر"
        'lblMessage.Text = ex.Message
        'End Try
        ''
    End Sub

    Private Sub ClearForm()
        txtNewsTitle.Text = String.Empty
        txtNewsLid.Text = String.Empty
        txtNewsBody.Text = String.Empty
        rblShowStatus.SelectedIndex = 0
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvNewsList.Rows.Count > 0 Then gvNewsList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class