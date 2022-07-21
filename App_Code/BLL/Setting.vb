Imports Microsoft.VisualBasic
Imports System.Data

Namespace Software.BLL

    Public Class Setting

        Public Shared Property ShowPostComment() As Boolean
            Get
                Return Convert.ToBoolean(dbHelper.ExecuteScalar(CommandType.Text, "SELECT ShowPostComment FROM tbl_Software_Setting WHERE ID=1"))
            End Get
            Set(ByVal value As Boolean)
                Dim cmdParams(0) As System.Data.Common.DbParameter
                cmdParams(0) = dbHelper.CreateParameter("@ShowPostComment", DbType.Boolean, value)
                dbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE tbl_Software_Setting SET ShowPostComment = @ShowPostComment WHERE ID=1", cmdParams)
            End Set
        End Property

        Public Shared Property ShowNewsComment() As Boolean
            Get
                Return Convert.ToBoolean(dbHelper.ExecuteScalar(CommandType.Text, "SELECT ShowNewsComment FROM tbl_Software_Setting WHERE ID=1"))
            End Get
            Set(ByVal value As Boolean)
                Dim cmdParams(0) As System.Data.Common.DbParameter
                cmdParams(0) = dbHelper.CreateParameter("@ShowNewsComment", DbType.Boolean, value)
                dbHelper.ExecuteNonQuery(CommandType.Text, "UPDATE tbl_Software_Setting SET ShowNewsComment = @ShowNewsComment WHERE ID=1", cmdParams)
            End Set
        End Property

    End Class

End Namespace