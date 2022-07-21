<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddLink.aspx.vb" Inherits="Management_Admin_admin_software_AddLink" title="افزودن دسته بندی لینک" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CellSpacing="20" 
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
    <asp:GridView ID="gvLink" runat="server" DataKeyNames="LinkGroupID" 
        DataSourceID="ObjectDataSource1" AutoGenerateColumns="False"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr" >
        <Columns>
        
            <asp:BoundField DataField="LinkGroupId" HeaderText="شماره گروه لینک" InsertVisible="False" ReadOnly="True" SortExpression="LinkGroupId" />
            <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="TotalSize" HeaderText="حجم کل فایل" SortExpression="TotalSize"></asp:BoundField>
            
            <asp:TemplateField HeaderText="حذف گروه" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" 
                        OnClientClick="return confirm('آیا میخواهید این گروه حذف شود؟');"  
                        OnCommand="DeletePost" 
                        CommandArgument='<% #Eval("LinkGroupId","{0}") %>' 
                        ImageUrl="../Content/Images/delete.gif" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="ویرایش" CssClass="myButton" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="ذخیره" CssClass="myButton" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="انصراف" CssClass="myButton" />
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:HyperLinkField DataNavigateUrlFields="LinkGroupId" 
                DataNavigateUrlFormatString="AddLinkDetail.aspx?GroupId={0}" 
                HeaderText="افزودن جزئیات" Text="افزودن...">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
            
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="SelectByPostID" 
        TypeName="Software.BLL.Link" DeleteMethod="Delete" 
        UpdateMethod="Update" >
        <DeleteParameters>
            <asp:Parameter Name="LinkGroupID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="LinkGroupID" Type="Int32" />
            <asp:Parameter Name="PostID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="TotalSize" Type="String" />
        </UpdateParameters>
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
                    <span class="lbl">حجم کل فایل :</span>
                    <asp:TextBox ID="txtTotalSize" runat="server"></asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                    <asp:Button ID="btnReturn" runat="server" Text="بازگشت به لیست" CssClass="myButton" PostBackUrl="~/Dashboard/Post1List.aspx" />
                </li>
            </ul>
        </fieldset> 
    </div>
    
</asp:Content>

