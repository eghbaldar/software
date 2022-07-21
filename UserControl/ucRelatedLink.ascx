<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucRelatedLink.ascx.vb" Inherits="UserControl_ucRelatedLink" %>

<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <h2>مطالب مرتبط</h2>
        <div class="related-topics-wrapper">
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li itemprop="relatedLink"><a href="ShowPost.aspx?PostId=<%#eval("PostId")%>"><%#eval("Title")%></a></li>
    </ItemTemplate>
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>    
