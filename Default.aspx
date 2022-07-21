<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="شهر نرم افزار" %>

<%@ Register src="UserControl/ucNewsSlider.ascx" tagname="ucNewsSlider" tagprefix="uc1" %>
<%@ Register src="UserControl/ucBestSoftwareList.ascx" tagname="ucBestSoftwareList" tagprefix="uc2" %>
<%@ Register src="UserControl/ucProductSlider.ascx" tagname="ucProductSlider" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript"> 
        var anetwork_pram = anetwork_pram || []; 
        anetwork_pram['aduser'] = '1387392916'; 
        anetwork_pram['adheight'] = '60'; 
        anetwork_pram['adwidth'] = '468'; 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Start of StatCounter Code for Default Guide -->
    <script type="text/javascript">
        var sc_project=9383231; 
        var sc_invisible=1; 
        var sc_security="db469e09"; 
        var scJsHost = (("https:" == document.location.protocol) ?
        "https://secure." : "http://www.");
        document.write("<sc"+"ript type='text/javascript' src='" +
        scJsHost+
        "statcounter.com/counter/counter.js'></"+"script>");
    </script>
    <noscript>
        <div class="statcounter"><a title="free hit
        counters" href="http://statcounter.com/free-hit-counter/"
        target="_blank"><img class="statcounter"
        src="http://c.statcounter.com/9383231/0/db469e09/1/"
        alt="free hit counters"></a>
        </div>
    </noscript>
    <!-- End of StatCounter Code for Default Guide -->


    <div id="Container">
        
        <div id="InfoSegment">
            
            <div id="Info">

                <uc3:ucProductSlider ID="ucProductSlider1" runat="server" />

            </div>
                
            <div id="MorePopularSoftware">
                <a href=#>پر بازدیدترین نرم افزارهای شهر</a>
            </div>
        </div>
        
        <div id="NewsSliderSegment">

            <uc1:ucNewsSlider ID="ucNewsSlider1" runat="server" />

            <div id="MoreNews">
                <a href="News.aspx">ادامه اخبار تکنولوژی</a>
            </div>
        
        </div>

    </div>
        
    <div id="AdsWrapper">
        <div class="AdsContainer">
            <div class="AdsBorder">
                <script type="text/javascript" src="http://static-cdn.anetwork.ir/showad/pub.js"></script>                
            </div>
            <div class="AdsBorder">
                <script language="javascript" src="http://tabligheirani.com/showads.php?webid=39da688fbab76d0a5e1f64ddb803ad37&s=1"></script>                 
            </div>
        </div>
        <div class="AdsContainer">
            <div class="AdsBorder">
                <script type='text/javascript' src='http://jahanads.com/index.php/javascript/site/3902?img=468_60'></script>            
            </div>
            <div class="AdsBorder">
                <script type='text/javascript' src='http://apanet.net/index.php/javascript/site/72?img=468_60'></script>
            </div>
        </div>
    </div>
    
    <div id="Content">
        <div id="BestSoftware">
            <uc2:ucBestSoftwareList ID="ucBestSoftwareList1" runat="server" />
        </div>
        
        <div id="MainContent">
            
            <asp:ListView ID="lvSoftware" runat="server" DataSourceID="ObjectDataSource1" GroupItemCount="2">
                <LayoutTemplate>
                    <table runat="server" id="table1" width="100%" cellspacing="16" class="TableSoftwareList">
                      <tr runat="server" id="groupPlaceholder">
                      </tr>
                    </table>
                    <div style="text-align: center; width: 100%; padding: 40px 0px;">
                        <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="10" PagedControlID="lvSoftware"
                            QueryStringField="PageId" style="display:inline-block;" >
                            <Fields>
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        <div style="float: left;" class="page-active-style">
                                            <b>
                                                صفحه
                                                <asp:Label runat="server" ID="CurrentPageLabel" Text="<%# IIf(Container.TotalRowCount>0,  (Container.StartRowIndex / Container.PageSize) + 1 , 0) %>" />
                                            از
                                                <asp:Label runat="server" ID="TotalPagesLabel" Text="<%# Math.Ceiling (System.Convert.ToDouble(Container.TotalRowCount) / Container.PageSize) %>" />
                                            </b>
                                        </div>
                                    </PagerTemplate>
                                </asp:TemplatePagerField>
                                <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="page-style" ShowFirstPageButton="true"
                                    ShowLastPageButton="false" FirstPageText="اولین صفحه" ShowPreviousPageButton="false"
                                    ShowNextPageButton="false" />
                                <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="page-style" ShowFirstPageButton="false"
                                    ShowLastPageButton="false" PreviousPageText="قبلی>>" ShowPreviousPageButton="true"
                                    ShowNextPageButton="false" />
                                <asp:NumericPagerField PreviousPageText="5 صفحه قبل" NextPageText="5 صفحه بعد" NextPreviousButtonCssClass="page-style"
                                    NumericButtonCssClass="page-style" CurrentPageLabelCssClass="page-active-style"
                                    ButtonCount="5" />
                                <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="page-style" ShowFirstPageButton="false"
                                    ShowLastPageButton="false" NextPageText="<<بعدی" ShowPreviousPageButton="false"
                                    ShowNextPageButton="true" />
                                <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="page-style" ShowFirstPageButton="false"
                                    ShowLastPageButton="true" LastPageText="آخرین صفحه" ShowPreviousPageButton="false"
                                    ShowNextPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <%--<tr runat="server" id="tableRow" class="SoftwareListRowStyle">--%>
                    <tr runat="server" id="tableRow">
                      <td runat="server" id="itemPlaceholder" />
                    </tr>
                </GroupTemplate>

                <ItemTemplate>
                   <td id="Td1" runat="server">
                   
                        <div class="<%#iif(eval("PostType")=1,"PostBorder1","PostBorder2")%>">
                            <div class="SoftwarePost">
                                
                                <div class="PostHeader">
                                    <h1 class="SoftwareTitle">
                                        <a style="" href="<%# GenLink(Eval("PostType"),Eval("PostId"), Eval("Hyperlink").tostring()) %>" target=target="<%#iif(eval("PostType")=1,"_parent","_blank") %>" >
                                            <%#Eval("Title")%>
                                        </a>
                                    </h1>
                                    <ul>
                                        <li class="Vizit">
                                            تعداد بازدید : 
                                            <%#Eval("DownloadCount").ToString%>
                                        </li>
                                        <li class="CreateDate">
                                            تاریخ درج : 
                                            <%#Eval("DateOfCreatePost").ToString.Split("-")(1)%>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li class="Category">
                                            طبقه بندی نرم افزار : 
                                            <%#Portal.Utilities.BuildCategoryList(Eval("CategoryId"))%>
                                        </li>
                                    </ul>
                                </div>

                                <div class="PostContent">
                                    <div class="PostImage">
                                        <asp:Image ID="Image1" runat="server" ToolTip='<%#Eval("Title")%>' AlternateText='<%#Eval("Title")%>' ImageUrl='<%# Eval("BigImageFilename", "/Content/UserFiles/Images/Software/{0}") %>' />
                                    </div>
                                    <asp:Label ID="lblLidFarsi" runat="server" Text='<%# Eval("LidFarsi", "{0}") %>'></asp:Label>
                                </div>
                                
                            </div>
                            
                            <div class="<%#iif(eval("PostType")=1,"PostBottom1","PostBottom2")%>">
                                <a href="<%# GenLink(Eval("PostType"),Eval("PostId"), Eval("Hyperlink").tostring()) %>" target=target="<%#iif(eval("PostType")=1,"_parent","_blank") %>" >
                                ادامه...</a>
                            </div>
                            
                        </div>
                   
                    </td>
                </ItemTemplate>
            </asp:ListView>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="SelectAllForShow" TypeName="Software.BLL.Post">
                <SelectParameters>
                    <asp:Parameter Name="today" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            </div>
        
    </div>

</asp:Content>