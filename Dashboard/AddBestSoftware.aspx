<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false"
    CodeFile="AddBestSoftware.aspx.vb" Inherits="Dashboard_AddBestSoftware" Title="افزودن نرم افزار" %>

<%@ Register Src="../UserControl/ucMessageBox.ascx" TagName="ucMessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div id="WebForm">
        <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
        <fieldset>
            <legend>فرم ورود اطلاعات</legend>
            <ul>
                <li>
                    <span class="lbl">عنوان نرم افزار : </span>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span class="lbl">توضیحات : </span>
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span class="lbl">لینک : </span>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="ltr medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtLink"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span class="lbl">آیکون : </span>
                    <asp:FileUpload ID="fuSoftwareIcon" runat="server" />
                    <span class="Notify">اندازه عکس باید 100*100 باشد </span></li>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                </li>
            </ul>
        </fieldset>
    </div>    
</asp:Content>
