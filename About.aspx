<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="About.aspx.vb" Inherits="About" title="درباره ما" %>
<%@ Register src="UserControl/ucBestSoftwareList.ascx" tagname="ucBestSoftwareList" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Content">
        <div id="BestSoftware">
            <uc2:ucBestSoftwareList ID="ucBestSoftwareList1" runat="server" />
        </div>
        
        <div id="MainContent">
        
            <div class="Note">
                <p>
                    <a href="http://software.shaahr.com">شهر نرم افزار</a> : یکی از  مجموعه سایت های 
                    <a href="http://www.shaahr.com">شهر.کام </a>است  که با نگرشی نوین در زمینه دانلود نرم افزار و بر پایه رعایت حق کپی رایت تمام عرضه کنندگان محصولات پا به عرصه نهاده&nbsp; 
                    است.
                </p>
                <p>
                    شما در <a href="http://software.shaahr.com">شهر نرم افزار </a>می توانید به آسانی نرم افزار مورد نیاز خود را به همراه فایل فیلم آموزش نصب و کرک دریافت و یا در صورت تمایل به سایت نمایندگی مجاز آن محصول هدایت شوید.
                </p>
                <p>
                    همچنین کلیه اطلاعات نرم افزار در دو زبان فارسی و انگلیسی تهیه می شود.
                    از نقاط مثبت ا<a href="http://software.shaahr.com">ین سایت </a>همکاری صمیمانه با سایت پی سی دانلود به عنوان قدیمی ترین سایت دانلود ایران و سایت دانلود ها به عنوان برترین سایت از دیدگاه مخاطبان است که شما تمامی پست های این دو سایت معتبر را به صورت کامل  مشاهده و در صورت کابردی بودن می توانید دانلود نمایید.
                </p>
                <p>
                    در این حالت در وقت شما صرفه جویی شده و بطور هم زمان سه سایت را یکجا مشاهده می کنید
                    از بخش های دیگر سایت می توان به واحدهای فروشگاه ، اخبار  و...... اشاره نمود که هر کدام  در نوع خود داری خصوصیاتی منحصر به فرد می باشند
                </p>
            </div>
            
        </div>
        
    </div>



</asp:Content>

