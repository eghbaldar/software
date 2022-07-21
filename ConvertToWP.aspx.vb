
Partial Class ConvertToWP
    Inherits System.Web.UI.Page

    Public Function FormatForXML(Input As Object) As String
        Dim data As String = Input.ToString()

        data = data.Replace("&", "&amp;")
        data = data.Replace("\", "&quot;")
        data = data.Replace("'", "&apos;")
        data = data.Replace("<", "&lt;")
        data = data.Replace(">", "&gt;")

        'If data.Length > 35 Then
        '    Return data.Substring(0, 30) & "..."
        'Else
        Return data
        'End If

    End Function

End Class
