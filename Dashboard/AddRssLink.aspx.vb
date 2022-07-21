
Partial Class Management_Admin_admin_software_AddRssLink
    Inherits System.Web.UI.Page

    Protected Sub btnSaveRssLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveRssLink.Click
        '
        Dim Action As New Software.BLL.RssLink
        Action.Insert(txtTitle.Text.Trim, txtRssLink.Text.Trim)
        gvRssLink.DataBind()
        '
        txtTitle.Text = String.Empty
        txtRssLink.Text = String.Empty
        '
    End Sub

End Class
