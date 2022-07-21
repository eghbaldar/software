<%@ Page Language="VB" MasterPageFile="~/Account/Account.master" AutoEventWireup="false"
    CodeFile="Login.aspx.vb" Inherits="Account_Login" Title="شهر نرم افزار - ورود" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div id="login">
        <asp:Login ID="Login1" runat="server" Width="100%" RememberMeSet="True" FailureText="نام کابری یا کلمه عبور اشتباه است. دوباره امتحان کنید">
            <LayoutTemplate>
                <p style="margin-bottom: 10px;">
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                </p>
                <p>
                    نام کاربری
                    <br />
                    <asp:TextBox ID="UserName" runat="server" TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    کلمه عبور
                    <br />
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                </p>
                <p style="float: right;">
                    <asp:CheckBox ID="RememberMe" runat="server" Checked="True" Text=" مرا به خاطر بسپار" />
                </p>
                <p style="float: left;">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ورود" CssClass="myButton"
                        ValidationGroup="Login1" />
                </p>
            </LayoutTemplate>
        </asp:Login>
    </div></asp:Content>
