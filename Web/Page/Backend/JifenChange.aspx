<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JifenChange.aspx.cs" Inherits="Page_Backend_JifenChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th colspan="3">
                客户积分修改</th>
                 </tr> 
            <tr>
                <td class="UserTR1">
                    账号列表:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="TextBox2" runat="server" Height="267px" TextMode="MultiLine" 
                        Width="193px"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    积分变化:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    变化方式：</td>
                <td class="UserTR2">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="true">增加</asp:ListItem>
                        <asp:ListItem Value="false">减少</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                </td>
                <td class="UserTR1">
                    <asp:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click" OnClientClick ="return confirm('确认对这些账户修改积分信息吗？');" />
                    </td>
                <td class="UserTR1">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
