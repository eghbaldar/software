
Partial Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim PostBLL As New Software.BLL.Post

        litTotalPost.Text = PostBLL.GetTotalPost()
        'litTotalVizit.Text = Software.BLL.Counter.GetTotalVisit() & " , " & PostBLL.TotalDownload()
        litTotalVizit.Text = Software.BLL.Counter.GetTotalVisit()
        litIP.Text = Request.UserHostAddress
        'litLastUpdate.Text = PostBLL.GetLastUpdate.Split("-")(1)

    End Sub

End Class

