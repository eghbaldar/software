Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Comments

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CommentsTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal ParentId As Integer, ByVal PostId As Integer, ByVal FullName As String, ByVal Email As String, ByVal Note As String) As Boolean
            '
            Try
                Dim DateCreate As String = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.LongDate)
                Dim TimeCreate As String = Mid(Now.TimeOfDay.ToString(), 1, 8)
                DAL.Insert(ParentId, PostId, FullName, Email, Note, DateCreate & " " & TimeCreate, False)
                Return True
            Catch ex As Exception
                'Throw ex
                MsgBox(ex.Message)
                MsgBox(PostId)
                Return False
            End Try
            ''
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        'Public Function Update() As Boolean
        '    '
        '    Try
        '        DAL.UpdateNews(Title, Lid, Body, Flag, BigImageName1, BigImageName2, BigImageName3, SmallImageName1, NewsId)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        '    ''
        'End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function ChangeVisable(ByVal CommentId As Integer, ByVal flag As Boolean) As Boolean
            '
            Try
                Return DAL.ChangeVisible(flag, CommentId)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal CommentId As Integer) As Boolean
            '
            Try
                Return DAL.Delete(CommentId)
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

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectByPostID(ByVal PostId As Integer) As DataTable
            '
            Try
                Return DAL.SelectByPostID(PostId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectByMainComment(ByVal PostId As Integer) As DataTable
            '
            Try
                Return DAL.SelectByMainComment(PostId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectByMainComment(ByVal PostId As Integer, ByVal Visible As Boolean) As DataTable
            '
            Try
                Return DAL.SelectByMainComment2(PostId, Visible)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectByParentID(ByVal ParentId As Integer) As DataTable
            '
            Try
                Return DAL.SelectByParentId(ParentId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectByParentID(ByVal ParentId As Integer, ByVal Visible As Boolean) As DataTable
            '
            Try
                Return DAL.SelectByParentId2(ParentId, Visible)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRow(ByVal CommentId As Integer) As DataTable

            Try
                Return DAL.SelectRow(CommentId)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function GetCountVoteForThisPost(ByVal PostId As Integer) As Integer
            '
            Try
                Return DAL.GetCountVoteForThisPost(PostId)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

    End Class

End Namespace