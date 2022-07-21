<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="NewsList.aspx.vb" Inherits="Management_Admin_admin_software_NewsList" title="لیست خبرها" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />

    <asp:GridView ID="gvNewsList" runat="server" 
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr"
        
        AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        Width="100%" AllowPaging="True"
        DataKeyNames="NewsId">
        <Columns>
            <asp:BoundField DataField="NewsId" HeaderText="شماره خبر" InsertVisible="False" 
                ReadOnly="True" SortExpression="NewsId" />
            <asp:BoundField DataField="Title" HeaderText="عنوان خبر" 
                SortExpression="Title">
                <HeaderStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="DateCreate" HeaderText="تاریخ درج خبر" 
                SortExpression="DateCreate">
                <HeaderStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="TimeCreate" HeaderText="ساعت درج خبر" 
                SortExpression="TimeCreate" />
            <asp:TemplateField HeaderText="وضعیت نمایش" SortExpression="Flag">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# iif(Eval("Flag"),"<div class=""GoodStatus"">قابل نمایش</div>","<div class=""BadStatus"">غیر قابل نمایش</div>") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="NewsId" Target="_blank" 
                DataNavigateUrlFormatString="ShowNewsDetail.aspx?NewsId={0}" 
                HeaderText="مشاهده جزئیات" Text="مشاهده...">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            
            <asp:TemplateField HeaderText="ویرایش خبر" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" 
                        OnCommand="EditNews" 
                        CommandArgument='<% #Eval("NewsId","{0}") %>' 
                        ImageUrl="../Content/Images/edit.gif" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="حذف خبر" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" 
                        OnClientClick="return confirm('آیا میخواهید این خبر حذف شود؟');"  
                        OnCommand="DeleteNews" 
                        CommandArgument='<% #Eval("NewsId","{0}") %>' 
                        ImageUrl="../Content/Images/delete.gif" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            خبری برای نمایش وجود ندارد
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
        SelectCommand="SELECT [NewsId], [Title], [DateCreate], [TimeCreate], [Flag] FROM [tbl_Software_News]">
    </asp:SqlDataSource>
    
    <asp:Panel ID="pnlEdit" runat="server" CssClass="DivStyle" Visible="false">

    
<%--        <table class="style5">
            <tr>
                <td class="LabelSegment">
                    عنوان خبر :</td>
                <td class="ControlSegment">
                    <asp:TextBox ID="txtNewsTitle" runat="server" Height="19px" 
                        style="font-family: Tahoma; font-size: 11px" Width="465px"></asp:TextBox>
                    <span dir="rtl" onkeypress="FKeyPress()">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtNewsTitle" ErrorMessage="*" 
                        ValidationGroup="insert_news"></asp:RequiredFieldValidator>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                    متن کوتاه خبر:</td>
                <td class="ControlSegment">
                    <CKEditor:CKEditorControl ID="txtNewsLid" Height="400px" Width="100%" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                    متن کامل خبر:</td>
                <td class="ControlSegment">
                    <CKEditor:CKEditorControl ID="txtNewsBody" Height="400px" Width="100%" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                    وضعیت خبر:</td>
                <td class="ControlSegment">
                    <asp:RadioButtonList ID="rblShowStatus" runat="server">
                        <asp:ListItem Value="True" Selected="True">نمایش داده شود</asp:ListItem>
                        <asp:ListItem Value="False">نمایش داده نشود</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                     
                    عکس بزرگ (1) :</td>
                <td class="ControlSegment">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Image ID="Image1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                     
                    عکس بزرگ (2) :</td>
                <td class="ControlSegment">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Image ID="Image2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                     
                    عکس بزرگ (3) :</td>
                <td class="ControlSegment">
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                    <asp:Image ID="Image3" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                     
                    عکس کوچک :</td>
                <td class="ControlSegment">
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                    <asp:Image ID="Image4" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelSegment">
                </td>
                <td style="height:60px;">
                    <div style="float:right; width:200px; margin-right:180px;">
                        <asp:Button ID="btnSaveNews" runat="server" CssClass="myButton" Text="ارسال" ValidationGroup="Edit_News" />
                    </div>
                    <div style="float:right">
                        <asp:Button ID="btnCancel" runat="server" CssClass="myButton" Text="انصراف" ValidationGroup="Edit_News" />
                    </div>
                    
                </td>
            </tr>
            
        </table>--%>
    
    
<div id="WebForm">
        <fieldset>
            <legend>افزودن خبر</legend>
            <ul>
                <li>
                    <span class="lbl">عنوان خبر :</span>
                    <asp:TextBox ID="txtNewsTitle" runat="server" Height="19px" 
                        style="font-family: Tahoma; font-size: 11px" Width="465px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtNewsTitle" ErrorMessage="*" 
                        ValidationGroup="insert_news"></asp:RequiredFieldValidator>
                    
                </li>
                <li>
                    <span class="lbl">متن کوتاه خبر :</span>
                    <CKEditor:CKEditorControl ID="txtNewsLid" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                </li>
                <li>
                    <span class="lbl">متن کامل خبر :</span>
                    <CKEditor:CKEditorControl ID="txtNewsBody" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>                    
                </li>
                <li>
                    <span class="lbl" style="float:right;">وضعیت خبر :</span>
                    <asp:RadioButtonList ID="rblShowStatus" runat="server">
                        <asp:ListItem Value="True" Selected="True">نمایش داده شود</asp:ListItem>
                        <asp:ListItem Value="False">نمایش داده نشود</asp:ListItem>
                    </asp:RadioButtonList>
                </li>
                <li>
                    <span class="lbl">عکس بزرگ (1) : </span>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Image ID="Image1" runat="server" />
                    <span class="Notify">توجه : سایز عکس 250*500 می باشد.</span>
                </li>

                <li>
                    <span class="lbl"> بزرگ (2) :</span>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Image ID="Image2" runat="server" />
                </li>                             

                <li>
                    <span class="lbl"> بزرگ (3) :</span>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                    <asp:Image ID="Image3" runat="server" />
                </li>
                <li>
                    <span class="lbl"> کوچک :</span>
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                    <asp:Image ID="Image4" runat="server" />
                    <span class="Notify">توجه : سایز عکس 82*153 می باشد.</span>
                </li>
                <li>
                    <div style="text-align:center;">
                        <asp:Button ID="btnSaveNews" runat="server" CssClass="myButton" Text="ذخیره"  ValidationGroup="insert_news" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="myButton" Text="انصراف" ValidationGroup="Edit_News" />
                    </div>
                </li>
            </ul>
        </fieldset>
    </div>
        
    
    </asp:Panel>    


</asp:Content>