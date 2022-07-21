
Partial Class Dashboard_BestSoftwareList
    Inherits System.Web.UI.Page

    Protected Sub DeleteRecord(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim Action As New Software.BLL.BestSoftware
            Dim strServerPath As String = String.Empty

            Dim row As Data.DataRow = Action.SelectRow(ID).Rows(0)

            strServerPath = Server.MapPath("../Content/UserFiles/Images/SoftwareIcon/") & row("Icon")
            If IO.File.Exists(strServerPath) Then IO.File.Delete(strServerPath)

            Action.Delete(ID)
            gvBestSoftware.DataBind()
            '    pnlEdit.Visible = False
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
            ucMessageBox1.Message = "رکورد مورد نظر با موفقیت حذف گردید."
            '    '
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در عملیت حذف! لطفا دوباره تلاش کنید"
            'TODO : Log error
        End Try
        ''
    End Sub

    Protected Sub EditRecord(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/SoftwareIcon/")
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim Action As New Software.BLL.BestSoftware
            Dim row As Data.DataRow = Action.SelectRow(ID).Rows(0)

            pnlEdit.Visible = True

            txtTitle.Text = row("Title").ToString()
            txtDesc.Text = row("Description").ToString()
            txtLink.Text = row("URL").ToString()
            imgIcon.ImageUrl = "../Content/UserFiles/Images/SoftwareIcon/" + row("Icon").ToString()

            Session("CurrentID") = e.CommandArgument
            '
        Catch ex As Exception
            '    'TODO : Log error
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در سیستم! دوباره تلاش کنید"
            pnlEdit.Visible = False
        End Try
        '
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '
        Try
            Dim action As New Software.BLL.BestSoftware
            Dim row As Data.DataRow = action.SelectRow(CInt(Session("CurrentID"))).Rows(0)
            Dim ServerPath As String = Server.MapPath("../Content/UserFiles/Images/SoftwareIcon/")
            Dim IconName As String = row("Icon")

            If fuSoftwareIcon.HasFile Then
                If IO.File.Exists(ServerPath & IconName) Then IO.File.Delete(ServerPath & IconName)
                IconName = Portal.Utilities.GenerateFileName(fuSoftwareIcon.FileName)
                fuSoftwareIcon.SaveAs(ServerPath & IconName)
            End If

            Dim bolResult As Boolean = action.Update(CInt(Session("CurrentID")), txtTitle.Text.Trim(), IconName, txtDesc.Text.Trim(), txtLink.Text.Trim())
            If bolResult = True Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "با موفقیت ذخیره گردید."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا در درج"
            End If
            gvBestSoftware.DataBind()
            'Call ClearForm()
            pnlEdit.Visible = False
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در درج"
            MsgBox(ex.Message)
        End Try
        '
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEdit.Visible = False
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvBestSoftware.Rows.Count > 0 Then gvBestSoftware.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
