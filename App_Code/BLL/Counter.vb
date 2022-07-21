Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class Counter

        'Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CounterTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Shared Function Insert(ByVal IP As String, ByVal URL As String) As Boolean
            '
            Dim DAL As ds_Shaahr_SoftwareTableAdapters.tbl_Software_CounterTableAdapter
            Try
                DAL = New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CounterTableAdapter()
                Dim VisitDate, VisitTime As String
                VisitDate = ShamsiDate.Miladi2Shamsi(Now, ShamsiDate.ShowType.ShortDate)
                VisitTime = Mid(Now.TimeOfDay.ToString(), 1, 8)
                DAL.Insert(VisitDate, VisitTime, IP, URL)
                Return True
            Catch ex As Exception
                Return False
            Finally
                DAL.Dispose()
            End Try
            '
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Shared Function GetTotalVisit() As Integer
            '
            Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_CounterTableAdapter
            Dim result As Integer = DAL.GetTotalVisit()
            DAL.Dispose()
            Return result
            ''
        End Function


    End Class

End Namespace