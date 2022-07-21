Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Link

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_LinkTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal PostID As Integer, ByVal Title As String, ByVal TotalSize As String) As Boolean
            '
            Try
                DAL.Insert(PostID, Title, TotalSize)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function Update(ByVal LinkGroupID As Integer, ByVal PostID As Integer, ByVal Title As String, ByVal TotalSize As String) As Boolean
            '
            Try
                DAL.Update(PostID, Title, TotalSize, LinkGroupID)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal LinkGroupID As Integer) As Boolean
            '
            Try
                Return DAL.Delete(LinkGroupID)
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

            Try
                Return DAL.SelectByPostID(PostId)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRow(ByVal LinkGroupID As Integer) As DataTable

            Try
                Return DAL.SelectRow(LinkGroupID)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class

    <System.ComponentModel.DataObject()> _
    Public Class LinkDetail

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_LinkDetailTableAdapter


        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal LinkGroupID As Integer, ByVal Link As String, ByVal PartSize As String) As Boolean
            '
            Try
                DAL.Insert(LinkGroupID, Link, PartSize)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function Update(ByVal ID As Integer, ByVal LinkGroupID As Integer, ByVal Link As String, ByVal PartSize As String) As Boolean
            '
            Try
                DAL.Update(LinkGroupID, Link, PartSize, ID)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal ID As Integer) As Boolean
            '
            Try
                Return DAL.Delete(ID)
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
        Public Function SelectByLinkGroupID(ByVal LinkGroupID As Integer) As DataTable

            Try
                Return DAL.SelectByLinkGroupID(LinkGroupID)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRow(ByVal Id As Integer) As DataTable

            Try
                Return DAL.SelectRow(Id)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class

End Namespace