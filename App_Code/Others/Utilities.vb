Imports Microsoft.VisualBasic
Imports System.Data

Namespace Portal

    Public Class Utilities

        Public Shared Function GenerateFileName(ByVal filename As String) As String
            '
            Dim f As New System.IO.FileInfo(filename)
            Dim strNewFileName = Guid.NewGuid.ToString.Replace("-", "") & f.Extension
            Return strNewFileName
            ''
        End Function

        Public Shared Function BuildCategoryList(ByVal CategoryID As Integer) As String

            Dim str As String = String.Empty
            Dim AncherTemplate As String = "<a href=""Category.aspx?categoryId={0}"">{1}</a>"
            '
            Dim dt As DataTable = Software.BLL.Category.SelectParents(CategoryID)
            For Each dr As DataRow In dt.Rows
                str &= String.Format(AncherTemplate, dr("CategoryID").ToString(), dr("CategoryName").ToString())
                str &= " >> "
            Next
            str = str.Remove(str.Length - 4, 4)
            '
            Return str

        End Function

        Public Shared Sub ClearForm(ByVal parent As Control)
            '
            For Each c As Control In parent.Controls
                If (c.Controls.Count > 0) Then
                    ClearForm(c)

                ElseIf (c.[GetType]() Is GetType(TextBox)) Then
                    DirectCast(c, TextBox).Text = String.Empty

                ElseIf (c.[GetType]() Is GetType(CheckBox)) Then
                    DirectCast(c, CheckBox).Checked = False
                End If
            Next
            '
        End Sub

    End Class

End Namespace
