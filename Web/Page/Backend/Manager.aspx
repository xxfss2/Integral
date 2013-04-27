<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Pages_Backend_UserManage_User" %>
<%@ Import Namespace ="integral.Action" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href ="backend.css" type ="text/css" rel ="Stylesheet" />   
   <script type ="text/javascript" src ="../../Scripts/jquery-1.4.1.min.js"></script>  
   <script type ="text/javascript" src ="../../Scripts/Base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="UserTable1" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
            <tr>
            <th> 管理员账号管理</th></tr> 
        </table>
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr>
        <th>用户名</th><th>密码</th><th>角色</th><th>修改</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
        <tr>
<td><%# DataBinder.Eval(Container.DataItem,"username") %> </td>
<td><%# DataBinder.Eval(Container.DataItem,"PassWord") %> </td>
<td><%# (ManagerRole)DataBinder.Eval(Container.DataItem,"RoleId") %> </td>
<td><a href ="#" onclick ="editLimit(<%# DataBinder.Eval(Container.DataItem,"Id")%>)" >修改</a>  </td>
</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
            <asp:Button ID="BTedit" runat="server" Text="添加账户" class="BTedit" OnClientClick ="changejifen();return false;" />
        </div>  
     </div>
    </div>
    </form>
   <script type ="text/javascript" >
       function editLimit(id) {
           window.open("MangerAdd.aspx?id=" + id, "账户设置", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
       function changejifen() {
           window.open("MangerAdd.aspx","账户设置", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
   </script> 
</body>
</html>
