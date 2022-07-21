
Partial Class Dashboard_AddProduct
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '
        Dim Action As New Software.BLL.Product
        Dim ImageName As String = String.Empty
        Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Product/")

        'TODO : بررسی فایل
        If fuProductImage.HasFile Then
            ImageName = Portal.Utilities.GenerateFileName(fuProductImage.FileName)
            fuProductImage.SaveAs(strServerPath & ImageName)
        Else
            Exit Sub
        End If

        Dim bolResult As Boolean = Action.Insert(txtTitle.Text.Trim(), ImageName, txtPrice.Text.Trim(), txtLink.Text.Trim())
        If bolResult = True Then
            ucMessageBox1.Message = "اطلاعات مورد نظر با موفقیت ذخیره گردید."
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
        Else
            ucMessageBox1.Message = "خطا در درج! لطفا دوباره تلاش کنید"
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
        End If
        Call ClearForm()
        '
    End Sub

    Private Sub ClearForm()
        txtTitle.Text = String.Empty
        txtPrice.Text = String.Empty
        txtLink.Text = String.Empty
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ucMessageBox1.Message = ""
    End Sub

End Class
