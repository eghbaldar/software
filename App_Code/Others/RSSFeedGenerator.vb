Imports System.Xml

'Namespace Utility
Public Class RSSFeedGenerator
    Private writer As XmlTextWriter

#Region "Private Members"
    Private _title As String
    Private _link As String
    Private _description As String
    Private _language As String = "en-gb"
    Private _copyright As String = "Copyright " + DateTime.Now.Year.ToString()
    Private _managingEditor As String
    Private _webMaster As String
    Private _pubDate As DateTime
    Private _lastBuildDate As DateTime
    Private _category As String
    Private _generator As String = "Axero Solutions RSS Generator"
    Private _docs As String = "http://blogs.law.harvard.edu/tech/rss"
    Private _rating As String
    Private _ttl As String = "20"
    Private _imgNavigationUrl As String
    Private _imgUrl As String
    Private _imgTitle As String
    Private _imgHeight As String
    Private _imgWidth As String
    Private _isItemSummary As Boolean = False
    Private _maxCharacters As Integer = 300
#End Region

#Region "Public Members"
    ''' 
    ''' Required - The name of the channel. It's how people refer to your service. If you have an HTML website that contains the same information as your RSS file, the title of your channel should be the same as the title of your website.
    ''' 
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    ''' 
    ''' Required - The URL to the HTML website corresponding to the channel.
    ''' 
    Public Property Link() As String
        Get
            Return _link
        End Get
        Set(ByVal value As String)
            _link = value
        End Set
    End Property

    ''' 
    ''' Required - Phrase or sentence describing the channel.
    ''' 
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    ''' 
    ''' The language the channel is written in.
    ''' 
    Public Property Language() As String
        Get
            Return _language
        End Get
        Set(ByVal value As String)
            _language = value
        End Set
    End Property

    ''' 
    ''' Copyright notice for content in the channel.
    ''' 
    Public Property Copyright() As String
        Get
            Return _copyright
        End Get
        Set(ByVal value As String)
            _copyright = value
        End Set
    End Property

    ''' 
    ''' Email address for person responsible for editorial content.
    ''' 
    Public Property ManagingEditor() As String
        Get
            Return _managingEditor
        End Get
        Set(ByVal value As String)
            _managingEditor = value
        End Set
    End Property

    ''' 
    ''' Email address for person responsible for technical issues relating to channel.
    ''' 
    Public Property WebMaster() As String
        Get
            Return _webMaster
        End Get
        Set(ByVal value As String)
            _webMaster = value
        End Set
    End Property

    ''' 
    ''' The publication date for the content in the channel. For example, the New York Times publishes on a daily basis, the publication date flips once every 24 hours. That's when the pubDate of the channel changes. 
    ''' 
    Public Property PubDate() As DateTime
        Get
            Return _pubDate
        End Get
        Set(ByVal value As DateTime)
            _pubDate = value
        End Set
    End Property

    ''' 
    ''' The last time the content of the channel changed.
    ''' 
    Public Property LastBuildDate() As DateTime
        Get
            Return _lastBuildDate
        End Get
        Set(ByVal value As DateTime)
            _lastBuildDate = value
        End Set
    End Property

    ''' 
    ''' Specify one or more categories that the channel belongs to.
    ''' 
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property

    ''' 
    ''' A string indicating the program used to generate the channel.
    ''' 
    Public Property Generator() As String
        Get
            Return _generator
        End Get
        Set(ByVal value As String)
            _generator = value
        End Set
    End Property

    ''' 
    ''' A URL that points to the documentation for the format used in the RSS file.
    ''' 
    Public Property Docs() As String
        Get
            Return _docs
        End Get
        Set(ByVal value As String)
            _docs = value
        End Set
    End Property

    ''' 
    ''' The PICS rating for the channel.
    ''' 
    Public Property Rating() As String
        Get
            Return _rating
        End Get
        Set(ByVal value As String)
            _rating = value
        End Set
    End Property

    ''' 
    ''' ttl stands for time to live. It's a number of minutes that indicates how long a channel can be cached before refreshing from the source. 
    ''' 
    Public Property Ttl() As String
        Get
            Return _ttl
        End Get
        Set(ByVal value As String)
            _ttl = value
        End Set
    End Property

    ''' 
    ''' is the URL of the site, when the channel is rendered, the image is a link to the site. (Note, in practice the image 
    Public Property ImgNavigationUrl() As String
        Get
            Return _imgNavigationUrl
        End Get
        Set(ByVal value As String)
            _imgNavigationUrl = value
        End Set
    End Property

    ''' 
    ''' The URL of a GIF, JPEG or PNG image that represents the channel
    ''' 
    Public Property ImgUrl() As String
        Get
            Return _imgUrl
        End Get
        Set(ByVal value As String)
            _imgUrl = value
        End Set
    End Property

    ''' 
    ''' Describes the image, it's used in the ALT attribute of the HTML  tag when the channel is rendered in HTML. 
    ''' 
    Public Property ImgTitle() As String
        Get
            Return _imgTitle
        End Get
        Set(ByVal value As String)
            _imgTitle = value
        End Set
    End Property

    ''' 
    ''' The height of the image
    ''' 
    Public Property ImgHeight() As String
        Get
            Return _imgHeight
        End Get
        Set(ByVal value As String)
            _imgHeight = value
        End Set
    End Property

    ''' 
    ''' The width of the image
    ''' 
    Public Property ImgWidth() As String
        Get
            Return _imgWidth
        End Get
        Set(ByVal value As String)
            _imgWidth = value
        End Set
    End Property

    ''' 
    ''' Indicates whether to show the full Item description or a summary
    ''' 
    Public Property IsItemSummary() As Boolean
        Get
            Return _isItemSummary
        End Get
        Set(ByVal value As Boolean)
            _isItemSummary = value
        End Set
    End Property

    ''' 
    ''' Indicates the amount of characters to display in the Item description
    ''' 
    Public Property MaxCharacters() As Integer
        Get
            Return _maxCharacters
        End Get
        Set(ByVal value As Integer)
            _maxCharacters = value
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New(ByVal stream As System.IO.Stream, ByVal encoding As System.Text.Encoding)
        writer = New XmlTextWriter(stream, encoding)
        writer.Formatting = Formatting.Indented
    End Sub

    Public Sub New(ByVal w As System.IO.TextWriter)
        writer = New XmlTextWriter(w)
        writer.Formatting = Formatting.Indented
    End Sub

#End Region

#Region "Methods"
    ''' 
    ''' Writes the beginning of the RSS document
    ''' 
    Public Sub WriteStartDocument()
        '            //
        '            writer.WriteStartDocument();
        'string PItext = "type='text/xsl' href='styles/rss.xsl'";
        'writer.WriteProcessingInstruction("xml-stylesheet", PItext);

        'string PItext2 = "type='text/css' href='styles/rss.css'";
        'writer.WriteProcessingInstruction("xml-stylesheet", PItext2);


        writer.WriteStartElement("rss")
        writer.WriteAttributeString("version", "2.0")
    End Sub

    ''' 
    ''' Writes the end of the RSS document
    ''' 
    Public Sub WriteEndDocument()
        writer.WriteEndElement()
        'rss
        writer.WriteEndDocument()
    End Sub

    ''' 
    ''' Closes this stream and the underlying stream
    ''' 
    Public Sub Close()
        writer.Flush()
        writer.Close()
    End Sub

    ''' 
    ''' Writes the beginning of a channel in the RSS document
    ''' 
    Public Sub WriteStartChannel()
        Try
            writer.WriteStartElement("channel")

            writer.WriteElementString("title", _title)
            writer.WriteElementString("link", _link)
            writer.WriteElementString("description", _description)

            If Not String.IsNullOrEmpty(_language) Then
                writer.WriteElementString("language", _language)
            End If

            If Not String.IsNullOrEmpty(_copyright) Then
                writer.WriteElementString("copyright", _copyright)
            End If

            If Not String.IsNullOrEmpty(_managingEditor) Then
                writer.WriteElementString("managingEditor", _managingEditor)
            End If

            If Not String.IsNullOrEmpty(_webMaster) Then
                writer.WriteElementString("webMaster", _webMaster)
            End If

            If _pubDate <> DateTime.MinValue AndAlso _pubDate <> DateTime.MaxValue Then
                writer.WriteElementString("pubDate", _pubDate.ToString("r"))
            End If

            If _lastBuildDate <> DateTime.MinValue AndAlso _lastBuildDate <> DateTime.MaxValue Then
                writer.WriteElementString("lastBuildDate", _lastBuildDate.ToString("r"))
            End If

            If Not String.IsNullOrEmpty(_category) Then
                writer.WriteElementString("category", _category)
            End If

            If Not String.IsNullOrEmpty(_generator) Then
                writer.WriteElementString("generator", _generator)
            End If

            If Not String.IsNullOrEmpty(_docs) Then
                writer.WriteElementString("docs", _docs)
            End If

            If Not String.IsNullOrEmpty(_rating) Then
                writer.WriteElementString("rating", _rating)
            End If

            If Not String.IsNullOrEmpty(_ttl) Then
                writer.WriteElementString("ttl", _ttl)
            End If

            If Not String.IsNullOrEmpty(_imgUrl) Then
                writer.WriteStartElement("image")
                writer.WriteElementString("url", _imgUrl)

                If Not String.IsNullOrEmpty(_imgNavigationUrl) Then
                    writer.WriteElementString("link", _imgNavigationUrl)
                End If

                If Not String.IsNullOrEmpty(_imgTitle) Then
                    writer.WriteElementString("title", _imgTitle)
                End If

                If Not String.IsNullOrEmpty(_imgWidth) Then
                    writer.WriteElementString("width", _imgWidth)
                End If

                If Not String.IsNullOrEmpty(_imgHeight) Then
                    writer.WriteElementString("height", _imgHeight)
                End If

                writer.WriteEndElement()


            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    ''' 
    ''' Writes the end of a channel in the RSS document
    ''' 
    Public Sub WriteEndChannel()
        writer.WriteEndElement()
        'channel
    End Sub

    ''' 
    ''' Writes an RSS Feed Item
    ''' 
    ''' The title of the item.
    ''' The URL of the item
    ''' The item synopsis.
    ''' Email address of the author of the item.
    ''' Includes the item in one or more categories
    ''' URL of a page for comments relating to the item.
    ''' A string that uniquely identifies the item.
    ''' Indicates when the item was published.
    ''' The URL of the RSS channel that the item came from.
    ''' The URL of where the enclosure is located
    ''' The length of the enclosure (how big it is in bytes).
    ''' The standard MIME type of the enclosure.
    Public Sub WriteItem(ByVal title As String, ByVal link As String, ByVal description As String, ByVal author As String, ByVal category As String, ByVal comments As String, _
     ByVal guid As String, ByVal pubDate As DateTime, ByVal source As String, ByVal encUrl As String, ByVal encLength As String, ByVal encType As String)
        Try
            writer.WriteStartElement("item")
            writer.WriteElementString("title", title)
            writer.WriteElementString("link", link)
            writer.WriteRaw("")

            If Not [String].IsNullOrEmpty(author) Then
                writer.WriteElementString("author", author)
            End If

            If Not [String].IsNullOrEmpty(category) Then
                writer.WriteElementString("category", category)
            End If

            If Not [String].IsNullOrEmpty(comments) Then
                writer.WriteElementString("comments", comments)
            End If

            If Not [String].IsNullOrEmpty(guid) Then
                writer.WriteElementString("guid", guid)
            End If

            'If pubDate IsNot Nothing AndAlso pubDate <> DateTime.MinValue AndAlso pubDate <> DateTime.MaxValue Then
            '    writer.WriteElementString("pubDate", pubDate.ToString("r"))
            'End If

            If Not [String].IsNullOrEmpty(source) Then
                writer.WriteElementString("source", source)
            End If

            If Not [String].IsNullOrEmpty(encUrl) AndAlso Not [String].IsNullOrEmpty(encLength) AndAlso Not [String].IsNullOrEmpty(encType) Then
                writer.WriteStartElement("enclosure")
                writer.WriteAttributeString("url", encUrl)
                writer.WriteAttributeString("length", encLength)
                writer.WriteAttributeString("type", encType)
                writer.WriteEndElement()
            End If

            writer.WriteEndElement()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' 
    ''' Trims the description if necessary
    ''' 
    ''' 
    ''' 
    Private Function GetDescription(ByVal description As String) As String
        If _isItemSummary Then
            If description = "" Then
                Return ""
            Else
                If description.Length > _maxCharacters Then
                    Return description.ToString().Substring(0, _maxCharacters) & " ..."
                Else
                    Return description
                End If
            End If
        Else
            Return description
        End If
    End Function

#End Region

End Class

'End Namespace
