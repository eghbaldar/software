
Partial Class Management_Admin_admin_software_AddLinkDetail
    Inherits System.Web.UI.Page

    Protected Sub DeletePost(ByVal sender As Object, ByVal e As CommandEventArgs)
        '
        Try
            Dim ID As Integer = CInt(e.CommandArgument)
            Dim Action As New Software.BLL.LinkDetail

            Action.Delete(ID)
            gvLink.DataBind()
        Catch ex As Exception
            'TODO : Log error
        End Try
        '
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Action As New Software.BLL.LinkDetail
        Dim DirectLink As String = txtLink.Text.Trim()
        Action.Insert(Request.QueryString("GroupID"), DirectLink, txtPartSize.Text.Trim)
        Call ClearForm()
        gvLink.DataBind()
    End Sub

    Private Sub ClearForm()
        txtLink.Text = String.Empty
        txtPartSize.Text = String.Empty
    End Sub

    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        e.InputParameters("LinkGroupID") = Request.QueryString.Get("GroupId")
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvLink.Rows.Count > 0 Then gvLink.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
