
Partial Class UserControl_ucStarRating
    Inherits System.Web.UI.UserControl

    Dim _StartCount As Integer
    Public Property StarCount() As Integer
        Get
            Return _StartCount
        End Get
        Set(ByVal value As Integer)
            '
            _StartCount = value

            Select Case value

                Case 0
                    imgStar.ImageUrl = "~/Content/images/Star/0.png"

                Case 1
                    imgStar.ImageUrl = "~/Content/images/Star/1.png"

                Case 2
                    imgStar.ImageUrl = "~/Content/images/Star/2.png"

                Case 3
                    imgStar.ImageUrl = "~/Content/images/Star/3.png"

                Case 4
                    imgStar.ImageUrl = "~/Content/images/Star/4.png"

                Case 5
                    imgStar.ImageUrl = "~/Content/images/Star/5.png"

            End Select

        End Set
        '
    End Property

End Class
