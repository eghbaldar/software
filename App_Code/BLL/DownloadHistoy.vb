Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class DownloadHistory

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_DownloadHistoryTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal Username As String, ByVal PostID As Integer, ByVal LinkGroupID As Integer, ByVal LinkDetailID As Integer) As Boolean
            '
            Try
                Dim DownloadDate As String = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.ShortDate)
                'TODO : زمان اصلاح شود
                Dim DownloadTime As String = "" 'Mid(Now.TimeOfDay.ToString(), 1, 8)
                DAL.Insert(Username, PostID, LinkGroupID, LinkDetailID, DownloadDate, DownloadTime)
                Return True
            Catch ex As Exception
                Throw ex
                'Return False
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
            '
            Try
                Return DAL.GetData()
            Catch ex As Exception
                Return Nothing
            End Try
            '
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        'Public Function SelectRow(ByVal NewsId As Integer) As DataTable
        '
        '    Try
        '        Return DAL.SelectRow(NewsId)
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '
        'End Function

    End Class

End Namespace