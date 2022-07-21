<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="Post2List.aspx.vb" Inherits="Management_Admin_admin_software_Post2List" title="لیست نرم افزارهای دسته 2" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />

    <asp:GridView ID="gvPostList" runat="server" 
        AutoGenerateColumns="False"  DataSourceID="SqlDataSource1"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr"            
        AllowPaging="True" DataKeyNames="PostId">
        <Columns>
            <asp:BoundField DataField="PostId" HeaderText="شماره پست" InsertVisible="False" ReadOnly="True" SortExpression="PostId" />
            <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="CategoryName" HeaderText="طبقه" SortExpression="CategoryName"></asp:BoundField>
            <asp:BoundField DataField="DateOfCreatePost" HeaderText="تاریخ و ساعت ایجاد پست" SortExpression="DateOfCreatePost"></asp:BoundField>
            <asp:BoundField DataField="LocationNumber" HeaderText="محل قرار گیری" SortExpression="LocationNumber" Visible="false" />
            
            <asp:TemplateField HeaderText="وضعیت" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblVisiblePost" runat="server" Text='<%# iif(cbool(Eval("VisiblePost")) = True,"<div class=""GoodStatus"">قابل نمایش</div>","<div class=""BadStatus"">غیرقابل نمایش</div>") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>            
            
            <asp:TemplateField ShowHeader="False" HeaderText="عملیات" ItemStyle-Width="180px" >
                <ItemTemplate>                    
                    |
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Eval("PostId", "ShowPost2Detail.aspx?PostId={0}") %>' 
                        Text="مشاهده جزئیات"></asp:HyperLink>
                    |
                    <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" 
                        ToolTip="ویرایش پست"
                        OnCommand="EditPost" 
                        CommandArgument='<% #Eval("PostId","{0}") %>' 
                        ImageUrl="../Content/Images/edit.gif" />
                    |
                    <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" 
                        OnClientClick="return confirm('آیا میخواهید این پست حذف شود؟');"  
                        OnCommand="DeletePost" 
                        ToolTip="حذف پست"
                        CommandArgument='<% #Eval("PostId","{0}") %>' 
                        ImageUrl="../Content/Images/delete.gif" />
                </ItemTemplate>                              
                <ItemStyle Width="180px"></ItemStyle>
            </asp:TemplateField>
            
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        <EmptyDataTemplate>
            پستی برای نمایش وجود ندارد
        </EmptyDataTemplate>
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>"         
        SelectCommand="SELECT dbo.tbl_Software_Post.PostId, dbo.tbl_Software_Post.Title, dbo.tbl_Software_Post.DateOfCreatePost, dbo.GetCategoryNameById(dbo.tbl_Software_Post.CategoryId) AS CategoryName, dbo.tbl_Software_Post.VisiblePost, dbo.tbl_Software_Post.ShowDate FROM dbo.tbl_Software_Post INNER JOIN dbo.tbl_Software_Category ON dbo.tbl_Software_Post.CategoryId = dbo.tbl_Software_Category.CategoryId WHERE (dbo.tbl_Software_Post.PostType = @PostType) ORDER BY dbo.tbl_Software_Post.PostId DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="PostType" Type="Byte" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">

        <div id="WebForm">
            <fieldset>
                <legend>ویرایش اطلاعات</legend>
                <ul>
                    <li>
                        <span class="lbl">عنوان پست :</span>
                        <asp:TextBox ID="txtPostTitle" runat="server" CssClass="medium"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtPostTitle" ErrorMessage="*" 
                            ValidationGroup="insert_news"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <span class="lbl">دسته بندی :</span>
                        <asp:DropDownList ID="dllCategory" runat="server" DataSourceID="SqlDataSource2" 
                            DataTextField="CatName" DataValueField="CategoryId">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
                            SelectCommand="SELECT [CatName], [CategoryId] FROM [vSelectcategoryLevel4] ORDER BY [CategoryId]">
                        </asp:SqlDataSource>                    
                    </li>
                    <li>
                        <span class="lbl">متن کامل :</span>
                        <CKEditor:CKEditorControl ID="txtDescBody" Height="400px" Width="100%" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                    </li>
                    <li>
                        <span class="lbl">لینک :</span>
                        <asp:TextBox ID="txtHyperlink" runat="server" CssClass="ltr medium"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">عکس :</span>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Image ID="imgBigImageFileName" runat="server" />
                        <asp:Button ID="btnDeleteImage" runat="server" Text="حذف این عکس" CssClass="myButton" />
                    </li>
                    <li>
                        <span class="lbl">تاریخ نمایش :</span>
                        <asp:TextBox ID="txtShowDate" runat="server" CssClass="ltr"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">محل قرار گیری در صفحه:</span>
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkFlag" runat="server" Text="قابل نمایش" />
                        </span>
                    </li>
                    <li>
                        <asp:Button ID="btnSavePost" runat="server" CssClass="myButton" Text="ارسال" ValidationGroup="Edit_News" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="myButton" Text="انصراف" ValidationGroup="Edit_News" />
                    </li>
                </ul>
            </fieldset>
        </div>        
    
    </asp:Panel>    


</asp:Content>