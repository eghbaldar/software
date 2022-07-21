<%@ Page Language="VB" MasterPageFile="~/Dashboard/SoftwareMaster.master" AutoEventWireup="false" CodeFile="AddAds.aspx.vb" Inherits="Management_Admin_admin_software_AddAds" title="افزودن تبلیغ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <style type="text/css">
        .style5
        {
            width: 97%;
            font-family: Tahoma;
            font-size: 11px;
        }
        .LabelSegment
        {
        	width:80px;
        }
        .ControlSegment
        {
            width: 700px;
            float:right;
        }
        #EmptyTable
        {
        	border:solid 1px green;
        	padding-top:25px;
        	margin: 0px auto;
        	height:50px;
        	text-align:center;
        	vertical-align:middle;
        	background-color:Gray;
        }
   </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style5">
        <tr>
            <td>
                <img alt="" src="../Content/Images/M_Show.jpg"
                    style="width: 763px; height: 45px" />
                <asp:GridView ID="gvPostList" runat="server" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                    DataSourceID="SqlDataSource1" ForeColor="Black" 
                    Width="100%" AllowPaging="True" Font-Size="10pt" Font-Names="Tahoma" 
                    DataKeyNames="PostId" >
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="PostId" HeaderText="شماره پست" InsertVisible="False" 
                            ReadOnly="True" SortExpression="PostId" />
                        <asp:BoundField DataField="Title" HeaderText="عنوان" 
                            SortExpression="Title">
                        </asp:BoundField>
                        <asp:BoundField DataField="DateOfCreatePost" HeaderText="تاریخ و ساعت ایجاد پست" 
                            SortExpression="DateOfCreatePost">
                        </asp:BoundField>
                        <asp:BoundField DataField="LocationNumber" HeaderText="محل قرار گیری" 
                            SortExpression="LocationNumber" />
                    </Columns>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        <div id="EmptyTable">
                            خبری برای نمایش وجود ندارد
                        </div>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ShaahrConnectionString %>" 
                    SelectCommand="SELECT [PostId], [Title], [DateOfCreatePost], [LocationNumber] FROM [tbl_Software_Post] WHERE ([PostType] = @PostType)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3" Name="PostType" Type="Byte" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
            </td>
        </tr>
        <tr>
            <td>
                <img alt="" src="../Content/Images/ADD_God.jpg" 
                    style="width: 763px; height: 45px" /></td>
        </tr>
        <tr>
            <td>
                <table class="style5">
                
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server" style="color: #FF0000"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="LabelSegment">
                            عنوان پست :</td>
                        <td class="ControlSegment">
                            <asp:TextBox ID="txtPostTitle" runat="server" Height="19px" 
                                style="font-family: Tahoma; font-size: 11px" Width="465px"></asp:TextBox>
                            <span dir="rtl" onkeypress="FKeyPress()">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPostTitle" ErrorMessage="*" 
                                ValidationGroup="insert_news"></asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کوتاه :</td>
                        <td class="ControlSegment">
                            <CKEditor:CKEditorControl ID="txtAdsLid" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            متن کامل :</td>
                        <td class="ControlSegment">
                            <CKEditor:CKEditorControl ID="txtAdsBody" BasePath="../Content/ckeditor" runat="server" Language="fa"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            عکس تبلیغی:
                        </td>
                        <td>
                            <asp:FileUpload ID="fuAdsPicture" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            محل قرار گیری در صفحه:</td>
                        <td class="ControlSegment">
                            <asp:TextBox ID="txtLocation" runat="server" Width=50></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            <asp:CheckBox ID="chkVisiblePost" runat="server" Text="قابل نمایش" />
                        </td>
                        <td class="ControlSegment">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                            <asp:CheckBox ID="chkShowInfuture" runat="server" Text="نمایش در آینده" />
                        </td>
                        <td class="ControlSegment">
                            <asp:TextBox ID="txtShowDate" runat="server" Width="99px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelSegment">
                        </td>
                        <td class="ControlSegment" style="height:50px;">
                            <asp:Button ID="btnSaveAds" runat="server" CssClass="myButton" Text="ارسال" 
                                ValidationGroup="insert_news" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:ImageButton ID="btn_back" runat="server" 
                    ImageUrl="~/Content/Images/back.gif" />
            </td>
        </tr>
    </table>
</asp:Content>