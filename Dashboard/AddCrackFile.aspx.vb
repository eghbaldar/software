
Partial Class Management_Admin_admin_software_AddCrackFile
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            '
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim Action As New Software.BLL.CrackFile

            'Dim strServerPath As String = Server.MapPath("../../Content/CrackFile/")
            'Dim ImageName As String = Action.SelectRow(ID).Rows(0)("Filename")
            'If IO.File.Exists(strServerPath & ImageName) Then IO.File.Delete(strServerPath & ImageName)

            Action.Delete(ID)
            gvCrackFile.DataBind()
            '
        Catch ex As Exception
            'TODO : Log error
        End Try
        '
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '
        Try
            Dim Action As New Software.BLL.CrackFile
            'TODO : نام کاربر در قسمت زیر وارد شود
            Dim Username As String = ""
            Dim bolResult As Boolean = Action.Insert(Request.QueryString("PostId"), txtTitle.Text.Trim(), txtCrackFile.Text.Trim)
            If bolResult = True Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "با موفقیت درج گردید."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا در درج"
            End If
            gvCrackFile.DataBind()
            Call ClearForm()
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در درج"
        End Try
        '
    End Sub

    Private Sub ClearForm()
        txtTitle.Text = String.Empty
        txtCrackFile.Text = String.Empty
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvCrackFile.Rows.Count > 0 Then gvCrackFile.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
