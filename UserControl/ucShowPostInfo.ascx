<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucShowPostInfo.ascx.vb"
    Inherits="software_UserControl_ucShowPostInfo" %>
<%@ Register Src="ucStarRating.ascx" TagName="ucStarRating" TagPrefix="uc1" %>
<%@ Register Src="CapchaControl.ascx" TagName="CapchaControl" TagPrefix="uc2" %>
<%@ Register src="ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc2" %>

<%--<div id="Content" dir="rtl">--%>

    <%--        line 1 --%>
    <div>
        <h1>
            <asp:Literal ID="litTitle" runat="server"></asp:Literal>
        </h1>
    </div>
    
    <%--        line 2 --%>
    <div id="Category">
        <ul>
            <li class="Vizit">
                تعداد بازدید : 
                <asp:Literal ID="litDownloadCount" runat="server"></asp:Literal>
            </li>
            <li class="CreateDate">
                تاریخ درج : 
                <asp:Literal ID="litDateOfCreatePost" runat="server"></asp:Literal>                
            </li>
        </ul>
        <ul>
            <li class="Category">
                طبقه بندی نرم افزار : 
                <asp:Literal ID="litCategory" runat="server"></asp:Literal>
            </li>
        </ul>
    </div>
    
    <%--        line 3 --%>
    
<%--    <div id="Vote">
        <div>
            <uc1:ucStarRating ID="ucStarRating1" runat="server" />
        </div>
    </div>
--%>    
    
    <%--        line 4 --%>
    <div id="Picture">
        <asp:Image ID="imgDefaultPicture" runat="server" CssClass="ImageStyle" />
    </div>
    
    <%--        line 5 --%>
    <div style="line-height:25px; text-align:justify;">
        <asp:Literal ID="litDescFarsi" runat="server"></asp:Literal>
    </div>
    <asp:Panel ID="pnlEnglishDesc" runat="server" style="line-height:25px; text-align:justify;" CssClass="ltr">
        <asp:Label ID="lblDescEnglish" runat="server"></asp:Label>
    </asp:Panel>
    
    <%--        line 6 --%>
   
    <div id="SoftwareInfo">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
            <ItemTemplate>
                <asp:Table ID="Table1" runat="server" CssClass="TableStyle">
                    <asp:TableRow Visible='<%#DataBinder.Eval(Container.DataItem, "HaveSoftwareFullName")%>'>
                        <asp:TableCell>
                            نام کامل نرم افزار و شرکت سازنده :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "SoftwareFullName")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Visible='<%#DataBinder.Eval(Container.DataItem, "HaveFactorySite")%>'>
                        <asp:TableCell>
                            سایت شرکت سازنده :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "FactorySite")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Visible='<%#DataBinder.Eval(Container.DataItem, "HaveProductPrice")%>'>
                        <asp:TableCell>
                            قیمت نرم افزار :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "ProductPrice")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            حجم دانلود :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "FileSize")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Visible='<%#DataBinder.Eval(Container.DataItem, "HaveVersion")%>'>
                        <asp:TableCell>
                            نسخه :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "Version")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Visible='<%#DataBinder.Eval(Container.DataItem, "HaveDatePublish")%>'>
                        <asp:TableCell>
                            تاریخ انتشار :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "DatePublish")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            تاریخ و زمان قرار گرفتن در سایت :
                            <strong>
                                <%#DataBinder.Eval(Container.DataItem, "DateOfCreatePost")%>
                            </strong>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectRow"
            TypeName="Software.BLL.Post">
            <SelectParameters>
                <asp:QueryStringParameter Name="PostId" QueryStringField="PostId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    

<%--        line 7 --%>
    <div id="LinkContainer" >
        <%--<div>--%>
            <span class="LinkExpander">لینک های دانلود</span>
        <%--</div>--%>
        <div class="LinkExpander-Items" style="display: none; margin-top:15px;">
            <asp:DataList ID="dlLinkGroup" runat="server" DataSourceID="ObjectDataSource2">
                <ItemTemplate>
                    <table>
                        <tr style="font-size: 9pt;">
                            <td style="color: #6a6a6a; margin-bottom:10px;">
                                <%#DataBinder.Eval(Container.DataItem, "Title")%>
                            </td>
                            <td style="padding-right: 10px; font-weight: bold;">
                                حجم کل :
                                <%#DataBinder.Eval(Container.DataItem, "TotalSize")%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DataList ID="dlLinkDetail" runat="server" RepeatDirection="Vertical" RepeatColumns="10">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Link")%>'
                                            onclick='<%hftemp.value %>'>
                                        <div style="float: right; border: solid 2px #d6ab79; margin-left: 2px;
                                            padding: 2px; background-color: #e4bf93; margin-top:5px; margin-bottom:0px;">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center; font-family: koodak; color: #ad722e; font-size: large; padding:5px 0px;">
                                                        <%#Container.ItemIndex + 1%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border-top: dashed 2px #d6ab79; color: Black; font-weight: bold; padding:5px 0px;">
                                                        <%#DataBinder.Eval(Container.DataItem, "PartSize")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="SelectByPostID"
            TypeName="Software.BLL.Link">
            <SelectParameters>
                <asp:QueryStringParameter Name="PostId" QueryStringField="PostId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    
    <%--        line 8 --%>
    <asp:Panel ID="pnlCrackFile" runat="server">
        <div id="CrackFile">
            <div style="font-family: koodakSMS; color: #c83c3b; font-size: 15px">
                رجیستر ، کرک و پچ</div>
            <asp:DataList ID="dlCrackFile" runat="server" DataSourceID="ObjectDataSource3">
                <ItemTemplate>
                    <div style="float: right;">
                        <img alt="" src="../Content/Images/down.png" />
                    </div>
                    <div style="float: right; padding-right: 10px; padding-bottom: 5px;">
                        <a style="color: #6a6a6a; text-decoration: none; font-size: 9pt;" href='<%# DataBinder.Eval(Container.DataItem, "Filename","http://shaahr.net/files/software/{0}")%>'>
                            <%#DataBinder.Eval(Container.DataItem, "Title")%>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="SelectByPotsId"
                TypeName="Software.BLL.CrackFile">
                <SelectParameters>
                    <asp:QueryStringParameter Name="PostId" QueryStringField="PostId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </asp:Panel>
    <%--        line 9 --%>
    <asp:Panel ID="pnlLearningFile" runat="server">
        <asp:HyperLink ID="HyperLinkLearningFile" runat="server">
            <asp:Image ID="Image1" ImageUrl="~/Content/Images/LearningFile.JPG" runat="server"
                Width="563px" />
        </asp:HyperLink>
    </asp:Panel>
    <%--        line 10 --%>
    <div id="ErrorInLink">
        <span class="ErrorExpander">گزارش خرابی لینکهای دانلود</span>
        <div class="ErrorExpander-Items" style="display: none;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
<%--                    
                    <div>
                        <div style="float: right; overflow: auto;">
                            <asp:TextBox ID="txtName" runat="server" CssClass="ErrorLinkTextBoxStyle" Text="نام و نام خانوادگی"
                                ValidationGroup="ErrorInLink" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtName" ValidationGroup="ErrorInLink" InitialValue="نام و نام خانوادگی"></asp:RequiredFieldValidator>
                        </div>
                        <div style="float: right; overflow: auto; padding-right: 10px;">
                            <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="ErrorLinkTextBoxStyle"
                                Text="پست الکترونیکی" ValidationGroup="ErrorInLink" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEmailAddress" ValidationGroup="ErrorInLink" InitialValue="پست الکترونیکی"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="ErrorInLink"
                                ErrorMessage="آدرس ایمیل را درست وارد کنید" ControlToValidate="txtEmailAddress"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div style="overflow: auto; padding-top: 10px;">
                        <div>
                            <asp:TextBox ID="txtNote" runat="server" CssClass="ErrorLinkTextareaStyle" TextMode="MultiLine"
                                Text="توضیحات..." ValidationGroup="ErrorInLink" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ErrorInLink"
                                ErrorMessage="*" ControlToValidate="txtNote" InitialValue="توضیحات..."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div style="width: 100%;">
                        <uc2:CapchaControl ID="CapchaControl1" runat="server" />
                    </div>
                    <div style="overflow: auto; width: 565px; padding-top: 10px; padding-bottom: 10px;
                        text-align: left;">
                        <asp:Button ID="btnSendErrorInLink" runat="server" Text="ارسال" Height="37px" Width="71px"
                            Style="font-family: Tahoma; font-size: 11px;" ValidationGroup="ErrorInLink" />
                    </div>
--%>                  

        <div id="CommentForm" class="UserInputFrom">
                    
                    <uc2:ucMessageBox ID="ucMessageBox1" runat="server" />
                    <div>
                        <div>
                            <asp:TextBox ID="txtName" runat="server" CssClass="TextBoxStyle" Text="نام و نام خانوادگی"
                                ValidationGroup="Comment" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Comment"
                                ErrorMessage="*" ControlToValidate="txtName" InitialValue="نام و نام خانوادگی"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxStyle ltr" Text="پست الکترونیکی"
                                ValidationGroup="Comment" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Comment"
                                ErrorMessage="*" ControlToValidate="txtEmail" InitialValue="پست الکترونیکی"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Comment"
                                ErrorMessage="آدرس ایمیل را درست وارد کنید" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div>
                        <div>
                            <asp:TextBox ID="txtNote" runat="server" CssClass="TextareaStyle" TextMode="MultiLine"
                                Text="توضیحات..." ValidationGroup="Comment" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Comment"
                                ErrorMessage="*" ControlToValidate="txtNote" InitialValue="توضیحات..."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div>
                        <uc2:CapchaControl ID="CapchaControl1" runat="server" />
                    </div>
                    <div style="width:100%">
                        <asp:Button ID="btnSend" runat="server" Text="ثبت نظر" ValidationGroup="Comment" CssClass="myButton" />
                    </div>
                
                </div>
                  
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    صبر کنید
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>


<style type="text/css">
    
    .ImageStyle
    {
        -webkit-border-radius: 1em;
        -moz-border-radius: 1em;
    }    
    .ErrorExpander, .LinkExpander
    {
        font-family: koodakSMS;
        font-size: 15px;
        color: #2d607d;
    }
    .LinkExpander
    {
        color: #ad722e;
    }
    .ErrorExpander:hover,  .LinkExpander:hover
    {
        cursor: pointer;
    }
    .ErrorExpander-Items, .LinkExpander-Items
    {
    }
 
</style>
