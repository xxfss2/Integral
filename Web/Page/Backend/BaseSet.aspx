<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaseSet.aspx.cs" Inherits="Pages_Backend_UserManage_LimitAdd" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="backend.css" type ="text/css" rel ="Stylesheet" />   <script type ="text/javascript" src ="../../../Scripts/jquery-1.3.2.min.js "></script>

   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
    <style type="text/css">
        .style2
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th colspan="3">
                系统基本设置</th>
                 </tr> 
            <tr>
                <td class="style2">
                    新用户默认积分:</td>
                <td class="style2">
                    <asp:TextBox ID="txtuserintegral" runat="server"></asp:TextBox>
                    </td>
                <td class="style2">
                    </td>
            </tr>
            <tr>
                <td class="UserTR1">
                    推荐人奖励积分:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtTuijianren" runat="server"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    被推荐人奖励积分：</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtBeituijianren" runat="server"></asp:TextBox>
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
