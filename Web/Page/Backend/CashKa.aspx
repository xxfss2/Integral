<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CashKa.aspx.cs" Inherits="Pages_Backend_UserManage_CashKa" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="backend.css" type ="text/css" rel ="Stylesheet" />   <script type ="text/javascript" src ="../../../Scripts/jquery-1.3.2.min.js "></script>

   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th> 充值卡管理</th></tr> 
        </table>
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr>
        <th>充值卡号</th> <th>面值</th><th>充值QQ</th><th>删除</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
<td><%#((CashKa )Container .DataItem).Number   %> </td>
<td><%#((CashKa)Container.DataItem).Cash %> </td>
<td><%#((CashKa)Container.DataItem).QQ %> </td>
<td><a href ="#" onclick ="editLimit(<%#((CashKa)Container .DataItem).Id   %>)" >删除</a> </td>
</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
                    <asp:Button ID="BTadd" runat="server" Text="批量生成" 
                        OnClientClick ="return confirm('确认生成充值卡？');" onclick="BTadd_Click" /> 
            
                    面值<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp; 数量<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            
        </div>  
     </div>
    </div>
    </form>
   <script type ="text/javascript" >
       function editLimit(id) {
           window.location.href = "CashKa.aspx?id="+id;
       }
   </script> 
</body>
</html>
