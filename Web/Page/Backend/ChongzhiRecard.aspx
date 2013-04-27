<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChongzhiRecard.aspx.cs" Inherits="Pages_Backend_UserManageChongzhiRecard" %>
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
    <div class ="table" >
       <asp:Repeater ID="Ruserlist" runat="server" EnableViewState="False">
        <HeaderTemplate >
        <table class="UserList" cellspacing="0" border="1" style="">
        <tr>
        <th>QQ号码</th><th>优惠卡号</th><th>充值时间</th></tr>
        </HeaderTemplate>
        <ItemTemplate >
<td><%#((ChongzhiRecard )Container .DataItem).QQ    %> </td>
<td><%#((ChongzhiRecard)Container .DataItem).Chongzhika   %> </td>
<td><%#((ChongzhiRecard)Container .DataItem).CreatedAt     %> </td>

</tr>
        </ItemTemplate>
        <FooterTemplate >
        </table>
        </FooterTemplate>
        </asp:Repeater> 
       <div class ="empty" ></div>  
        <div class ="orderbt">
            <%--<asp:Button ID="BTedit" runat="server" Text="修改积分" class="BTedit" OnClientClick ="changejifen();return false;" />--%>
        </div>  
     </div>
    </div>
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
