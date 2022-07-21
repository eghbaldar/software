
Partial Class Category
    Inherits System.Web.UI.Page

    'Protected Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
    '    Dim Today As String = ShamsiDate.Miladi2Shamsi(Date.Today, ShamsiDate.ShowType.ShortDate)
    '    e.InputParameters("today") = Today
    'End Sub

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Dim CategoryID As Integer
        Try
            CategoryID = Integer.Parse(Request.QueryString("CategoryID"))
            If (CategoryID > 0) And (Software.BLL.Category.IsEexistCategory(CategoryID)) Then
                Dim action As New Software.BLL.Post
                Dim dt As Data.DataTable = action.SelectAllForShow(CategoryID)

                litCategoryName.Text = Portal.Utilities.BuildCategoryList(CategoryID)

                lvSoftware.DataSource = dt
                lvSoftware.DataBind()
            Else
                'ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                'ucMessageBox1.Message = "دسته بندی مورد نظر شما یافت نشد."
            End If

        Catch ex As Exception
            'lvSoftware.DataSource = Nothing
            'lvSoftware.DataBind()
        End Try
        ''
    End Sub

End Class
