<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Pages_Backend_UserManage_User" %>
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
            <th> 用户管理</th></tr> 
        </table>
        <div class ="orderbt">
            QQ号码：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="查询" class="BTedit" 
                onclick="Button1_Click" />
        </div>
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr>
        <th>QQ号码</th><th>密码</th><th>推荐人QQ</th><th>当前积分</th><th>等级</th><th>注册时间</th><th>是否禁用</th><th>修改</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
        <tr>
<td><%# DataBinder.Eval(Container.DataItem,"QQ") %> </td>
<td><%# DataBinder.Eval(Container.DataItem,"PassWord") %> </td>
<td><%# DataBinder.Eval(Container.DataItem,"TuijianrenQQ") %> </td>
<td><%# DataBinder.Eval(Container.DataItem,"Jifen") %></td>
<td><%# DataBinder.Eval(Container.DataItem,"Name") %></td>
<td><%# DataBinder.Eval(Container.DataItem,"CreatedAt") %> </td>
<td><%#((bool) DataBinder.Eval(Container.DataItem,"CanLogin"))?"否":"是" %> </td>
<td><a href ="#" onclick ="editUser(<%# DataBinder.Eval(Container.DataItem,"QQ")%>)" >修改</a>  </td>
</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
            <asp:Button ID="BTedit" runat="server" Text="修改积分" class="BTedit" OnClientClick ="changejifen();return false;" />
        </div>  
     </div>
    </div>
    </form>
   <script type ="text/javascript" >
       function changejifen() {
//           if (selList.length == 0) {
//               alert('请选择账号');
//               return;
//           }
//           var ids=selList.join(';');
           window.open("JifenChange.aspx","积分修改",'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
       function editUser(id) {
           window.open("UserEdit.aspx?id=" + id, "用户修改", 'width=400,height=500,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
       }
   </script> 
</body>
</html>
