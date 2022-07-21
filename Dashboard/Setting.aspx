<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="Setting.aspx.vb" Inherits="Management_Admin_admin_software_Setting" title="تنظمیات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        p
        {
        	margin-bottom:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <p>
            <label>نمایش نظرات پست ها پس از تایید : </label>
            <asp:CheckBox ID="chkShowPostComment" runat="server" />
        </p>
        <p>
            <label>نمایش نظرات خبرها ها پس از تایید : </label>
            <asp:CheckBox ID="chkShowNewsComment" runat="server" />
        </p>
        <p>
            <asp:Button ID="btnSave" runat="server" Text="ذخیره تنظیمات" CssClass="myButton" />
        </p>
    </div>
</asp:Content>

