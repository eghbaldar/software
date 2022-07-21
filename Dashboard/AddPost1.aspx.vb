
Partial Class Management_Admin_admin_software_AddPost1
    Inherits System.Web.UI.Page


    Protected Sub btnSaveAds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveAds.Click
        '
        Try
            Dim bolResult As Boolean

            Dim intLocation As Integer
            Integer.TryParse(txtLocation.Text.Trim(), intLocation)
            If intLocation = 0 Then intLocation = -1


            Dim ImageFileName As String = String.Empty
            If fuBigImageFileName.HasFile Then
                Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Software/")
                ImageFileName = Portal.Utilities.GenerateFileName(fuBigImageFileName.FileName)
                fuBigImageFileName.SaveAs(strServerPath & ImageFileName)
            End If

            Dim LearningFileName As String = txtLearningFile.Text
            'If fuLearningFile.HasFile Then
            '    Dim strServerPath As String = Server.MapPath("../../Content/LearningFile/")
            '    LearningFileName = GenerateFileName(fuLearningFile.FileName)
            '    fuLearningFile.SaveAs(strServerPath & LearningFileName)
            'End If

            'نمایش در زمان آینده
            'If chkShowInfuture.Checked Then
            'Dim PostInFutureBll As New Software.BLL.PostInFuture
            'bolResult = PostInFutureBll.InsertPost1(txtPostTitle.Text.Trim(), ddlCategory.SelectedValue, txtLidFarsi.Text.Trim(), txtBodyFarsi.Text.Trim(), chkHaveBodyEng.Checked, txtBodyEng.Text.Trim(), chkSoftwareFullName.Checked, txtSoftwareFullName.Text.Trim(), chkVersion.Checked, txtVersion.Text.Trim(), chkFactorySite.Checked, txtFactorySite.Text.Trim(), chkDatePublish.Checked, txtDatePublish.Text.Trim(), txtFileSize.Text.Trim(), chkProductPrice.Checked, txtProductPrice.Text.Trim(), ImageFileName, chkLearningFile.Checked, LearningFileName, intLocation, False, txtShowDate.Text.Trim)
            'Else
            Dim PostBll As New Software.BLL.Post
            bolResult = PostBll.InsertPost1(txtPostTitle.Text.Trim(), ddlCategory.SelectedValue, txtLidFarsi.Text.Trim(), txtBodyFarsi.Text.Trim(), chkHaveBodyEng.Checked, txtBodyEng.Text.Trim(), chkSoftwareFullName.Checked, txtSoftwareFullName.Text.Trim(), chkVersion.Checked, txtVersion.Text.Trim(), chkFactorySite.Checked, txtFactorySite.Text.Trim(), chkDatePublish.Checked, txtDatePublish.Text.Trim(), txtFileSize.Text.Trim(), chkProductPrice.Checked, txtProductPrice.Text.Trim(), ImageFileName, chkLearningFile.Checked, LearningFileName, intLocation, chkVisiblePost.Checked, txtShowDate.Text.Trim)
            'End If


            If bolResult = True Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "پست جدید با موفقیت ذخیره گردید."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا در درج پست"
            End If
            gvPostList.DataBind()
            Call ClearForm()
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در درج پست"
        End Try
        '
    End Sub

    Private Sub ClearForm()
        '
        txtLidFarsi.Text = String.Empty
        txtBodyEng.Text = String.Empty
        txtBodyFarsi.Text = String.Empty

        Portal.Utilities.ClearForm(Me)
        '
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Dim JavaCommand As String = "enableField('{0}')"
        Dim jc As String = "fnenable({0}, '{1}')"

        chkHaveBodyEng.Attributes.Add("onclick", String.Format(jc, chkHaveBodyEng.ClientID, txtBodyEng.ClientID))
        chkSoftwareFullName.Attributes.Add("onclick", String.Format(JavaCommand, txtSoftwareFullName.ClientID))
        chkVersion.Attributes.Add("onclick", String.Format(JavaCommand, txtVersion.ClientID))
        chkFactorySite.Attributes.Add("onclick", String.Format(JavaCommand, txtFactorySite.ClientID))
        chkDatePublish.Attributes.Add("onclick", String.Format(JavaCommand, txtDatePublish.ClientID))
        chkProductPrice.Attributes.Add("onclick", String.Format(JavaCommand, txtProductPrice.ClientID))
        chkLearningFile.Attributes.Add("onclick", String.Format(JavaCommand, txtLearningFile.ClientID))
        chkShowInfuture.Attributes.Add("onclick", String.Format(JavaCommand, txtShowDate.ClientID))
        '
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvPostList.Rows.Count > 0 Then gvPostList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
