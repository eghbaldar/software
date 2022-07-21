﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Services

Partial Class UserControl_ucNewsComments
    Inherits System.Web.UI.UserControl

    Dim _NewsId As Integer
    Property NewsID() As Integer
        Get
            Return _NewsId
        End Get
        Set(ByVal value As Integer)
            _NewsId = value
        End Set
    End Property

    Dim _ShowComment As Boolean
    Property ShowComment() As Boolean
        Get
            Return _ShowComment
        End Get
        Set(ByVal value As Boolean)
            _ShowComment = value
            If value = True Then
                hdShowComment.Value = 1
            Else
                hdShowComment.Value = 0
            End If

        End Set
    End Property

    Dim Action As New Software.BLL.NewsComments

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click

        If CapchaControl1.IsCorrect() Then
            Dim bolResult As Boolean = Action.Insert(0, _NewsId, txtFullName.Text.Trim(), txtEmail.Text.Trim(), txtNote.Text.Trim())
            If bolResult Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "با تشکر"
                If Me.ShowComment = True Then Call BindData()
                Call EmptyForm()
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خطا! دوباره سعی کنید."
            End If
        End If

    End Sub

    Private Sub EmptyForm()
        txtFullName.Text = "نام و نام خانوادگی"
        txtEmail.Text = "پست الکترونیکی"
        txtNote.Text = "توضیحات..."
    End Sub

    Public Sub ShowContent()
        NewsIdSaver.Value = Me.NewsID
        lblCountVote.Text = String.Format("( {0} نظر )", Software.BLL.NewsComments.GetCountVoteForThisPost(Me.NewsID))
        Call BindData()
    End Sub

    Private Sub BindData()
        Dim Action As New Software.BLL.NewsComments
        Dim dt As DataTable = Action.SelectByMainComment(_NewsId, Software.BLL.Setting.ShowNewsComment)
        Repeater1.DataSource = dt
        Repeater1.DataBind()
    End Sub

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

        Dim lt As ListItemType = e.Item.ItemType
        If lt = ListItemType.Item Or lt = ListItemType.AlternatingItem Then
            Dim dv As DataRowView = TryCast(e.Item.DataItem, DataRowView)
            If dv IsNot Nothing Then
                Dim nestedRepeater As Repeater = TryCast(e.Item.FindControl("NestedRepeater"), Repeater)
                If nestedRepeater IsNot Nothing Then
                    Dim action As New Software.BLL.NewsComments
                    Dim dt As DataTable = action.SelectByParentID(dv.Item("CommentId"), Software.BLL.Setting.ShowNewsComment)
                    nestedRepeater.DataSource = dt
                    nestedRepeater.DataBind()
                End If
            End If
        End If

    End Sub

End Class
