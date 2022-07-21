<%@ Page Language="VB" ContentType="text/xml" AutoEventWireup="false" CodeFile="ConvertToWP.aspx.vb" Inherits="ConvertToWP" %>

<asp:repeater id="RepeaterWP" runat="server" datasourceid="SqlDataSource1">
   
     <HeaderTemplate>
        <rss version="2.0"
            xmlns:excerpt="http://wordpress.org/export/1.2/excerpt/"
            xmlns:content="http://purl.org/rss/1.0/modules/content/"
            xmlns:wfw="http://wellformedweb.org/CommentAPI/"
            xmlns:dc="http://purl.org/dc/elements/1.1/"
            xmlns:wp="http://wordpress.org/export/1.2/">
        <channel>
	        <title>شهر نرم افزار</title>
            <link>http://software.shaahr.com</link>
            <%--<pubDate>Sun, 21 Apr 2013 11:12:28 +0000</pubDate>
            <language>en-US</language>--%>
            <wp:wxr_version>1.2</wp:wxr_version>
            <%--<wp:base_site_url>http://blog.saeidmirzaei.com</wp:base_site_url>
            <wp:base_blog_url>http://blog.saeidmirzaei.com</wp:base_blog_url>--%>
            <wp:author><wp:author_id>1</wp:author_id><wp:author_login>admin</wp:author_login><wp:author_email>ebrahim_tabrizi@yahoo.com</wp:author_email><wp:author_display_name><![CDATA[admin]]></wp:author_display_name><wp:author_first_name><![CDATA[]]></wp:author_first_name><wp:author_last_name><![CDATA[]]></wp:author_last_name></wp:author>
            <%--<wp:category><wp:term_id>1</wp:term_id><wp:category_nicename>uncategorized</wp:category_nicename><wp:category_parent></wp:category_parent><wp:cat_name><![CDATA[Uncategorized]]></wp:cat_name></wp:category>--%>
            <%--<generator>http://wordpress.org/?v=3.5.1</generator>--%>
    </HeaderTemplate>

    <ItemTemplate>

        <item>
            <title><%# FormatForXML(DataBinder.Eval(Container.DataItem, "Title"))%></title>
            <link><%# "http://software.shaahr.com" & Page.GetRouteUrl("Post", New With {.PostID = Eval("PostId"), .title = Seo.GenerateSlug(Eval("Title"), "html")})%></link>
            <pubDate><%# String.Format("{0:R}", ShamsiDate.ConvertToMiladi(Eval("DateOfCreatePost"), ShamsiDate.EnglishFormat.DateTime))%></pubDate>
            <dc:creator>admin</dc:creator>
            <guid isPermaLink="false"><%# "http://software.shaahr.com" & Page.GetRouteUrl("Post", New With {.PostID = Eval("PostId"), .title = Seo.GenerateSlug(Eval("Title"), "html")})%></guid>
            <description></description>
            <content:encoded><![CDATA[<%#Eval("DescFarsi") & "<br/>" & Eval("DescEnglish")%>]]></content:encoded>
            <excerpt:encoded><![CDATA[]]></excerpt:encoded>
            <wp:post_id><%#Eval("PostID")%></wp:post_id>
            <wp:post_date><%# String.Format("{0:R}", ShamsiDate.ConvertToMiladi(Eval("DateOfCreatePost"), ShamsiDate.EnglishFormat.DateTime))%></wp:post_date>
            <wp:post_date></wp:post_date>
            <wp:post_date_gmt><%# String.Format("{0:R}", ShamsiDate.ConvertToMiladi(Eval("DateOfCreatePost"), ShamsiDate.EnglishFormat.DateTime))%></wp:post_date_gmt>
            <wp:comment_status>open</wp:comment_status>
            <wp:ping_status>open</wp:ping_status>
            <wp:post_name></wp:post_name>
            <wp:status>publish</wp:status>
            <wp:post_parent>0</wp:post_parent>
            <wp:menu_order>0</wp:menu_order>
            <wp:post_type>post</wp:post_type>
            <wp:post_password></wp:post_password>
            <wp:is_sticky>0</wp:is_sticky>
            <category domain="category" nicename="<%# Software.BLL.Category.GetCategoryNameByID(Eval("CategoryID"))%>"><![CDATA[<%# Software.BLL.Category.GetCategoryNameByID(Eval("CategoryID"))%>]]></category>
        </item>

    </ItemTemplate>

    <FooterTemplate>
            </channel>
        </rss>  
    </FooterTemplate>

</asp:repeater>

<asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:ShaahrConnectionString %>" selectcommand="SELECT TOP (2) PostId, Title, PostType, CategoryId, DownloadCount, OpinionCount, LidFarsi, DescFarsi, HaveDescEnglish, DescEnglish, HaveSoftwareFullName, SoftwareFullName, HaveVersion, Version, HaveFactorySite, FactorySite, HaveDatePublish, DatePublish, FileSize, HaveProductPrice, ProductPrice, BigImageFilename, SmallImageFilename, DateOfCreatePost, HaveLearningFile, LearningFileName, LocationNumber, Hyperlink, VisiblePost, ShowDate, ShowOrder FROM dbo.tbl_Software_Post WHERE (VisiblePost = 1) AND (ShowDate = '')"></asp:sqldatasource>
