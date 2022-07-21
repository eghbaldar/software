<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="ContactList.aspx.vb" Inherits="Dashboard_ContactList" title="لیست تماس ها" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
         function checkAllBoxes(){
              var totalChkBoxes = parseInt('<%= Me.gvContactList.Rows.Count %>');    
              var gvControl = document.getElementById('<%= Me.gvContactList.ClientID %>');
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
            <asp:ListItem Value="NotVerification">خوانده نشده</asp:ListItem>
            <asp:ListItem Value="Verification">خوانده شده</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnRun" runat="server" Text="اجرا" CssClass="myButton" />
    </div>
        
    <asp:GridView ID="gvContactList" runat="server" AllowPaging="True"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr"
        AutoGenerateColumns="False"
        DataKeyNames="Id" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkBoxAll" type="checkbox" onclick="checkAllBoxes()" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkBoxChild" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField>
                <ItemTemplate>
                    <span>
                        <%#Container.DataItemIndex + 1%>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value=<%#eval("ID")%> />
                    </span>
                    <asp:Label ID="lblCommentId" runat="server" Text='<%#Eval("Id")%>' Style="display: none;"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="CommentId" Visible="False" />
            <asp:BoundField DataField="FullName" HeaderText="نام نویسنده" SortExpression="FullName" />
            <asp:BoundField DataField="Email" HeaderText="آدرس ایمیل" SortExpression="FullName" />
            <asp:BoundField DataField="CreateDate" HeaderText="تاریخ درج" SortExpression="CreateDate" />
            <asp:BoundField DataField="CreateTime" HeaderText="زمان درج" SortExpression="CreateTime" />
            <asp:TemplateField HeaderText="وضعیت پیام">
                <ItemTemplate>
                    <asp:Label ID="lblFlag" runat="server" Text='<%# iif(cbool(Eval("Flag")) = false,"<div class=""GoodStatus"">خوانده نشده</div>","<div class=""BadStatus"">خوانده شده</div>") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField ShowHeader="False" HeaderText="عملیات" >
                <ItemTemplate>                    
                    <asp:LinkButton ID="LnkBtnDelete" runat="server" CausesValidation="False" OnCommand="DeleteRecord" CommandArgument=<%# Eval("ID") %> Text="حذف" OnClientClick="return confirm('آیا میخواهید این رکورد حذف گردد؟');" />
                    |
                    <asp:LinkButton ID="LnkBtnShowMsg" runat="server" CausesValidation="False" OnCommand="ShowRecord" CommandArgument=<%# Eval("ID") %> Text="نمایش پیام" />
                </ItemTemplate>                              
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="SelectAll" 
        TypeName="Software.BLL.Contact"></asp:ObjectDataSource>
        
    <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="ShowNote">
        <p>
            <span class="lbl">نام : </span><asp:Literal ID="litName" runat="server"></asp:Literal>
        </p>
        <p>
            <span class="lbl">آدرس ایمیل : </span><asp:Literal ID="litEmail" runat="server"></asp:Literal>
        </p>
        <p>
            <span class="lbl">متن پیام : </span><asp:Literal ID="litNote" runat="server"></asp:Literal>
        </p>
        <p>
            <span class="lbl">تاریخ و زمان درج : </span><asp:Literal ID="LitCreateDateTime" runat="server"></asp:Literal>
        </p>
    </asp:Panel>        
        
</asp:Content>

