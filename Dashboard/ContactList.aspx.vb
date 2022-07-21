
Partial Class Dashboard_ContactList
    Inherits System.Web.UI.Page

    Dim action As New Software.BLL.Contact

    Protected Sub DeleteRecord(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim row As Data.DataRow = action.SelectRow(ID).Rows(0)

            action.Delete(ID)
            gvContactList.DataBind()
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
            ucMessageBox1.Message = "رکورد مورد نظر با موفقیت حذف گردید."
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در عملیت حذف! لطفا دوباره تلاش کنید"
            'TODO : Log error
        End Try
        ''
    End Sub

    Protected Sub ShowRecord(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Dim ID As Integer = CInt(e.CommandArgument)
        Dim row As Data.DataRow = action.SelectRow(ID).Rows(0)
        Panel1.Visible = True
        litName.Text = row("FullName").ToString()
        litEmail.Text = row("Email").ToString()
        litNote.Text = row("Note").ToString.Replace(vbCrLf, "<br/>")
        LitCreateDateTime.Text = row("CreateDate").ToString & " - " & row("CreateTime").ToString

        action.ChangeFlag(ID, True)
        gvContactList.DataBind()
        '
    End Sub

    Protected Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
        '
        For Each row As GridViewRow In gvContactList.Rows
            Dim cb As CheckBox = row.FindControl("chkBoxChild")
            If cb.Checked = True Then
                Dim hf As HiddenField = row.Cells(1).FindControl("HiddenField1")
                Dim ID As Integer = hf.Value
                Select Case ddlGroupOperation.SelectedValue
                    Case "Delete"
                        action.Delete(ID)
                        'TODO : log event
                    Case "NotVerification"
                        action.ChangeFlag(ID, False)
                        'TODO : log event
                    Case "Verification"
                        action.ChangeFlag(ID, True)
                        'TODO : log event
                End Select
            End If
        Next
        'TODO : نمایش پیغام
        gvContactList.DataBind()
        '
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvContactList.Rows.Count > 0 Then gvContactList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
