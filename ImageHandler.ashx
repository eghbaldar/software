<%@ WebHandler Language="VB" Class="ImgHandler_2" %>


Imports System
Imports System.IO
Imports System.Drawing
Imports System.Globalization

Public Class ImgHandler_2 : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        If context.Request("PostId") IsNot Nothing Then
            
            Dim PostId As Integer
            Integer.TryParse(context.Request("PostId"), PostId)
            Dim ImagePath As String = GetImagePathByPostId(PostId)
            If ImagePath = String.Empty Then Exit Sub
            Dim fullSizeImg As Image = System.Drawing.Image.FromFile(ImagePath)
            Dim w As Integer = fullSizeImg.Width
            Dim h As Integer = fullSizeImg.Height
            
            If context.Request("w") IsNot Nothing Then
                Integer.TryParse(context.Request("w"), w)
            End If
            If context.Request("h") IsNot Nothing Then
                Integer.TryParse(context.Request("h"), h)
            End If
            
            '=======================================
            Dim ms As New IO.MemoryStream
            fullSizeImg.Save(ms, Drawing.Imaging.ImageFormat.Jpeg)
            Dim mybmp As Bitmap
            
            If h > 0 And w > 0 Then
                If h >= fullSizeImg.Height And w >= fullSizeImg.Width Then
                    mybmp = fullSizeImg
                Else
                    mybmp = CreateThumbnail(ms, True, w, h)
                End If
            Else
                mybmp = fullSizeImg
            End If

            '=========================
            
            context.Response.ContentType = "image/jpeg"
            context.Response.Cache.SetCacheability(HttpCacheability.Public)
            context.Response.BufferOutput = True
            mybmp.Save(context.Response.OutputStream, Drawing.Imaging.ImageFormat.Jpeg)
            context.Response.End()

                '=========================
            
            'Dim ms1 As New IO.MemoryStream
            'mybmp.Save(ms1, Drawing.Imaging.ImageFormat.Jpeg)
            'Dim imageByte As Byte() = ms1.ToArray()

            'context.Response.ContentType = "image/jpeg"
            'context.Response.Cache.SetCacheability(HttpCacheability.Public)
            'context.Response.BufferOutput = true
            'context.Response.AddHeader("Content-Length", imageByte.Length.ToString(CultureInfo.InvariantCulture))
            'context.Response.BinaryWrite(imageByte)
            'context.Response.End()
            
            End If

    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Private Function GetImagePathByPostId(ByVal PostId As Integer) As String
        
        Dim imageName As String = GetImageNameFromDatabase(PostId)
        Dim imageType As Integer = GetImageTypeFromDatabase(PostId)
        Dim path As String = String.Empty
        
        If imageName = String.Empty Then Return String.Empty
        Select Case imageType
            Case 1, 2
                path = String.Format("/Content/Images/SoftwareImage/{0}", imageName)
            Case 3
                path = String.Format("/Content/Images/Ads/{0}", imageName)
        End Select
        
        Dim filePath As String = HttpContext.Current.Server.MapPath(path)
        Return filePath
        
    End Function
    
    Private Function GetImageNameFromDatabase(ByVal PostId As Integer) As String
        Dim PostBLL As New Software.BLL.Post
        Return PostBLL.GetPictureByPostID(PostId)
    End Function

    Private Function GetImageTypeFromDatabase(ByVal PostId As Integer) As String
        Dim PostBLL As New Software.BLL.Post
        Return PostBLL.GetPostType(PostId)
    End Function
    
    Public Function CreateThumbnail(ByVal memStream As MemoryStream, ByVal maintainAspectRatio As Boolean, ByVal desiredWidth As Integer, ByVal desiredHeight As Integer) As Bitmap
        '
        Dim bmp As Bitmap = Nothing
        Try
            'Dim memStream As New MemoryStream(imageByte)
            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(memStream)

            If maintainAspectRatio Then
                Dim aspectRatio As New AspectRatio()
                aspectRatio.WidthAndHeight(img.Width, img.Height, desiredWidth, desiredHeight)
                bmp = New Bitmap(img, aspectRatio.Width, aspectRatio.Height)
            Else
                bmp = New Bitmap(img, desiredWidth, desiredHeight)
            End If
            memStream.Dispose()
        Catch ex As Exception
            'havException = True
            'ExceptionMessage = ex.Message
        End Try
        Return bmp
        ''
    End Function
    
End Class

Public Class AspectRatio
    Private d_Width As Integer = 0
	Private d_Height As Integer = 0
	Public Property Width() As Integer
		Get
			Return d_Width
		End Get
		Set
			d_Width = value
		End Set
	End Property
	Public Property Height() As Integer
		Get
			Return d_Height
		End Get
		Set
			d_Height = value
		End Set
	End Property
	''' <summary>
	''' Methord For Calculate Hight and Width
	''' </summary>
	''' <param name="aWidth"></param>
	''' <param name="aHeight"></param>
	''' <param name="dWidth"></param>
	''' <param name="dHeight"></param>
	Public Sub WidthAndHeight(aWidth As Integer, aHeight As Integer, dWidth As Integer, dHeight As Integer)
		Dim height As Double = aHeight
		Dim width As Double = aWidth
		Dim rWidht As Double = Convert.ToDouble(dWidth)
		Dim rHeight As Double = Convert.ToDouble(dHeight)
		Dim fWidth As Integer = 0
		Dim fHeight As Integer = 0
		Dim hRatio As Double = 0.0
		Dim vRatio As Double = 0.0
		If width > rWidht Then
			hRatio = (rWidht / width)
			vRatio = (rHeight / height)

			If vRatio > hRatio Then
				fWidth = Convert.ToInt32(CDbl(width) * hRatio)
				fHeight = Convert.ToInt32(CDbl(height) * hRatio)
			Else
				fWidth = Convert.ToInt32(CDbl(width) * vRatio)
				fHeight = Convert.ToInt32(CDbl(height) * vRatio)

			End If
		ElseIf rWidht > width Then
			hRatio = (rWidht / width)
			vRatio = (rHeight / height)

			If vRatio > hRatio Then
				fWidth = Convert.ToInt32(CDbl(width) * hRatio)
				fHeight = Convert.ToInt32(CDbl(height) * hRatio)
			Else
				fWidth = Convert.ToInt32(CDbl(width) * vRatio)
				fHeight = Convert.ToInt32(CDbl(height) * vRatio)
			End If
		ElseIf height > rHeight Then
			hRatio = (rWidht / width)
			vRatio = (rHeight / height)

			If vRatio > hRatio Then
				fWidth = Convert.ToInt32(CDbl(width) * hRatio)
				fHeight = Convert.ToInt32(CDbl(height) * hRatio)
			Else
				fWidth = Convert.ToInt32(CDbl(width) * vRatio)
				fHeight = Convert.ToInt32(CDbl(height) * vRatio)
			End If
		ElseIf rHeight > height Then
			hRatio = (rWidht / width)
			vRatio = (rHeight / height)

			If vRatio > hRatio Then
				fWidth = Convert.ToInt32(CDbl(width) * hRatio)
				fHeight = Convert.ToInt32(CDbl(height) * hRatio)
			Else
				fWidth = Convert.ToInt32(CDbl(width) * vRatio)
				fHeight = Convert.ToInt32(CDbl(height) * vRatio)
			End If
		End If
		d_Width = fWidth
		d_Height = fHeight
	End Sub
End Class