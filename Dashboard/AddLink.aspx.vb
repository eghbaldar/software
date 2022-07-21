
Partial Class Management_Admin_admin_software_AddLink
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim LinkGroupID As Integer = CInt(e.CommandArgument)
            Dim Action As New Software.BLL.Link

            Action.Delete(LinkGroupID)
            gvLink.DataBind()
        Catch ex As Exception
            'TODO : Log error
        End Try
        '
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim Action As New Software.BLL.Link
            Action.Insert(Request.QueryString("PostId"), txtTitle.Text.Trim(), txtTotalSize.Text.Trim)
            Call ClearForm()
            gvLink.DataBind()
        Catch ex As Exception
            'TODO : log error
        End Try
    End Sub

    Private Sub ClearForm()
        txtTitle.Text = String.Empty
        txtTotalSize.Text = String.Empty
    End Sub

    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        e.InputParameters("PostId") = Request.QueryString.Get("PostId")
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvLink.Rows.Count > 0 Then gvLink.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
