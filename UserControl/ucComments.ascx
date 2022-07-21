<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucComments.ascx.vb" Inherits="Management_UserControl_ucComments" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="CapchaControl.ascx" TagName="CapchaControl" TagPrefix="uc1" %>
<%@ Register src="ucMessageBox.ascx" tagname="ucMessageBox" tagprefix="uc2" %>

<script type="text/javascript">

	function ShowDialog(id){
	
		$.prompt($(".FormAddAnswer").html(),{ 
		    prefix: 'dnt',
		    buttons:{انصراف:false, ارسال:true}, 
		    focus: 1,
		    submit: function(e,v,m,f){
		        if (v) {

		            var ParentId = id;
                    var PostId = $('#<%= PostIdSaver.ClientID %>').val();
           	        var FullName = m.find('#txtFullName_Di').val();
                    var Email = m.find('#txtEmail_Di').val();
                    var Note = m.find('#txtNote_Di').val();
                    var ShowComment = $('#<%= hdShowComment.ClientID %>').val();

                    $.ajax({
                        type: 'POST',
                        url: 'ShowPost.aspx/AddNewItem',
                        data: '{"ParentId":"' + ParentId + '", "PostId":"' + PostId + '", "FullName":"' + FullName + '", "Email":"' + Email + '", "Note":"' + Note + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            if (msg.d) {
                            
                                if (ShowComment==1){
                    			    $( "#" + ParentId ).append( "<div class='ReAnswer'>" +
                                        "<div class='InfoBar'>" +
                                            "<div class='AutherName'>" +
                                                  FullName +
                                            "</div>" +
                                        "</div>" +
                                        "<br />" +
                                        "<div class='Content'>" +
                                            Note + 
                                        "</div>" +
                                    "</div>");
                                } // if (VisibleComment==1)
                                
                            } // if (msg.d)
                        },
                        error: function () {
                            alert("خطا در سرور. دوباره تلاش کنید.");
                        }
                    }); // $.ajax
		            
		        } // if (v)
		    }, // submit
		    close: function(e,v,m,f){
		    }  // close
		});	//$.prompt
	} // function
	       
</script>

<div id="Comments">
    <asp:HiddenField ID="hdShowComment" runat="server" />
    <div class="FormAddAnswer" title="افزودن نظر" style="display: none;">
        <input id="CommentIdSaver" type="hidden" value="" />
        <asp:HiddenField ID="PostIdSaver" runat="server" />
        <div style="overflow: auto;">
            <div style="float: right; overflow: auto;">
                <input id="txtFullName_Di" type="text" class="TextBoxStyle" value="نام و نام خانوادگی"
                    onfocus="if (this.value==this.defaultValue) this.value = ''" onblur="if (this.value=='') this.value = this.defaultValue" />
            </div>
            <div style="float: right; overflow: auto; padding-right: 10px;">
                <input id="txtEmail_Di" type="text" class="TextBoxStyle" value="پست الکترونیکی" onfocus="if (this.value==this.defaultValue) this.value = ''"
                    onblur="if (this.value=='') this.value = this.defaultValue" />
            </div>
        </div>
        <div style="overflow: auto; padding-top: 10px;">
            <div>
                <textarea id="txtNote_Di" cols="20" rows="2" class="TextareaStyle" onfocus="if (this.value==this.defaultValue) this.value = ''"
                    onblur="if (this.value=='') this.value = this.defaultValue">توضیحات...</textarea>
            </div>
        </div>
    </div>
    <div class="CommentExpander" style="margin-bottom:0px;">
        سوالات و نظرات شما
        <asp:Label ID="lblCountVote" runat="server" Font-Size="Medium" ForeColor="Gray"></asp:Label>
    </div>
    <div class="CommentExpander-Items" style="display: none;">
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        </asp:ScriptManagerProxy>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- start parent repeater -->
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div id='<%# DataBinder.Eval(Container.DataItem, "CommentId")%>' class="CommentContainer">
                            <div class="InfoBar">
                                <div class="AutherName">
                                    <%#DataBinder.Eval(Container.DataItem, "FullName")%>
                                </div>
                                <div class="Answer">
                                    <a href="javascript:;" onclick='ShowDialog(<%#DataBinder.Eval(Container.DataItem, "CommentId")%>)'
                                        style="text-decoration: none; cursor: pointer;">پاسخ</a>
                                </div>
                            </div>
                            <br />
                            <div class="Content">
                                <div>
                                    <%#DataBinder.Eval(Container.DataItem, "Note")%>
                                </div>
                                <asp:Repeater ID="NestedRepeater" runat="Server">
                                    <ItemTemplate>
                                        <div class="ReAnswer">
                                            <div class="InfoBar">
                                                <div class="AutherName">
                                                    <%#DataBinder.Eval(Container.DataItem, "FullName")%>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="Content">
                                                <%#DataBinder.Eval(Container.DataItem, "Note")%>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div id='<%# DataBinder.Eval(Container.DataItem, "CommentId")%>' class="CommentContainerAleternative">
                            <div class="InfoBar">
                                <div class="AutherName">
                                    <%#DataBinder.Eval(Container.DataItem, "FullName")%>
                                </div>
                                <div class="Answer">
                                    <a href="javascript:;" onclick='ShowDialog(<%#DataBinder.Eval(Container.DataItem, "CommentId")%>)'
                                        style="text-decoration: none; cursor: pointer;">پاسخ</a>
                                </div>
                            </div>
                            <br />
                            <div class="Content">
                                <div>
                                    <%#DataBinder.Eval(Container.DataItem, "Note")%>
                                </div>
                                <asp:Repeater ID="NestedRepeater" runat="Server">
                                    <ItemTemplate>
                                        <div class="ReAnswer">
                                            <div class="InfoBar">
                                                <div class="AutherName">
                                                    <%#DataBinder.Eval(Container.DataItem, "FullName")%>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="Content">
                                                <%#DataBinder.Eval(Container.DataItem, "Note")%>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                
                <!-- end parent repeater -->
                
                <div id="CommentForm" class="UserInputFrom">
                    
                    <uc2:ucMessageBox ID="ucMessageBox1" runat="server" />
                    <div>
                        <div>
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="TextBoxStyle" Text="نام و نام خانوادگی"
                                ValidationGroup="Comment" onfocus="if (this.value==this.defaultValue) this.value = ''"
                                onblur="if (this.value=='') this.value = this.defaultValue"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Comment"
                                ErrorMessage="*" ControlToValidate="txtFullName" InitialValue="نام و نام خانوادگی"></asp:RequiredFieldValidator>
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
                        <uc1:CapchaControl ID="CapchaControl1" runat="server" />
                    </div>
                    <div style="width:100%">
                        <asp:Button ID="btnSend" runat="server" Text="ثبت نظر" ValidationGroup="Comment" CssClass="myButton" />
                    </div>
                
                </div>
                     
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
