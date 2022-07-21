Imports System.Data

Partial Class Management_Admin_admin_software_GetRSS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        If Not Page.IsPostBack Then
            Call CreateMenu()
        End If
        '
    End Sub

    Private Sub CreateMenu()
        '
        Dim Action As New Software.BLL.RssLink
        Dim dt As DataTable = Action.SelectAll()

        For Each row As DataRow In dt.Rows
            Dim mnuItem As New MenuItem(row("Title"), row("RssLink"))
            mnuRssSouce.Items.Add(mnuItem)
        Next
        '
    End Sub

    Protected Sub mnuRssSouce_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mnuRssSouce.MenuItemClick
        '

        'http://feed.mihandownload.com/mihandl
        'http://www.feed.downloadha.com/downloadha-feed/
        'http://p30download.com/fa/main/feed/rss.xml
        'http://www.softgozar.com/Rss.aspx
        '================

        'http://vatandownload.com/rss/

        '================
        'http://www.asandownload.com/feed/rss.xml

        'Dim RssLink As String = e.Item.Value
        'Dim reader As New RSSReader2(RssLink)

        'gvRecordList.DataSource = reader.items
        'gvRecordList.DataBind()

        Try

            Dim RssLink As String = e.Item.Value
            Dim reader As New Raccoom.Xml.RssChannel(New System.Uri(e.Item.Value))

            Me.Title = Me.Title & "  -  " & e.Item.Text
            'reader.Items(0).Description 
            gvRecordList.DataSource = reader.Items
            gvRecordList.DataBind()

            btnSelect1.Visible = True
            btnSelect2.Visible = True

        Catch ex As Exception
            '
            Me.Title = "دریافت اطلاعات"
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در دستیابی به صفحه مورد نظر    -    " & e.Item.Value
            'lblMsg.Text &= "<br/>" & ex.Message
            btnSelect1.Visible = False
            btnSelect2.Visible = False
            gvRecordList.Visible = False
            '
        End Try
        ''
    End Sub

    Protected Sub btnSelect1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect1.Click
        Call Save2Database()
    End Sub

    Protected Sub btnSelect2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect2.Click
        Call Save2Database()
    End Sub

    Private Sub Save2Database()
        '
        Try
            Dim PostInFuture As New Software.BLL.Post

            For Each row As GridViewRow In gvRecordList.Rows
                Dim cb As CheckBox = row.FindControl("chkBoxChild")
                If cb.Checked = True Then
                    '
                    Dim Title As Label = row.FindControl("lblTitle")
                    Dim ddl As DropDownList = row.FindControl("ddlCategory")
                    Dim Link As HyperLink = row.FindControl("RefLink")
                    Dim LitDescription As Literal = row.FindControl("LitDescription")
                    Dim txtShowDate As TextBox = row.FindControl("txtShowDate")
                    PostInFuture.InsertPost2(Title.Text, ddl.SelectedValue, LitDescription.Text, "", 0, Link.NavigateUrl, False, txtShowDate.Text.Trim)
                    '
                End If
            Next
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
            ucMessageBox1.Message = "پست های انتخاب شده در بانک اطلاعاتی شهر ثبت گردید."
        Catch ex As Exception
            ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
            ucMessageBox1.Message = "خطا در ثبت اطلاعات - دوباره تلاش کنید"
        End Try
        '
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If gvRecordList.Rows.Count > 0 Then gvRecordList.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class
