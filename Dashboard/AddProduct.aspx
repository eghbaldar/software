<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddProduct.aspx.vb" Inherits="Dashboard_AddProduct" title="افزودن محصول در فروشگاه" %>
<%@ Register Src="../UserControl/ucMessageBox.ascx" TagName="ucMessageBox" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="WebForm">
        <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
        <fieldset>
            <legend>فرم ورود اطلاعات</legend>
            <ul>
                <li>
                    <span class="lbl">عنوان محصول :</span>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span class="lbl">قیمت :</span>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="ltr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span class="lbl">لینک : </span>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="ltr medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtLink"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span class="lbl">تصویر محصول :</span>
                    <asp:FileUpload ID="fuProductImage" runat="server" />
                    <span class="Notify">اندازه عکس باید 117*84 باشد </span></li>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                </li>
            </ul>
        </fieldset>
    </div>
</asp:Content>

