Imports System.ServiceModel.Syndication
Imports System.Xml

Partial Class RSS_Rss_4
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Response.Clear()
    '    Response.ContentType = "text/xml"
    '    Dim myFeed As New SyndicationFeed
    '    myFeed.Title = New TextSyndicationContent("Test Feed")
    '    myFeed.Description = New TextSyndicationContent("Examples")

    '    Dim feedItems As New List(Of SyndicationItem)

    '    Dim i As Integer

    '    For i = 0 To 10
    '        Dim item As SyndicationItem = New SyndicationItem()
    '        item.Title = New TextSyndicationContent("title" & i)
    '        Dim person As New SyndicationPerson("name@yahoo.com", "ebrahim", "ebrahimtabrizi.ir")
    '        item.Authors.Add(person)

    '        Dim link As New SyndicationLink(New System.Uri("http://www.google.com"))
    '        item.Links.Add(link)


    '        'item.Title = New TextSyndicationContent("Title " & i)
    '        'item.Summary = New TextSyndicationContent("Sumary " & i)
    '        'item.PublishDate = New DateTimeOffset(DateTime.Now)
    '        ''item.Categories = New SyndicationCategory("category")
    '        ''item.Content = New System.ServiceModel.Syndication.TextSyndicationContent("ebrahim")
    '        'item.Copyright = New TextSyndicationContent("copy right")
    '        'item.Id = i
    '        'item.


    '        'Dim authInfo As New SyndicationPerson
    '        'authInfo.Name = "Jon"
    '        'item.Authors.Add(authInfo)

    '        feedItems.Add(item)
    '    Next
    '    myFeed.Items = feedItems

    '    'Dim writer As XmlWriter
    '    'writer = XmlWriter.Create(Context.Response.Output)
    '    'XmlWriter.Create(Context.Response.Output)
    '    'myFeed.SaveAsRss20(writer)
    '    'writer.Close()

    '    Dim writer As XmlWriter
    '    writer = XmlWriter.Create(Context.Response.Output)
    '    myFeed.SaveAsRss20(writer)
    '    XmlWriter.Create(Context.Response.Output)
    '    writer.Close()

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)

        ' Add a custom attribute.
        Dim xqName As XmlQualifiedName = New XmlQualifiedName("CustomAttribute")
        feed.AttributeExtensions.Add(xqName, "Value")

        Dim sp As SyndicationPerson = New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://jesper/aaberg")
        feed.Authors.Add(sp)

        Dim category As SyndicationCategory = New SyndicationCategory("FeedCategory", "CategoryScheme", "CategoryLabel")
        feed.Categories.Add(category)

        feed.Contributors.Add(New SyndicationPerson("Lene@contoso.com", "Lene Aaling", "http://Lene/Aaling"))
        feed.Copyright = New TextSyndicationContent("Copyright 2007")
        feed.Description = New TextSyndicationContent("This is a sample feed")

        ' Add a custom element.
        Dim doc As XmlDocument = New XmlDocument()
        Dim feedElement As XmlElement = doc.CreateElement("CustomElement")
        feedElement.InnerText = "Some text"
        feed.ElementExtensions.Add(feedElement)

        feed.Generator = "Sample Code"
        feed.Id = "FeedID"
        feed.ImageUrl = New Uri("http://server/image.jpg")

        Dim textContent As TextSyndicationContent = New TextSyndicationContent("Some text content")
        Dim item As SyndicationItem = New SyndicationItem("Item Title", textContent, New Uri("http://server/items"), "ItemID", DateTime.Now)

        Dim items As List(Of SyndicationItem) = New List(Of SyndicationItem)()
        items.Add(item)
        feed.Items = items

        feed.Language = "en-us"
        feed.LastUpdatedTime = DateTime.Now

        Dim link As SyndicationLink = New SyndicationLink(New Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000)
        feed.Links.Add(link)

        Dim atomWriter As XmlWriter = XmlWriter.Create("atom.xml")
        Dim atomFormatter As Atom10FeedFormatter = New Atom10FeedFormatter(feed)
        atomFormatter.WriteTo(atomWriter)
        atomWriter.Close()
        Response.Clear()
        Response.ContentType = "text/xml"
        'Dim rssWriter As XmlWriter = XmlWriter.Create(Server.MapPath("rss.xml"))
        Dim rssWriter As XmlWriter = XmlWriter.Create(Response.Output)
        Dim rssFormatter As Rss20FeedFormatter = New Rss20FeedFormatter(feed)
        rssFormatter.WriteTo(rssWriter)
        rssWriter.Close()

    End Sub

End Class
