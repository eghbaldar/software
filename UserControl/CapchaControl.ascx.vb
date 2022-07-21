
Partial Class UserControl_CapchaControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Call CreateQuestion()
        End If
    End Sub

    Private Sub CreateQuestion()
        '
        Dim strQuestion As String = String.Empty
        Dim QuestionOperator As Integer
        Dim RndGen As New Random

        Dim Num1 As Integer = RndGen.Next(1, 11)
        Dim Num2 As Integer = RndGen.Next(1, 11)
        If Num1 < Num2 Then Swap(Num1, Num2)

        QuestionOperator = RndGen.Next(1, 4)

        Select Case QuestionOperator

            Case 1, 4
                strQuestion = String.Format("{0} بعلاوه {1} می شود؟", Num1.ToString, Num2.ToString)
                HttpContext.Current.Session("Answer") = Num1 + Num2
                Session("Validate") = Num1 + Num2

            Case 2
                strQuestion = String.Format("{0} منهای {1} می شود؟", Num1.ToString, Num2.ToString)
                HttpContext.Current.Session("Answer") = Num1 - Num2
                Session("Validate") = Num1 - Num2

            Case 3
                strQuestion = String.Format("{0} ضربدر {1} می شود؟", Num1.ToString, Num2.ToString)
                HttpContext.Current.Session("Answer") = Num1 * Num2
                Session("Validate") = Num1 * Num2

        End Select

        lblQuesion.Text = strQuestion
        '
    End Sub

    Private Sub Swap(ByRef Number1 As Integer, ByRef Number2 As Integer)
        Dim temp As Integer = Number1
        Number1 = Number2
        Number2 = temp
    End Sub

    Public Function IsCorrect() As Boolean
        If txtInput.Text.Trim = Session("Validate").ToString() Then
            Call CreateQuestion()
            txtInput.BorderColor = Drawing.Color.Gray
            txtInput.Text = ""
            Return True
        Else
            Call CreateQuestion()
            txtInput.BorderColor = Drawing.Color.Red
            Return False
        End If
    End Function

End Class
