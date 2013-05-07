<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="Video_UserInfo" %>
<div>
        <table class="head"  cellpadding ="0" cellspacing ="0" >

            <tr style ="height :25px" >
                <td >
                    您的授权QQ号：<asp:Literal ID="lQQ" runat="server"></asp:Literal>
                </td>
                <td >
                    &nbsp;当前积分：<asp:Literal ID="lJifen" runat="server"></asp:Literal>
                    &nbsp;</td>
                <td >
                    消费积分：<asp:Literal ID="Literal5" runat="server"></asp:Literal>
                </td>
                <td >
                    累计积分：<asp:Literal ID="lJifenTotal" runat="server"></asp:Literal>
                </td>
                <td >
                    当前等级：<asp:Literal ID="lLevel" runat="server"></asp:Literal>
                </td>
                <td >
                    距离升级还差：<asp:Literal ID="Literal4" runat="server"></asp:Literal>
                </td>
            </tr>
            </table>
    
    </div>