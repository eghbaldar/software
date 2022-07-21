
Partial Class Management_Admin_admin_software_CommentList
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
        Dim CommentBLL As New Software.BLL.Comments
        Dim CommentId As Integer = CInt(gvCommentList.SelectedValue)
        Dim row As GridViewRow = gvCommentList.SelectedRow
        Dim imgEnvelope As Image = DirectCast(row.FindControl("imgEnvelope"), Image)

        imgEnvelope.ImageUrl = "/../Content/Images/open-envelope.png"
        CommentBLL.ChangeVisable(CommentId, True)
        '
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '
        Dim CommentBLL As New Software.BLL.Comments
        Dim CommentID As Integer
        For Each row As GridViewRow In gvCommentList.Rows
            Dim cb As CheckBox = row.FindControl("chkSelectRecord")
            If cb.Checked = True Then
                Dim lbl As Label = DirectCast(row.FindControl("lblCommentId"), Label)
                CommentID = lbl.Text
                'Response.Write(CommentID & "<br/>")
                CommentBLL.Delete(CommentID)
            End If
        Next
        gvCommentList.DataBind()
        ''
    End Sub

    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        '
        Dim CommentBLL As New Software.BLL.Comments
        Dim CommentID As Integer
        For Each row As GridViewRow In gvCommentList.Rows
            Dim cb As CheckBox = row.FindControl("chkSelectRecord")
            If cb.Checked = True Then
                Dim lbl As Label = DirectCast(row.FindControl("lblCommentId"), Label)
                CommentID = lbl.Text
                'Response.Write(CommentID & "<br/>")
                CommentBLL.ChangeVisable(CommentID, True)
            End If
        Next
        gvCommentList.DataBind()
        '
    End Sub

End Class
