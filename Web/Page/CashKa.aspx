﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CashKa.aspx.cs" Inherits="Page_ChshKa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
                 html,body
        {
            font-size :14px;overflow:hidden;
        }
        .style1
        {
            width: 100%;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="margin :0 auto; width :600px;" >
    <table class="style1" border ="1">
            <tr>
                <td>
                        购买的充值卡号：</td>
                <td>
                    <asp:TextBox ID="txtChongzhika" runat="server" Width="160px" MaxLength="11"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BTsubmit" runat="server" Text="确认充值" Height="28px" Width="80px" 
                        OnClick="BTsubmit_Click" />
                    </td>
            </tr>
        </table>
   </div>
   <iframe src ="http://soft.11343777.com/soft/shengji.html" width ="100%" height ="500px" ></iframe>
    </form>
</body>
</html>