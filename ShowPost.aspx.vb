Imports System.Web.Services

Partial Class ShowPost
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Dim PostID As Integer
        Try
            PostID = Integer.Parse(Request.QueryString("PostID"))
            Dim PostBLL As New Software.BLL.Post
            If (PostID > 0) And (Software.BLL.Post.IsEexistPost(PostID)) Then
                PostBLL.DownloadCountPlus1(PostID)

                Select Case PostBLL.GetPostType(PostID)
                    Case 1
                        MultiView1.ActiveViewIndex = 0
                        ucShowPostInfo1.PostID = PostID
                        ucShowPostInfo1.Visible = True
                        ucShowPostInfo1.ShowContent()

                        ucComments1.PostID = PostID
                        ucComments1.ShowComment = Software.BLL.Setting.ShowPostComment
                        ucComments1.Visible = True
                        ucComments1.ShowContent()

                        ucRelatedLink1.PostID = PostID
                    Case 2
                        MultiView1.ActiveViewIndex = 1

                        Dim WrapperDiv As UI.HtmlControls.HtmlGenericControl = Master.FindControl("Wrapper")
                        Dim HeaderDiv As UI.HtmlControls.HtmlGenericControl = Master.FindControl("Header")
                        Dim TopMenuDiv As UI.HtmlControls.HtmlGenericControl = Master.FindControl("TopMenu")
                        Dim FooterDiv As UI.HtmlControls.HtmlGenericControl = Master.FindControl("Footer")

                        'If HeaderDiv isnot nothing
                        HeaderDiv.Visible = False
                        FooterDiv.Visible = False
                        TopMenuDiv.Visible = False
                        WrapperDiv.Style.Add("Width", "100%")
                        WrapperDiv.Style.Add("Height", "100%")
                        iframe.Attributes("src") = PostBLL.GetLink(PostID)
                        'Response.Redirect(PostBLL.GetLink(PostID))
                End Select
            Else
                Call ShowMsgNotFoundPost()
            End If
        Catch ex As Exception
            Call ShowMsgNotFoundPost()
        End Try
        ''
    End Sub

    Private Sub ShowMsgNotFoundPost()
        'Response.Write("not found post")
    End Sub

    <WebMethod()> _
    Public Shared Function AddNewItem(ByVal ParentId As Integer, ByVal PostId As Integer, ByVal FullName As String, ByVal Email As String, ByVal Note As String) As Boolean

        Dim Action As New Software.BLL.Comments
        'Dim s As String = "ParentId = {0), PostId = {1}, FullName = {2}, Email = {3}, Note = {4}"
        'MsgBox(String.Format(s, ParentId, PostId, FullName, Email, Note))
        Action.Insert(ParentId, PostId, FullName, Email, Note)
        Return True

    End Function

End Class
