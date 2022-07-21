<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucBestSoftwareList.ascx.vb" Inherits="UserControl_ucBestSoftwareList" %>

<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <script>$(document).ready(function(){$(".best-post-<%#Eval("ID")%>").hover(function(){ $(".best-post-title-<%#Eval("ID")%>").slideToggle("3000"); });});</script>
        <li class="best-post-<%#Eval("ID")%> best-post-list">
            <h3 class="best-post-title-<%#Eval("ID")%> best-post-title" style="display: none;">
                <a href="<%#Eval("URL")%>" title="more detail" rel="bookmark"><%#Eval("Description")%></a>
            </h3>
            <a href="<%#Eval("URL")%>">
                <img width="100" height="100" src="~/../Content/UserFiles/Images/SoftwareIcon/<%#Eval("Icon")%>" class="attachment-100x100 wp-post-image" alt="Sygic GPS">
            </a>
            <span><%#Eval("Title")%></span>
        </li>        
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="SelectAll" TypeName="Software.BLL.BestSoftware">
</asp:ObjectDataSource>