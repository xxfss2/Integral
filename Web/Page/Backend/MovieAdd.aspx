<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MovieAdd.aspx.cs" Inherits="Page_Backend_MovieAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>      
       <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th colspan="3">
                播放视频编辑</th>
                 </tr> 
            <tr>
                <td class="UserTR1">
                    视频列表:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="TextBox2" runat="server" Height="267px" TextMode="MultiLine" 
                        Width="733px"></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                    第一条播放日期:</td>
                <td class="UserTR2">
                    <asp:TextBox ID="txtDay" runat="server" onClick="WdatePicker()" ></asp:TextBox>
                    </td>
                <td class="UserTR2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="UserTR1">
                </td>
                <td class="UserTR1">
                    <asp:Button ID="Button2" runat="server" Text="保存" OnClick="Button2_Click" OnClientClick ="return confirm('确认导入这些视频？');" />
                    </td>
                <td class="UserTR1">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
