<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="ProductList.aspx.vb" Inherits="Dashboard_ProductList" title="لیست محصولات فروشگاه" %>

<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
         function checkAllBoxes(){

              var totalChkBoxes = parseInt('<%= Me.gvProductList.Rows.Count %>');    
              var gvControl = document.getElementById('<%= Me.gvProductList.ClientID %>');
              var gvChkBoxControl = "chkBoxChild";   
              var mainChkBox = document.getElementById("chkBoxAll");
              var inputTypes = gvControl.getElementsByTagName("input");
                        
              for(var i = 0; i < inputTypes.length; i++)
              {   
                 if(inputTypes[i].type == 'checkbox' && inputTypes[i].id.indexOf(gvChkBoxControl,0) >= 0)
                      inputTypes[i].checked = mainChkBox.checked;   
              }
        }
    </script>
        
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
    
    <div style="display:block; margin-bottom:15px; width:100%;">
        <asp:DropDownList ID="ddlGroupOperation" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="Delete">حذف گروهی</asp:ListItem>
            <asp:ListItem Value="NotVerification">غیرفعال</asp:ListItem>
            <asp:ListItem Value="Verification">فعال</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnRun" runat="server" Text="اجرا" CssClass="myButton" />
    </div>
        
    <asp:GridView ID="gvProductList" runat="server" DataSourceID="ObjectDataSource1" DataKeyNames="ID"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr"            
        AllowPaging="True" AutoGenerateColumns="False" PageSize="10" >
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <%--<asp:CheckBox ID="chkSelectAll" runat="server" onclick="if (this.checked==false) {ChangeAllCheckBoxStates(false)} else {ChangeAllCheckBoxStates(true)}" />--%>
                    <input id="chkBoxAll" type="checkbox" onclick="checkAllBoxes()" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkBoxChild" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="ردیف">
                <ItemTemplate>
                    <%#Container.DataItemIndex + 1%>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value=<%#eval("ID")%> />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="عنوان" />
            <asp:BoundField DataField="Price" HeaderText="قیمت" />
            <asp:TemplateField HeaderText="آیکون">
                <ItemTemplate>
                    <img src="../Content/UserFiles/Images/Product/<%#eval("Picture")%>" />
                </ItemTemplate>
            </asp:TemplateField>                
            <asp:TemplateField HeaderText="وضعیت" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblFlag" runat="server" Text='<%# iif(cbool(Eval("flag")) = True,"<div class=""GoodStatus"">فعال</div>","<div class=""BadStatus"">غیر فعال</div>") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField ShowHeader="False" HeaderText="عملیات" >
                <ItemTemplate>                    
                    <a target="_blank" href="<%#eval("URL") %>">مشاهده لینک</a>
                    |
                    <asp:LinkButton ID="LnkBtnEdit" runat="server" CausesValidation="False" OnCommand="EditRecord" CommandArgument=<%# Eval("ID") %> Text="ویرایش" />
                    |
                    <asp:LinkButton ID="LnkBtnDelete" runat="server" CausesValidation="False" OnCommand="DeleteRecord" CommandArgument=<%# Eval("ID") %> Text="حذف" OnClientClick="return confirm('آیا میخواهید این رکورد حذف گردد؟');" />
                    |
                    <asp:Button ID="btnChangeStatus" runat="server" Text="تغییر وضعیت" CssClass="myButton"
                        CommandArgument=<%# Eval("ID") %>  OnClick="btnChangeStatus_Click" />
                    
                </ItemTemplate>                              
            </asp:TemplateField>
        </Columns>
    <PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="SelectAll" 
        TypeName="Software.BLL.Product" >
    </asp:ObjectDataSource>      
        
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        
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
                    <asp:Image ID="imgProduct" runat="server" />
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="ذخیره" CssClass="myButton" />
                    <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass="myButton" />
                </li>
            </ul>
        </fieldset>            
        
    </asp:Panel>

</asp:Content>

