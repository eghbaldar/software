<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddCrackFile.aspx.vb" Inherits="Management_Admin_admin_software_AddCrackFile" title="افزودن فایل کرک" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
       
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
        BorderColor="#FF9900" BorderStyle="Solid" BorderWidth="1px" CellPadding="20" 
        Font-Names="Tahoma" ForeColor="#333333" GridLines="Both" Font-Size="10pt">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
        
            <table>
                <tr>
                    <td>
                        <span class="lbl">عنوان پست :</span>
                        <%#DataBinder.Eval(Container.DataItem, "Title")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="lbl">طبقه :</span>
                        <%#DataBinder.Eval(Container.DataItem, "CategoryName")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="lbl">تاریخ و ساعت درج پست :</span>
                        <%#DataBinder.Eval(Container.DataItem, "DateOfCreatePost")%>
                    </td>
                </tr>
                
            </table>

        </ItemTemplate>
    </asp:DataList>
               
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
        SelectCommand="SELECT tbl_Software_Post.PostId, tbl_Software_Post.Title, tbl_Software_Post.DateOfCreatePost, tbl_Software_Post.LocationNumber, tbl_Software_Post.DescFarsi, tbl_Software_Post.BigImageFilename, tbl_Software_Post.Hyperlink, dbo.GetCategoryNameById(tbl_Software_Post.CategoryId) AS CategoryName FROM tbl_Software_Post INNER JOIN tbl_Software_Category ON tbl_Software_Post.CategoryId = tbl_Software_Category.CategoryId WHERE (tbl_Software_Post.PostId = @PostId)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="PostId" 
                QueryStringField="PostId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        
    <p><br /></p>
        
    <asp:GridView ID="gvCrackFile" runat="server" DataKeyNames="ID"
        DataSourceID="ObjectDataSource1"
        AutoGenerateColumns="False"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr" >
        <Columns>

            <asp:BoundField DataField="Title" HeaderText="عنوان"  SortExpression="Title"></asp:BoundField>
            
            <asp:TemplateField HeaderText="نام فایل" SortExpression="TotalSize">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Filename") %>' style="direction:ltr; padding:5p; text-align:left;"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Filename") %>' style="direction:ltr; padding:5p; text-align:left;"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="حذف" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" 
                        OnClientClick="return confirm('آیا میخواهید این فایل حذف شود؟');"  
                        OnCommand="DeletePost" 
                        CommandArgument='<% #Eval("Id","{0}") %>' 
                        ImageUrl="../Content/Images/delete.gif" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
            
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="SelectByPotsId" 
        TypeName="Software.BLL.CrackFile" DeleteMethod="Delete" 
        OldValuesParameterFormatString="" >
        <DeleteParameters>
            <asp:Parameter Name="Original_Id" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="PostId" QueryStringField="PostId" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
             
    <div id="WebForm">
        <fieldset>
            <legend>افزودن لینک</legend>
            <ul>
                <li>
                    <span class="lbl">عنوان :</span>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </li>
                <li>
                    <span class="lbl">نام فایل :</span>
                    <asp:TextBox ID="txtCrackFile" runat="server" CssClass="ltr medium" ></asp:TextBox>
                </li>            
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                    <asp:Button ID="btnReturn" runat="server" Text="بازگشت به لیست" CssClass="myButton" PostBackUrl="~/Dashboard/Post1List.aspx" />                        
                </li>
            </ul>
        </fieldset>
    </div>
    
</asp:Content>

