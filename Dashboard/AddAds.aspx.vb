
Partial Class Management_Admin_admin_software_AddAds
    Inherits System.Web.UI.Page

    Protected Sub btnSaveAds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveAds.Click
        '
        Try
            Dim bolResult As Boolean
            Dim intLocation As Integer
            Dim ImageName As String

            Integer.TryParse(txtLocation.Text.Trim(), intLocation)
            If intLocation = 0 Then intLocation = -1

            If fuAdsPicture.HasFile Then
                Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")
                ImageName = Portal.Utilities.GenerateFileName(fuAdsPicture.FileName)
                fuAdsPicture.SaveAs(strServerPath & ImageName)
            End If

            'نمایش در آینده
            If chkShowInfuture.Checked Then
                'Dim PostInFutureBll As New Software.BLL.PostInFuture
                'bolResult = PostInFutureBll.InsertAds(txtPostTitle.Text.Trim(), txtAdsLid.Text.Trim(), txtAdsBody.Text.Trim(), ImageName, intLocation, chkVisiblePost.Checked, txtShowDate.Text.Trim)
            Else
                Dim PostBll As New Software.BLL.Post
                'TODO : 'bolResult = PostBll.InsertAds(txtPostTitle.Text.Trim(), txtAdsLid.Text.Trim(), txtAdsBody.Text.Trim(), ImageName, intLocation, chkVisiblePost.Checked)
            End If

            If bolResult = True Then
                lblMessage.Text = "پست جدید با موفقیت ذخیره گردید."
            Else
                lblMessage.Text = "خطا در درج پست"
            End If
            gvPostList.DataBind()
            Call ClearForm()
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
