Imports System.Data

Partial Class UserControl_ucNewsSlider
    Inherits System.Web.UI.UserControl

    Dim BeginFigure As String = "<figure class=""image-{0}"" style=""{1}"">" + vbCrLf
    Dim EndFigure As String = "</figure>" + vbCrLf
    Dim el1 As String = "<a href=""ShowNews.aspx?NewsID={0}""><img alt=""{1}"" src=""/Content/UserFiles/Images/News/{2}"" width=""500"" height=""250"" /></a>" + vbCrLf
    Dim el2 As String = "<span>{0}</span>" + vbCrLf
    Dim el3 As String = "<a href=""ShowNews.aspx?NewsID={0}"">{1}</a>" + vbCrLf
    Dim BeginFigcaption As String = "<figcaption>" + vbCrLf
    Dim EndFigcaption As String = "</figcaption>" + vbCrLf


    Dim BeginDivSmall As String = "<div class=""small thumb-{0}"">" + vbCrLf
    Dim EndDivSmall As String = "</div>" + vbCrLf
    Dim el4 As String = "<img alt=""{0}"" src=""/Content/UserFiles/Images/News/{1}"" width=""153"" height=""82"" />" + vbCrLf
    Dim el5 As String = "<span class=""media""><i class=""icon-pencil icon-white""></i></span>" + vbCrLf
    Dim BeginFigureSmall As String = "<figure>" + vbCrLf
    Dim EndFigureSmall As String = "</figure>" + vbCrLf


    Dim SliderStringBig As New StringBuilder
    Dim SliderStringSmall As New StringBuilder

    Private Function BuildSlider() As String
        '
        Dim NewsBLL As New Software.BLL.News
        Dim dtNewsItems As DataTable = NewsBLL.SelectThreeTopNews
        Dim i As Integer
        '
        SliderStringBig.Append("<div class=""slider"">" + vbCrLf)

        SliderStringBig.Append("<div class=""big"">" + vbCrLf)
        For Each dr As DataRow In dtNewsItems.Rows
            If i = 0 Then
                SliderStringBig.Append(String.Format(BeginFigure, i, "opacity: 1;"))
            Else
                SliderStringBig.Append(String.Format(BeginFigure, i, "display: none;"))
            End If
            SliderStringBig.Append(String.Format(el1, dr("NewsID").ToString(), dr("Title").ToString(), dr("BigImageName1").ToString()))
            SliderStringBig.Append(BeginFigcaption)
            'SliderStringBig.Append(String.Format(el2, dr("Title").ToString()))
            SliderStringBig.Append(String.Format(el3, dr("NewsID").ToString(), dr("Title").ToString()))
            SliderStringBig.Append(EndFigcaption)
            SliderStringBig.Append(EndFigure)
            i += 1
        Next
        SliderStringBig.Append("</div>" + vbCrLf) '</div class="big">

        i = 0
        SliderStringSmall.Append("<div class=""thumbs"">" + vbCrLf)
        For Each dr As DataRow In dtNewsItems.Rows

            SliderStringSmall.Append(String.Format(BeginDivSmall, i))
            SliderStringSmall.Append(BeginFigureSmall)
            'SliderStringSmall.Append(String.Format(el4, dr("Title").ToString(), dr("SmallImageName1").ToString()))
            SliderStringSmall.Append(String.Format(el4, dr("Title").ToString(), dr("SmallImageName1").ToString()))
            SliderStringSmall.Append(el5)
            SliderStringSmall.Append(EndFigureSmall)
            SliderStringSmall.Append(EndDivSmall)
            i += 1

        Next
        SliderStringSmall.Append("</div>" + vbCrLf) '</div class="thumbs">

        SliderStringBig.Append(SliderStringSmall.ToString)
        SliderStringBig.Append("<a class=""next"" style=""display: inline;""></a>")
        SliderStringBig.Append("</div>" + vbCrLf) '</div class="slider">
        '
        Return SliderStringBig.ToString
        ''
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSlider As String = BuildSlider()
        LitNewsSlider.Text = strSlider
    End Sub

End Class
