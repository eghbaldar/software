<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test1.aspx.vb" Inherits="test_test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
    
    </div>   
    
    <%--<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
            <table border="1" cellpadding="0" cellspacing="0">
            <thead>
                <th>PostID</th>
                <th>Title</th>
                <th>DescEnglish</th>
                <th></th>
            </thead>
            <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("PostID")%></td>
                <td><%#Eval("Title")%></td>
                <td><%#Eval("DescEnglish")%></td>
                <td><%#SplitParaghraf(Eval("DescEnglish"))%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:DataList>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
        SelectCommand="SELECT [PostId], [Title], [DescEnglish], [VisiblePost] FROM [tbl_Software_Post] WHERE PostType=1 ">
    </asp:SqlDataSource>--%>
    
    
    </form>
</body>
</html>
