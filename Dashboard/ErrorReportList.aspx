<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="ErrorReportList.aspx.vb" Inherits="Management_Admin_admin_software_ErrorReportList" title="مشاهده گزارشات خظا" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" 
        ForeColor="#333333" DataKeyNames="OpinionId" Width="100%">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="OpinionId" Visible="false" />
            <asp:BoundField DataField="PostId" HeaderText="شماره پست" />
            <asp:BoundField DataField="Name"   HeaderText="نام" />
            <asp:BoundField DataField="EmailAddress" HeaderText="آدرس ایمیل"/>
            <asp:TemplateField HeaderText="آدرس صفحه">
                <ItemTemplate>
                    <a href="<%# Eval("Link")%>" target="_blank">مشاهده صفحه</a>
                    
<%--                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Link") %>'></asp:Label>
--%>                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="توضیحات">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Flag" Visible="False" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete"
        SelectMethod="SelectAll" TypeName="Software.BLL.ErrorInLink" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="OpinionId" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="OpinionId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>

