<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master"
    AutoEventWireup="false" CodeFile="AddLinkDetail.aspx.vb" Inherits="Management_Admin_admin_software_AddLinkDetail"
    Title="افزودن آدرس فایلهای دانلودی" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" BorderColor="#FF9900"
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" ForeColor="#333333"
        GridLines="Both" Font-Size="10pt">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <span class="lbl">عنوان :</span>
                        <%#DataBinder.Eval(Container.DataItem, "Title")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="lbl">کل فایل :</span>
                        <%#DataBinder.Eval(Container.DataItem, "TotalSize")%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>"
        SelectCommand="SELECT LinkGroupID, Title, TotalSize FROM tbl_Software_Link WHERE (LinkGroupID = @LinkGroupID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="LinkGroupID" QueryStringField="GroupID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <div style="margin-top: 20px;">
        <asp:GridView ID="gvLink" runat="server" DataKeyNames="ID" DataSourceID="ObjectDataSource1"
            GridLines="None"
            CssClass="gridview"
            PagerStyle-CssClass="pgr"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="شماره لینک" InsertVisible="False" ReadOnly="True"  SortExpression="Id" />
                <asp:TemplateField HeaderText="آدرس" SortExpression="Link">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Link") %>' CssClass="ltr"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Link") %>'  CssClass="ltr"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PartSize" HeaderText="حجم فایل" SortExpression="PartSize"></asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="ویرایش" CssClass="myButton" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="ذخیره" CssClass="myButton" />
                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="انصراف" CssClass="myButton" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="حذف گروه" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" OnClientClick="return confirm('آیا میخواهید این گروه حذف شود؟');"
                            OnCommand="DeletePost" CommandArgument='<% #Eval("ID","{0}") %>' ImageUrl="../Content/Images/delete.gif" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectByLinkGroupID"
        TypeName="Software.BLL.LinkDetail" DeleteMethod="Delete" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="LinkGroupID" Type="Int32" />
            <asp:Parameter Name="Link" Type="String" />
            <asp:Parameter Name="PartSize" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="LinkGroupID" QueryStringField="GroupID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <div id="WebForm">
        <fieldset>
            <legend>افزودن جزئیات لینک</legend>
            <ul>
                <li>
                    <span class="lbl">آدرس :</span>
                    <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                </li>
                <li>
                    <span class="lbl">حجم فایل :</span>
                    <asp:TextBox ID="txtPartSize" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                    <asp:Button ID="btnReturn" runat="server" Text="بازگشت به لیست" CssClass="myButton" PostBackUrl="~/Dashboard/Post1List.aspx" />
                </li>
            </ul>
        </fieldset>
    </div>

</asp:Content>
