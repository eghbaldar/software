
Partial Class Dashboard_ProductList
    Inherits System.Web.UI.Page

    Dim Action As New Software.BLL.Product

    Protected Sub DeleteRecord(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim strServerPath As String = String.Empty

            Dim row As Data.DataRow = Action.SelectRow(ID).Rows(0)

            strServerPath = Server.MapPath("../Content/UserFiles/Images/Product/") & row("Picture")
            If IO.File.Exists(strServerPath) Then IO.File.Delete(strServerPath)

            Action.Delete(ID)
            gvProductList.DataBind()
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
            Dim strServerPath As String = Server.MapPath("../Content/UserFiles/Images/Product/")
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim row As Data.DataRow = Action.SelectRow(ID).Rows(0)

            pnlEdit.Visible = True

            txtTitle.Text = row("Title").ToString()
            txtPrice.Text = row("Price").ToString()
            txtLink.Text = row("URL").ToString()
            imgProduct.ImageUrl = "../Content/UserFiles/Images/Product/" + row("Picture").ToString()

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
            Dim row As Data.DataRow = Action.SelectRow(CInt(Session("CurrentID"))).Rows(0)
            Dim ServerPath As String = Server.MapPath("../Content/UserFiles/Images/Product/")
            Dim ImageName As String = row("Picture")

            If fuProductImage.HasFile Then
                If IO.File.Exists(ServerPath & ImageName) Then IO.File.Delete(ServerPath & ImageName)
                ImageName = Portal.Utilities.GenerateFileName(fuProductImage.FileName)
                fuProductImage.SaveAs(ServerPath & ImageName)
            End If

            Dim bolResult As Boolean = Action.Update(CInt(Session("CurrentID")), txtTitle.Text.Trim(), ImageName, txtPrice.Text.Trim(), txtLink.Text.Trim())
            If bolResult = True Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "با موفقیت ذخیره گردید."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا در درج"
            End If
            gvProductList.DataBind()
            'Call ClearForm()
            pnlEdit.Visible = False
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در درج"
            MsgBox(ex.Message)
        End Try
        '
    End Sub

    Protected Sub btnChangeStatus_Click(ByVal sender As Object, ByVal e As EventArgs)
        '
        Dim gvRow As GridViewRow = CType(CType(sender, Control).Parent.Parent, GridViewRow)
        Dim RowIndex As Integer = gvRow.RowIndex
        Dim btn As Button = CType(sender, Button)
        Dim ID As Integer = btn.CommandArgument.ToString()

        Dim result As Boolean = Action.ChangeStatus(ID)

        gvProductList.DataBind()
        '
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlEdit.Visible = False
    End Sub

    Protected Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
        '
        For Each row As GridViewRow In gvProductList.Rows
            Dim cb As CheckBox = row.FindControl("chkBoxChild")
            If cb.Checked = True Then
                Dim hf As HiddenField = row.Cells(1).FindControl("HiddenField1")
                Dim ID As Integer = hf.Value
                Select Case ddlGroupOperation.SelectedValue
                    Case "Delete"
                        Action.Delete(ID)
                        'TODO : log event
                    Case "NotVerification"
                        Action.ChangeStatus(ID, False)
                        'TODO : log event
                    Case "Verification"
                        Action.ChangeStatus(ID, True)
                        'TODO : log event
                End Select
            End If
        Next
        'TODO : نمایش پیغام
        gvProductList.DataBind()
        '
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvProductList.Rows.Count > 0 Then gvProductList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
