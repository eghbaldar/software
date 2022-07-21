<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="ShowPost.aspx.vb" Inherits="ShowPost" %>

<%@ Register Src="UserControl/ucShowPostInfo.ascx" TagName="ucShowPostInfo" TagPrefix="SoftwareControl" %>
<%@ Register Src="UserControl/ucComments.ascx" TagName="ucComments" TagPrefix="uc1" %>
<%@ Register src="UserControl/ucRelatedLink.ascx" tagname="ucRelatedLink" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" src="UserControl/Impromptu/jquery-impromptu.js"></script>
    <link rel="stylesheet" media="all" type="text/css" href="UserControl/Impromptu/jquery-impromptu.css" />
    <script>
        $(document).ready(function () { $(".ErrorExpander").click(function () { $(".ErrorExpander-Items").slideToggle() }) })
        $(document).ready(function () { $(".CommentExpander").click(function () { $(".CommentExpander-Items").slideToggle() }) })
        $(document).ready(function () { $(".LinkExpander").click(function () { $(".LinkExpander-Items").slideToggle() }) })
        
        
	    function resizeToWindow() {
	      var windowHeight = $(window).height();
    	  
	      if ($('.recomended-form')) {
	  	    $('.resize-to-window').height(windowHeight - 0);
	      } else {
	  	    $('.resize-to-window').height(windowHeight);
	      }
	    }
    	
	    //change height whene document is ready
	    $(function(){
	      resizeToWindow();
    	  
	      //change iframe height whene browser is resize
	      $(window).resize(function() {
	        resizeToWindow();
	      });
	    });
            
	    window.parent.document.body.style.overflow="hidden";	  	

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" Visible="False">

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex=-1>

        <asp:View ID="View1" runat="server">

            <div id="PostContainer">
                <SoftwareControl:ucShowPostInfo ID="ucShowPostInfo1" runat="server" Visible="False" />
                
                <div class="CommentWrapper">        
                    <uc1:ucComments ID="ucComments1" runat="server" Visible="False" />        
                </div>
                                
                <div id="related-topics">
                    <uc2:ucRelatedLink ID="ucRelatedLink1" runat="server" />
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
        
        </asp:View>

        <asp:View ID="View2" runat="server">
        
            <div class="resize-to-window">
                <iframe  runat="server" class="resize-to-window" scrolling="auto" frameborder="0" id="iframe" allowtransparency="true" style="width: 100%; height: 100%;"></iframe>
            </div>
            
        </asp:View>
    
    </asp:MultiView>

</asp:Content>
