
Partial Class test_test1
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pattern As String = "<p>([^<]+)</p>"

        Dim html As String = "<p>a123</p><p>b</p> <p>c</p> <p>d</p> <p>e</p> <p>f</p>"
        Dim firstEngTagP As Integer = html.IndexOf("</p>")
        Response.Write(HttpUtility.HtmlEncode(html.Substring(0, firstEngTagP + 4)))
        Response.Write("<br/>")
        Response.Write(HttpUtility.HtmlEncode(html.Substring(firstEngTagP + 4, html.Length - (firstEngTagP + 4))))
        'Dim result() As String = Regex.Split(html, pattern, RegexOptions.Multiline)

        'For i As Integer = 0 To result.Length - 1
        '    Response.Write(String.Format("{0} - {1}<br/>", i, result(i)))
        'Next
    End Sub

    'Function SplitParaghraf(ByVal p As String) As String
    '    'Dim result() As String = Regex.Split(p, "<p style=""text-align:left"">([^<]+)</p>", RegexOptions.IgnoreCase)
    '    'Dim result() As String = Regex.Split(p, "<p>([^<]+)</p>", RegexOptions.Multiline)
    '    Dim result() As String = Regex.Split(p, "/<\s*p[^>]*>([^<]*)<\s*\/\s*p\s*>/")
    '    Return result(0)
    'End Function

    Function SplitParaghraf(ByVal p As String) As Integer
        'Dim result() As String = Regex.Split(p, "<p style=""text-align:left"">([^<]+)</p>", RegexOptions.IgnoreCase)
        'Dim result() As String = Regex.Split(p, "<p>([^<]+)</p>", RegexOptions.Multiline)
        Dim result() As String = Regex.Split(p, "/<\s*p[^>]*>([^<]*)<\s*\/\s*p\s*>/",RegexOptions.Multiline)
        Return result.Length()
    End Function

End Class

