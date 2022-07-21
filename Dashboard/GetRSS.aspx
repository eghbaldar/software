<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="GetRSS.aspx.vb" Inherits="Management_Admin_admin_software_GetRSS" title="دریافت اطلاعات" %>
<%@ Register src="../UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
         function checkAllBoxes(){

              var totalChkBoxes = parseInt('<%= Me.gvRecordList.Rows.Count %>');    
              var gvControl = document.getElementById('<%= Me.gvRecordList.ClientID %>');
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
    
    <div style="margin:30px 0px; display:block;">
        <asp:Menu ID="mnuRssSouce" runat="server" Orientation="Horizontal"
            BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" 
            Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px" >
            <LevelSelectedStyles>
                <asp:MenuItemStyle BackColor="#FF9900" Font-Underline="False" 
                    BorderColor="Black" BorderWidth="1px" Font-Bold="True" />
            </LevelSelectedStyles>
            <StaticMenuItemStyle BackColor="#CCCC00" BorderColor="Black" BorderWidth="1px" 
                Font-Bold="True" HorizontalPadding="5px" VerticalPadding="5px" />
        </asp:Menu>
    </div>
    
    <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
    
    <div style="margin:30px 0px; display:block;">
        <asp:Button ID="btnSelect1" runat="server" Text="ذخیره در بانک اطلاعاتی شهر" CssClass="myButton" Visible="False" />
    </div>
    
    <asp:GridView ID="gvRecordList" runat="server" AutoGenerateColumns="False"
        GridLines="None"
        CssClass="gridview"
        PagerStyle-CssClass="pgr" >
        <Columns>
        
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkBoxAll" type="checkbox" onclick="checkAllBoxes()" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkBoxChild" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>            
            
            <asp:TemplateField HeaderText="عنوان">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="مشاهده صفحه">
                <ItemTemplate>
                    <asp:HyperLink ID="RefLink" runat="server" NavigateUrl=<%# Bind("Link", "{0}") %>
                        Target="_blank" Text='مشاهده'></asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="طبقه بندی">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource2" Width="100px"
                        DataTextField="CatName" DataValueField="CategoryId">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
                        SelectCommand="SELECT [CatName], [CategoryId] FROM [vSelectcategoryLevel4]">
                    </asp:SqlDataSource>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="تاریخ نمایش">
                <ItemTemplate>
                    <asp:TextBox ID="txtShowDate" runat="server" Width="100px" CssClass="ltr" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="توضیحات" SortExpression="Description">
                <ItemTemplate>
                    <asp:Literal ID="LitDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Literal>
                </ItemTemplate>
                <ControlStyle Width="600px" />
            </asp:TemplateField>
            
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>    
    
    <asp:Button ID="btnSelect2" runat="server" Text="ذخیره در بانک اطلاعاتی شهر"  CssClass="myButton" Visible="False" />
        

</asp:Content>

