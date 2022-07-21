Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Post

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_PostTableAdapter

#Region "تبلیغات"

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, False)> _
        Public Function InsertAds(ByVal Title As String, ByVal LidFarsi As String, ByVal DescFarsi As String, ByVal BigImageFilename As String, ByVal LocationNumber As Integer, ByVal VisiblePost As Boolean, ByVal ShowDate As String) As Boolean
            '
            Try
                Dim DateCreate As String = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.LongDate)
                Dim TimeCreate As String = Mid(Now.TimeOfDay.ToString(), 1, 8)
                DAL.InsertAds(Title, 0, LidFarsi, DescFarsi, BigImageFilename, String.Format("{1} - {0}", DateCreate, TimeCreate), LocationNumber, VisiblePost, ShowDate)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Function UpdateAds(ByVal PostId As Integer, ByVal Title As String, ByVal LidFarsi As String, ByVal DescFarsi As String, ByVal LocationNumber As Integer, ByVal Flag As Boolean) As Boolean
            '
            Try
                DAL.UpdateAds(Title, LidFarsi, DescFarsi, LocationNumber, PostId)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

#End Region


#Region "نرم افزارهای بیرون از شهر"

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, False)> _
        Public Function InsertPost2(ByVal Title As String, ByVal CategoryId As Integer, ByVal LidFarsi As String, ByVal BigImageFilename As String, ByVal LocationNumber As Integer, ByVal HyperLink As String, ByVal VisiblePost As Boolean, ByVal ShowDate As String) As Boolean
            '
            Try
                Dim DateCreate As String = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.LongDate)
                Dim TimeCreate As String = Mid(Now.TimeOfDay.ToString(), 1, 8)
                DAL.InsertPost2(Title, 2, CategoryId, LidFarsi, BigImageFilename, String.Format("{1} - {0}", DateCreate, TimeCreate), LocationNumber, HyperLink, VisiblePost, ShowDate)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Function UpdatePost2(ByVal PostId As Integer, ByVal Title As String, ByVal CategoryId As Integer, ByVal LidFarsi As String, ByVal BigImageFilename As String, ByVal LocationNumber As Integer, ByVal HyperLink As String, ByVal Flag As Boolean, ByVal ShowDate As String) As Boolean
            '
            Try
                DAL.UpdatePost2(Title, CategoryId, LidFarsi, BigImageFilename, LocationNumber, HyperLink, Flag, ShowDate, PostId)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

#End Region


#Region "نرم افزارهای داخل شهر"

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function InsertPost1(ByVal Title As String, ByVal CategoryId As Integer, ByVal LidFarsi As String, ByVal DescFarsi As String, ByVal HaveDescEnglish As Boolean, ByVal DescEnglish As String, ByVal HaveSoftwareFullName As Boolean, ByVal SoftwareFullName As String, ByVal HaveVersion As Boolean, ByVal Version As String, ByVal HaveFactorySite As Boolean, ByVal FactorySite As String, ByVal HaveDatePublish As Boolean, ByVal DatePublish As String, ByVal FileSize As String, ByVal HaveProductPrice As Boolean, ByVal ProductPrice As String, ByVal BigImageFilename As String, ByVal HaveLearningFile As Boolean, ByVal LearningFileName As String, ByVal LocationNumber As Integer, ByVal VisiblePost As Boolean, ByVal ShowDate As String) As Boolean
            '
            Try
                Dim DateCreate As String = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.LongDate)
                Dim TimeCreate As String = Mid(Now.TimeOfDay.ToString(), 1, 8)

                DAL.InsertPost1(Title, 1, CategoryId, LidFarsi, DescFarsi, HaveDescEnglish, DescEnglish, HaveSoftwareFullName, SoftwareFullName, HaveVersion, Version, HaveFactorySite, FactorySite, HaveDatePublish, DatePublish, FileSize, HaveProductPrice, ProductPrice, BigImageFilename, String.Format("{1} - {0}", DateCreate, TimeCreate), HaveLearningFile, LearningFileName, LocationNumber, VisiblePost, ShowDate)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function UpdatePost1(ByVal PostId As Integer, ByVal Title As String, ByVal CategoryId As Integer, ByVal LidFarsi As String, ByVal DescFarsi As String, ByVal HaveDescEnglish As Boolean, ByVal DescEnglish As String, ByVal HaveSoftwareFullName As Boolean, ByVal SoftwareFullName As String, ByVal HaveVersion As Boolean, ByVal Version As String, ByVal HaveFactorySite As Boolean, ByVal FactorySite As String, ByVal HaveDatePublish As Boolean, ByVal DatePublish As String, ByVal FileSize As String, ByVal HaveProductPrice As Boolean, ByVal ProductPrice As String, ByVal BigImageFilename As String, ByVal HaveLearningFile As Boolean, ByVal LearningFileName As String, ByVal LocationNumber As Integer, ByVal Flag As Boolean) As Boolean
            '
            'Try
            DAL.UpdatePost1(Title, CategoryId, LidFarsi, DescFarsi, HaveDescEnglish, DescEnglish, HaveSoftwareFullName, SoftwareFullName, HaveVersion, Version, HaveFactorySite, FactorySite, HaveDatePublish, DatePublish, FileSize, HaveProductPrice, ProductPrice, BigImageFilename, HaveLearningFile, LearningFileName, LocationNumber, Flag, PostId)
            Return True
            'Catch ex As Exception
            'Return False
            'End Try
            ''
        End Function

#End Region


        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Function ChangeFlag(ByVal PostId As Integer, ByVal Flag As Boolean) As Boolean
            '
            Try
                Return DAL.ChangeFlag(Flag, PostId)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal PostId As Integer) As Boolean
            '
            Try
                Return DAL.DeletePost(PostId)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function SelectAll() As DataTable

            Try
                Return DAL.GetData()
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function SelectAllForShow() As DataTable

            Try
                Return DAL.SelectAllForShow()
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function SelectAllForShow(ByVal today As String) As DataTable

            Try
                Return DAL.SelectAllForShowByDate(today)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function SelectAllForShow(ByVal categoryId As Integer) As DataTable

            Try
                Return DAL.SellectAllForShowByCategoryId(categoryId)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRelatedPost(ByVal PostId As Integer, ByVal CategoryId As Integer) As DataTable
            '
            Try
                Return DAL.GetRelatedPost(CategoryId, PostId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function


        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRow(ByVal PostId As Integer) As DataTable
            '
            Try
                Return DAL.SelectRow(PostId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectPopularSoftware() As DataTable
            '
            Try
                Return DAL.GetPopularSoftware()
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectPostCategory(ByVal PostID As Integer) As String
            '
            'Try
            Return DAL.GetPostCategory(PostID).ToString
            'Return DAL.GetCategoryNameById(CatID).ToString()
            'Dim temp As String = DAL.GetCategoryNameById(CatID).ToString()
            '(MsgBox(temp))
            'Return temp
            'Catch ex As Exception
            'Return Nothing
            'End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function GetCategoryNameById(ByVal CatID As Integer) As String
            '
            Return DAL.GetCategoryNameById(CatID).ToString()
            'Return ""
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function GetCategoryID(ByVal PostID As Integer) As Integer
            '
            Return DAL.GetCategoryID(PostID)
            '
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Private Function GetPostRating(ByVal PostId As Integer) As Single
            '
            'Try
            Return DAL.Software_GetPostRating(PostId)
            'Catch ex As Exception
            'Return 0
            'End Try
            ''
        End Function

        Public Function GetStarCount(ByVal PostId As Integer) As Byte
            '
            Dim bytResult As Byte
            Dim sngRating As Single = GetPostRating(PostId)

            Select Case sngRating
                Case 0 To 19
                    bytResult = 0
                Case 19 To 39
                    bytResult = 1
                Case 40 To 59
                    bytResult = 2
                Case 60 To 79
                    bytResult = 3
                Case 80 To 94
                    bytResult = 4
                Case 95 To 100
                    bytResult = 5
            End Select

            Return bytResult
            '
        End Function

        Public Function GetTotalPost() As Integer
            Return DAL.GetTotalPost()
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function SearchByTitle(ByVal title As String) As DataTable
        '    '
        '    Try
        '        Return DAL.SearchByTitle(title)
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    ''
        'End Function

        Public Shared Function IsEexistPost(ByVal PostID As Integer) As Boolean
            Dim action As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_PostTableAdapter
            Dim result As Integer = CBool(action.IsExistPost(PostID))
            action.Dispose()
            Return result
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function Search(ByVal Title As String) As DataTable
            '
            Dim dt As DataTable = Search(1, Title, "", "", "", "", 0)
            Return dt
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function Search(ByVal Title As String, ByVal Desc As String, ByVal SoftwareName As String, ByVal SiteAddress As String, ByVal FileSize As String, ByVal CategoryId As Integer) As DataTable
            '
            Dim dt As DataTable = Search(2, Title, Desc, SoftwareName, SiteAddress, FileSize, CategoryId)
            Return dt
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Private Function Search(ByVal searchType As Byte, ByVal Title As String, ByVal Desc As String, ByVal SoftwareName As String, ByVal SiteAddress As String, ByVal FileSize As String, ByVal CategoryId As Integer) As DataTable
            '
            'Try

            Dim searchDAL As New ds_Shaahr_SoftwareTableAdapters.usp_SearchTableAdapter
            Dim dt As DataTable = searchDAL.GetData(searchType, Title, Desc, SoftwareName, SiteAddress, FileSize, CategoryId)
            Return dt
            'Catch ex As Exception
            'Return Nothing
            'End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function HasCrackFile(ByVal PostId As Integer) As Boolean
            '
            Try
                Return DAL.HasCrackFile(PostId)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function TotalDownload() As Integer
            '
            Try
                Return Convert.ToInt32(DAL.TotalDownload)
            Catch ex As Exception
                Return 0
            End Try
            ''
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function TotalVisit() As Integer
        '    '
        '    Try
        '        Return Convert.ToInt32(DAL.TotalVisit())
        '    Catch ex As Exception
        '        Return 0
        '    End Try
        '    ''
        'End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, False)> _
        Public Function DownloadCountPlus1(ByVal PostId As Integer) As Boolean
            '
            Try
                Return DAL.DownloadCountPlus1(PostId)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function GetLastUpdate() As String
            '
            Return DAL.GetLastUpdate()
            ''
        End Function

        Public Function GetPictureByPostID(ByVal PostID As Integer) As String
            '
            Try
                Return DAL.GetPictureByPostId(PostID).ToString
            Catch ex As Exception
                Return String.Empty
            End Try
            ''
        End Function

        Public Function GetLink(ByVal PostID As Integer) As String
            Return DAL.GetLink(PostID)
        End Function

        Public Function GetPostType(ByVal PostID As Integer) As Integer
            Return DAL.GetPostType(PostID)
        End Function

        Public Sub DeleteImage(ByVal PostID As Integer)
            DAL.DeleteImage(PostID)
        End Sub

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function GetAllSoftwareForDefaultPage(ByVal ShamsiToday As String) As String
        '    '
        '    Dim AllSoftware As New ds_shaahr_Software_showTableAdapters.tbl_Software_AllPostTableAdapter
        '    Dim Res As String = String.Empty
        '    Dim dt As DataTable = AllSoftware.SelectAllForShow(ShamsiToday)
        '    If dt.Rows.Count = 0 Then Return Nothing
        '    For i As Byte = 0 To dt.Rows.Count - 1
        '        Res += dt.Rows(i)("PostType").ToString + "," + dt.Rows(i)("PostID").ToString + "," + _
        '             dt.Rows(i)("Title").ToString + "," + dt.Rows(i)("BigImageFilename").ToString + "," & dt.Rows(i)("Hyperlink").ToString & "|"
        '    Next
        '    Return Res.Substring(0, Res.Length - 1)
        '    ''
        'End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function GetAllSoftwareForDefaultPage2(ByVal ShamsiToday As String) As DataTable
        '    '
        '    Dim AllSoftware As New ds_shaahr_Software_showTableAdapters.tbl_Software_AllPostTableAdapter
        '    Dim Res As String = String.Empty
        '    Dim dt As DataTable = AllSoftware.SelectAllForShow(ShamsiToday)
        '    dt.Dispose()
        '    Return dt
        '    ''
        'End Function

    End Class



End Namespace