
Partial Class Dashboard_AddBestSoftware
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '
        Dim Action As New Software.BLL.BestSoftware
        Dim ImageName As String = String.Empty
        Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/SoftwareIcon/")

        If fuSoftwareIcon.HasFile Then
            ImageName = Portal.Utilities.GenerateFileName(fuSoftwareIcon.FileName)
            fuSoftwareIcon.SaveAs(strServerPath & ImageName)
        Else
            Exit Sub
        End If

        Dim bolResult As Boolean = Action.Insert(txtTitle.Text.Trim(), ImageName, txtDesc.Text.Trim(), txtLink.Text.Trim())
        If bolResult = True Then
            ucMessageBox1.Message = "اطلاعات مورد نظر با موفقیت ذخیره گردید."
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
        Else
            ucMessageBox1.Message = "خطا در درج! لطفا دوباره تلاش کنید"
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
        End If
        '            gvNewsList.DataBind()
        Call ClearForm()
        ''
    End Sub

    Private Sub ClearForm()
        txtTitle.Text = String.Empty
        txtDesc.Text = String.Empty
        txtLink.Text = String.Empty
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ucMessageBox1.Message = ""
    End Sub

End Class
