Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class CrackFile

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CrackFileTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal PostId As Integer, ByVal Title As String, ByVal Filename As String) As Boolean
            '
            Try
                DAL.Insert(PostId, Title, Filename)
                Return True
            Catch ex As Exception
                Throw ex
                'Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function Update(ByVal Original_Id As Integer, ByVal PostId As Integer, ByVal Title As String, ByVal Filename As String) As Boolean
            '
            Try
                DAL.Update(PostId, Title, Filename, Original_Id)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal Original_Id As Integer) As Boolean
            '
            Try
                Return DAL.Delete(Original_Id)
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function SelectAll() As DataTable
            '
            Try
                Return DAL.GetData()
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function SelectByPotsId(ByVal PostId As Integer) As DataTable
            '
            Try
                Return DAL.SelectByPostId(PostId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
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