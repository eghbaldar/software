Imports System.Data

Partial Class UserControl_ucDynamicMenu
    Inherits System.Web.UI.UserControl

    Dim BeginItem As String = "<li><a href=""{0}"">{1}</a>" + vbCrLf
    Dim EndItem As String = "</li>" + vbCrLf
    Dim BeginSub As String = "<ul>" + vbCrLf
    Dim EndSub As String = "</ul>" + vbCrLf

    Dim MenuString As New StringBuilder

    Private Function BuildMenu() As String
        '
        Dim Menu As New Software.BLL.Category
        Dim dtMenuItems As DataTable = Menu.SelectAll

        '
        MenuString.Append("<ul id=""nav"">" + vbCrLf)
        MenuString.Append(String.Format(BeginItem, "http://software.shaahr.com/", "صفحه نخست"))

        For Each dr As DataRow In dtMenuItems.Select("ParentID = 0")
            MenuString.Append(String.Format(BeginItem, "Category.aspx?categoryId=" & dr("CategoryId").ToString(), dr("CategoryName")))
            AddChildToMenu(dtMenuItems, dr("CategoryId").ToString())
            MenuString.Append(EndItem)
        Next

        'MenuString.Append(String.Format(BeginItem, "News.aspx", "اخبار"))
        'MenuString.Append(String.Format(BeginItem, "http://sms.shaahr.com", "اس ام اس"))
        MenuString.Append(String.Format(BeginItem, "http://ebook.shaahr.com", "کتاب"))
        MenuString.Append(String.Format(BeginItem, "http://photoshop.shaahr.com", "گرافیک"))
        MenuString.Append(String.Format(BeginItem, "http://www.shaahroid.ir", "اندروید"))

        MenuString.Append("</ul>" + vbCrLf)
        '
        Return MenuString.ToString
        ''
    End Function

    Private Sub AddChildToMenu(ByVal dt As DataTable, ByVal parentId As Integer)
        '
        Dim rows As DataRow() = dt.Select("ParentID = " & parentId.ToString)

        If rows.Count > 0 Then
            MenuString.Append(BeginSub)

            For Each dr As DataRow In rows
                MenuString.Append(String.Format(BeginItem, "Category.aspx?categoryId=" & dr("CategoryId").ToString(), dr("CategoryName")))
                Call AddChildToMenu(dt, dr("CategoryId").ToString())
            Next

            MenuString.Append(EndSub)
        End If
        ''
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strMenuItems As String = BuildMenu()
        LitMenu.Text = strMenuItems
    End Sub

End Class
