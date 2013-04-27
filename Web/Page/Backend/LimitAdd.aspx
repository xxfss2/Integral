<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LimitAdd.aspx.cs" Inherits="Pages_Backend_UserManage_LimitAdd" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="../backend.css" type ="text/css" rel ="Stylesheet" />   <script type ="text/javascript" src ="../../../Scripts/jquery-1.3.2.min.js "></script>

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
                会员等级设置</th>
                 </tr> 
            <tr>
                <td class="UserTR1">
                    等级名称:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    达到该等级需要的积分:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtIntegral" runat="server"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    浏览的网址：</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtURL" runat="server" Width="657px"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    是否可重复观看：</td>
                <td class="style1">
                    <asp:DropDownList ID="dropCanrepeter" runat="server">
                                            <asp:ListItem Value="true">是</asp:ListItem>
                        <asp:ListItem Value="false">否</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="style1">
                    </td>
            </tr>
            <tr>
                <td class="UserTR1">
                    是否需要积分：</td>
                <td class="UserTR2">
                    <asp:DropDownList ID="dropNeedIntegral" runat="server">
                                                                <asp:ListItem Value="true">是</asp:ListItem>
                        <asp:ListItem Value="false">否</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    推荐人升级奖励:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtshengjijiangli" runat="server"></asp:TextBox>
                    </td>
                <td class="UserTR2">
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
