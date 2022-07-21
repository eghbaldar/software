Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Contact

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_ContactTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal FullName As String, ByVal Email As String, ByVal Note As String) As Boolean
            '
            Try
                Dim CreateDate As String = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.ShortDate)
                Dim CreateTime As String = Mid(Now.TimeOfDay.ToString(), 1, 8)
                DAL.Insert(FullName, Email, String.Empty, Note, CreateDate, CreateTime, False)
                Return True
            Catch ex As Exception
                'Throw ex
                Return False
            End Try
            ''
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        'Public Function Update() As Boolean
        '    '
        '    Try
        '        'Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        '    ''
        'End Function

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
                Return DAL.GetDataByID(ID)
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function ChangeFlag(ByVal ID As Integer) As Boolean
            Return DAL.UpdateFlagToNot(ID)
        End Function

        Public Function ChangeFlag(ByVal ID As Integer, ByVal Flag As Boolean) As Boolean
            Return DAL.UpdateFlag(Flag, ID)
        End Function

    End Class

End Namespace