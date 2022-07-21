<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowNewsDetail.aspx.vb" Inherits="Management_Admin_admin_software_ShowNewsDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>مشاهده جزئیات خبر</title>
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
        
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" 
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
                            عنوان خبر :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "Title")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کوتاه خبر:</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "Lid")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کامل خبر :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "Body")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            تاریخ درج خبر :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "DateCreate")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            ساعت درج خبر :</td>
                        <td class="ControlSegment">
                            <%#DataBinder.Eval(Container.DataItem, "TimeCreate")%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="LabelSegment">
                            وضعیت خبر:</td>
                        <td class="ControlSegment">
                            <%#IIf(DataBinder.Eval(Container.DataItem, "Flag"), "قابل نمایش", "غیر قابل نمایش")%>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            عکس بزرگ (1) :</td>
                        <td class="ControlSegment">
                            <img alt="" src='../Content/UserFiles/Images/News/<%#DataBinder.Eval(Container.DataItem, "BigImageName1")%>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            عکس بزرگ (2) :</td>
                        <td class="ControlSegment">
                            <img alt="" src='../Content/UserFiles/Images/News/<%#DataBinder.Eval(Container.DataItem, "BigImageName2")%>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            عکس بزرگ (3) :</td>
                        <td class="ControlSegment">
                            <img alt="" src='../Content/UserFiles/Images/News/<%#DataBinder.Eval(Container.DataItem, "BigImageName3")%>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            عکس کوچک :</td>
                        <td class="ControlSegment">
                            <img alt="" src='../Content/UserFiles/Images/News/<%#DataBinder.Eval(Container.DataItem, "SmallImageName1")%>' />
                        </td>
                    </tr>
                </table>
 
            </ItemTemplate>
        </asp:DataList>
               
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="SelectRow" 
            TypeName="Software.BLL.News">
            <SelectParameters>
                <asp:QueryStringParameter Name="NewsId" QueryStringField="NewsId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
