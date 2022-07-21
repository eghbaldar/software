Imports System.Web.Services

Partial Class ShowNews
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Dim NewsID As Integer
        Try
            NewsID = Integer.Parse(Request.QueryString("NewsId"))
            Dim NewsBll As New Software.BLL.News
            If (NewsID > 0) And (Software.BLL.News.IsEexistNews(NewsID)) Then
                Dim drNews As Data.DataRow = NewsBll.SelectRow(NewsID).Rows(0)
                Me.Title = String.Format("{1} - {0}", drNews("Title").ToString(), "شهر نرم افزار")
                litTitle.Text = drNews("Title").ToString()
                litDateCreate.Text = drNews("DateCreate").ToString()
                'imgNews.ImageUrl = "/Content/UserFiles/Images/News/" & drNews("BigImageName1").ToString()
                imgNews.Src = "/Content/UserFiles/Images/News/" & drNews("BigImageName1").ToString()
                imgNews.Alt = drNews("Title").ToString()
                litBody.Text = drNews("Body").ToString()
                litTotalComment.Text = Software.BLL.NewsComments.GetCountVoteForThisPost(drNews("NewsId"))

                ucNewsComments1.Visible = True
                ucNewsComments1.NewsID = NewsID
                ucNewsComments1.ShowComment = Software.BLL.Setting.ShowNewsComment
                ucNewsComments1.ShowContent()
            End If
        Catch ex As Exception
            Call ShowMsgNotFoundPost()
        End Try
        '
    End Sub

    Private Sub ShowMsgNotFoundPost()
        litTitle.Visible = False
        litDateCreate.Visible = False
        litBody.Visible = False
    End Sub

    <WebMethod()> _
    Public Shared Function AddNewItem(ByVal ParentId As Integer, ByVal NewsId As Integer, ByVal FullName As String, ByVal Email As String, ByVal Note As String) As Boolean

        Dim Action As New Software.BLL.NewsComments
        Action.Insert(ParentId, NewsId, FullName, Email, Note)
        Return True

    End Function

End Class
