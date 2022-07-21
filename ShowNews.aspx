<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ShowNews.aspx.vb"
    Inherits="ShowNews" %>

<%@ Register Src="UserControl/ucNewsComments.ascx" TagName="ucNewsComments" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="UserControl/Impromptu/jquery-impromptu.js"></script>
    <link rel="stylesheet" media="all" type="text/css" href="UserControl/Impromptu/jquery-impromptu.css" />
    <script>
        $(document).ready(function(){$(".CommentExpander").click(function(){$(".CommentExpander-Items").slideToggle()})})
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="NewsContainer">
        <div class="NewsDetail">

            <div class="News-Content">
                <h2>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                </h2>
            
                <div class="Info">
                    <span>
                        <asp:Literal ID="litDateCreate" runat="server"></asp:Literal>
                    </span>
                    <span>•</span>
                    <span>
                        <asp:Literal ID="litTotalComment" runat="server"></asp:Literal>
                        نظر
                    </span>
                </div>
                <div class="NewsImage">
                    <%--<asp:Image ID="imgNews" runat="server" />--%>
                    <img id="imgNews" alt="" src="" runat="server" />
                </div>                
                <div class="Body">
                    <asp:Literal ID="litBody" runat="server"></asp:Literal>
                </div>
            </div>            
                
            <div class="CommentWrapper">
                <uc1:ucNewsComments ID="ucNewsComments1" runat="server" Visible="false" />
            </div>

        </div>
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
