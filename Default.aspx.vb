
Partial Class _Default
    Inherits System.Web.UI.Page

    Public Function GenLink(ByVal PostType As Integer, ByVal PostId As Integer, ByVal Hyperlink As String) As String
        '
        Dim href As String = String.Empty
        Select Case PostType
            Case 1, 2
                href = String.Format("ShowPost.aspx?PostId={0}", PostId)
                'Case 2
                'href = Hyperlink
            Case 3
                href = String.Format("ShowAds.aspx?AdsId={0}", PostId)
        End Select
        Return href
        ''
    End Function

    Public Function ShowCateName(ByVal CatID As Integer) As String
        Dim bll As New Software.BLL.Post
        Return bll.GetCategoryNameById(CatID)
    End Function

    Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        Dim Today As String = ShamsiDate.Miladi2Shamsi(Date.Today, ShamsiDate.ShowType.ShortDate)
        e.InputParameters("today") = Today
    End Sub

End Class
