Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Category

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CategoryTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal ParentId As Integer, ByVal CategoryName As String, ByVal Icon As String) As Boolean
            '
            Try
                DAL.Insert(ParentId, CategoryName, Icon)
                Return True
            Catch ex As Exception
                'Throw ex
                Return False
            End Try
            ''
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        'Public Function Update(ByVal CategoryId As Integer, ByVal ParentId As Integer, ByVal CategoryName As String, ByVal Icon As String) As Boolean
        '    '
        '    Try
        '        DAL.Update(ParentId, CategoryName, Icon, CategoryId)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        '    ''
        'End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function UpdateCategoryName(ByVal CategoryId As Integer, ByVal CategoryName As String) As Boolean
            '
            Try
                DAL.UpdateCategoryName(CategoryName, CategoryId)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal CategoryId As Integer) As Boolean
            '
            Try
                Return DAL.Delete(CategoryId)
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

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectRow(ByVal CategoryId As Integer) As DataTable
            '
            Try
                Return DAL.SelectRow(CategoryId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function SelectNestedCategory() As DataTable
            '
            Dim action As New ds_Shaahr_SoftwareTableAdapters.vSelectcategoryLevel4TableAdapter
            Return action.GetData
            '
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Shared Function SelectParents(ByVal CategoryID As Integer) As DataTable
            '
            Dim action As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CategoryTableAdapter
            Dim dt As DataTable = action.SelectParents(CategoryID)
            action.Dispose()
            Return dt
            ''
        End Function

        Public Shared Function IsEexistCategory(ByVal CategoryID As Integer) As Boolean
            Dim action As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CategoryTableAdapter
            Dim result As Integer = CBool(action.IsExistCategory(CategoryID))
            action.Dispose()
            Return result
        End Function

    End Class

End Namespace