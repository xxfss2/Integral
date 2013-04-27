<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="Pages_Backend_UserManage_UserEdit" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="../backend.css" type ="text/css" rel ="Stylesheet" />  
   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th colspan="3">
                管理员账户设置</th>
                 </tr> 
            <tr>
                <td class="UserTR1">
                    QQ号:</td>
                <td class="UserTR2">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    密码:</td>
                <td class="UserTR2">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    等级：</td>
                <td class="UserTR2">
                    <asp:DropDownList ID="dropLimit" runat="server">
                    </asp:DropDownList>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    积分：</td>
                <td class="style1">
                    <asp:TextBox ID="txtJifen" runat="server"></asp:TextBox>
                    </td>
                <td class="style1">
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    收益：</td>
                <td class="style1">
                    <asp:TextBox ID="txtShouyi" runat="server"></asp:TextBox>
                    </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    是否禁用：</td>
                <td class="style1">
                    <asp:DropDownList ID="dropCanuse" runat="server">
                        <asp:ListItem Value="false">是</asp:ListItem>
                        <asp:ListItem Value="true">否</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                </td>
                <td class="UserTR1">
                    <asp:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click" OnClientClick ="return confirm('确认保存？');" />
                    </td>
                <td class="UserTR1">
                </td>
            </tr>
        </table>
    </form>
   <script type ="text/javascript" >
       function changejifen() {
           if (selList.length == 0) {
               alert('请选择账号');
               return;
           }
           var ids=selList.join(';');
           window.open("JifenChange.aspx?id="+ids,"积分修改",'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
   </script> 
</body>
</html>
