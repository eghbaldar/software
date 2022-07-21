<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="News.aspx.vb" Inherits="News" Title="شهر نرم افزار - اخبار" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div id="NewsContainer">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
            AllowPaging="True" GridLines="None" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="NewsList">
                            <div class="News-Image">
                                <a href="<%#String.Format("ShowNews.aspx?NewsId={0}", Eval("NewsId")) %>">
                                    <img alt="<%#Eval("Title")%>" title="<%#Eval("Title")%>" src="<%#String.Format("Content/UserFiles/Images/News/{0}", Eval("SmallImageName1"))%>" width="153px" height="82px" />
                                </a>
                            </div>
                            
                            <div class="News-Content">
                                <h2>
                                    <a href="<%#String.Format("ShowNews.aspx?NewsId={0}", Eval("NewsId")) %>">
                                        <%#Eval("Title")%>
                                    </a>
                                </h2>
                            
                                <div class="Info">
                                    <span>
                                        <%#Eval("DateCreate")%>
                                    </span>
                                    <span>•</span>
                                    <span>
                                        <%#Software.BLL.NewsComments.GetCountVoteForThisPost(Eval("NewsId"))%>
                                        نظر
                                    </span>
                                </div>
                                <div class="Body">
                                    <%#Eval("Lid")%>
                                </div>
                            </div>                   
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerStyle" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAll"
            TypeName="Software.BLL.News">
        </asp:ObjectDataSource>

    </div>
   
    <div id="Sidebar">
        <div class="Ads">
            <%--<img src="Content/UserFiles/Images/Ads/ads300x250.jpg" alt="تبلیغات" />--%>
            <script type="text/javascript"> 
            var anetwork_pram = anetwork_pram || []; 
            anetwork_pram['aduser'] = '1387392916'; 
            anetwork_pram['adheight'] = '250'; 
            anetwork_pram['adwidth'] = '300'; 
            </script> 
            <script type="text/javascript" src="http://static-cdn.anetwork.ir/showad/pub.js"></script>
        </div>
        <div class="Ads">
            <img src="Content/UserFiles/Images/Ads/ads336x280.jpg" alt="تبلیغات" />
        </div>
    </div>
    
</asp:Content>
