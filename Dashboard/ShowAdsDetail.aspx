<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowAdsDetail.aspx.vb" Inherits="Management_Admin_admin_software_ShowAdsDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>مشاهده جزئیات تبلیغ</title>
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
                            متن کوتاه پست:</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "LidFarsi")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کامل پست :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "DescFarsi")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            عکس تبلیغی :</td>
                        <td class="ControlSegment">
                            <img src="<%# string.format("../Content/UserFiles/Images/Ads/{0}", DataBinder.Eval(Container.DataItem, "BigImageFilename"))%>"/>
                            
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
            
            SelectCommand="SELECT [PostId], [Title], [LidFarsi], [DescFarsi], [BigImageFilename],[DateOfCreatePost], [LocationNumber] FROM [tbl_Software_Post] WHERE ([PostId] = @PostId)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="PostId" 
                    QueryStringField="PostId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
