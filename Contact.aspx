<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact" title="ارتباط با ما" %>

<%@ Register src="UserControl/ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Contact">
        <div id= "WebForm">
            <p>
                <uc1:ucMessageBox ID="ucMessageBox1" runat="server" />
            </p>
            <p>
                <span class="lbl">نام و نام خانوادگی :</span>
                <%--<br />--%>
                <asp:TextBox ID="txtFn" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFn" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <span class="lbl">آدرس ایمیل :</span>
                <%--<br />--%>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="ltr"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="آدرس ایمیل معتبر وارد کنید" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>
            
<%--            <p>
                <span class="lbl">گیرنده پیام :</span>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </p>
--%>            
            <p>
                <span class="lbl">پیام :</span>
                <%--<br />--%>
                <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" rows="10" CssClass="medium"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtNote" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSend" runat="server" Text="ارسال" CssClass="myButton" />
            </p>
            
        </div>
    </div>
    <div id="Sidebar">
        <div id="ContactNote">
            <h2>
                چگونگی ارتباط با ما
            </h2>
            <div>
                <p>
                    شما از طریق این فرم می توانید پیشنهادات ، مشکلات و نظرات خود را به مسئولان
                    شهر دات کام انتقال دهید.
                </p>
                <p>
                    کاربر محترم ، با توجه به حجم  بالای پیامها ، پاسخ دادن به آنها
                    در زمان کوتاه امکان پذیر نمی باشد. اما سعی می گردد تمامی مطالب مطالعه شده و در صورت نیاز واحد مربوطه
                    با شما مکاتبه نموده و پاسخ لازم را ارائه دهد.
                </p>
                <%--<p>
                    لطفا برای تسریع در پاسخ به پیام ها، واحد مربوطه را به درستی انتخاب نمایید.
                </p>--%>
                <p>
                    با تشکر 
                </p>
                <p>
                    مدیریت شهر دات کام
                </p>
            </div> 
        </div>       
    </div>
</asp:Content>

