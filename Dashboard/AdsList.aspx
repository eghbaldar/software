<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AdsList.aspx.vb" Inherits="Management_Admin_admin_software_AdsList" title="لیست تبلیغات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
        .style5
        {
            width: 97%;
            font-family: Tahoma;
            font-size: 11px;
        }
        .LabelSegment
        {
        	width:100px;
        }
        .ControlSegment
        {
            width: 700px;
            float:right;
            vertical-align:top;
        }
        .DivStyle
        {
        	margin-top:30px;
        	border-style:solid;
        	border-width:1px;
        	border-color:Green;
        	width:850px;
        	padding:20px;
        	direction:rtl;
        }
        .MessageStyle
        {
            border:solid 1px green; 
            margin:10px; 
            padding:10px; 
            font:Tahoma;
            background-color:Yellow;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="gvPostList" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="Black" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
        DataSourceID="SqlDataSource1" ForeColor="Black" 
        Width="100%" AllowPaging="True" Font-Size="10pt" Font-Names="Tahoma" DataKeyNames="PostId">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="PostId" HeaderText="شماره پست" InsertVisible="False" 
                ReadOnly="True" SortExpression="PostId" />
            <asp:BoundField DataField="Title" HeaderText="عنوان" 
                SortExpression="Title">
            </asp:BoundField>
            <asp:BoundField DataField="DateOfCreatePost" HeaderText="تاریخ و ساعت ایجاد پست" 
                SortExpression="DateOfCreatePost">
            </asp:BoundField>
            <asp:BoundField DataField="LocationNumber" HeaderText="محل قرار گیری" 
                SortExpression="LocationNumber" />
            
            <asp:HyperLinkField DataNavigateUrlFields="PostId" 
                DataNavigateUrlFormatString="ShowAdsDetail.aspx?PostId={0}" 
                HeaderText="مشاهده جزئیات" Text="مشاهده...">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            
            <asp:TemplateField HeaderText="ویرایش محتویات" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" 
                        OnCommand="EditPost" 
                        CommandArgument='<% #Eval("PostId","{0}") %>' 
                        ImageUrl="../Content/Images/edit.gif" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="حذف پست" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" 
                        OnClientClick="return confirm('آیا میخواهید این پست حذف شود؟');"  
                        OnCommand="DeletePost" 
                        CommandArgument='<% #Eval("PostId","{0}") %>' 
                        ImageUrl="../Content/Images/delete.gif" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <EmptyDataTemplate>
            پستی برای نمایش وجود ندارد
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
        SelectCommand="SELECT [PostId], [Title], [DateOfCreatePost], [LocationNumber] FROM [tbl_Software_Post] WHERE ([PostType] = @PostType)">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="PostType" Type="Byte" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <div style="float:right; margin:30px 0 30px 0">
    <asp:Label ID="lblMessage" runat="server" CssClass="MessageStyle" Visible="False"></asp:Label>
    </div>
    <asp:Panel ID="pnlEdit" runat="server" CssClass="DivStyle" Visible="false">

        <div>
    
                <table class="style5">
                
                    <tr>
                        <td class="LabelSegment">
                            عنوان پست :</td>
                        <td class="ControlSegment">
                            <asp:TextBox ID="txtPostTitle" runat="server" Height="19px" 
                                style="font-family: Tahoma; font-size: 11px" Width="465px"></asp:TextBox>
                            <span dir="rtl" onkeypress="FKeyPress()">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPostTitle" ErrorMessage="*" 
                                ValidationGroup="insert_news"></asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کوتاه :</td>
                        <td class="ControlSegment">
                            <CKEditor:CKEditorControl ID="txtAdsLid" Height="400px" Width="100%" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کامل :</td>
                        <td class="ControlSegment">
                            <CKEditor:CKEditorControl ID="txtAdsBody" Height="400px" Width="100%" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            محل قرار گیری در صفحه:</td>
                        <td class="ControlSegment">
                            <asp:TextBox ID="txtLocation" runat="server" Width=50></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            <asp:CheckBox ID="chkFlag" runat="server" Text="قابل نمایش" />
                        </td>
                        <td class="ControlSegment">
                        </td>
                    </tr>

                    <tr>
                        <td class="LabelSegment">
                        </td>
                        <td style="height:60px;">
                            <div style="float:right; width:200px; margin-right:180px;">
                                <asp:Button ID="btnSavePost" runat="server" CssClass="myButton" Text="ارسال" 
                                    ValidationGroup="Edit_News" />
                            </div>
                            <div style="float:right">
                                <asp:Button ID="btnCancel" runat="server" CssClass="myButton" Text="انصراف" 
                                    ValidationGroup="Edit_News" />
                            </div>
                        </td>
                    </tr>

                </table>
    
    </div>        
    
    </asp:Panel>    


</asp:Content>

