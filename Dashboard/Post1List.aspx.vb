
Partial Class Management_Admin_admin_software_Post1List
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim PostId As Integer = CInt(e.CommandArgument)
            Dim PostBLL As New Software.BLL.Post
            Dim strServerPath As String

            Dim row As Data.DataRow = PostBLL.SelectRow(PostId).Rows(0)

            strServerPath = Server.MapPath("../Content/UserFiles/Images/Software/")
            If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))

            'strServerPath = Server.MapPath("../../Content/LearningFile/")
            'If IO.File.Exists(strServerPath & row("LearningFileName")) Then IO.File.Delete(strServerPath & row("LearningFileName"))

            PostBLL.Delete(PostId)
            gvPostList.DataBind()
            pnlEdit.Visible = False
            '
        Catch ex As Exception
            'Response.Write(ex.Message)
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
            Dim PostBLL As New Software.BLL.Post
            Dim row As Data.DataRow = PostBLL.SelectRow(PostId).Rows(0)

            pnlEdit.Visible = True

            txtPostTitle.Text = row("Title").ToString()
            ddlCategory.SelectedValue = row("CategoryId")
            txtLidFarsi.Text = row("LidFarsi").ToString()
            txtBodyFarsi.Text = row("DescFarsi").ToString()
            chkHaveBodyEng.Checked = CBool(row("HaveDescEnglish"))
            txtBodyEng.Text = row("DescEnglish").ToString()

            If CBool(row("HaveSoftwareFullname")) Then txtSoftwareFullName.Text = row("SoftwareFullName").ToString()
            chkSoftwareFullName.Checked = CBool(row("HaveSoftwareFullname"))
            txtSoftwareFullName.Enabled = CBool(row("HaveSoftwareFullname"))

            If CBool(row("HaveVersion")) Then txtVersion.Text = row("Version")
            chkVersion.Checked = CBool(row("HaveVersion"))
            txtVersion.Enabled = CBool(row("HaveVersion"))

            If CBool(row("HaveFactorySite")) Then txtFactorySite.Text = row("FactorySite")
            chkFactorySite.Checked = CBool(row("HaveFactorySite"))
            txtFactorySite.Enabled = CBool(row("HaveFactorySite"))

            If CBool(row("HaveDatePublish")) Then txtDatePublish.Text = row("DatePublish")
            chkDatePublish.Checked = CBool(row("HaveDatePublish"))
            txtDatePublish.Enabled = CBool(row("HaveDatePublish"))

            txtFileSize.Text = row("FileSize")

            If CBool(row("HaveProductPrice")) Then txtProductPrice.Text = row("ProductPrice")
            chkProductPrice.Checked = CBool(row("HaveProductPrice"))
            txtProductPrice.Enabled = CBool(row("HaveProductPrice"))

            If row("BigImageFilename").ToString() <> String.Empty Then
                imgBigImageFileName.ImageUrl = "../Content/UserFiles/Images/Software/" + row("BigImageFilename").ToString()
                btnDeleteImage.Visible = True
            Else
                imgBigImageFileName.ImageUrl = ""
                btnDeleteImage.Visible = False
            End If


            If CBool(row("HaveLearningFile")) Then txtLearningFile.Text = row("LearningFileName").ToString()
            chkLearningFile.Checked = CBool(row("HaveLearningFile"))
            txtLearningFile.Enabled = CBool(row("HaveLearningFile"))

            txtLocation.Text = row("LocationNumber")
            chkVisiblePost.Checked = row("VisiblePost")

            Session("CurrentPostId") = e.CommandArgument
            '
        Catch ex As Exception
            'TODO : Log error
            MsgBox(ex.Message)
        End Try
        ''
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEdit.Visible = False
    End Sub

    Protected Sub btnSavePost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSavePost.Click
        '
        Try
            Dim PostBll As New Software.BLL.Post
            Dim strServerPath As String
            Dim row As Data.DataRow = PostBll.SelectRow(CInt(Session("CurrentPostId"))).Rows(0)

            Dim intLocation As Integer
            Integer.TryParse(txtLocation.Text.Trim(), intLocation)
            If intLocation = 0 Then intLocation = -1

            Dim ImageFielName As String = row("BigImageFilename")
            If fuBigImageFileName.HasFile Then
                strServerPath = Server.MapPath("../Content/UserFiles/Images/Software/")
                ImageFielName = Portal.Utilities.GenerateFileName(fuBigImageFileName.FileName)
                fuBigImageFileName.SaveAs(strServerPath & ImageFielName)
                If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))
            End If

            Dim LearningFileName As String = txtLearningFile.Text.Trim() ' row("LearningFileName").ToString()
            'If fuLearningFile.HasFile Then
            '    strServerPath = Server.MapPath("../../Content/LearningFile/")
            '    LearningFileName = GenerateFileName(fuLearningFile.FileName)
            '    fuLearningFile.SaveAs(strServerPath & LearningFileName)
            '    If IO.File.Exists(strServerPath & row("BigImageFilename")) Then IO.File.Delete(strServerPath & row("BigImageFilename"))
            'End If

            Dim bolResult As Boolean = PostBll.UpdatePost1(CInt(Session("CurrentPostId")), txtPostTitle.Text.Trim(), ddlCategory.SelectedValue, txtLidFarsi.Text.Trim(), txtBodyFarsi.Text.Trim(), chkHaveBodyEng.Checked, txtBodyEng.Text.Trim(), chkSoftwareFullName.Checked, txtSoftwareFullName.Text.Trim(), chkVersion.Checked, txtVersion.Text.Trim(), chkFactorySite.Checked, txtFactorySite.Text.Trim(), chkDatePublish.Checked, txtDatePublish.Text.Trim(), txtFileSize.Text.Trim(), chkProductPrice.Checked, txtProductPrice.Text.Trim(), ImageFielName, chkLearningFile.Checked, LearningFileName, intLocation, chkVisiblePost.Checked)
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

        chkHaveBodyEng.Attributes.Add("onclick", String.Format(JavaCommand, txtBodyEng.ClientID))
        chkSoftwareFullName.Attributes.Add("onclick", String.Format(JavaCommand, txtSoftwareFullName.ClientID))
        chkVersion.Attributes.Add("onclick", String.Format(JavaCommand, txtVersion.ClientID))
        chkFactorySite.Attributes.Add("onclick", String.Format(JavaCommand, txtFactorySite.ClientID))
        chkDatePublish.Attributes.Add("onclick", String.Format(JavaCommand, txtDatePublish.ClientID))
        chkProductPrice.Attributes.Add("onclick", String.Format(JavaCommand, txtProductPrice.ClientID))
        chkLearningFile.Attributes.Add("onclick", String.Format(JavaCommand, txtLearningFile.ClientID))
        chkShowInfuture.Attributes.Add("onclick", String.Format(JavaCommand, txtShowDate.ClientID))
        ''
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
