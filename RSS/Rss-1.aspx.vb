
Partial Class RSS_Rss_1
    Inherits System.Web.UI.Page

    Protected Function RemoveIllegalCharacters(ByVal input As Object) As String
        Dim data As String = input.ToString()
        ' replace illegal characters in XML documents with their entity references
        data = data.Replace("&", "&amp;")
        data = data.Replace("""", "&quot;")
        data = data.Replace("'", "&apos;")
        data = data.Replace("<", "&lt;")
        data = data.Replace(">", "&gt;")

        Return data
    End Function

End Class
