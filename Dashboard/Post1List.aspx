<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="Post1List.aspx.vb" Inherits="Management_Admin_admin_software_Post1List" title="لیست نرم افزار های شهر" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />

    <asp:GridView ID="gvPostList" runat="server"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr"            
    
        AutoGenerateColumns="False"
        DataSourceID="SqlDataSource1" 
        AllowPaging="True" 
        DataKeyNames="PostId">
        <Columns>
            <asp:BoundField DataField="PostId" HeaderText="شماره پست" InsertVisible="False" ReadOnly="True" SortExpression="PostId" />
            <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title" />
            <asp:BoundField DataField="CategoryName" HeaderText="طبقه" SortExpression="CategoryName"></asp:BoundField>
            <asp:BoundField DataField="DateOfCreatePost" HeaderText="تاریخ و ساعت ایجاد پست" SortExpression="DateOfCreatePost"></asp:BoundField>
            <asp:BoundField DataField="LocationNumber" HeaderText="محل قرار گیری" SortExpression="LocationNumber" Visible="false" />

            <asp:TemplateField HeaderText="وضعیت" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblVisiblePost" runat="server" Text='<%# iif(cbool(Eval("VisiblePost")) = True,"<div class=""GoodStatus"">قابل نمایش</div>","<div class=""BadStatus"">غیرقابل نمایش</div>") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False" HeaderText="عملیات" ItemStyle-Width="320px" >
                <ItemTemplate>                    
                    <asp:HyperLink ID="HyperLink3" runat="server" 
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
                        ToolTip="حذف پست"
                        OnClientClick="return confirm('آیا میخواهید این پست حذف شود؟');"  
                        OnCommand="DeletePost" 
                        CommandArgument='<% #Eval("PostId","{0}") %>' 
                        ImageUrl="../Content/Images/delete.gif" />                    
                    |
                    <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl='<%# Eval("PostId", "AddLink.aspx?PostId={0}") %>' Text="افزودن لینک"></asp:HyperLink>
                    |
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Eval("PostId", "AddCrackFile.aspx?PostId={0}") %>' 
                        Text="افزودن کرک"></asp:HyperLink>
                        
                </ItemTemplate>                              

<ItemStyle Width="320px"></ItemStyle>
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
            <asp:Parameter DefaultValue="1" Name="PostType" Type="Byte" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <div id="WebForm">
            <fieldset>
                <legend>افزودن خبر</legend>
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
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource2" 
                            DataTextField="CatName" DataValueField="CategoryId">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
                            SelectCommand="SELECT [CatName], [CategoryId] FROM [vSelectcategoryLevel4] ORDER BY [CategoryId]">
                        </asp:SqlDataSource>
                    </li>
                    <li>
                        <span class="lbl">متن کوتاه فارسی :</span>
                        <CKEditor:CKEditorControl ID="txtLidFarsi" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                    </li>
                    <li>
                        <span class="lbl">متن کامل فارسی :</span>
                        <CKEditor:CKEditorControl ID="txtBodyFarsi" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                    </li>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkHaveBodyEng" runat="server" Text="توضیح انگلیسی کامل" />
                        </span>
                        <CKEditor:CKEditorControl ID="txtBodyEng" BasePath="../Content/ckeditor" runat="server"></CKEditor:CKEditorControl>
                    </li>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkSoftwareFullName" runat="server" Text="نام کامل نرم افزار :" />
                        </span>
                        <asp:TextBox ID="txtSoftwareFullName" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </li>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkVersion" runat="server" Text="نسخه :" />
                        </span>
                        <asp:TextBox ID="txtVersion" runat="server" Enabled="False"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkFactorySite" runat="server" Text=" سایت شرکت سازنده :" />
                        </span>
                        <asp:TextBox ID="txtFactorySite" runat="server" Enabled="False"></asp:TextBox>
                    </li>

                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkDatePublish" runat="server" Text="سال و تاریخ انتشار :" />
                        </span>
                        <asp:TextBox ID="txtDatePublish" runat="server" Enabled="False"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">حجم فایل :</span>
                        <asp:TextBox ID="txtFileSize" runat="server" ></asp:TextBox>
                    </li>

                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkProductPrice" runat="server" Text="قیمت نرم افزار :" />
                        </span>
                        <asp:TextBox ID="txtProductPrice" runat="server" Enabled="False"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">
                            عکس بزرگ :
                        </span>
                        <asp:FileUpload ID="fuBigImageFileName" runat="server" />
                        <asp:Image ID="imgBigImageFileName" runat="server" />
                        <asp:Button ID="btnDeleteImage" runat="server" Text="حذف این عکس" CssClass="myButton" />
                    </li>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkLearningFile" runat="server" Text="آدرس فایل آموزشی :" />
                        </span>
                        <asp:TextBox ID="txtLearningFile" runat="server" Enabled="false" CssClass="ltr medium"></asp:TextBox>
                    </li>
                    <li>
                        <span class="lbl">
                            محل قرار گیری در صفحه:
                        </span>
                        <asp:TextBox ID="txtLocation" runat="server" ></asp:TextBox>
                    </li>
                    
                    <ii>
                        <span class="lbl">
                            <asp:CheckBox ID="chkVisiblePost" runat="server" Text="قابل نمایش" />
                        </span>
                    </ii>
                    <li>
                        <span class="lbl">
                            <asp:CheckBox ID="chkShowInfuture" runat="server" Text="نمایش در آینده" />
                        </span>
                        <asp:TextBox ID="txtShowDate" runat="server" Enabled="false"></asp:TextBox>
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