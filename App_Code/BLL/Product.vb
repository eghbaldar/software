Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Product

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_ProductTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal Title As String, ByVal Picture As String, ByVal Price As Integer, ByVal URL As String) As Boolean
            '
            Return DAL.Insert(Title, Picture, Price, URL, False)
            '
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function Update(ByVal ID As Integer, ByVal Title As String, ByVal Picture As String, ByVal Price As Integer, ByVal URL As String) As Boolean
            '
            'Try
            Return DAL.UpdateProduct(Title, Picture, Price, URL, ID)
            'Catch ex As Exception
            'Return False
            'End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal ID As Integer) As Boolean
            '
            Return DAL.Delete(ID)
            '
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
        Public Function SelectActiveProduct() As DataTable

            Try
                Return DAL.SelectActiveProduct()
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function ChangeStatus(ByVal ID As Integer) As Boolean
            Return DAL.UpdateStatusToNot(ID)
        End Function

        Public Function ChangeStatus(ByVal ID As Integer, ByVal Flag As Boolean) As Boolean
            Return DAL.UpdateStatus(Flag, ID)
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function SelectTopNews() As DataTable
        '    '
        '    Try
        '        Return DAL.SelectTopNews()
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    ''
        'End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function SelectThreeTopNews() As DataTable
        '    '
        '    Try
        '        Return DAL.Select8TopNews()
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    ''
        'End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRow(ByVal ID As Integer) As DataTable

            Try
                Return DAL.GetDataByID(ID)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        'Public Shared Function IsEexistNews(ByVal NewsID As Integer) As Boolean
        '    Dim action As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_NewsTableAdapter
        '    Dim result As Integer = CBool(action.IsExistPost(NewsID))
        '    action.Dispose()
        '    Return result
        'End Function

    End Class

End Namespace