<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">       
   <div style="margin :0 auto; width :500px; height: 371px;" >
    <div style ="width :400px; text-align :left;"> </div>
    <div style ="width :400px;height:337px; background-color:White; margin-top:5px;border :solid 1px #BBBBBB; text-align :left">
        <table>
            <tr>
                <td style="width: 40px">
                </td>
                <td colspan="2">
                    <h2>
                        &nbsp;</h2>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span style="color:#999999; font-size:smaller; font-weight :bold; ">qq账号</span> </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 170px;">
                    <asp:TextBox ID="txtQQNO" runat="server" Width="160px" MaxLength="11"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3" style ="height:10px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span style="color:#999999;font-size:smaller ;font-weight :bold;">账号密码</span></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="160px" 
                        MaxLength="15"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3"  style ="height:10px">
                </td>
            </tr>
                        <tr>
                <td>
                </td>
                <td>
                    <span style="color:#999999;font-size:smaller ;font-weight :bold;">重复密码</span></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="160px" 
                        MaxLength="15"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3"  style ="height:10px">
                </td>
            </tr>
                        <tr>
                <td>
                </td>
                <td>
                    <span style="color:#999999;font-size:smaller ;font-weight :bold;">推荐人QQ</span></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtTuijian" runat="server" Width="160px" 
                        MaxLength="11"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3"  style ="height:10px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="BTsubmit" runat="server" Text="" Height="28px" Width="66px" OnClick="BTsubmit_Click" />
                    <asp:TextBox ID="txtMac" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
        </table>
    
    </div>
   </div> 
    </form>
</body>
</html>
