
Partial Class Management_Admin_admin_software_PostInFutureList
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostInFutureBLL As New Software.BLL.Post
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")

            Dim row As Data.DataRow = PostInFutureBLL.SelectRow(PostId).Rows(0)

            If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))

            PostInFutureBLL.Delete(PostId)
            gvPostList.DataBind()
            pnlEdit.Visible = False
            lblMessage.Visible = False
            '
        Catch ex As Exception
            'TODO : Log error
        End Try
        ''
    End Sub

    Protected Sub EditPost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostInFutureBLL As New Software.BLL.Post
            Dim row As Data.DataRow = PostInFutureBLL.SelectRow(PostId).Rows(0)

            pnlEdit.Visible = True
            lblMessage.Visible = False

            txtPostTitle.Text = row("Title").ToString()
            dllCategory.SelectedValue = row("CategoryId").ToString()
            txtDescBody.Text = row("Descfarsi").ToString()
            txtHyperlink.Text = row("Hyperlink").ToString()
            Image2.ImageUrl = "../Content/UserFiles/Images/Software/" + row("BigImageFilename").ToString()
            txtLocation.Text = row("LocationNumber").ToString()
            txtShowDate.Text = row("ShowDate").ToString()

            Session("CurrentPostId") = e.CommandArgument
            '
        Catch ex As Exception
            'TODO : Log error
        End Try
        ''
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEdit.Visible = False
        lblMessage.Visible = False
    End Sub

    Protected Sub btnSavePost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSavePost.Click
        '
        Try
            Dim PostInFutureBLL As New Software.BLL.Post
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")
            Dim row As Data.DataRow = PostInFutureBLL.SelectRow(CInt(Session("CurrentPostId"))).Rows(0)

            Dim ImageName As String = row("BigImageFilename")

            If FileUpload1.HasFile Then
                ImageName = Portal.Utilities.GenerateFileName(FileUpload1.FileName)
                FileUpload1.SaveAs(strServerPath & ImageName)
                If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))
            End If

            'Dim bolResult As Boolean = PostInFutureBLL.UpdatePost2(CInt(Session("CurrentPostId")), txtPostTitle.Text.Trim(), dllCategory.SelectedValue, txtDescBody.Value.Trim(), ImageName, txtLocation.Text.Trim(), txtHyperlink.Text.Trim, chkFlag.Checked)
            Dim bolResult As Boolean = PostInFutureBLL.UpdatePost2(CInt(Session("CurrentPostId")), txtPostTitle.Text.Trim(), dllCategory.SelectedValue, txtDescBody.Text.Trim(), ImageName, txtLocation.Text.Trim(), txtHyperlink.Text.Trim, chkFlag.Checked, txtShowDate.Text.Trim())
            If bolResult = True Then
                lblMessage.Text = "با موفقیت ذخیره گردید."
            Else
                lblMessage.Text = "خطا در درج پست"
            End If
            gvPostList.DataBind()
            Call ClearForm()
            pnlEdit.Visible = False
            lblMessage.Visible = True
        Catch ex As Exception
            lblMessage.Text = "خطا در درج پست"
        End Try
        ''
    End Sub

    Private Sub ClearForm()
        txtPostTitle.Text = String.Empty
        txtDescBody.Text = String.Empty
        txtHyperlink.Text = String.Empty
        txtLocation.Text = String.Empty
    End Sub

End Class