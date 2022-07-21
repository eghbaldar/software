<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CapchaControl.ascx.vb"
    Inherits="UserControl_CapchaControl" %>
<style type="text/css">
    .Question
    {
        float: right;
        font-family: tahoma;
        font-size: 11px;
    }
    .InputBox
    {
        text-align: center;
        width: 60px;
        height: 20px;
        font-family: tahoma;
        font-size: 11px;
        border: solid 2px gray;
        -moz-border-radius: 5px;
        -webkit-border-radius: 5px;
        border-radius: 5px;
    }
</style>
<div dir="rtl">
    <div class="Question">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblQuesion" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInput" runat="server" CssClass="InputBox"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
    </div>
</div>
