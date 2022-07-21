
Partial Class Management_Admin_admin_software_Post2List
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostBLL As New Software.BLL.Post
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")

            Dim row As Data.DataRow = PostBLL.SelectRow(PostId).Rows(0)

            If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))

            PostBLL.Delete(PostId)
            gvPostList.DataBind()
            pnlEdit.Visible = False
        Catch ex As Exception
            'TODO : Log error
        End Try
        '
    End Sub

    Protected Sub EditPost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostBLL As New Software.BLL.Post
            Dim row As Data.DataRow = PostBLL.SelectRow(PostId).Rows(0)

            pnlEdit.Visible = True

            txtPostTitle.Text = row("Title").ToString()
            dllCategory.SelectedValue = CInt(row("CategoryId"))
            txtDescBody.Text = row("LidFarsi").ToString()
            txtHyperlink.Text = row("Hyperlink").ToString()

            If row("BigImageFilename").ToString() <> String.Empty Then
                imgBigImageFileName.ImageUrl = "../Content/UserFiles/Images/Software/" + row("BigImageFilename").ToString()
                btnDeleteImage.Visible = True
            Else
                imgBigImageFileName.ImageUrl = ""
                btnDeleteImage.Visible = False
            End If

            txtLocation.Text = row("LocationNumber").ToString()
            txtShowDate.Text = row("ShowDate").ToString()
            chkFlag.Checked = CBool(row("VisiblePost"))

            Session("CurrentPostId") = e.CommandArgument
            '
        Catch ex As Exception
            'TODO : Log error
        End Try
        '
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEdit.Visible = False
    End Sub

    Protected Sub btnSavePost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSavePost.Click
        '
        Try
            Dim PostBll As New Software.BLL.Post
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")
            Dim row As Data.DataRow = PostBll.SelectRow(CInt(Session("CurrentPostId"))).Rows(0)

            Dim ImageName As String = row("BigImageFilename")

            If FileUpload1.HasFile Then
                ImageName = Portal.Utilities.GenerateFileName(FileUpload1.FileName)
                FileUpload1.SaveAs(strServerPath & ImageName)
                If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))
            End If

            Dim bolResult As Boolean = PostBll.UpdatePost2(CInt(Session("CurrentPostId")), txtPostTitle.Text.Trim(), dllCategory.SelectedValue, txtDescBody.Text.Trim(), ImageName, txtLocation.Text.Trim(), txtHyperlink.Text.Trim, chkFlag.Checked, txtShowDate.Text.Trim())
            If bolResult = True Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "با موفقیت ذخیره گردید."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا در درج پست"
            End If
            gvPostList.DataBind()
            Call ClearForm()
            pnlEdit.Visible = False
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در درج پست"
        End Try
        ''
    End Sub

    Private Sub ClearForm()
        txtPostTitle.Text = String.Empty
        txtDescBody.Text = String.Empty
        txtHyperlink.Text = String.Empty
        txtLocation.Text = String.Empty
    End Sub

    Protected Sub btnDeleteImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteImage.Click
        Try
            '
            Dim PostId As Integer = Session("CurrentPostId")
            Dim PostBLL As New Software.BLL.Post
            Dim strServerPath As String = Server.MapPath(imgBigImageFileName.ImageUrl)

            PostBLL.DeleteImage(PostId)
            If IO.File.Exists(strServerPath) Then IO.File.Delete(strServerPath)
            imgBigImageFileName.ImageUrl = ""
            btnDeleteImage.Visible = False
            '
        Catch ex As Exception
            'Response.Write(ex.Message)
            'TODO : Log error
        End Try
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvPostList.Rows.Count > 0 Then gvPostList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
