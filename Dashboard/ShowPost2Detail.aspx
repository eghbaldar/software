<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowPost2Detail.aspx.vb" Inherits="Management_Admin_admin_software_ShowPost2Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>مشاهده جزئیات پست</title>
    <style type="text/css">
         .LabelSegment
        {
        	width:140px;
        	font-weight:bold;
        }
        .ControlSegment
        {
            width: 700px;
            float:right;
        }
        .TableStyle
        {
            width: 97%;
            font-family: Tahoma;
            font-size: 13px;
        }        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top: 10px 10px 10px 10px; direction:rtl;">
        
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
            BorderColor="#FF9900" BorderStyle="Solid" BorderWidth="1px" CellPadding="20" 
            Font-Names="Tahoma" ForeColor="#333333" GridLines="Both" Font-Size="10pt">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemTemplate>
            
                <table class="TableStyle">
                
                    <tr>
                        <td class="LabelSegment">
                            عنوان پست :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "Title")%>
                        </td>
                    </tr>

                    <tr>
                        <td class="LabelSegment">
                            طبقه :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "CategoryName")%>
                        </td>
                    </tr>

                    <tr>
                        <td class="LabelSegment">
                            عکس :</td>
                        <td class="ControlSegment">
                            <asp:Image ID="Image1" runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem,  "BigImageFilename" , "../../Content/Images/SoftwareImage/{0}")%> />
                        </td>
                    </tr>

                    <tr>
                        <td class="LabelSegment">
                            متن کامل پست :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "LidFarsi")%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="LabelSegment">
                            لینک :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "Hyperlink")%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="LabelSegment">
                            تاریخ و ساعت درج پست :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "DateOfCreatePost")%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="LabelSegment">
                            محل قرارگیری :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "LocationNumber")%>
                        </td>
                    </tr>

                </table>
 
            </ItemTemplate>
        </asp:DataList>
               
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
            
            
            SelectCommand="SELECT tbl_Software_Post.PostId, tbl_Software_Post.Title, tbl_Software_Post.DateOfCreatePost, tbl_Software_Post.LocationNumber, tbl_Software_Post.LidFarsi, tbl_Software_Post.BigImageFilename, tbl_Software_Post.Hyperlink, dbo.GetCategoryNameById(tbl_Software_Post.CategoryId) AS CategoryName FROM tbl_Software_Post INNER JOIN tbl_Software_Category ON tbl_Software_Post.CategoryId = tbl_Software_Category.CategoryId WHERE (tbl_Software_Post.PostId = @PostId)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="PostId" 
                    QueryStringField="PostId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
