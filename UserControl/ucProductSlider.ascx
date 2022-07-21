<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucProductSlider.ascx.vb" Inherits="UserControl_ucProductSlider" %>

 <!-- Slider -->
                    
<div class="jwrapper" style="max-width: 440px;">
    <div class="jcarousel-wrapper">
        <div class="jcarousel">

            <ul>
                
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                    <ItemTemplate>
                    
                        <li>
                            <img style="cursor: pointer" onclick="window.open('<%#eval("URL") %>');return true" src="~/../Content/UserFiles/Images/Product/<%#eval("Picture")%>" width="84" height="117"> 
                            <em><%#Eval("Title")%></em> 
                            <em class="price"><%#Eval("Price")%> تومان</em> 
                            <a target="_blank" rel="nofollow" href="<%#eval("URL") %>">خرید</a>
                        </li>
                        
                    </ItemTemplate>                    
                </asp:Repeater>
        
            </ul>
            
        </div>
        <a href="#" class="jcarousel-control-prev" style="color:#fff;">&lsaquo;</a>
        <a href="#" class="jcarousel-control-next" style="color:#fff;">&rsaquo;</a>
    </div>
</div>
                    
<!-- /Slider -->


<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="SelectActiveProduct" TypeName="Software.BLL.Product" >
</asp:ObjectDataSource>



