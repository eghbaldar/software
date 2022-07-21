<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddNews.aspx.vb" Inherits="Management_Admin_admin_software_AddNews" title="افزودن خبر" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>
<%--<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />

    <asp:GridView ID="gvNewsList" runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        Width="100%" AllowPaging="True"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr" >
        <Columns>
            <asp:BoundField DataField="NewsId" HeaderText="شماره خبر" InsertVisible="False" ReadOnly="True" SortExpression="NewsId" />
            <asp:BoundField DataField="Title" HeaderText="عنوان خبر" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="DateCreate" HeaderText="تاریخ درج خبر" SortExpression="DateCreate"></asp:BoundField>
            <asp:BoundField DataField="TimeCreate" HeaderText="ساعت درج خبر" SortExpression="TimeCreate" />
            <asp:TemplateField HeaderText="وضعیت نمایش" SortExpression="Flag">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# iif(Eval("Flag"),"<div class=""GoodStatus"">قابل نمایش</div>","<div class=""BadStatus"">غیر قابل نمایش</div>") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div id="EmptyTable">
                خبری برای نمایش وجود ندارد
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
        SelectCommand="SELECT [NewsId], [Title], [DateCreate], [TimeCreate], [Flag] FROM [tbl_Software_News]">
    </asp:SqlDataSource>

                
    <div id="WebForm">
        <fieldset>
            <legend>افزودن خبر</legend>
            <ul>
                <li>
                    <span class="lbl">عنوان خبر :</span>
                    <asp:TextBox ID="txtNewsTitle" runat="server" CssClass="medium"></asp:TextBox>
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
                    <span class="Notify">توجه : سایز عکس 250*500 می باشد.</span>
                </li>

                <li>
                    <span class="lbl"> بزرگ (2) :</span>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </li>                             

                <li>
                    <span class="lbl"> بزرگ (3) :</span>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </li>
                <li>
                    <span class="lbl"> کوچک :</span>
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                    <span class="Notify">توجه : سایز عکس 82*153 می باشد.</span>
                </li>
                <li>
                    <asp:Button ID="btnSaveNews" runat="server" CssClass="myButton" Text="ارسال"  ValidationGroup="insert_news" />
                </li>
            </ul>
        </fieldset>
    </div>
                
</asp:Content>

