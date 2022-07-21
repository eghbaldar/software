Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    <System.ComponentModel.DataObject()> _
    Public Class ErrorInLink

        Dim DAL As New ds_Shaahr_SoftwareTableAdapters.tbl_Software_ErrorInLinkTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function Insert(ByVal PostId As Integer, ByVal Name As String, ByVal EmailAddress As String, ByVal Description As String, ByVal Link As String) As Boolean
            '
            Try
                Description = Description.Replace(vbCrLf, "<br/>")
                'Return CBool(DAL.Insert(PostId, Name, EmailAddress, Description, True))
                Return CBool(DAL.Insert(PostId, Name, EmailAddress, Description, Link, True))
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function Update(ByVal OpinionId As Integer) As Boolean
            '
            Try

                DAL.UpdateFlag(OpinionId)
                Return True
            Catch ex As Exception
                Return False
            End Try
            ''
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function Delete(ByVal OpinionId As Integer) As Boolean
            '
            Try
                Return DAL.DeleteOpinion(OpinionId)
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
        Public Function SelectRow(ByVal OpinionId As Integer) As DataTable
            '
            Try
                Return DAL.SelectRow(OpinionId)
            Catch ex As Exception
                Return Nothing
            End Try
            ''
        End Function

    End Class

End Namespace