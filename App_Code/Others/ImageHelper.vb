Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class ImageHelper

    Private Shared Function CalculateDimensions(ByVal oldSize As Size, ByVal targetSize As Integer) As Size
        Dim newSize As Size
        If (oldSize.Height > oldSize.Width) Then
            newSize.Width = CType((oldSize.Width * CType((targetSize / CType(oldSize.Height, Single)), Single)), Integer)
            newSize.Height = targetSize
        Else
            newSize.Width = targetSize
            newSize.Height = CType((oldSize.Height * CType((targetSize / CType(oldSize.Width, Single)), Single)), Integer)
        End If
        Return newSize
    End Function

    'Public Shared Function ResizeImageFile(ByVal imageFile() As Byte, ByVal targetSize As Integer) As Byte()
    '    Using oldImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(imageFile))
    '        Dim newSize As Size = CalculateDimensions(oldImage.Size, targetSize)
    '        Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
    '            Using canvas As Graphics = Graphics.FromImage(newImage)
    '                canvas.SmoothingMode = SmoothingMode.AntiAlias
    '                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
    '                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
    '                canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
    '                Dim m As New MemoryStream
    '                newImage.Save(m, ImageFormat.Jpeg)
    '                Return m.GetBuffer
    '            End Using
    '        End Using
    '    End Using
    'End Function

    Public Shared Function ResizeImageFile(ByVal imageFile() As Byte, ByVal Width As Integer, ByVal Height As Integer) As Byte()
        Using oldImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(imageFile))
            Dim newSize As Size
            newSize.Height = Height
            newSize.Width = Width
            Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
                Using canvas As Graphics = Graphics.FromImage(newImage)
                    canvas.SmoothingMode = SmoothingMode.AntiAlias
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                    canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                    Dim m As New MemoryStream
                    newImage.Save(m, ImageFormat.Jpeg)
                    Return m.GetBuffer
                End Using
            End Using
        End Using
    End Function


    'Public Shared Function ResizeImageFile(ByVal OldFile As String, ByVal NewFile As String, ByVal targetSize As Integer) As Boolean
    '    '----------------------------------------------------
    '    Dim f As IO.FileInfo = New IO.FileInfo(OldFile)
    '    Dim Buffer() As Byte = New Byte((f.OpenRead.Length) - 1) {}
    '    f.OpenRead.Read(Buffer, 0, CType(f.OpenRead.Length, Integer))
    '    '----------------------------------------------------
    '    Dim OldImageFile As Byte() = Buffer
    '    '----------------------------------------------------
    '    Try
    '        Using oldImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(OldImageFile))
    '            Dim newSize As Size = CalculateDimensions(oldImage.Size, targetSize)
    '            Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
    '                Using canvas As Graphics = Graphics.FromImage(newImage)
    '                    canvas.SmoothingMode = SmoothingMode.AntiAlias
    '                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
    '                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
    '                    canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
    '                    newImage.Save(NewFile)
    '                    Return True
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Shared Function ResizeImageFile(ByVal imageFile As String, ByVal NewFile As String, ByVal Width As Integer, ByVal Height As Integer) As Boolean
        '----------------------------------------------------
        Dim f As IO.FileInfo = New IO.FileInfo(imageFile)
        Dim Buffer() As Byte = New Byte((f.OpenRead.Length) - 1) {}
        f.OpenRead.Read(Buffer, 0, CType(f.OpenRead.Length, Integer))
        '----------------------------------------------------
        Dim OldImageFile As Byte() = Buffer
        '----------------------------------------------------
        Try
            Using oldImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(OldImageFile))
                Dim newSize As Size
                newSize.Height = Height
                newSize.Width = Width
                Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
                    Using canvas As Graphics = Graphics.FromImage(newImage)
                        canvas.SmoothingMode = SmoothingMode.AntiAlias
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                        canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                        newImage.Save(NewFile, Drawing.Imaging.ImageFormat.Jpeg)
                        Return True
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ResizeImageFile(ByVal imageFile As Byte(), ByVal newFile As String, ByVal Width As Integer, ByVal Height As Integer) As Boolean
        '
        Try
            Using oldImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(imageFile))
                Dim newSize As Size
                newSize.Height = Height
                newSize.Width = Width
                Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
                    Using canvas As Graphics = Graphics.FromImage(newImage)
                        canvas.SmoothingMode = SmoothingMode.AntiAlias
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                        canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                        newImage.Save(newFile, Drawing.Imaging.ImageFormat.Jpeg)
                        Return True
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
        '
    End Function

End Class