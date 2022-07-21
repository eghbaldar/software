Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Partial Class RSS_Rss_2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim PostBLL As New Software.BLL.Post
        Dim dt As DataTable = PostBLL.SelectAllForShow()

        Response.Clear()
        Response.ContentType = "text/xml"
        Dim TextWriter As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
        TextWriter.WriteStartDocument()
        'Below tags are mandatory rss
        TextWriter.WriteStartElement("rss")
        TextWriter.WriteAttributeString("version", "2.0")
        ' Channel tag will contain RSS feed details
        TextWriter.WriteStartElement("channel")
        TextWriter.WriteElementString("title", "C#.NET,ASP.NET Samples and Tutorials")
        TextWriter.WriteElementString("link", "http://aspdotnet-suresh.blogspot.com")
        TextWriter.WriteElementString("description", "Free ASP.NET articles,C#.NET,ASP.NET tutorials and Examples,Ajax,SQL Server,Javascript,XML,GridView Articles and code examples -- by Suresh Dasari")
        TextWriter.WriteElementString("copyright", "Copyright 2009 - 2010 aspdontnet-suresh.blogspot.com. All rights reserved.")
        For Each oFeedItem As DataRow In dt.Rows
            TextWriter.WriteStartElement("item")
            TextWriter.WriteElementString("title", oFeedItem("Title").ToString())
            TextWriter.WriteElementString("description", oFeedItem("DescFarsi").ToString())
            'TextWriter.WriteElementString("link", oFeedItem("URL").ToString())
            TextWriter.WriteElementString("link", "http://www.mylink.com/")
            TextWriter.WriteEndElement()
        Next
        TextWriter.WriteEndElement()
        TextWriter.WriteEndElement()
        TextWriter.WriteEndDocument()
        TextWriter.Flush()
        TextWriter.Close()
        Response.End()
    End Sub

End Class
