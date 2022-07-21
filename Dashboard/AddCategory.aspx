<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddCategory.aspx.vb" Inherits="Management_Admin_admin_software_AddCategory" title="افزودن دسته بندی" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="padding:0 10px 0 10px">
        <tr style="width:90%">
            <td style="width:50%" valign="top">
            
<%--                <asp:GridView ID="gvMenuItem" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
                    GridLines="None" DataKeyNames="CategoryId" Font-Names="Tahoma" 
                    Font-Size="10pt" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="CategoryId" HeaderText="شماره گروه" />
                        <asp:BoundField DataField="CategoryName" HeaderText="عنوان گروه" />
                        <asp:TemplateField HeaderText="حذف گروه" ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    OnClientClick="return confirm('آیا میخواهید این گروه حذف شود؟');"  
                                    ImageUrl="~/Management/Content/Images/Icon/delete.gif"
                                    CommandArgument='<% #Eval("CategoryId","{0}") %>' CommandName="Delete" 
                                    OnCommand="DeleteItem" Text="حذف..." />
                                    
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    DeleteMethod="Delete" OldValuesParameterFormatString=""
                    SelectMethod="SelectAll" TypeName="Software.BLL.Category" 
                    UpdateMethod="UpdateCategoryName">
                    <DeleteParameters>
                        <asp:Parameter Name="CategoryId" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="gvMenuItem" Name="CategoryId" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="gvMenuItem" Name="CategoryName" 
                            PropertyName="SelectedValue" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
--%>                           
                
                <asp:GridView ID="gvMenuItem" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataKeyNames="CategoryId" 
                    DataSourceID="SqlDataSource1" ForeColor="Black">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="CategoryId" HeaderText="شماره گزینه" 
                            InsertVisible="False" ReadOnly="True" SortExpression="CategoryId" />
                        <asp:BoundField DataField="CategoryName" HeaderText="نام دسته" 
                            SortExpression="CategoryName" />
                        <asp:TemplateField HeaderText="حذف گزینه" ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" ImageUrl="../Content/Images/delete.gif" 
                                    OnClientClick="return confirm('آیا میخواهید این گروه حذف شود؟');"  
                                    Text="Delete" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="انصراف" 
                            EditText="ویرایش گزینه" HeaderText="ویرایش" UpdateText="ثبت" />
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
                    DeleteCommand="DELETE FROM [tbl_Software_Category] WHERE [CategoryId] = @original_CategoryId AND [CategoryName] = @original_CategoryName" 
                    SelectCommand="SELECT [CategoryId], [CategoryName] FROM [tbl_Software_Category] ORDER BY [CategoryId]" 
                    UpdateCommand="UPDATE [tbl_Software_Category] SET [CategoryName] = @CategoryName WHERE [CategoryId] = @original_CategoryId AND [CategoryName] = @original_CategoryName" 
                    InsertCommand="INSERT INTO [tbl_Software_Category] ([CategoryName]) VALUES (@CategoryName)"
                    OldValuesParameterFormatString="original_{0}">
                    
<%--                    OldValuesParameterFormatString="original_{0}"
--%>                    
                    <DeleteParameters>
                        <asp:Parameter Name="original_CategoryId" Type="Int32" />
                        <asp:Parameter Name="original_CategoryName" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="original_CategoryId" Type="Int32" />
                        <asp:Parameter Name="original_CategoryName" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                
            </td>
            <td align="center" valign="top">
                <asp:Button ID="btnCreateMenu" runat="server" Text="ایجاد گزینه" 
                    CssClass="myButton" />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table>
                        <tr>
                            <td>
                                <p>
                                    عنوان صفحه :
                                </p>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" runat="server" ValidationGroup="InsertItem"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtTitle" ErrorMessage="*" style="direction: ltr" 
                                    ValidationGroup="InsertItem"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    شناسه پدر :
                                </p>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMenuItems" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton"
                                    ValidationGroup="InsertItem" />
                                <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass="myButton"
                                    ValidationGroup="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    
        <tr>
            <td colspan="2">
                <br /><br />
                <div>
                    <asp:TreeView ID="tvMenu" runat="server" BorderColor="Black" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="tahoma" ShowLines="True" 
                        BackColor="#ECE9D8">
                    </asp:TreeView>
                </div>                
            </td>
        </tr>    
    </table>
    <br />

</asp:Content>

