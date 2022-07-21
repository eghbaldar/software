
Partial Class UserControl_ucRelatedLink
    Inherits System.Web.UI.UserControl

    Dim Action As New Software.BLL.Post
    Dim CategoryID As Integer
    Dim _PostId As Integer
    Property PostID() As Integer
        Get
            Return _PostId
        End Get
        Set(ByVal value As Integer)
            _PostId = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Software.BLL.Post.IsEexistPost(Me.PostID) = True Then
            CategoryID = Action.GetCategoryID(Me.PostID)
            Call BindData()
        End If
    End Sub

    Private Sub BindData()
        Dim dt As System.Data.DataTable
        dt = Action.SelectRelatedPost(Me.PostID, CategoryID)
        Repeater1.DataSource = dt
        Repeater1.DataBind()
    End Sub

End Class
