Imports System.Data
Imports System.Data.SqlClient

Partial Class Management_Admin_admin_software_AddCategory
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '
        Dim Action As New Software.BLL.Category
        Dim ParentId As Integer = IIf(ddlMenuItems.SelectedValue.ToString = String.Empty, 0, ddlMenuItems.SelectedValue)

        Action.Insert(ParentId, txtTitle.Text, "")

        txtTitle.Text = String.Empty
        Panel1.Visible = False

        gvMenuItem.DataBind()
        ddlMenuItems.DataBind()

        Call CreateMenu()
        '
    End Sub

    Protected Sub btnCreateMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateMenu.Click
        '
        'ddlMenuItems.SelectedIndex = -1
        'ddlMenuItems.Items.Add("a")
        Dim Action As New Software.BLL.Category
        'Dim dt As DataTable = Action.SelectAll
        Dim dt As DataTable = Action.SelectNestedCategory
        Dim dr As DataRow = dt.NewRow
        'dr(0) = 0 : dr(1) = 0 : dr(2) = "گروه اصلی" : dr(3) = ""
        dr(1) = 0 : dr(0) = "گروه اصلی"
        'dt.Rows.Add(0, 0, "گروه اصلی", "")
        dt.Rows.InsertAt(dr, 0)
        ddlMenuItems.DataSource = dt
        ddlMenuItems.DataValueField = "CategoryId"
        ddlMenuItems.DataTextField = "CatName"
        ddlMenuItems.DataBind()
        Panel1.Visible = True
        '
    End Sub

    'Protected Sub DeleteItem(ByVal sender As Object, ByVal e As CommandEventArgs)
    '    Dim Action As New Software.BLL.Category
    '    Action.Delete(CInt(e.CommandArgument))
    '    Call CreateMenu()
    '    ObjectDataSource1.DataBind()
    '    gvMenuItem.DataBind()
    'End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Panel1.Visible = False
    End Sub

    'Protected Sub MoveLeft(ByVal sender As Object, ByVal e As CommandEventArgs)
    '    Dim Action As New BLL.DynamicMenu
    '    Action.MoveLeft(CInt(e.CommandArgument))
    '    Call CreateMenu()
    '    ObjectDataSource1.DataBind()
    '    gvMenuItem.DataBind()
    'End Sub

    'Protected Sub MoveRight(ByVal sender As Object, ByVal e As CommandEventArgs)
    '    Dim Action As New BLL.DynamicMenu
    '    Action.MoveRight(CInt(e.CommandArgument))
    '    Call CreateMenu()
    '    ObjectDataSource1.DataBind()
    '    gvMenuItem.DataBind()
    'End Sub

    'Protected Sub MoveUp(ByVal sender As Object, ByVal e As CommandEventArgs)
    '    Dim Action As New BLL.DynamicMenu
    '    Action.MoveUp(CInt(e.CommandArgument))
    '    Call CreateMenu()
    '    ObjectDataSource1.DataBind()
    '    gvMenuItem.DataBind()
    'End Sub

    'Protected Sub MoveDown(ByVal sender As Object, ByVal e As CommandEventArgs)
    '    Dim Action As New BLL.DynamicMenu
    '    Action.MoveDown(CInt(e.CommandArgument))
    '    Call CreateMenu()
    '    ObjectDataSource1.DataBind()
    '    gvMenuItem.DataBind()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CreateMenu()
    End Sub

    'Private Sub CreateMenu()
    '    '
    '    menuBar.Items.Clear()
    '    Dim Menu As New DynamicMenu
    '    Dim dt As DataTable = Menu.SelectAll

    '    For Each dr As DataRow In dt.Select("ParentID = 0")
    '        menuBar.Items.Add(New MenuItem(dr("Title").ToString(), dr("NodeID").ToString(), "", "#"))

    '    Next

    '    For Each dr As DataRow In dt.Select("ParentID > 0")
    '        Dim mnu As New MenuItem(dr("Title").ToString(), dr("NodeID").ToString(), "", "#")

    '        'menuBar.FindItem(dr("ParentID").ToString()).ChildItems.Add(mnu)

    '        For Each itm As MenuItem In menuBar.Items

    '            'Response.Write(itm.Text & "<br/>")

    '            'If itm.Value = dr("ParentID").ToString() Then
    '            '    itm.ChildItems.Add(mnu)
    '            'End If
    '        Next

    '    Next
    '    '
    'End Sub

    '#Region "تکه کد اصلی برای ساخت منو"

    '    Private Sub CreateMenu()
    '        '
    '        menuBar.Items.Clear()
    '        Dim Menu As New DynamicMenu
    '        Dim dt As DataTable = Menu.SelectAll

    '        For Each dr As DataRow In dt.Select("ParentID = 0")
    '            Dim NewItem As MenuItem = New MenuItem(dr("Title").ToString(), dr("NodeID").ToString(), "", "#")
    '            menuBar.Items.Add(NewItem)
    '            Call AddChildToMenu(dt, NewItem)
    '        Next
    '        ''
    '    End Sub

    '    Private Sub AddChildToMenu(ByVal dt As DataTable, ByVal parent As MenuItem)
    '        '
    '        For Each dr As DataRow In dt.Select("ParentID = " & parent.Value)
    '            Dim NewItem As MenuItem = New MenuItem(dr("Title").ToString(), dr("NodeID").ToString(), "", "#")
    '            parent.ChildItems.Add(NewItem)
    '            Call AddChildToMenu(dt, NewItem)
    '        Next
    '        '
    '    End Sub

    '#End Region

#Region "تکه کد اصلی برای ساخت منو در TreeView"

    Private Sub CreateMenu()
        '
        tvMenu.Nodes.Clear()
        Dim Menu As New Software.BLL.Category
        Dim dt As DataTable = Menu.SelectAll

        For Each dr As DataRow In dt.Select("ParentID = 0")
            Dim NewItem As TreeNode = New TreeNode(dr("CategoryName").ToString(), dr("CategoryId").ToString())
            tvMenu.Nodes.Add(NewItem)
            Call AddChildToMenu(dt, NewItem)
        Next
        tvMenu.ExpandAll()
        '
    End Sub

    Private Sub AddChildToMenu(ByVal dt As DataTable, ByVal parent As TreeNode)
        '
        For Each dr As DataRow In dt.Select("ParentID = " & parent.Value)
            Dim NewItem As TreeNode = New TreeNode(dr("CategoryName").ToString(), dr("CategoryId").ToString())
            parent.ChildNodes.Add(NewItem)
            Call AddChildToMenu(dt, NewItem)
        Next
        '
    End Sub

#End Region

    Protected Sub SqlDataSource1_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Deleted
        CreateMenu()
    End Sub

End Class
