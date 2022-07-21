
Partial Class Management_Admin_admin_software_NewsList
    Inherits System.Web.UI.Page

    Protected Sub DeleteNews(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim NewsId As Integer = CInt(e.CommandArgument)
            Dim NewsBLL As New Software.BLL.News
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/News/")

            Dim row As Data.DataRow = NewsBLL.SelectRow(NewsId).Rows(0)

            If IO.File.Exists(strServerPath & row("BigImageName1")) Then IO.File.Delete(strServerPath & row("BigImageName1"))
            If IO.File.Exists(strServerPath & row("BigImageName2")) Then IO.File.Delete(strServerPath & row("BigImageName2"))
            If IO.File.Exists(strServerPath & row("BigImageName3")) Then IO.File.Delete(strServerPath & row("BigImageName3"))
            If IO.File.Exists(strServerPath & row("SmallImageName1")) Then IO.File.Delete(strServerPath & row("SmallImageName1"))

            NewsBLL.Delete(NewsId)
            gvNewsList.DataBind()
            pnlEdit.Visible = False
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
            ucMessageBox1.Message = "رکورد مورد نظر با موفقیت حذف گردید."
            '
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در عملیات"
            'TODO : Log error
        End Try
        '
    End Sub

    Protected Sub EditNews(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim NewsId As Integer = CInt(e.CommandArgument)
            Dim NewsBLL As New Software.BLL.News
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/News/")
            Dim row As Data.DataRow = NewsBLL.SelectRow(NewsId).Rows(0)

            pnlEdit.Visible = True

            txtNewsTitle.Text = row("Title").ToString()
            txtNewsLid.Text = row("Lid").ToString()
            txtNewsBody.Text = row("Body").ToString()
            rblShowStatus.SelectedValue = row("Flag")
            Session("CurrentNewsId") = e.CommandArgument
            Image1.ImageUrl = "../Content/UserFiles/Images/News/" + row("BigImageName1")
            Image2.ImageUrl = "../Content/UserFiles/Images/News/" + row("BigImageName2")
            Image3.ImageUrl = "../Content/UserFiles/Images/News/" + row("BigImageName3")
            Image4.ImageUrl = "../Content/UserFiles/Images/News/" + row("SmallImageName1")
            '
        Catch ex As Exception
            'TODO : Log error
        End Try
        ''
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEdit.Visible = False
    End Sub

    Protected Sub btnSaveNews_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveNews.Click

        Try
            Dim NewsBll As New Software.BLL.News
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/News/")
            Dim row As Data.DataRow = NewsBll.SelectRow(CInt(Session("CurrentNewsId"))).Rows(0)

            Dim ImageName() As String = {row("BigImageName1").ToString(), row("BigImageName2").ToString(), row("BigImageName3").ToString(), row("SmallImageName1").ToString()}

            If FileUpload1.HasFile Then
                ImageName(0) = Portal.Utilities.GenerateFileName(FileUpload1.FileName)
                FileUpload1.SaveAs(strServerPath & ImageName(0))
                If IO.File.Exists(strServerPath & row("BigImageName1")) Then IO.File.Delete(strServerPath & row("BigImageName1"))
            End If

            If FileUpload2.HasFile Then
                ImageName(1) = Portal.Utilities.GenerateFileName(FileUpload2.FileName)
                FileUpload2.SaveAs(strServerPath & ImageName(1))
                If IO.File.Exists(strServerPath & row("BigImageName2")) Then IO.File.Delete(strServerPath & row("BigImageName2"))
            End If

            If FileUpload3.HasFile Then
                ImageName(2) = Portal.Utilities.GenerateFileName(FileUpload3.FileName)
                FileUpload3.SaveAs(strServerPath & ImageName(2))
                If IO.File.Exists(strServerPath & row("BigImageName3")) Then IO.File.Delete(strServerPath & row("BigImageName3"))
            End If

            If FileUpload4.HasFile Then
                ImageName(3) = Portal.Utilities.GenerateFileName(FileUpload4.FileName)
                FileUpload4.SaveAs(strServerPath & ImageName(3))
                If IO.File.Exists(strServerPath & row("SmallImageName1")) Then IO.File.Delete(strServerPath & row("SmallImageName1"))
            End If

            'TODO : نام کاربر در قسمت زیر وارد شود
            Dim Username As String = ""
            Dim bolResult As Boolean = NewsBll.Update(CInt(Session("CurrentNewsId")), txtNewsTitle.Text.Trim, txtNewsLid.Text.Trim, txtNewsBody.Text.Trim, rblShowStatus.SelectedValue, ImageName(0), ImageName(1), ImageName(2), ImageName(3))
            If bolResult = True Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "خبر با موفقیت ذخیره گردید."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا در درج خبر"
            End If
            gvNewsList.DataBind()
            Call ClearForm()
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا - با ابراهیم ترکمنی نژاد تماس بگیرید."
        Finally
            pnlEdit.Visible = False
        End Try    
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