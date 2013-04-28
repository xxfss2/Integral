<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMain.aspx.cs" Inherits="UserMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         html,body
        {
            font-size :14px;overflow:hidden;
            background-color :#ECE9D8;
        }
        .style1
        {
            width: 100%;
        }
        
        .style1 td
        {
            border :1px solid #000000;
        }

    </style>
</head>
<body style ="padding:2px; margin :3px; font-size:12px" >
    <form id="form1" runat="server">
    <div>
        <table class="style1"  cellpadding ="0" cellspacing ="0" >

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
                <td class="style2">
                    累计积分：<asp:Literal ID="lJifenTotal" runat="server"></asp:Literal>
                </td>
                <td class="style2">
                    当前等级：<asp:Literal ID="lLevel" runat="server"></asp:Literal>
                </td>
                <td class="style2">
                    距离升级还差：<asp:Literal ID="Literal4" runat="server"></asp:Literal>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
