
Partial Class Management_Admin_admin_software_NewsCommentsList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        For Each gvr As GridViewRow In gvCommentList.Rows
            Dim cb As CheckBox = CType(gvr.FindControl("chkSelectRecord"), CheckBox)
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
        Next
        '
    End Sub

    Protected Sub gvCommentList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCommentList.SelectedIndexChanged
        '
        Dim NewsCommentBLL As New Software.BLL.NewsComments
        Dim CommentId As Integer = CInt(gvCommentList.SelectedValue)
        Dim row As GridViewRow = gvCommentList.SelectedRow
        Dim lblVisible As Label = DirectCast(row.FindControl("lblVisible"), Label)

        lblVisible.Text = "<div class=""BadStatus"">خوانده شده</div>"
        NewsCommentBLL.ChangeVisable(CommentId, True)
        '
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '
        Dim NewsCommentBLL As New Software.BLL.NewsComments
        Dim CommentID As Integer
        For Each row As GridViewRow In gvCommentList.Rows
            Dim cb As CheckBox = row.FindControl("chkSelectRecord")
            If cb.Checked = True Then
                Dim lbl As Label = DirectCast(row.FindControl("lblCommentId"), Label)
                CommentID = lbl.Text
                'Response.Write(CommentID & "<br/>")
                NewsCommentBLL.Delete(CommentID)
            End If
        Next
        gvCommentList.DataBind()
        ''
    End Sub

    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        '
        Dim NewsCommentBLL As New Software.BLL.NewsComments
        Dim CommentID As Integer
        For Each row As GridViewRow In gvCommentList.Rows
            Dim cb As CheckBox = row.FindControl("chkSelectRecord")
            If cb.Checked = True Then
                Dim lbl As Label = DirectCast(row.FindControl("lblCommentId"), Label)
                CommentID = lbl.Text
                'Response.Write(CommentID & "<br/>")
                NewsCommentBLL.ChangeVisable(CommentID, True)
            End If
        Next
        gvCommentList.DataBind()
        '
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvCommentList.Rows.Count > 0 Then gvCommentList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
