<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="BestSoftwareList.aspx.vb" Inherits="Dashboard_BestSoftwareList" title="لیست نرم افزارهای برتر" %>

<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
    
    <asp:GridView ID="gvBestSoftware" runat="server" DataSourceID="ObjectDataSource1"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr"            
        AllowPaging="True" AutoGenerateColumns="False" >
        <Columns>
            <asp:TemplateField HeaderText="ردیف">
                <ItemTemplate>
                    <%#Container.DataItemIndex + 1%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="عنوان" />
            <asp:TemplateField HeaderText="آیکون">
                <ItemTemplate>
                    <img width="50" height="50" src="../Content/UserFiles/Images/SoftwareIcon/<%#eval("Icon")%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:HyperLinkField DataNavigateUrlFields="URL" HeaderText="ارجاع به لینک"  Target="_blank"  Text="مشاهده" />--%>
                
            <asp:TemplateField ShowHeader="False" HeaderText="عملیات" >
                <ItemTemplate>                    
                    <a target="_blank" href="<%#eval("URL") %>">مشاهده لینک</a>
                    |
                    <asp:LinkButton ID="LnkBtnEdit" runat="server" CausesValidation="False" OnCommand="EditRecord" CommandArgument=<%# Eval("ID") %> Text="ویرایش" />
                    |
                    <asp:LinkButton ID="LnkBtnDelete" runat="server" CausesValidation="False" OnCommand="DeleteRecord" CommandArgument=<%# Eval("ID") %> Text="حذف" OnClientClick="return confirm('آیا میخواهید این رکورد حذف گردد؟');" />
                </ItemTemplate>                              
            </asp:TemplateField>
                        
        </Columns>
    <PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="SelectAll" 
        TypeName="Software.BLL.BestSoftware"></asp:ObjectDataSource>
                
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <fieldset>
            <legend>فرم ویرایش اطلاعات</legend>
            <ul>
                <li>
                    <span>عنوان نرم افزار : </span>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span>توضیحات : </span>
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span>لینک : </span>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="ltr medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtLink"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <span>آیکون : </span>
                    <asp:FileUpload ID="fuSoftwareIcon" runat="server" />
                    <span class="Notify">اندازه عکس باید 100*100 باشد </span></li>
                    <asp:Image ID="imgIcon" runat="server" />
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                    <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass="myButton" />
                </li>
            </ul>
        </fieldset>
    
    </asp:Panel>
            
</asp:Content>

