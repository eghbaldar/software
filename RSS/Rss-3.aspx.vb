Imports System.Xml
Imports System.Data


Partial Class RSS_Rss_3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Clear()
        Response.ContentType = "text/xml"
        Dim objX As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
        objX.WriteStartDocument()
        objX.WriteStartElement("rss")
        objX.WriteAttributeString("version", "2.0")
        objX.WriteStartElement("channel")

        objX.WriteElementString("title", "Sample Article RSS Feed")
        objX.WriteElementString("link", "http://www.vbasic.net/")
        objX.WriteElementString("description", "VBasic.NET offers simple downloadable, easy to understand tutorials and code examples using Visual Basic.NET, ASP.NET and Visual Studio. Visit often as new Tutorials and VB.NET Examples are added every day!")
        objX.WriteElementString("language", "en-us")
        objX.WriteElementString("ttl", "60")
        objX.WriteElementString("image", "http://vbasic.net/media/logo.gif")
        objX.WriteElementString("lastBuildDate", [String].Format("{0:R}", DateTime.Now))

        Dim PostBLL As New Software.BLL.Post
        Dim dt As DataTable = PostBLL.SelectAllForShow()
        For Each dr As DataRow In dt.Rows
            objX.WriteStartElement("item")
            objX.WriteElementString("title", dr("Title").ToString())
            objX.WriteElementString("author", "VBasic.net")
            objX.WriteElementString("link", "http://www.vbasic.net/")
            objX.WriteStartElement("guid")
            objX.WriteAttributeString("isPermaLink", "true")
            objX.WriteString("http://www.vbasic.net/")
            objX.WriteEndElement()
            objX.WriteElementString("pubDate", String.Format("{0:R}", Date.Now))
            objX.WriteStartElement("category")
            objX.WriteString("دسته بندی")
            objX.WriteEndElement()
            objX.WriteElementString("description", dr("DescFarsi").ToString())
            objX.WriteEndElement()
        Next

        objX.WriteEndElement()
        objX.WriteEndElement()
        objX.WriteEndDocument()
        objX.Flush()
        objX.Close()
        Response.End()

    End Sub



End Class
