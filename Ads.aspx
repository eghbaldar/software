<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Ads.aspx.vb" Inherits="Ads" title="تبلیغات" %>
<%@ Register src="UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Ads">
        <div class="Note">
        <p>
            بر هیچ کس این موضوع پوشیده نیست که تبلیغات اینترنتی در دنیای امروز به عنوان موفق 
            ترین روش در هدف گیری مخاطب در جهت جذب هر چه بیشتر کاربر و شناساندن کالا ، سایت و 
            یا خدمات برای تمامی‌ فعالیت ها محسوب می شود و تاثیر آن به نسبت هزینه , غیر قابل 
            انکار است سایت <a href="http://software.shaahr.com">شهر نرم افزار</a> به عنوان 
            بستری مناسب آماده پوشش و معرفی هر چه بهتر محصولات و سایت شما دوستان است. لطفا 
            جهت هماهنگی با آدرس ایمیل software@shaahr.com و یا فرم زیر مکاتبه نمایید        
        </p>
        
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
    
    <div id="Contact">
        <div id= "WebForm">
            <p>
                <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
            <p>
                <span class="lbl">نام و نام خانوادگی :</span>
                <asp:TextBox ID="txtFn" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFn" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <span class="lbl">آدرس ایمیل :</span>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="ltr"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="آدرس ایمیل معتبر وارد کنید" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>
            <p>
                <span class="lbl">پیام :</span>
                <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" rows="10" CssClass="medium"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtNote" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSend" runat="server" Text="ارسال" CssClass="myButton" />
            </p>
            
        </div>
    </div>
    
</asp:Content>

