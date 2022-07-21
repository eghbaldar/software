
Partial Class Management_Admin_admin_software_AdsList
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostBLL As New Software.BLL.Post

            PostBLL.Delete(PostId)
            gvPostList.DataBind()
            pnlEdit.Visible = False
            lblMessage.Visible = False
        Catch ex As Exception
            'TODO : Log error
        End Try
        ''
    End Sub

    Protected Sub EditPost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostBLL As New Software.BLL.Post
            Dim row As Data.DataRow = PostBLL.SelectRow(PostId).Rows(0)

            pnlEdit.Visible = True
            lblMessage.Visible = False

            txtPostTitle.Text = row("Title")
            txtAdsLid.Text = row("LidFarsi")
            txtAdsBody.Text = row("Descfarsi")
            txtLocation.Text = row("LocationNumber")
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
            Dim PostBll As New Software.BLL.Post
            Dim row As Data.DataRow = PostBll.SelectRow(CInt(Session("CurrentPostId"))).Rows(0)

            Dim bolResult As Boolean = PostBll.UpdateAds(CInt(Session("CurrentPostId")), txtPostTitle.Text.Trim(), txtAdsLid.Text.Trim(), txtAdsBody.Text.Trim(), txtLocation.Text.Trim(), chkFlag.Checked)
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
        '
    End Sub

    Private Sub ClearForm()
        txtPostTitle.Text = String.Empty
        txtAdsLid.Text = String.Empty
        txtAdsBody.Text = String.Empty
        txtLocation.Text = String.Empty
    End Sub

End Class
