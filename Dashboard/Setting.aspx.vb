
Partial Class Management_Admin_admin_software_Setting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            chkShowPostComment.Checked = Software.BLL.Setting.ShowPostComment
            chkShowNewsComment.Checked = Software.BLL.Setting.ShowNewsComment
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Software.BLL.Setting.ShowPostComment = chkShowPostComment.Checked
        Software.BLL.Setting.ShowNewsComment = chkShowNewsComment.Checked
    End Sub

End Class
