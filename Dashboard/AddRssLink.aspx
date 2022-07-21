<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddRssLink.aspx.vb" Inherits="Management_Admin_admin_software_AddRssLink" title="افزودن منابع RSS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="overflow:auto; margin-bottom:30px;">
        <div style="overflow:auto; margin:40px 10px 10px 10px;">
            <div style="float:right; width:70px;">عنوان سایت : </div>
            <div style="float:right;">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </div>
        </div>
        <div style="overflow:auto; margin:10px 10px 10px 10px;">
            <div style="float:right; width:70px;">عنوان سایت : </div>
            <div style="float:right;">
                <asp:TextBox ID="txtRssLink" runat="server" Width="250px"></asp:TextBox>
            </div>
        </div>
        <div style="width:80px; text-align:left; margin-top:20px;">
            <asp:Button ID="btnSaveRssLink" runat="server" Text="ذخیره" CssClass="myButton" />
        </div>
    </div>
    <asp:GridView ID="gvRssLink" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" 
        ForeColor="Black" BackColor="White" BorderColor="Black" 
        BorderStyle="None" BorderWidth="1px">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
        
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title" />
            <asp:BoundField DataField="RssLink" HeaderText="آدرس" 
                SortExpression="RssLink" />
            <asp:CommandField CancelText="انصراف" EditText="ویرایش" ShowEditButton="True" 
                UpdateText="ذخیره" HeaderText="ویرایش منبع" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" 
                HeaderText="حذف منبع" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
        DeleteCommand="DELETE FROM [tbl_Software_RssLink] WHERE [Id] = @original_Id AND [Title] = @original_Title AND [RssLink] = @original_RssLink" 
        InsertCommand="INSERT INTO [tbl_Software_RssLink] ([Title], [RssLink]) VALUES (@Title, @RssLink)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [tbl_Software_RssLink]" 
        UpdateCommand="UPDATE [tbl_Software_RssLink] SET [Title] = @Title, [RssLink] = @RssLink WHERE [Id] = @original_Id AND [Title] = @original_Title AND [RssLink] = @original_RssLink">
        <DeleteParameters>
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_Title" Type="String" />
            <asp:Parameter Name="original_RssLink" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="RssLink" Type="String" />
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_Title" Type="String" />
            <asp:Parameter Name="original_RssLink" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="RssLink" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

