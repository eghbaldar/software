Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class DonwloadCount
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function Inserting(ByVal PostId As Integer) As Integer

        Dim PostBLL As New Software.BLL.Post
        PostBLL.DownloadCountPlus1(PostId)
        ''Try
        'Dim sqlda As New SqlDataAdapter
        'Dim ds As New DataSet
        'Using cnn As New SqlConnection("Data Source=.;Initial Catalog=nupo;Integrated Security=True")
        '    Using sqlcom As New SqlCommand("insert into t([name]) values ('" + name + "')", cnn)
        '        sqlda.SelectCommand = sqlcom
        '        sqlda.Fill(ds)
        '        Return 1
        '    End Using
        'End Using
        '' Catch ex As Exception
        ''Return -1
        ''End Try

    End Function

End Class
