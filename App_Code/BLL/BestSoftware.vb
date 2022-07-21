Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class BestSoftware

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_BestSoftwareTableAdapter    

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal Title As String, ByVal Icon As String, ByVal Description As String, ByVal URL As String) As Boolean
            '
            Try
                DAL.Insert(Title, Icon, Description, URL)
                Return True
            Catch ex As Exception
                'Throw ex
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function Update(ByVal ID As String, ByVal Title As String, ByVal Icon As String, ByVal Description As String, ByVal URL As String) As Boolean
            '
            Try
                Return DAL.Update(Title, Icon, Description, URL, ID)
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
        Public Function SelectRow(ByVal ID As Integer) As DataTable

            Try
                Return DAL.GetDataBy(ID)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class

End Namespace