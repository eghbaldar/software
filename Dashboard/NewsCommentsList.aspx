<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="NewsCommentsList.aspx.vb" Inherits="Management_Admin_admin_software_NewsCommentsList" title="لیست نظرات خبرها" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
           function ChangeCheckBoxState(id, checkState)
           {
              var cb = document.getElementById(id);
              if (cb != null)
                 cb.checked = checkState;
           }

           function ChangeAllCheckBoxStates(checkState)
           {
              // Toggles through all of the checkboxes defined in the CheckBoxIDs array
              // and updates their value to the checkState input parameter
              if (CheckBoxIDs != null)
              {
                 for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxState(CheckBoxIDs[i], checkState);
              }
           }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div style="width: 100%; padding: 20px 0 20px 0">
            <div style="float: right; padding-left: 20px;">
                <asp:Button ID="btnDelete" runat="server" Text="حذف گروهی" CssClass="myButton" />
            </div>
            <div>
                <asp:Button ID="btnRead" runat="server" Text="خوانده شده" CssClass="myButton" />
            </div>
        </div>
        <div>
            <asp:GridView ID="gvCommentList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                GridLines="None" CssClass="gridview" PagerStyle-CssClass="pgr"
                DataKeyNames="CommentId" DataSourceID="SqlDataSource1" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkSelector" runat="server" onclick="if (this.checked==false) {ChangeAllCheckBoxStates(false)} else {ChangeAllCheckBoxStates(true)}" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectRecord" runat="server" Enabled="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <span>
                                <%#Container.DataItemIndex + 1%>
                            </span>
                            <asp:Label ID="lblCommentId" runat="server" Text='<%#Eval("CommentId")%>' Style="display: none;"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CommentId" HeaderText="CommentId" InsertVisible="False"   ReadOnly="True" SortExpression="CommentId" Visible="False" />
                    <asp:BoundField DataField="ParentId" HeaderText="ParentId" SortExpression="ParentId"  Visible="False" />
                    <asp:BoundField DataField="NewsId" HeaderText="NewsId" SortExpression="NewsId" Visible="False" />
                    <asp:BoundField DataField="Title" HeaderText="عنوان خبر" SortExpression="Title" />
                    <asp:BoundField DataField="FullName" HeaderText="نام نویسنده نظر" SortExpression="FullName" />
                    <asp:BoundField DataField="Email" HeaderText="آدرس ایمیل" SortExpression="Email" />
                    <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note" Visible="False" />
                    <asp:BoundField DataField="CreateOn" HeaderText="تاریخ ایجاد" SortExpression="CreateOn" />
                    <asp:CheckBoxField DataField="Visible" HeaderText="Visible" SortExpression="Visible" Visible="False" />
                    <asp:TemplateField HeaderText="وضعیت پیام" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%--<asp:Image ID="imgEnvelope" runat="server" Width="32px" ImageUrl='<%# iif(cbool(Eval("Visible")) = true,"../../Content/Images/Icon/open-envelope.png","../../Content/Images/Icon/close-envelope.png") %>' />--%>
                            <asp:Label ID="lblVisible" runat="server" Text='<%# iif(cbool(Eval("Visible")) = false,"<div class=""GoodStatus"">خوانده نشده</div>","<div class=""BadStatus"">خوانده شده</div>") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField SelectText="مشاهده پیام" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>"
                SelectCommand="SELECT tbl_Software_NewsComments.CommentId, tbl_Software_NewsComments.ParentId, tbl_Software_NewsComments.NewsId, tbl_Software_News.Title, tbl_Software_NewsComments.FullName, tbl_Software_NewsComments.Email, tbl_Software_NewsComments.Note, tbl_Software_NewsComments.CreateOn, tbl_Software_NewsComments.Visible FROM tbl_Software_News INNER JOIN tbl_Software_NewsComments ON tbl_Software_News.NewsId = tbl_Software_NewsComments.NewsId ORDER BY tbl_Software_NewsComments.Visible, tbl_Software_NewsComments.CommentId DESC">
            </asp:SqlDataSource>
        </div>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="CommentId" DataSourceID="SqlDataSource2">
            <ItemTemplate>
                <table style="margin-top: 20px;">
                    <tr>
                        <td style="font-weight: bold; padding-bottom: 10px;">
                            نام و نام خانوادگی :
                        </td>
                        <td>
                            <asp:Label ID="FullNameLabel" runat="server" Text='<%# Bind("FullName") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; padding-bottom: 10px;">
                            آدرس ایمیل :
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; padding-bottom: 10px;">
                            متن پیام :
                        </td>
                        <td>
                            <asp:Label ID="NoteLabel" runat="server" Text='<%# eval("Note").tostring().replace(vbcrlf,"<br/>") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; padding-bottom: 10px;">
                            تاریخ درج :
                        </td>
                        <td>
                            <asp:Label ID="CreateOnLabel" runat="server" Text='<%# Bind("CreateOn") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>"
            SelectCommand="SELECT [CommentId], [ParentId], [FullName], [Email], [Note], [CreateOn] FROM [tbl_Software_NewsComments] WHERE ([CommentId] = @CommentId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="gvCommentList" Name="CommentId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>
