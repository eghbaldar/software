Imports System.Data

Partial Class software_UserControl_ucShowPostInfo
    Inherits System.Web.UI.UserControl

    Dim _PostId As Integer
    Property PostID() As Integer
        Get
            Return _PostId
        End Get
        Set(ByVal value As Integer)
            _PostId = value
        End Set
    End Property

    Dim _PostType As Integer
    Property PostType() As Integer
        Get
            Return _PostType
        End Get
        Set(ByVal value As Integer)
            _PostType = value
        End Set
    End Property

    Public Function ShowCateName(ByVal CatID As Integer) As String
        Dim bll As New Software.BLL.Post
        Return bll.GetCategoryNameById(CatID)
    End Function

    Public Sub ShowContent()
        '
        'Try

        Dim Action As New Software.BLL.Post
        Dim dr As DataRow = Action.SelectRow(Me.PostID).Rows(0)

        litTitle.Text = dr("Title").ToString
        Me.Page.Title = dr("Title").ToString
        'litCategory.Text = Action.GetCategoryNameById(dr("CategoryId"))
        litCategory.Text = Portal.Utilities.BuildCategoryList(dr("CategoryId"))
        litDateOfCreatePost.Text = dr("DateOfCreatePost").ToString().Split("-")(1)
        litDownloadCount.Text = IIf(dr("DownloadCount").ToString() = String.Empty, "0", dr("DownloadCount").ToString())    'dr("DownloadCount").ToString()

        'ucStarRating1.StarCount = Action.GetStarCount(Me.PostID)
        'Dim x As Single = Action.GetPostRating(Me.PostID)
        'Action.GetPostRating(Me.PostID)
        '        Response.Write("PostId=" & Me.PostID.ToString & "<br/>")
        'Response.Write("x=" & x.ToString() & "<br/>")

        imgDefaultPicture.ImageUrl = String.Format("~/Content/UserFiles/Images/Software/{0}", dr("BigImageFilename").ToString())
        pnlCrackFile.Visible = Action.HasCrackFile(Me.PostID)

        litDescFarsi.Text = dr("DescFarsi").ToString()

        If CBool(dr("HaveDescEnglish").ToString()) Then
            lblDescEnglish.Text = dr("DescEnglish").ToString()
        Else
            pnlEnglishDesc.Visible = False
        End If

        If CBool(dr("HaveLearningFile").ToString()) Then
            HyperLinkLearningFile.NavigateUrl = String.Format("http://shaahr.net/files/software/{0}", dr("LearningFileName").ToString())
        Else
            pnlLearningFile.Visible = False
        End If

        'Catch ex As Exception

        'End Try

        ''
    End Sub

    Protected Sub dlLinkGroup_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlLinkGroup.ItemDataBound
        '
        Dim lt As ListItemType = e.Item.ItemType
        If lt = ListItemType.Item OrElse lt = ListItemType.AlternatingItem Then
            Dim dv As DataRowView = TryCast(e.Item.DataItem, DataRowView)
            If dv IsNot Nothing Then
                Dim nestedDataList As DataList = TryCast(e.Item.FindControl("dlLinkDetail"), DataList)
                If nestedDataList IsNot Nothing Then
                    Dim action As New Software.BLL.LinkDetail
                    Dim dt As DataTable = action.SelectByLinkGroupID(dv.Item("LinkGroupID"))
                    nestedDataList.DataSource = dt
                    AddHandler nestedDataList.ItemDataBound, AddressOf dlLinkDetail_ItemDataBound
                    nestedDataList.DataBind()
                End If
            End If
        End If
        ''
    End Sub

    Protected Sub dlLinkDetail_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        '

        Dim HLink As HyperLink = TryCast(e.Item.FindControl("HyperLink1"), HyperLink)

        'Server Way
        HLink.NavigateUrl = "http://shaahr.net/files/software/" & HLink.NavigateUrl
        'HLink.Attributes.Add("onclick", "add_d(" &  & ")")
        'Client Way
        'HLink.NavigateUrl = Server.MapPath("~\Management\Content\Software\") & HLink.NavigateUrl

        '
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        '
        btnSend.Enabled = False
        'MsgBox("y")
        'btnSendErrorInLink.Text = "صبر کنید"

        'System.Threading.Thread.Sleep(3000)
        Dim ErroLinkAction As New Software.BLL.ErrorInLink
        If CapchaControl1.IsCorrect() Then
            '
            'lblMsg.Text = "لطفا صبر کنید"
            Dim bolResult As Boolean = ErroLinkAction.Insert(Me.PostID, txtName.Text.Trim, txtEmail.Text.Trim, txtNote.Text, Request.UrlReferrer.AbsoluteUri)
            If bolResult Then
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.Success
                ucMessageBox1.Message = "متشکریم. به پیغام شما رسیدگی می شود."
                txtName.Text = "نام و نام خانوادگی"
                txtEmail.Text = "پست الکترونیکی"
                txtNote.Text = "توضیحات..."
            Else
                ucMessageBox1.Type = UserControl_ucMessageBox.MessageType.ErrorMsg
                ucMessageBox1.Message = "خظا! دوباره سعی کنید."
            End If
            '
        End If
        btnSend.Enabled = True
        'btnSendErrorInLink.Text = "ارسال"
        ''
    End Sub

End Class